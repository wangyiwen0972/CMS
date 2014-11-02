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

    public class DishController
        : Base.BaseController
    {
        private Model.Employee employee = null;

        private static Dictionary<Guid, DishStatus> dishStatusCollection = null;
        private static Dictionary<Guid, DishType> dishTypeCollection = null;
        private static Dictionary<Guid, DishStyle> dishStyleCollection = null;

        public DishController(Employee Staff)
            : base()
        {
            this.employee = Staff;
        }

        public DishController()
            : base()
        {
            this.employee = null;
        }

        static DishController()
        {
            using (Controller.Base.BaseController.dbContext)
            {
                dishStatusCollection = new Dictionary<Guid, DishStatus>();

                ICollection<DishStatus> statusCollection = EntranceController.dbContext.SyncAttributeEnum<DishStatus>(typeof(DishStatus));
                if (statusCollection != null && statusCollection.Count > 0)
                {
                    foreach (DishStatus status in statusCollection)
                    {
                        if (!dishStatusCollection.ContainsKey(status.ID))
                        {
                            dishStatusCollection[status.ID] = status;
                        }
                    }
                }

                dishTypeCollection = new Dictionary<Guid, DishType>();

                ICollection<DishType> dishType = EntranceController.dbContext.SyncAttributeEnum<DishType>(typeof(DishType));
                if (dishType != null && dishType.Count > 0)
                {
                    foreach (DishType type in dishType)
                    {
                        if (!dishStatusCollection.ContainsKey(type.ID))
                        {
                            dishTypeCollection[type.ID] = type;
                        }
                    }
                }

                dishStyleCollection = new Dictionary<Guid, DishStyle>();

                ICollection<DishStyle> dishStyle = EntranceController.dbContext.SyncAttributeEnum<DishStyle>(typeof(DishStyle));
                if (dishStyle != null && dishStyle.Count > 0)
                {
                    foreach (DishStyle style in dishStyle)
                    {
                        if (!dishStyleCollection.ContainsKey(style.ID))
                        {
                            dishStyleCollection[style.ID] = style;
                        }
                    }
                }
            }
        }

        private DishStatus getDishStatus(Guid guid)
        {
            DishStatus status;

            if (!DishController.dishStatusCollection.TryGetValue(guid, out status))
            {
            }
            return status;
        }

        private DishType getDishType(Guid guid)
        {
            DishType type;

            if (!DishController.dishTypeCollection.TryGetValue(guid, out type))
            {
            }
            return type;
        }

        private DishStyle getDishStyle(Guid guid)
        {
            DishStyle style;

            if (!DishController.dishStyleCollection.TryGetValue(guid, out style))
            {
            }
            return style;
        }

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


        /// <summary>
        /// 给单个菜品打折
        /// </summary>
        /// <param name="Dish">菜品</param>
        /// <param name="Percent">打折比例</param>
        /// <returns>返回打完折菜品xml数据格式</returns>
        public ActionResultBase TakeDiscount(Model.DishOrder Order,Model.Dish Dish, int Percent)
        {
            using (this.CMSContext)
            {
                try
                {
                    foreach (Model.Dish dish in Order.DishCollection)
                    {
                        if (dish.IsEqual(Dish))
                        {
                            dish.Discount = Percent;
                        }
                    }

                    this.CMSContext.Save<Model.DishOrder>(Order);
                }
                catch (Exception ex)
                {
                    return Content(ex.Message);
                }

            }

            return Content<Model.Dish>(Dish);
        }

        /// <summary>
        /// 为订单添加菜品
        /// </summary>
        /// <param name="Dish">菜品模型</param>
        /// <param name="Order">订单模型</param>
        /// <returns>返回添加菜品结果模型</returns>
        public ActionResultBase AddDish(Model.Dish Dish, Model.DishOrder Order)
        {
            bool result = false;

            return this.Action<Model.Dish, Model.DishOrder>(Dish, Order, addDish);
            
        }

        //从订单中去除菜
        public ActionResultBase RemoveDish(Model.Dish Dish, Model.DishOrder Order)
        {
            return null;
        }

        /// <summary>
        /// 为订单新增菜品
        /// </summary>
        /// <param name="Dish">菜品模型</param>
        /// <param name="Order">订单菜品</param>
        private bool addDish(Model.Dish Dish, Model.DishOrder Order)
        {
            bool Result = false;

            if (!Order.DishCollection.Contains<Model.Dish>(Dish))
            {
                //检查是否有权限点单
                Model.Emun.Action action = Model.Emun.Action.EditDish;

                bool hasRight = employee.Actions.Contains(action);

                if (hasRight)
                {
                    Order.DishCollection.Add(Dish);

                    using (this.CMSContext)
                    {
                        this.CMSContext.Save<Model.DishOrder>(Order);
                    }
                }
            }
            return Result;
        }

        /// <summary>
        /// 获取单个菜品信息
        /// </summary>
        /// <param name="Code">菜品ID</param>
        /// <returns>返回菜品数据格式</returns>
        public ActionResultBase GetDishByID(Guid Code)
        {
            using (this.CMSContext)
            {
                string content = string.Empty;

                CMSContext.Sync<Dish>(typeof(Dish));

                DBCacheManager cache = this.CMSContext.DatabaseCacheManager;

                CMS.Common.Database.Base.BaseCache<IModel> db = cache[typeof(Dish).Name];

                Dish dish = db[Code] as Dish;

                try
                {
                    if (dish != null)
                    {
                        content = CMS.Common.Utility.Core.Reflector.ModelReflector.GetColumnsByModel(dish);
                    }
                    else
                    {
                        throw new Exception("Cann't be found by ID!");
                    }
                }
                catch (Exception ex)
                {
                   throw new Exception(string.Format("Failed to get dish! Error message: {0}", ex.Message));
                }
                finally
                {
                    dbContext.Sync<Dish>(typeof(Dish));
                }

                return base.Content<Dish>(dish);
            }
        }

        /// <summary>
        /// 获取所有菜品信息
        /// </summary>
        /// <returns>返回菜品数据格式</returns>
        //public ActionResultBase GetAllDishes() 
        //{
        //    string content = string.Empty;

        //    using (this.CMSContext)
        //    {
        //        ICollection<Dish> dishCollection = CMSContext.Sync<Dish>(typeof(Dish));

        //        using (CMS.Common.Utility.Core.Resolver.XmlResolver resolver = new Utility.Core.Resolver.XmlResolver())
        //        {
        //            content = resolver.SerializeAll(dishCollection as ICollection<IModel>);
        //        }
        //    }
        //    return this.Content(content);
        //}

        /// <summary>
        /// 获取给定时间段适宜菜品
        /// </summary>
        /// <param name="FromDate">开始日期</param>
        /// <param name="ToDate">结束日期</param>
        /// <returns></returns>
        public ActionResultBase GetDishesByDate(DateTime FromDate, DateTime ToDate)
        {
            return null;
        }

        /// <summary>
        /// 创建新菜品
        /// </summary>
        /// <param name="DishName">菜品名称</param>
        /// <param name="Price">单价</param>
        /// <param name="Unit">单位</param>
        /// <returns>返回新菜品数据格式</returns>
        public ActionResultBase CreateDish(string DishName, string Title, decimal Price,string Introduction,string ImageUrl, UnitType Unit, DishStyle Style,DishType Type)
        {
            if (string.IsNullOrEmpty(DishName))
            {
                throw new Exception("Dish name can't be empty!");
            }


            CMS.Common.Model.Dish dish = new Model.Dish() 
            {
                ID = Guid.NewGuid(),
                Name = DishName,
                Title = Title,
                Style = Style,
                Type = Type,
                ImageUrl = ImageUrl,
                ShortID = CMS.Common.Utility.Core.Generater.MneCodeGenerater.GenerateShortID(DishName)
            };

            using (this.CMSContext)
            {
                try
                {
                    this.CMSContext.New<Dish>(dish);
                    return base.Xml<CMS.Common.Model.Dish>(dish);
                }
                catch (Exception ex)
                {
                    return base.Content(string.Format("Failed to create new dish! Error message: {0}",ex.Message));
                }
                finally
                {
                    //this.CMSContext.Sync<Dish>(typeof(Dish));
                }
            } 
        }

        public ActionResultBase CreateDishType(DishType newType)
        {
            AttributeEnumController AEController = new AttributeEnumController();
            try
            {
                ActionResultBase result = AEController.New<DishType>(newType);
                return result;
            }
            catch (Exception ex)
            {
                return base.Content(string.Format("Failed to create new dish type! Error message: {0}", ex.Message));
            }
        }

        public ActionResultBase CreateDish(Dish newDish)
        {
            if (string.IsNullOrEmpty(newDish.Name))
            {
                throw new Exception("Dish name can't be empty!");
            }

            using (this.CMSContext)
            {
                try
                {
                    this.CMSContext.New<Dish>(newDish);
                    return base.Xml<CMS.Common.Model.Dish>(newDish);
                }
                catch (Exception ex)
                {
                    return base.Content(string.Format("Failed to create new dish! Error message: {0}", ex.Message));
                }
                finally
                {
                    this.CMSContext.Sync<Dish>(typeof(Dish));
                }
            }
        }

        public ActionResultBase CreatePriceForDish(Dish dish, ICollection<DishUnitPriceSetting> priceCollection)
        {
            using (this.CMSContext)
            {
                try
                {
                    foreach (DishUnitPriceSetting price in priceCollection)
                    {
                        if (Guid.Empty == price.DishID)
                        {
                            price.DishID = dish.ID;
                        }
                        this.CMSContext.New<DishUnitPriceSetting>(price);
                    }
                    return this.Boolean(true);   
                }
                catch (Exception)
                {
                    return this.Boolean(false);
                }
            }
        }

        public ActionResultBase UpdatePriceForDish(Dish dish, ICollection<DishUnitPriceSetting> priceCollection)
        {
            using (this.CMSContext)
            {
                try
                {
                    foreach (DishUnitPriceSetting price in priceCollection)
                    {
                        if (Guid.Empty == price.DishID)
                        {
                            price.DishID = dish.ID;
                        }
                        this.CMSContext.Save<DishUnitPriceSetting>(price);
                    }
                    return this.Boolean(true);
                }
                catch (Exception)
                {
                    return this.Boolean(false);
                }
            }
        }

        /// <summary>
        /// 删除菜品
        /// </summary>
        /// <param name="ID">菜品唯一ID</param>
        /// <returns>删除结果</returns>
        public ActionResultBase DeleteDishByID(Guid ID)
        {
            using (this.CMSContext)
            {
                string message = string.Empty;

                CMSContext.Sync<Dish>(typeof(Dish));

                DBCacheManager cache = this.CMSContext.DatabaseCacheManager;

                CMS.Common.Database.Base.BaseCache<IModel> db = cache[typeof(Dish).Name];

                Dish dirtyDish = db[ID] as Dish;

                try
                {
                    if (dirtyDish != null)
                    {
                        dbContext.Delete<Dish>(dirtyDish);

                        dbContext.SyncSubTypeCollection<DishUnitPriceSetting>(dirtyDish);

                        foreach (DishUnitPriceSetting price in dirtyDish.UnitPriceSetting)
                        {
                            dbContext.Delete<DishUnitPriceSetting>(price);
                        }

                        message = "Delete dish successfully!";
                    }
                    else
                    {
                        message = "Cann't be found by ID!";
                    }
                }
                catch (Exception ex)
                {
                    message = string.Format("Failed to delete dish! Error message: {0}", ex.Message);
                }
                finally
                {
                    dbContext.Sync<Dish>(typeof(Dish));
                }

                return base.Content(message);
            }
        }

        

        //删除已有菜品
        public ActionResultBase DeleteDishByModel(Model.Dish Dish)
        {
            using (this.CMSContext)
            {
                Guid id = Dish.ID;

                return DeleteDishByID(id);
            }
        }

        public ActionResultBase DeleteDishType(DishType dishType)
        {
            using (this.CMSContext)
            {
                string message = "";
                try
                {
                    if (dishType != null)
                    {
                        dbContext.Delete<DishType>(dishType);

                        message = "Delete dish type successfully!";
                    }
                    else
                    {
                        message = "Cann't be found by ID!";
                    }
                }
                catch (Exception ex)
                {
                    message = string.Format("Failed to delete dish type! Error message: {0}", ex.Message);
                }
                finally
                {
                    //dbContext.Sync<Dish>(typeof(Dish));
                }

                return base.Content(message);
            }
        }

        //修改菜品
        public ActionResultBase UpdateDish(Model.Dish Dish)
        {
            using (this.CMSContext)
            {
                //DBCacheManager cache = this.CMSContext.DatabaseCacheManager;

                //CMS.Common.Database.Base.BaseCache<IModel> db = cache[typeof(Dish)];

                //Model.Dish oldDish = db[Dish.ID] as Dish;


                    try
                    {
                        this.CMSContext.Save<Dish>(Dish);

                        return this.Content<Dish>(Dish);

                    }
                    catch(Exception ex)
                    {
                        return this.Content("更新菜品失败！" + ex.Message);
                    }
                    finally
                    {
                        this.CMSContext.DatabaseCacheManager.UpdateCache<Dish>(Dish);
                    }
                

            }
        }

        public ActionResultBase UpdateDishType(Model.DishType dishType)
        {
            using (this.CMSContext)
            {

                if (dishType != null)
                {
                    try
                    {
                        this.CMSContext.UpdateAttributeEnum<DishType>(dishType);

                        return this.Content<DishType>(dishType);

                    }
                    catch (Exception ex)
                    {
                        return this.Content("更新菜品失败！" + ex.Message);
                    }
                    finally
                    {
                        this.CMSContext.DatabaseCacheManager.UpdateCache<DishType>(dishType);
                    }
                }
                else
                {
                    throw new Exception("Can't update");
                }
            }
        }

        public XMLCollectionResults GetAllDishes()
        {
            using (this.CMSContext)
            {
                try
                {
                    ICollection<Dish> dishList = this.CMSContext.Sync<Dish>(typeof(Dish));

                    //ICollection<IModel> list = new List<IModel>();

                    //foreach (IModel model in dishList)
                    //{
                    //    list.Add(model as Dish);
                    //}


                    return this.Collection<Dish>(dishList);
                    
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        public XMLCollectionResults GetAllDishTypes()
        {
            using (this.CMSContext)
            {
                try
                {
                    ICollection<DishType> dishTypeList = this.CMSContext.SyncAttributeEnum<DishType>(typeof(DishType));

                    //ICollection<IModel> list = new List<IModel>();

                    //foreach (IModel model in dishTypeList)
                    //{
                    //    list.Add(model as DishType);
                    //}

                    return this.Collection<DishType>(dishTypeList);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public ICollection<DishType> GetAllDishTypeCollection()
        {
            using (this.CMSContext)
            {
                try
                {
                    ICollection<DishType> dishTypeList = this.CMSContext.SyncAttributeEnum<DishType>(typeof(DishType));

                    //ICollection<IModel> list = new List<IModel>();

                    //foreach (IModel model in dishTypeList)
                    //{
                    //    list.Add(model as DishType);
                    //}

                    return dishTypeList;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public XMLCollectionResults GetAllDishStyles()
        {
            using (this.CMSContext)
            {
                try
                {
                    ICollection<DishStyle> dishTypeList = this.CMSContext.SyncAttributeEnum<DishStyle>(typeof(DishStyle));

                    //ICollection<IModel> list = new List<IModel>();

                    //foreach (IModel model in dishTypeList)
                    //{
                    //    list.Add(model as DishType);
                    //}

                    return this.Collection<DishStyle>(dishTypeList);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public XMLCollectionResults GetAllDishStatus()
        {
            using (this.CMSContext)
            {
                try
                {
                    ICollection<DishStatus> dishTypeList = this.CMSContext.SyncAttributeEnum<DishStatus>(typeof(DishStatus));

                    //ICollection<IModel> list = new List<IModel>();

                    //foreach (IModel model in dishTypeList)
                    //{
                    //    list.Add(model as DishType);
                    //}

                    return this.Collection<DishStatus>(dishTypeList);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public ActionResultBase GetDishStatus(Dish dish)
        {
            try
            {
                this.SyncSubType(dish, typeof(DishStatus));
                return this.Xml(dish);
            }
            catch
            {
                throw;
            }
        }

        public ActionResultBase GetDishType(Dish dish)
        {
            try
            {
                this.SyncSubType(dish, typeof(DishType));

                return this.Xml(dish);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public ActionResultBase GetDishStyle(Dish dish)
        {
            try
            {
                this.SyncSubType(dish, typeof(DishStyle));

                return this.Xml<Dish>(dish);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 生成菜品类型号码
        /// </summary>
        /// <returns>返回菜品类型号码结果集</returns>
        public ActionResultBase GenerateDishTypeCode()
        {
            using (this.CMSContext)
            {
                try
                {
                    int index = this.CMSContext.SyncRowsNumber<CMS.Common.Model.DishType>(typeof(CMS.Common.Model.DishType));

                    string code = string.Empty;

                    CMS.Common.Utility.Core.Generater.CodeGenerater.GenerateCode("A", 5, index, out code);

                    return this.Content(code);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public ActionResultBase GenerateDishCode()
        {
            using (this.CMSContext)
            {
                try
                {
                    int index = this.CMSContext.SyncRowsNumber<CMS.Common.Model.Dish>(typeof(CMS.Common.Model.Dish));

                    string code = string.Empty;

                    CMS.Common.Utility.Core.Generater.CodeGenerater.GenerateCode("D", 7, index, out code);

                    return this.Content(code);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public ActionResultBase GenerateDishShortID(string DishFullName)
        {
            using (this.CMSContext)
            {
                try
                {
                    string code = string.Empty;

                    code = CMS.Common.Utility.Core.Generater.MneCodeGenerater.GenerateShortID(DishFullName);

                    return this.Content(code);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public ActionResultCollectionBase<XMLResult> GetPriceUnitSettingCollection(Dish dish)
        {
            using (this.CMSContext)
            {
                try
                {
                    this.CMSContext.SyncSubTypeCollection<DishUnitPriceSetting>(dish);

                    

                    if (dish.UnitPriceSetting != null && dish.UnitPriceSetting.Count > 0)
                    {
                        XMLCollectionResults results = new XMLCollectionResults();

                        foreach (DishUnitPriceSetting price in dish.UnitPriceSetting)
                        {
                            this.CMSContext.SyncSubType<Unit>(price);
                            XMLResult result = new XMLResult(price);

                            results.Add(result);
                        }

                        return results;
                    }
                    return null;
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }

        public ActionResultBase GetUnitByPriceSetting(DishUnitPriceSetting priceSetting)
        {
            using (this.CMSContext)
            {
                try
                {
                    this.CMSContext.SyncSubType<Unit>(priceSetting);

                    if (priceSetting.UnitID != null)
                    {
                        return this.Xml(priceSetting.UnitID);
                    }
                    return null;
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }

        public ActionResultBase GetUnitByID(Guid ID)
        {
            using (this.CMSContext)
            {
                try
                {
                    ICollection<Unit> unitCollection =  this.CMSContext.Sync<Unit>(typeof(Unit));
                    foreach (Unit unit in unitCollection)
                    {
                        if (unit.ID == ID)
                        {
                            return this.Xml(unit);
                        }
                    }
                    return null;
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }

        public XMLCollectionResults GetAllUnit()
        {
            using (this.CMSContext)
            {
                try
                {
                    ICollection<Unit> unitCollection = this.CMSContext.Sync<Unit>(typeof(Unit));
                    return this.Collection<Unit>(unitCollection);
                }
                catch (Exception)
                {
                    
                }
                return this.Collection<Unit>(null);
            }
        }

        public ActionResultBase IsDishTypeUsedByEntrance(DishType dishType)
        {
            using (this.CMSContext)
            {
                bool result = false;
                ICollection<Entrance> entranceCollection = this.CMSContext.Sync<Entrance>(typeof(Entrance));
                foreach (Entrance entrance in entranceCollection)
                {
                    this.CMSContext.SyncSubTypeCollection<EntranceLimitationDetail>(entrance);

                    var lookup = from e in entrance.LimitationCollection where e.DishType.ID == dishType.ID select e;

                    result = lookup.Count() > 0 ? true : false;

                    if (result)
                    {
                        return this.Boolean(result);
                    }
                }
                return this.Boolean(result);
            }
        }

        public OOSDish GetOOSDish(Dish dish)
        {
            using (this.CMSContext)
            {
                try
                {
                    OOSDish oosDish = null;

                    ICollection < OOSDish> oosDishCollection = this.CMSContext.Sync<OOSDish>(typeof(OOSDish));

                    if (oosDishCollection == null || oosDishCollection.Count == 0)
                    {
                        return null;
                    }

                    var lookup = from oos in oosDishCollection where oos.DishID.Equals(dish.ID) select oos;

                    if (lookup != null && lookup.Count() > 0)
                    {
                        oosDish = lookup.ElementAt(0);

                        this.CMSContext.SyncSubType<Employee>(oosDish);
                    }

                    return oosDish;
                }
                catch
                {
                    return null;
                }
            }
        }

        public OOSDish GetOOSDish(Guid dishID)
        {
            using (this.CMSContext)
            {
                try
                {
                    OOSDish oosDish = null;

                    ICollection<OOSDish> oosDishCollection = this.CMSContext.Sync<OOSDish>(typeof(OOSDish));

                    if (oosDishCollection == null || oosDishCollection.Count == 0)
                    {
                        return null;
                    }

                    var lookup = from oos in oosDishCollection where oos.DishID.Equals(dishID) select oos;

                    if (lookup != null && lookup.Count() > 0)
                    {
                        oosDish = lookup.ElementAt(0);

                        this.CMSContext.SyncSubType<Employee>(oosDish);

                        
                    }

                    return oosDish;
                }
                catch
                {
                    return null;
                }
            }
        }

        public void UpdateOOSDish(Dish dish,OOSDish oosDish)
        {
            using (this.CMSContext)
            {
                try
                {
                    if(dish.ID.Equals(oosDish.DishID))
                    {
                        this.CMSContext.Save<OOSDish>(oosDish);
                    }
                }
                catch
                {

                }
            }
        }

        public void UpdateOOSDish(Guid dishID, OOSDish oosDish)
        {
            using (this.CMSContext)
            {
                try
                {
                    if (dishID.Equals(oosDish.DishID))
                    {
                        this.CMSContext.Save<OOSDish>(oosDish);
                    }
                }
                catch
                {

                }
            }
        }

        public void CreateOOSDish(Dish dish, OOSDish oosDish)
        {
            using (this.CMSContext)
            {
                try
                {
                    if (dish.ID.Equals(oosDish.DishID))
                    {
                        this.CMSContext.New<OOSDish>(oosDish);
                    }
                }
                catch
                {

                }
            }
        }

    }
}
