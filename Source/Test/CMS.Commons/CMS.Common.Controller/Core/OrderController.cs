namespace CMS.Common.Controller.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CMS.Common.ViewResult.Core;
    using CMS.Common.ViewResult.Base;
    using CMS.Common.Database.Core;
    using CMS.Common.Model;
    using CMS.Common.Utility.Core;
    using CMS.Interface.Model;

    public class OrderController:Base.BaseController
    {
        private const string prefix = "SS";

        private static Dictionary<Guid, SalesStatus> salesStatus = null;

        private static Dictionary<Guid, EntranceOrderStatus> orderStatus = null;

        public const string SALES_STATUS_ACTIVE = "active";
        public const string SALES_STATUS_INACTIVE = "inactive";

        public const string ORDER_STATUS_PENDING = "pending";
        public const string ORDER_STATUS_DONE = "done";

        public OrderController()
        {
        }

        #region static constract
        static OrderController()
        {
            using (EntranceController.dbContext)
            {
                salesStatus = new Dictionary<Guid, SalesStatus>();

                ICollection<SalesStatus> statusCollection = EntranceController.dbContext.SyncAttributeEnum<SalesStatus>(typeof(SalesStatus));
                if (statusCollection != null && statusCollection.Count > 0)
                {
                    foreach (SalesStatus status in statusCollection)
                    {
                        if (!salesStatus.ContainsKey(status.ID))
                        {
                            salesStatus[status.ID] = status;
                        }
                    }
                }

                orderStatus = new Dictionary<Guid, EntranceOrderStatus>();

                ICollection<EntranceOrderStatus> orderStatusCollection = EntranceController.dbContext.SyncAttributeEnum<EntranceOrderStatus>(typeof(EntranceOrderStatus));
                if (statusCollection != null && statusCollection.Count > 0)
                {
                    foreach (EntranceOrderStatus status in orderStatusCollection)
                    {
                        if (!orderStatus.ContainsKey(status.ID))
                        {
                            orderStatus[status.ID] = status;
                        }
                    }
                }
            }
        }
        #endregion 

        #region get status
        public SalesStatus getSalesStatus(Guid guid)
        {
            SalesStatus status;

            if (!OrderController.salesStatus.TryGetValue(guid, out status))
            {
            }
            return status;
        }

        public SalesStatus getSalesStatus(string name)
        {
            foreach (KeyValuePair<Guid, SalesStatus> status in OrderController.salesStatus)
            {
                if (status.Value.EnumCode.Equals(name, StringComparison.CurrentCultureIgnoreCase))
                {
                    return status.Value;
                }
            }
            return null; ;
        }

        public EntranceOrderStatus getOrderStatus(Guid guid)
        {
            EntranceOrderStatus status;

            if (!OrderController.orderStatus.TryGetValue(guid, out status))
            {
            }
            return status;
        }

        public EntranceOrderStatus getOrderStatus(string name)
        {
            foreach (KeyValuePair<Guid, EntranceOrderStatus> status in OrderController.orderStatus)
            {
                if (status.Value.EnumCode.Equals(name, StringComparison.CurrentCultureIgnoreCase))
                {
                    return status.Value;
                }
            }
            return null; ;
        }
        #endregion
        /// <summary>
        /// Generate sales number
        /// </summary>
        /// <returns>return sales number</returns>
        public ActionResultBase GenerateSalesCode()
        {
            using (this.CMSContext)
            {
                try
                {
                    int index = this.CMSContext.SyncRowsNumber<CMS.Common.Model.SalesOrder>(typeof(CMS.Common.Model.SalesOrder));

                    string code = string.Empty;

                    CMS.Common.Utility.Core.Generater.CodeGenerater.GenerateCode(OrderController.prefix, 5, index, out code);

                    return this.Content(code);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        #region create methods
        /// <summary>
        /// Create a new sales order for
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public ActionResultBase CreateNewSalesOrder(SalesOrder order)
        {
            using (this.CMSContext)
            {
                try
                {
                    if (order == null)
                    {
                        throw new Exception("Order cannot be null");
                    }
                    if (string.IsNullOrEmpty(order.SalesNo))
                    {
                        order.SalesNo = this.GenerateSalesCode().Result;
                    }
                    this.CMSContext.New<SalesOrder>(order);

                    return this.Boolean(true);
                }
                catch (Exception ex)
                {
                    return this.Boolean(false);
                }
            }
        }

        public ActionResultBase GenerateOrderCode()
        {
            using (this.CMSContext)
            {
                try
                {
                    int index = this.CMSContext.SyncRowsNumber<CMS.Common.Model.EntranceOrder>(typeof(CMS.Common.Model.EntranceOrder));

                    string code = string.Empty;

                    CMS.Common.Utility.Core.Generater.CodeGenerater.GenerateCode("EO", 7, index, out code);

                    return this.Content(code);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        #endregion

        #region get methods

        public XMLCollectionResults GetSalesOrderByCard(CMS.Common.Model.Base.CardBase Card)
        {
            //Need to improve
            string keyWord = "CardID";

            using (this.CMSContext)
            {
                try
                {
                    ICollection<SalesOrder> modelCollection = new List<SalesOrder>();

                    if (this.CacheManage[typeof(SalesOrder).Name] == null)
                    {
                        CMS.Common.Database.Base.BaseCache<IModel> cache = this.CacheManage[typeof(SalesOrder).Name];

                        foreach (SalesOrder order in cache)
                        {
                            if (order.CardID.Equals(Card.ID))
                            {
                                modelCollection.Add(order);

                                break;
                            }
                        }
                    }
                    if (modelCollection == null || modelCollection.Count == 0)
                    {
                        System.Reflection.PropertyInfo property = typeof(DishOrder).GetProperty(keyWord);

                        object[] objAttribute = property.GetCustomAttributes(typeof(CMS.Common.Model.Attribute.ModelColumnAttribute), true);

                        if (objAttribute != null && objAttribute.Length > 0)
                        {
                            CMS.Common.Model.Attribute.ModelColumnAttribute attribute = objAttribute[0] as CMS.Common.Model.Attribute.ModelColumnAttribute;

                            DBContext.ConditionStructure cardID = DBContext.CreateConditionStucture(attribute, Card.ID.ToString(), DBContext.DBOperator.MoreEqual, Card.ID.GetType());

                            System.Xml.XmlDocument doc = DBContext.CreateConditionForCommand(new DBContext.ConditionStructure[1] { cardID });

                            modelCollection = this.CMSContext.Sync<SalesOrder>(typeof(SalesOrder), doc);

                        }
                        if (modelCollection != null && modelCollection.Count > 0)
                        {
                            return this.Collection(modelCollection);
                        }
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
            return null;
        }

        public XMLCollectionResults GetOrderCollectionBySalesOrder(SalesOrder salesOrder)
        {
            using (this.CMSContext)
            {
                try
                {

                    this.CMSContext.SyncSubTypeCollection<EntranceOrder>(salesOrder);

                    return this.Collection<EntranceOrder>(salesOrder.OrderCollection);

                }
                catch (Exception)
                {
                    return this.Collection<EntranceOrder>(null);
                }
            }
        }

        public XMLCollectionResults GetSalesOrderByCard(CMS.Common.Model.Base.CardBase Card, DateTime date)
        {
            //Need to improve
            string[] keyWord = new string[] { "CardID", "CreatedDate" };

            using (this.CMSContext)
            {
                try
                {
                    ICollection<SalesOrder> model = new List<SalesOrder>();

                    if (this.CacheManage[typeof(SalesOrder).Name] != null)
                    {
                        CMS.Common.Database.Base.BaseCache<IModel> cache = this.CacheManage[typeof(SalesOrder).Name];

                        foreach (SalesOrder order in cache)
                        {
                            if (order.CardID.Equals(Card.ID) && order.CreatedDate.ToString("yyyy-MM-dd") == date.ToString("yyyy-MM-dd"))
                            {
                                model.Add(order);
                            }
                        }
                    }
                    if (model.Count == 0)
                    {
                        DBContext.ConditionStructure[] structures = new DBContext.ConditionStructure[3];


                        System.Reflection.PropertyInfo cardIDProperty = typeof(SalesOrder).GetProperty(keyWord[0]);
                        System.Reflection.PropertyInfo createdDateProperty = typeof(SalesOrder).GetProperty(keyWord[1]);

                        object[] objCustomerAttribute = cardIDProperty.GetCustomAttributes(typeof(CMS.Common.Model.Attribute.ModelColumnAttribute), true);
                        if (objCustomerAttribute != null && objCustomerAttribute.Length > 0)
                        {
                            CMS.Common.Model.Attribute.ModelColumnAttribute attribute = objCustomerAttribute[0] as CMS.Common.Model.Attribute.ModelColumnAttribute;

                            structures[0] = DBContext.CreateConditionStucture(attribute, Card.ID.ToString(), DBContext.DBOperator.Equal, typeof(Guid));
                        }

                        objCustomerAttribute = createdDateProperty.GetCustomAttributes(typeof(CMS.Common.Model.Attribute.ModelColumnAttribute), true);

                        if (objCustomerAttribute != null && objCustomerAttribute.Length > 0)
                        {
                            CMS.Common.Model.Attribute.ModelColumnAttribute attribute = objCustomerAttribute[0] as CMS.Common.Model.Attribute.ModelColumnAttribute;

                            structures[1] = DBContext.CreateConditionStucture(attribute, date.ToString("yyyy-MM-dd 00:00:00"), DBContext.DBOperator.MoreEqual, date.GetType());

                            structures[2] = DBContext.CreateConditionStucture(attribute, date.ToString("yyyy-MM-dd 23:59:59"), DBContext.DBOperator.LessEqual, date.GetType());
                        }

                        System.Xml.XmlDocument doc = DBContext.CreateConditionForCommand(structures);

                        ICollection<SalesOrder> modelCollection = this.CMSContext.Sync<SalesOrder>(typeof(SalesOrder), doc);

                        if (modelCollection != null && modelCollection.Count > 0)
                        {
                            return this.Collection<SalesOrder>(modelCollection);
                        }
                    }
                    else
                    {
                        return this.Collection<SalesOrder>(model);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return this.Collection<SalesOrder>(null);
        }

        public ActionResultBase GetSalesOrderBySalesStatus(CMS.Common.Model.Base.CardBase Card, SalesStatus Status)
        {
            string[] keyWord = new string[] { "CardID", "SalesStatus","CreatedDate"};
            using (this.CMSContext)
            {
                try
                {
                    SalesOrder model = null;
                    
                    XMLCollectionResults results = GetSalesOrderByCard(Card, DateTime.Now);

                    ICollection<SalesOrder> modelCollection = new List<SalesOrder>();

                    foreach (SalesOrder order in results.GetModelResults())
                    {
                        if (order.SalesStatus == Status.ID)
                        {
                            model = order;
                            break;
                        }
                    }

                    if (model == null)
                    {
                        return this.Xml<SalesOrder>(null);
                        //DBContext.ConditionStructure[] structures = new DBContext.ConditionStructure[keyWord.Length];


                        //System.Reflection.PropertyInfo cardIDProperty = typeof(SalesOrder).GetProperty(keyWord[0]);
                        //System.Reflection.PropertyInfo createdStatusProperty = typeof(SalesOrder).GetProperty(keyWord[1]);
                        //System.Reflection.PropertyInfo createdDateProperty = typeof(SalesOrder).GetProperty(keyWord[2]);

                        //object[] objCustomerAttribute = cardIDProperty.GetCustomAttributes(typeof(CMS.Common.Model.Attribute.ModelColumnAttribute), true);
                        //if (objCustomerAttribute != null && objCustomerAttribute.Length > 0)
                        //{
                        //    CMS.Common.Model.Attribute.ModelColumnAttribute attribute = objCustomerAttribute[0] as CMS.Common.Model.Attribute.ModelColumnAttribute;

                        //    structures[0] = DBContext.CreateConditionStucture(attribute, Card.ID.ToString(), DBContext.DBOperator.Equal, typeof(Guid));
                        //}

                        //objCustomerAttribute = createdStatusProperty.GetCustomAttributes(typeof(CMS.Common.Model.Attribute.ModelColumnAttribute), true);

                        //if (objCustomerAttribute != null && objCustomerAttribute.Length > 0)
                        //{
                        //    CMS.Common.Model.Attribute.ModelColumnAttribute attribute = objCustomerAttribute[0] as CMS.Common.Model.Attribute.ModelColumnAttribute;

                        //    structures[1] = DBContext.CreateConditionStucture(attribute, Status.ID.ToString(), DBContext.DBOperator.MoreEqual, typeof(Guid));
                        //}

                        //objCustomerAttribute = createdDateProperty.GetCustomAttributes(typeof(CMS.Common.Model.Attribute.ModelColumnAttribute), true);

                        //if (objCustomerAttribute != null && objCustomerAttribute.Length > 0)
                        //{
                        //    CMS.Common.Model.Attribute.ModelColumnAttribute attribute = objCustomerAttribute[0] as CMS.Common.Model.Attribute.ModelColumnAttribute;

                        //    structures[1] = DBContext.CreateConditionStucture(attribute, date.ToString(), DBContext.DBOperator.MoreEqual, typeof(Guid));
                        //}

                        //System.Xml.XmlDocument doc = DBContext.CreateConditionForCommand(structures);

                        //ICollection<SalesOrder> modelCollection = this.CMSContext.Sync<SalesOrder>(typeof(SalesOrder), doc);

                        //if (modelCollection != null && modelCollection.Count > 0)
                        //{
                        //    return this.Xml<SalesOrder>(modelCollection.ElementAt(0));
                        //}
                    }
                    else
                    {
                        return this.Xml<SalesOrder>(model);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public XMLCollectionResults GetSalesStatusCollection()
        {
            using (this.CMSContext)
            {
                try
                {
                    ICollection<SalesStatus> salesCollection = this.CMSContext.SyncAttributeEnum<SalesStatus>(typeof(SalesStatus));

                    return this.Collection<SalesStatus>(salesCollection);
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }

        public ActionResultBase CheckOut(CMS.Common.Model.Base.CardBase Card)
        {
            using (this.CMSContext)
            {
                try
                {
                    ICollection<CMS.Interface.Model.IModel> statusCollection = this.GetSalesStatusCollection().GetModelResults();

                    SalesOrder order = null;

                    foreach (SalesStatus status in statusCollection)
                    {
                        if (status.EnumCode.Equals("active", StringComparison.CurrentCultureIgnoreCase))
                        {
                            order = this.GetSalesOrderBySalesStatus(Card, status).Model as SalesOrder;
                            break;
                        }
                    }
                    if (order == null)
                    {
                        return this.Xml<SalesOrder>(null);
                    }
                    foreach (SalesStatus status in statusCollection)
                    {
                        if (status.EnumCode.Equals("inactive", StringComparison.CurrentCultureIgnoreCase))
                        {
                            order.SalesStatus = status.ID;

                            this.CMSContext.Save<SalesOrder>(order);

                            return this.Xml<SalesOrder>(order);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return this.Xml<SalesOrder>(null);
            }
        }

        #endregion

        #region update methods
        public ActionResultBase UpdateSalesOrder(SalesOrder order)
        {
            using (this.CMSContext)
            {
                try
                {
                    if (order == null)
                    {
                        throw new Exception("Order cannot be null");
                    }

                    this.CMSContext.Save<SalesOrder>(order);

                    return this.Boolean(true);
                }
                catch (Exception)
                {
                    return this.Boolean(false);
                }
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
