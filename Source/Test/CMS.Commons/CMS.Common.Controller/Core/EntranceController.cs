namespace CMS.Common.Controller.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ViewResultBase = CMS.Common.ViewResult.Base;
    using CMS.Common.ViewResult.Core;
    using ModelBase = CMS.Common.Model.Base;
    using CMS.Common.Model;
    using CMS.Common.Database.Core;

    public class EntranceController:Base.BaseController
    {
        private Employee staff = null;

        private static Dictionary<Guid, EntranceStatus> entranceStatus = null;

        public EntranceController(Employee Staff)
        {
            this.staff = Staff;
        }

        public EntranceController()
            : this(null)
        {

        }

        static EntranceController()
        {
            using (EntranceController.dbContext)
            {
                entranceStatus = new Dictionary<Guid, EntranceStatus>();

                ICollection<EntranceStatus> statusCollection = EntranceController.dbContext.SyncAttributeEnum<EntranceStatus>(typeof(EntranceStatus));
                if(statusCollection != null && statusCollection.Count > 0)
                {
                    foreach (EntranceStatus status in statusCollection)
                    {
                        if (!entranceStatus.ContainsKey(status.ID))
                        {
                            entranceStatus[status.ID] = status;
                        }
                    }
                }
            }
        }

        private EntranceStatus getEntranceStatus(Guid guid)
        {
            EntranceStatus status;

            if (!EntranceController.entranceStatus.TryGetValue(guid,out status))
            {
            }
            return status;
        }

        #region create/add data
        /// <summary>
        /// 创建档口
        /// </summary>
        /// <param name="entrance">档口</param>
        /// <returns>返回结果集</returns>
        public ViewResultBase.ActionResultBase CreateEntrance(Entrance entrance)
        {
            using (this.CMSContext)
            {
                try
                {
                    this.CMSContext.New<Entrance>(entrance);

                    return this.Boolean(true);
                }
                catch (Exception ex)
                {
                    return this.Boolean(false);
                }
            }
        }

        public bool CreateEntrance(Entrance entrance, out string error)
        {
            using (this.CMSContext)
            {
                error = string.Empty;
                try
                {
                    this.CMSContext.New<Entrance>(entrance);
                    return true;
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    return false;
                }
            }
        }

        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="entrance">所在档口</param>
        /// <param name="order">订单</param>
        /// <returns>返回结果集</returns>
        public ViewResultBase.ActionResultBase CreateEntranceOrder(Entrance entrance, EntranceOrder order)
        {
            using (this.CMSContext)
            {
                try
                {
                    //if (entrance.ID != order.EntranceID) order.EntranceID = entrance.ID;
                    this.CMSContext.New<EntranceOrder>(order);
                    return this.Boolean(true);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool CreateEntranceOrder(Entrance entrance, EntranceOrder order,out string error)
        {
            using (this.CMSContext)
            {
                error = string.Empty;

                try
                {
                    if (entrance.ID != order.EntranceID) order.EntranceID = entrance.ID;

                    this.CMSContext.New<EntranceOrder>(order);

                    return true;
                }
                catch (Exception ex)
                {
                    error = ex.Message;

                    return false;
                }
            }
        }


        /// <summary>
        /// 为订单添加菜品
        /// </summary>
        /// <param name="Order">订单</param>
        /// <param name="Dishes">菜品</param>
        /// <returns>返回结果集</returns>
        public ViewResultBase.ActionResultBase AddDishesForOrder(EntranceOrder Order, ICollection<EntranceOrderDetail> OrderDetails)
        {
            using (this.CMSContext)
            {
                try
                {
                    if (Order.OrderDetail != null)
                    {
                        foreach (EntranceOrderDetail detail in OrderDetails)
                        {
                            try
                            {
                                this.CMSContext.New<EntranceOrderDetail>(detail);
                                //Order.OrderDetail = detail;
                            }
                            catch (Exception ex)
                            {
                                throw new Exception("添加菜品失败！错误原因：" + ex.Message);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return this.Content("添加菜品完成");
            }
        }

        public bool AddDishesForOrder(EntranceOrder Order, ICollection<EntranceOrderDetail> OrderDetails, out string error)
        {
            using (this.CMSContext)
            {
                error = string.Empty;

                bool result = true ;

                if (Order.OrderDetail != null)
                {
                    foreach (EntranceOrderDetail detail in OrderDetails)
                    {
                        try
                        {
                            if (detail.OrderID.Equals(Order.ID))
                            {
                                this.CMSContext.New<EntranceOrderDetail>(detail);
                            }
                        }
                        catch (Exception ex)
                        {
                            error = string.Format("订单号：{0} - 添加菜品: {0}失败！错误原因：{1}\r\n", detail.OrderID, detail.Dish, ex.Message);
                            result = false;
                        }
                    }
                }
                return result;
            }
        }

        public ViewResultBase.ActionResultBase CreateNewLimitation(Entrance Entrance, EntranceLimitationDetail Limitation)
        {
            using (this.CMSContext)
            {
                //if (Entrance.LimitationCollection != null)
                //{
                //    throw new Exception("");
                //}
                //Entrance.LimitationCollection = new List<EntranceLimitationDetail>();

                //Entrance.LimitationCollection.Add(Limitation);
                try
                {
                    this.CMSContext.New<EntranceLimitationDetail>(Limitation);
                    return this.Boolean(true);
                }
                catch (Exception ex)
                {
                    return this.Boolean(false);
                }
            }
        }

        public bool CreateNewLimitation(Entrance Entrance, EntranceLimitationDetail Limitation, out string error)
        {
            using (this.CMSContext)
            {
                error = string.Empty;

                try
                {
                    this.CMSContext.New<EntranceLimitationDetail>(Limitation);
                    return true;
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    return false;
                }
            }
        }

        #endregion

        #region get data from database
        /// <summary>
        /// 获取所有档口
        /// </summary>
        /// <returns>返回结果集</returns>
        public ViewResultBase.ActionResultCollectionBase<XMLResult> GetAllEntrance()
        {
            using (this.CMSContext)
            {
                try
                {
                    ICollection<Model.Entrance> entranceCollection = this.CMSContext.Sync<Model.Entrance>(typeof(Model.Entrance));

                    return this.Collection<Model.Entrance>(entranceCollection);
                }
                catch (Exception ex) { throw ex; }
            }
        }

        public CMS.Common.ViewResult.Base.ActionResultBase GetEntrance(string entranceName)
        {
            using (this.CMSContext)
            {
                try
                {
                    DBCacheManager cache = this.CMSContext.DatabaseCacheManager;

                    CMS.Common.Database.Base.BaseCache<CMS.Interface.Model.IModel> db = cache[typeof(Entrance)];

                    Entrance entrance = db[entranceName] as Entrance;

                    if (entrance == null)
                    {
                        this.GetAllEntrance();
                    }

                    entrance = db[entranceName] as Entrance;

                    return this.Xml<Entrance>(entrance);
                }
                catch
                {
                    throw;
                }
            }
        }

        public CMS.Common.ViewResult.Base.ActionResultBase GetEntrance(Guid entranceID)
        {
            using (this.CMSContext)
            {
                try
                {
                    Entrance entrance = null;

                    DBCacheManager cache = this.CMSContext.DatabaseCacheManager;

                    CMS.Common.Database.Base.BaseCache<CMS.Interface.Model.IModel> db = cache[typeof(Entrance).Name];

                    if (db != null)
                    {
                        entrance = db[entranceID] as Entrance;
                        if (entrance == null)
                        {

                        }
                    }

                    this.GetAllEntrance();

                    db = cache[typeof(Entrance).Name];

                    entrance = db[entranceID] as Entrance;

                    return this.Xml<Entrance>(entrance);
                }
                catch
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// 获取订单信息
        /// </summary>
        /// <param name="entrance">档口</param>
        /// <returns>返回结果集</returns>
        public ViewResultBase.ActionResultCollectionBase<XMLResult> GetOrderByEntrance(Entrance entrance)
        {
            using (this.CMSContext)
            {
                this.CMSContext.SyncSubTypeCollection<EntranceOrder>(entrance);

                //ICollection<Interface.Model.IModel> modelCollection = new List<Interface.Model.IModel>();

                //foreach (EntranceOrder order in entrance.OrderCollection)
                //{
                //    this.CMSContext.SyncSubType<Employee>(order);

                //    modelCollection.Add(order);
                //}

                return this.Collection<EntranceOrder>(entrance.OrderCollection);
            }
        }

        /// <summary>
        /// 获取订单详细
        /// </summary>
        /// <param name="entranceOrder">订单</param>
        /// <returns>返回结果集</returns>
        public ViewResultBase.ActionResultBase GetOrderDetailByEntrance(EntranceOrder entranceOrder)
        {
            using (this.CMSContext)
            {
                this.CMSContext.SyncSubTypeCollection<EntranceOrderDetail>(entranceOrder);

                //return this.Collection(entranceOrder.OrderDetail);
                return null;
            }
        }

        /// <summary>
        /// 获取订单营业额
        /// </summary>
        /// <param name="Order">订单</param>
        /// <returns>结果集</returns>
        public ViewResultBase.ActionResultBase GetSalesRevenueByEntranceOrder(EntranceOrder Order)
        {
            using (this.CMSContext)
            {
                this.CMSContext.SyncSubTypeCollection<EntranceOrderDetail>(Order);

                //this.CMSContext.SyncSubTypeCollection<EntranceOrderDetail>(Order.OrderDetail);

                return this.Content(Order.PayAmount.ToString());
            }
        }

        public ViewResultBase.ActionResultBase GetOrderCountByEntrance(Entrance entrance)
        {
            using (this.CMSContext)
            {
                if (entrance.OrderCollection == null)
                {
                    this.CMSContext.SyncSubTypeCollection<EntranceOrder>(entrance);
                }

                return this.Content(entrance.OrderCollection.Count.ToString());
            }
        }

        /// <summary>
        /// 获取档口营业额
        /// </summary>
        /// <param name="entrance">档口</param>
        /// <returns>返回结果集</returns>
        public ViewResultBase.ActionResultBase GetSalesRevenueByEntrance(Entrance entrance)
        {
            using (this.CMSContext)
            {
                decimal sales = 0;

                if (entrance.OrderCollection == null)
                {
                    this.CMSContext.SyncSubTypeCollection<EntranceOrder>(entrance);
                }
                foreach (EntranceOrder order in entrance.OrderCollection)
                {
                    ViewResultBase.ActionResultBase result = GetSalesRevenueByEntranceOrder(order);

                    decimal orderSales = 0;

                    decimal.TryParse(result.Result, out orderSales);
                    sales += orderSales;
                }
                return this.Content(sales.ToString());
            }
        }

        public ViewResultBase.ActionResultBase GetSalesRevenueByEntrance(Entrance entrance,DateTime date)
        {
            using (this.CMSContext)
            {
                if (entrance.OrderCollection == null)
                {
                    this.CMSContext.SyncSubTypeCollection<EntranceOrder>(entrance);
                }

                var order = (from o in entrance.OrderCollection where o.CreatedDate.ToString("yyyy-MM-dd") == date.ToString("yyyy-MM-dd") select o.Amount).Sum();

                return this.Content(order.ToString());
            }
        }

        public int GetOrderCountByEntrance(Entrance entrance, DateTime date)
        {
            using (this.CMSContext)
            {
                if (entrance.OrderCollection == null)
                {
                    this.CMSContext.SyncSubTypeCollection<EntranceOrder>(entrance);
                }

                var order = (from o in entrance.OrderCollection where o.CreatedDate.ToString("yyyy-MM-dd") == date.ToString("yyyy-MM-dd") select o.Amount).Count();

                return order;
            }
        }

        public ViewResultBase.ActionResultBase GetSalesRevenueByMachine(Machine machine)
        {
            using (this.CMSContext)
            {
                decimal sales = 0;

                Entrance entrance = this.GetEntrance(machine.EntranceID).Model as Entrance;

                if (entrance == null)
                {
                    throw new Exception("The machine cannot be added to entrance");
                }
                if (entrance.OrderCollection == null)
                {
                    this.CMSContext.SyncSubTypeCollection<EntranceOrder>(entrance);
                }

                foreach (EntranceOrder order in entrance.OrderCollection)
                {
                    ViewResultBase.ActionResultBase result = GetSalesRevenueByEntranceOrder(order);

                    if (entrance.OrderCollection == null)
                    {
                        this.CMSContext.SyncSubTypeCollection<EntranceOrder>(entrance);
                    }

                    decimal orderSales = 0;

                    decimal.TryParse(result.Result, out orderSales);
                    sales += orderSales;
                }
                return this.Content(sales.ToString());
            }
        }

        public ViewResultBase.ActionResultBase GetSalesRevenueByMachine(Machine machine,DateTime startDate, DateTime endDate)
        {
            using (this.CMSContext)
            {
                //Need to improve
                string keyWord = "CreatedDate";

                decimal sales = 0;

                Entrance entrance = this.GetEntrance(machine.EntranceID).Model as Entrance;

                if (entrance == null)
                {
                    throw new Exception("The machine cannot be added to entrance");
                }

                System.Reflection.PropertyInfo property = typeof(EntranceOrder).GetProperty(keyWord);

                object[] columnAttribute = property.GetCustomAttributes(typeof(CMS.Common.Model.Attribute.ModelColumnAttribute), true);

                if (columnAttribute != null && columnAttribute.Length == 1)
                {
                    CMS.Common.Model.Attribute.ModelColumnAttribute attribute = columnAttribute[0] as CMS.Common.Model.Attribute.ModelColumnAttribute;

                    DBContext.ConditionStructure startCondition = DBContext.CreateConditionStucture(attribute, startDate.ToString("yyyy-MM-dd 00:00:00"), DBContext.DBOperator.MoreEqual, startDate.GetType());

                    DBContext.ConditionStructure endCondition = DBContext.CreateConditionStucture(attribute, startDate.ToString("yyyy-MM-dd 23:59:59"), DBContext.DBOperator.LessEqual, endDate.GetType());

                    List<DBContext.ConditionStructure> conditionList = new List<DBContext.ConditionStructure>();
                    conditionList.AddRange(new DBContext.ConditionStructure[] { startCondition, endCondition });

                    System.Xml.XmlDocument document = DBContext.CreateConditionForCommand(conditionList);

                    this.CMSContext.SyncSubTypeCollection<EntranceOrder>(entrance, document);

                    foreach (EntranceOrder order in entrance.OrderCollection)
                    {
                        sales += order.Amount;
                    }
                }

                //DBContext.CreateConditionStucture(
                
                return this.Content(sales.ToString());
            }
        }

        public ViewResultBase.ActionResultCollectionBase<XMLResult> GetLimitationCollection(Entrance Entrance)
        {
            using (this.CMSContext)
            {
                if (Entrance.LimitationCollection == null)
                {
                    this.CMSContext.SyncSubTypeCollection<EntranceLimitationDetail>(Entrance);
                }
                return this.Collection<EntranceLimitationDetail>(Entrance.LimitationCollection);
            }
        }

        public ViewResultBase.ActionResultBase GetDishTypeByLimitation(EntranceLimitationDetail Limitation)
        {
            using (this.CMSContext)
            {
                if (Limitation.DishType == null)
                {
                    this.CMSContext.SyncSubType<DishType>(Limitation);
                }
                return this.Xml<EntranceLimitationDetail>(Limitation);
            }
        }



        public ViewResultBase.ActionResultCollectionBase<XMLResult> GetMachineCollectionByEntrance(Entrance entrance)
        {
            using (this.CMSContext)
            {
                this.CMSContext.SyncSubTypeCollection<Machine>(entrance);

                return this.Collection(entrance.MachineCollection);
            }
        }

        #endregion

        #region delete data
        public ViewResultBase.ActionResultBase DeleteLimitation(Entrance entrance)
        {
            using (this.CMSContext)
            {
                try
                {
                    foreach (EntranceLimitationDetail limitation in entrance.LimitationCollection)
                    {
                        this.CMSContext.Delete<EntranceLimitationDetail>(limitation);
                    }
                    entrance.LimitationCollection = new List<EntranceLimitationDetail>();
                    return this.Xml<Entrance>(entrance);
                }
                catch (Exception ex) { throw ex; }
            }
        }
        #endregion

        #region
        protected override string GetConnectionString()
        {
            return !string.IsNullOrEmpty(this.CMSContext.ConnectionString) ? this.CMSContext.ConnectionString : string.Empty;
        }

        protected override string GetProvider()
        {
            return !string.IsNullOrEmpty(this.CMSContext.Provider) ? this.CMSContext.Provider : string.Empty;
        }
        #endregion
    }
}
