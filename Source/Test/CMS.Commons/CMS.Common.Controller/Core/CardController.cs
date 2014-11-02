namespace CMS.Common.Controller.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Configuration;
    using ViewResultBase = CMS.Common.ViewResult.Base;
    using CMS.Common.ViewResult.Core;
    using ModelBase = CMS.Common.Model.Base;
    using CMS.Common.Model;
    using CMS.Module.CardMachine;

    public class CardController:Base.BaseController
    {
        #region private variables
        private readonly string port;
        private readonly int baud;

        private string[] portArray = new string[6] { "COM1", "COM2", "COM3", "COM4", "COM4","COM5" };
        private int[] baudArray = new int[5] { 9600, 19200, 38400, 57600, 115200 };

        private static Dictionary<Guid, CardStatus> dictCardStatus = null;

        private static Dictionary<Guid, CardTypes> dictCardTypes = null;

        private static CardMachine cardMachine = null;

        public const string CARD_STATUS_ACTIVE = "active";
        public const string CARD_STATUS_INACTIVE= "inactive";

        public const string CARD_TYPE_VIP = "vip";
        public const string CARD_TYPE_TEMPORARY = "temporary";

        #endregion

        #region 受保护的方法
        protected override string GetConnectionString()
        {
            return !string.IsNullOrEmpty(this.CMSContext.ConnectionString) ? this.CMSContext.ConnectionString : string.Empty;
        }

        protected override string GetProvider()
        {
            return !string.IsNullOrEmpty(this.CMSContext.Provider) ? this.CMSContext.Provider : string.Empty;
        }
        #endregion

        #region 暂时不需要
        /// <summary>
        /// 调整金额
        /// </summary>
        /// <returns></returns>
        public ViewResultBase.ActionResultBase AdjustMoney(ModelBase.CardBase Card, decimal money)
        {
            if (Card is RechargeCard)
            {
                RechargeCard rechargecard = Card as RechargeCard;

                rechargecard.Amount += money;

                using (this.CMSContext)
                {
                    try
                    {
                        this.CMSContext.Save<RechargeCard>(rechargecard);
                        return this.Content("Update successfully");
                    }
                    catch (Exception ex)
                    {
                        return this.Content(ex.Message);
                    }
                    finally
                    {
                        this.CMSContext.DatabaseCacheManager.UpdateCache(rechargecard);
                    }
                }
            }
            else if (Card is TemporaryCard)
            {
                TemporaryCard tempCard = Card as TemporaryCard;

                tempCard.Amount += money;

                using (this.CMSContext)
                {
                    try
                    {
                        this.CMSContext.Save<TemporaryCard>(tempCard);
                        return this.Content("Update successfully");
                    }
                    catch (Exception ex)
                    {
                        return this.Content(ex.Message);
                    }
                    finally
                    {
                        this.CMSContext.DatabaseCacheManager.UpdateCache(tempCard);
                    }
                }
            }
            else
            {
                return this.Content("Not support to recharge for the card");
            }
        }

        /// <summary>
        /// 调整卡片成本
        /// </summary>
        /// <param name="money"></param>
        /// <returns></returns>
        public ViewResultBase.ActionResultBase AdjustCost(ModelBase.CardBase Card, decimal money)
        {
            Card.Cost = money;

            using (this.CMSContext)
            {
                try
                {
                    switch (Card.Type)
                    {
                        case Model.Emun.Card.CardType.RechargeCard:
                            {
                                this.CMSContext.Save<RechargeCard>(Card as RechargeCard);
                                break;
                            }
                        case Model.Emun.Card.CardType.VIPCard:
                            {
                                this.CMSContext.Save<VIPCard>(Card as VIPCard);
                                break;
                            }
                        case Model.Emun.Card.CardType.Coupon:
                            {
                                this.CMSContext.Save<CouponCard>(Card as CouponCard);
                                break;
                            }
                    }
                    return this.Content("Update successfully");
                }
                catch (Exception ex)
                {
                    return this.Content(ex.Message);
                }
                finally
                {
                    this.CMSContext.DatabaseCacheManager.UpdateCache(Card);
                }
            }
            
        }

        /// <summary>
        /// 挂失卡片
        /// </summary>
        /// <returns></returns>
        public ViewResultBase.ActionResultBase Logoff(ModelBase.CardBase Card)
        {
            using (this.CMSContext)
            {
                //Card.Status = Model.Emun.Card.CardStatus.Lost;

                try
                {
                    this.CMSContext.Save<ModelBase.CardBase>(Card);
                    return this.Content("挂失成功！");
                }
                catch (Exception ex)
                {
                    return this.Content(ex.Message);
                }
                finally
                {
                    this.CMSContext.DatabaseCacheManager.UpdateCache(Card);
                }

            }
        }

        /// <summary>
        /// 换卡
        /// </summary>
        /// <param name="Card"></param>
        /// <returns></returns>
        public ViewResultBase.ActionResultBase ExchangeCard(Model.Base.CardBase OriginalCard, ModelBase.CardBase DestCard)
        {
            if (OriginalCard.Type != DestCard.Type)
            {
                return this.Content("Not support exchange with different card type");
            }
            else
            {
                using (this.CMSContext)
                {
                    try
                    {
                        switch (DestCard.Type)
                        {
                            default:
                            case Model.Emun.Card.CardType.RechargeCard:
                                {
                                    RechargeCard card = DestCard as RechargeCard;
                                    card.Exchange(OriginalCard);

                                    this.CMSContext.Save<ModelBase.CardBase>(OriginalCard as RechargeCard);
                                    this.CMSContext.Save<ModelBase.CardBase>(card as RechargeCard);
                                    break;
                                }
                            case Model.Emun.Card.CardType.Coupon:
                                {
                                    CouponCard card = DestCard as CouponCard;
                                    card.Exchange(OriginalCard);

                                    this.CMSContext.Save<ModelBase.CardBase>(OriginalCard as CouponCard);
                                    this.CMSContext.Save<ModelBase.CardBase>(card as CouponCard);
                                    break;
                                }
                        }
                        return this.Content("update successfully");
                    }
                    catch (Exception ex)
                    {
                        return this.Content(ex.Message);
                    }
                    finally
                    {
                        List<ModelBase.CardBase> updateCollection = new List<ModelBase.CardBase>();

                        updateCollection.AddRange(new ModelBase.CardBase[] { OriginalCard, DestCard });

                        this.CMSContext.DatabaseCacheManager.UpdateCache(updateCollection as ICollection<CMS.Interface.Model.IModel>);
                    }
                }         
            }
        }
        #endregion

        public CardController()
            : base()
        {
            this.port = ConfigurationManager.AppSettings["cardPort"];

            if (!int.TryParse(ConfigurationManager.AppSettings["cardBaud"], out baud))
            {
                baud = baudArray[4];
            }
        }

        static CardController()
        {
            using (CardController.dbContext)
            {
                string errorMessage = string.Empty;

                if (!CardController.dbContext.TestConnection(out errorMessage))
                {
                    throw new Exception(errorMessage);
                }

                ICollection<CardStatus> statusCollection = CardController.dbContext.SyncAttributeEnum<CardStatus>(typeof(CardStatus));

                CardController.dictCardStatus = new Dictionary<Guid, CardStatus>();

                if (statusCollection != null && statusCollection.Count > 0)
                {
                    foreach (CardStatus status in statusCollection)
                    {
                        CardController.dictCardStatus.Add(status.ID, status);
                    }
                }

                CardController.dictCardTypes = new Dictionary<Guid, CardTypes>();

                ICollection<CardTypes> typeCollection = CardController.dbContext.Sync<CardTypes>(typeof(CardTypes));

                if (typeCollection != null && typeCollection.Count > 0)
                {
                    foreach (CardTypes type in typeCollection)
                    {
                        CardController.dictCardTypes.Add(type.ID, type);
                    }
                }
            }
        }

        #region private method
        public CardStatus getCardStatus(Guid Guid)
        {
            CardStatus status;

            if (!CardController.dictCardStatus.TryGetValue(Guid, out status))
            {

            }

            return status;
        }

        public CardStatus getCardStatus(string name)
        {
            foreach (KeyValuePair<Guid,CardStatus> status in CardController.dictCardStatus)
            {
                if (status.Value.EnumCode.Equals(name, StringComparison.CurrentCultureIgnoreCase))
                {
                    return status.Value;
                }
            }

            return null;   
        }

        public CardTypes getCardType(Guid Guid)
        {
            CardTypes type;

            if (!CardController.dictCardTypes.TryGetValue(Guid, out type))
            {

            }

            return type;
        }

        public CardTypes getCardType(string name)
        {
            foreach (KeyValuePair<Guid, CardTypes> type in CardController.dictCardTypes)
            {
                if (type.Value.TypeEName.Equals(name, StringComparison.CurrentCultureIgnoreCase))
                {
                    return type.Value;
                }
            }

            return null; 
        }

        #endregion

        /// <summary>
        /// 卡片充值
        /// </summary>
        /// <param name="card">卡片</param>
        /// <returns>返回结果集</returns>
        public ViewResultBase.ActionResultBase Repiad(ModelBase.CardBase card)
        {
            using (this.CMSContext)
            {
                if (card is VIPCard)
                {
                    try
                    {
                        this.CMSContext.Save<VIPCard>(card as VIPCard);
                        this.CacheManage.UpdateCache<CMS.Common.Model.Base.CardBase>(card);

                        return this.Content("会员卡充值成功！");
                    }
                    catch(Exception ex)
                    {
                        return this.Content("会员卡充值失败！" + ex.Message);
                    }
                }
                else if (card is RechargeCard)
                {
                    try
                    {
                        this.CMSContext.Save<RechargeCard>(card as RechargeCard);
                        this.CacheManage.UpdateCache<CMS.Common.Model.Base.CardBase>(card);

                        return this.Content("充值成功！");
                    }
                    catch (Exception ex)
                    {
                        return this.Content("充值失败！" + ex.Message);
                    }
                }
                else if (card is TemporaryCard)
                {
                    this.CMSContext.Save<TemporaryCard>(card as TemporaryCard);
                    this.CacheManage.UpdateCache<CMS.Common.Model.Base.CardBase>(card);

                    return this.Content("会员卡充值成功！");
                }
                else
                {
                    return this.Content("不支持此卡类型进行充值！");
                }
            }
        }

        /// <summary>
        /// 创建卡类型
        /// </summary>
        /// <param name="CardType">卡类型</param>
        /// <returns>返回结果集</returns>
        public ViewResultBase.ActionResultBase CreateCardType(CardTypes CardType)
        {
            using (this.CMSContext)
            {
                try
                {
                    this.CMSContext.New<CardTypes>(CardType);

                    this.CacheManage.UpdateCache<CardTypes>(CardType);

                    return this.Content("卡片类型创建成功！");
                }
                catch (Exception ex)
                {
                    return this.Content("卡片类型创建失败！" + ex.Message);
                }
            }
        }

        private CardMachine CreateCardMachineInstrance()
        {
            if (CardController.cardMachine != null) return CardController.cardMachine;

            Int16 portIndex = 0;
            int baudIndex = 4;

            for (int i = 0; i < portArray.Length; i++)
            {
                if (portArray[i] == this.port)
                {
                    portIndex = (Int16)i;
                    break;
                }
            }

            for (int i = 0; i < baudArray.Length; i++)
            {
                if (baudArray[i] == this.baud)
                {
                    baudIndex = i;
                    break;
                }
            }

            CardController.cardMachine = new CardMachine(portIndex, baudArray[baudIndex]);

            return CardController.cardMachine;
        }

        public ViewResultBase.ActionResultBase IsExists()
        {
            using (this.CMSContext)
            {
                string SeriesNumber = string.Empty;

                CardMachine cardMachine = CreateCardMachineInstrance();

                if (!cardMachine.Test())
                {
                    throw new Exception("Can't connect specific card machine!");
                }
                try
                {
                    SeriesNumber = cardMachine.ReadCardNo();

                    if (string.IsNullOrEmpty(SeriesNumber))
                    {
                        throw new Exception("Can't read specific card! Please confirm the card is valid!");
                    }

                    ICollection<RechargeCard> cardCollection = this.CMSContext.Sync<RechargeCard>(typeof(RechargeCard));

                    if (cardCollection == null)
                    {
                        return this.Boolean(false);
                    }

                    var result = from m in cardCollection where m.SeriesNumber == SeriesNumber select m;

                    if (result == null || result.Count() == 0)
                    {
                        return this.Boolean(false);
                    }
                    else
                    {
                        return this.Boolean(true);
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }

        public ViewResultBase.ActionResultBase ReadCardNo()
        {
            using (this.CMSContext)
            {
                string SeriesNumber = string.Empty;

                CardMachine cardMachine = CreateCardMachineInstrance();

                if (!cardMachine.Test())
                {
                    throw new Exception("Can't connect specific card machine!");
                }
                try
                {
                    SeriesNumber = cardMachine.ReadCardNo();

                    return this.Content(SeriesNumber);
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }

        public ViewResultBase.ActionResultBase ReadCardInfo()
        {
            using (this.CMSContext)
            {
                string SeriesNumber = string.Empty;

                CardMachine cardMachine = CreateCardMachineInstrance();

                if (!cardMachine.Test())
                {
                    throw new Exception("Can't connect specific card machine!");
                }
                try
                {
                    SeriesNumber = cardMachine.ReadCardNo();

                    if (string.IsNullOrEmpty(SeriesNumber))
                    {
                        throw new Exception("Can't read specific card! Please confirm the card is valid!");
                    }

                    ICollection<Model.RechargeCard> cardCollection = this.CMSContext.Sync<Model.RechargeCard>(typeof(Model.RechargeCard));
                    

                    var result = from m in cardCollection where m.SeriesNumber == SeriesNumber select m;

                    if (result == null || result.Count() == 0)
                    {
                        throw new Exception("Can't find card info from database!");
                    }
                    else
                    {
                        Model.Base.CardBase tmpCard = result.ElementAt(0);

                        CardStatus status = this.getCardStatus(CARD_STATUS_ACTIVE);

                        this.SyncSubType(tmpCard, typeof(CardTypes));

                        this.SyncSubType(tmpCard, typeof(Employee));

                        if (tmpCard.CardType.TypeEName == CardController.CARD_TYPE_VIP)
                        {
                            tmpCard.Type = Model.Emun.Card.CardType.RechargeCard;
                        }
                        else
                        {
                            tmpCard.Type = Model.Emun.Card.CardType.TemporaryCard;
                        }

                        //CMS.Interface.Model.IModel model = this.GetCardInfo(tmpCard.SeriesNumber).Model;

                        switch (tmpCard.Type)
                        {
                            case Model.Emun.Card.CardType.RechargeCard:
                                {
                                    return this.Xml<ModelBase.CardBase>(tmpCard as RechargeCard);
                                }
                            case Model.Emun.Card.CardType.TemporaryCard:
                                {
                                    RechargeCard rCard = tmpCard as RechargeCard;

                                    TemporaryCard tempCard = new TemporaryCard()
                                    {
                                        ID = rCard.ID,
                                        Amount = rCard.Amount,
                                        CardType = rCard.CardType,
                                        Cost = rCard.Cost,
                                        CreatedBy = rCard.CreatedBy,
                                        EndDate = rCard.EndDate,
                                        SeriesNumber = rCard.SeriesNumber,
                                        StartDate = rCard.StartDate,
                                        Status = rCard.Status,
                                        ValidDate = rCard.ValidDate,
                                        Type = Model.Emun.Card.CardType.TemporaryCard
                                    };

                                    return this.Xml<ModelBase.CardBase>(tempCard);
                                }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return this.Xml<ModelBase.CardBase>(null);
            }
        }

        /// <summary>
        /// 激活卡片
        /// </summary>
        /// <param name="SeriesNumber">卡号</param>
        /// <returns>返回结果集</returns>
        public ViewResultBase.ActionResultBase ActiveCard(CMS.Common.Model.Base.CardBase Card)
        {
            using (this.CMSContext)
            {
                try
                {
                    CardStatus status = this.getCardStatus(CARD_STATUS_ACTIVE);

                    Card.Status = status;

                    this.SyncSubType(Card, typeof(CardTypes));

                    this.SyncSubType(Card, typeof(Employee));


                    if (Card is RechargeCard)
                    {
                        this.CMSContext.Save<RechargeCard>(Card as RechargeCard);

                        return this.Xml<ModelBase.CardBase>(Card as RechargeCard);
                    }
                    else if (Card is TemporaryCard)
                    {
                        this.CMSContext.Save<TemporaryCard>(Card as TemporaryCard);

                        return this.Xml<ModelBase.CardBase>(Card as TemporaryCard);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return this.Xml<ModelBase.CardBase>(null);
            }
        }

        public ViewResultBase.ActionResultBase InactiveCard(CMS.Common.Model.Base.CardBase Card)
        {
            using (this.CMSContext)
            {
                try
                {
                    Card.Status = this.getCardStatus(CARD_STATUS_INACTIVE);

                    this.SyncSubType(Card, typeof(CardTypes));

                    this.SyncSubType(Card, typeof(Employee));

                    switch (Card.Type)
                    {
                        case Model.Emun.Card.CardType.RechargeCard:
                            {
                                RechargeCard tmpCard = Card as RechargeCard;
                                tmpCard.Amount = 0;
                                //this.CacheManage.UpdateCache<ModelBase.CardBase>(card);
                                this.CMSContext.Save<RechargeCard>(tmpCard);

                                return this.Xml<ModelBase.CardBase>(tmpCard);
                            }
                        case Model.Emun.Card.CardType.TemporaryCard:
                            {
                                TemporaryCard card = Card as TemporaryCard;

                                card.Amount = 0;

                                //this.CacheManage.UpdateCache<ModelBase.CardBase>(card);

                                this.CMSContext.Save<TemporaryCard>(card);

                                return this.Xml<ModelBase.CardBase>(card);
                            }
                    }
                }

                catch (Exception ex)
                {
                    throw ex;
                }

                return this.Xml<ModelBase.CardBase>(null);
            }
        }

        /// <summary>
        /// 注册卡片
        /// </summary>
        /// <param name="Card">卡片</param>
        /// <returns>返回结果集</returns>
        public ViewResultBase.ActionResultBase CreateCard(ModelBase.CardBase Card)
        {
            using (this.CMSContext)
            {
                if (Card is VIPCard)
                {
                    VIPCard vipCard = Card as VIPCard;
                    try
                    {
                        this.CMSContext.New<VIPCard>(vipCard);

                        this.CacheManage.UpdateCache<CMS.Common.Model.Base.CardBase>(Card);

                        return this.Content("注册卡片成功！" );
                    }
                    catch (Exception ex)
                    {
                        return this.Content("注册卡片失败！" + ex.Message);
                    }
                }
                else if (Card is TemporaryCard)
                {
                    TemporaryCard tempCard = Card as TemporaryCard;
                    try
                    {
                        this.CMSContext.New<TemporaryCard>(tempCard);

                        this.CacheManage.UpdateCache<CMS.Common.Model.Base.CardBase>(Card);

                        return this.Content("注册卡片成功！");
                    }
                    catch (Exception ex)
                    {
                        return this.Content("注册卡片失败！" + ex.Message);
                    }
                }
                else if (Card is RechargeCard)
                {
                    RechargeCard recharge = Card as RechargeCard;

                    try
                    {
                        this.CMSContext.New<RechargeCard>(recharge);

                        this.CacheManage.UpdateCache<CMS.Common.Model.Base.CardBase>(Card);

                        return this.Content("注册卡片成功！");
                    }
                    catch (Exception ex)
                    {
                        return this.Content("注册卡片失败！" + ex.Message);
                    }

                }
                else
                {
                    return this.Content("卡片类型不支持！");
                }
            }
        }

        /// <summary>
        /// 获取所有卡片类型
        /// </summary>
        /// <returns>返回卡片类型集合</returns>
        public ViewResultBase.ActionResultCollectionBase<XMLResult> GetAllCardTypes()
        {
            using (this.CMSContext)
            {
                try
                {
                    ICollection<CardTypes> types = this.CMSContext.Sync<CardTypes>(typeof(CardTypes));

                    return this.Collection<CardTypes>(types);
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }
        }

        public ViewResultBase.ActionResultCollectionBase<XMLResult> GetAllCardStatus()
        {
            using (this.CMSContext)
            {
                try
                {
                    ICollection<CardStatus> statuses = this.CMSContext.SyncAttributeEnum<CardStatus>(typeof(CardStatus));

                    return this.Collection<CardStatus>(statuses);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        /// <summary>
        /// Get card info from database
        /// </summary>
        /// <returns>return card collection</returns>
        public ViewResultBase.ActionResultCollectionBase<XMLResult> GetCardInfoCollection()
        {
            using (this.CMSContext)
            {
                try
                {
                    ICollection<CMS.Common.Model.Base.CardBase> cards = new List<CMS.Common.Model.Base.CardBase>();

                    foreach (RechargeCard card in this.CMSContext.Sync<RechargeCard>(typeof(RechargeCard)))
                    {
                        cards.Add(card);
                    }

                    ICollection<CMS.Interface.Model.IModel> returnCollection = new List<CMS.Interface.Model.IModel>();

                    //foreach (Model.Base.CardBase type in cards)
                    //{
                    //    returnCollection.Add(type);
                    //}

                    return this.Collection(cards);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        /// <summary>
        /// Get card info from database
        /// </summary>
        /// <param name="CardNo">Card number</param>
        /// <returns>Card model</returns>
        public ViewResultBase.ActionResultBase GetCardInfo(string CardNo)
        {
            string keyword = "SeriesNumber";

            using (this.CMSContext)
            {
                try
                {
                    CMS.Common.Model.Base.CardBase card = null;

                    if (this.CacheManage[typeof(CMS.Common.Model.Base.CardBase)] != null)
                    {
                        card = this.CacheManage[typeof(CMS.Common.Model.Base.CardBase)][CardNo] as CMS.Common.Model.Base.CardBase;
                    }

                    if (card == null)
                    {
                        System.Reflection.PropertyInfo property = typeof(CMS.Common.Model.Base.CardBase).GetProperty(keyword);

                        if (property == null)
                        {
                            throw new Exception("");
                        }

                        object[] obj = property.GetCustomAttributes(typeof(CMS.Common.Model.Attribute.ModelColumnAttribute), true);

                        if (obj == null || obj.Length == 0)
                        {
                            throw new Exception("");
                        }

                        CMS.Common.Model.Attribute.ModelColumnAttribute attribute = obj.ElementAt(0) as CMS.Common.Model.Attribute.ModelColumnAttribute;

                        Database.Core.DBContext.ConditionStructure condition = Database.Core.DBContext.CreateConditionStucture(attribute, CardNo, Database.Core.DBContext.DBOperator.Equal, CardNo.GetType());

                        System.Xml.XmlDocument doc = Database.Core.DBContext.CreateConditionForCommand(new Database.Core.DBContext.ConditionStructure[] { condition });

                        ICollection<CMS.Common.Model.RechargeCard> cardCollection = this.CMSContext.Sync<CMS.Common.Model.RechargeCard>(typeof(CMS.Common.Model.RechargeCard), doc);

                        if (cardCollection != null && cardCollection.Count > 0)
                        {
                            card = cardCollection.ElementAt(0);
                        }
                    }

                    return this.Xml<CMS.Common.Model.Base.CardBase>(card);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        /// <summary>
        /// 设置卡片状态
        /// </summary>
        /// <returns></returns>
        public ViewResultBase.ActionResultBase DisableCard(ModelBase.CardBase Card,CardStatus StatusID)
        {
            using (this.CMSContext)
            {
                Card.Status = StatusID;

                try
                {
                    this.CMSContext.Save<ModelBase.CardBase>(Card);
                    return this.Content("退卡成功！");
                }
                catch(Exception ex)
                {
                    return  this.Content(ex.Message);
                }
                finally
                {
                    this.CMSContext.DatabaseCacheManager.UpdateCache(Card);
                }
            }
        }

        
    }
}
