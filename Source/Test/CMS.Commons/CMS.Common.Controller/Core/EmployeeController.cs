namespace CMS.Common.Controller.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using CMS.Common.ViewResult.Base;
    using CMS.Common.ViewResult.Core;

    public class EmployeeController:Base.UserController
    {
        private Model.Employee employee = null;

        private static Dictionary<Guid, Model.UserStatus> userStatus = null;

        private static Dictionary<Guid, Model.RightLevel> userLevel = null;

        public EmployeeController() :this(null){ }

        public EmployeeController(Model.Employee Employee)
        {
            this.employee = Employee;
        }

        static EmployeeController()
        {
            using (Controller.Base.BaseController.dbContext)
            {
                userStatus = new Dictionary<Guid, Model.UserStatus>();

                userLevel = new Dictionary<Guid, Model.RightLevel>();

                ICollection<Model.UserStatus> statusCollection = EntranceController.dbContext.SyncAttributeEnum<Model.UserStatus>(typeof(Model.UserStatus));
                if (statusCollection != null && statusCollection.Count > 0)
                {
                    foreach (Model.UserStatus status in statusCollection)
                    {
                        if (!userStatus.ContainsKey(status.ID))
                        {
                            userStatus[status.ID] = status;
                        }
                    }
                }
            }
        }

        public Model.UserStatus getEntranceStatus(Guid guid)
        {
            Model.UserStatus status;

            if (!EmployeeController.userStatus.TryGetValue(guid, out status))
            {
            }
            return status;
        }

        public Model.RightLevel getRightLevel(Guid guid)
        {
            Model.RightLevel level;
            if (!EmployeeController.userLevel.TryGetValue(guid, out level))
            {
            }
            return level;
        }

        #region 实现底层控制器方法
        public override ActionResultBase LogIn(Model.Base.UserBase User)
        {
            using (this.CMSContext)
            {
                try
                {

                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            return this.Content("");
        }

        public ActionResultBase LogIn(string UserName,string Password)
        {
            using (this.CMSContext)
            {
                ICollection<Model.Employee> employeeCollection = this.CMSContext.Sync<Model.Employee>(typeof(Model.Employee));

                foreach (Model.Employee employee in employeeCollection)
                {
                    if (employee.Login.Equals(UserName, StringComparison.CurrentCultureIgnoreCase))
                    {
                        if (CMS.Common.Utility.Core.Common.Helper.VerifyMd5Hash(Password, employee.Password))
                        {
                            return this.Boolean(employee,true);
                        }
                    }
                }
                return this.Boolean(false);
            }
        }

        public ActionResultBase LogIn(string UserName, string Password,string Department)
        {
            using (this.CMSContext)
            {
                ICollection<Model.Employee> employeeCollection = this.CMSContext.Sync<Model.Employee>(typeof(Model.Employee));

                foreach (Model.Employee employee in employeeCollection)
                {
                    if (employee.Login.Equals(UserName) && employee.Department.ID.ToString() == Department)
                    {
                        if (CMS.Common.Utility.Core.Common.Helper.VerifyMd5Hash(Password, employee.Password))
                        {
                            return this.Boolean(employee, true);
                        }
                    }
                }
                return this.Boolean(false);
            }
        }

        public override ActionResultBase ChangePassWord(string newPassword, string oldPassword)
        {
            throw new NotImplementedException();
        }

        public override ActionResultBase LogOut(Model.Base.UserBase User)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region 未实现方法

        //点菜
        public ActionResultBase TakeOrders(Model.Dish Dish)
        {
            return null;
        }
        //为客户预订
        public ActionResultBase BookTable(Model.Customer Customer, Model.DishTable Table)
        {
            return null;
        }

        //生成订单
        public ActionResultBase CreateOrder()
        {
            return null;
        }

        //查看订单
        public ActionResultBase CheckOrder(Model.DishOrder Order)
        {
            return null;
        }

        //收款
        public ActionResultBase AccountBill(Model.DishOrder Order)
        {
            return null;
        }
        //设置职位（经理，收银，服务生）
        public ActionResultBase SetPosition(Model.Employee Employee,Model.Emun.Position Position)
        {
            return null;
        }
        //为职位设置动作
        public ActionResultBase SetPermission(Model.Employee Employee,Model.Emun.Position Position, ICollection<Model.Emun.Action> Actions)
        {
            return null;
        }
        
        //创建VIP客户
        public ActionResultBase CreateVIP(Model.Customer Employee,string FullName)
        {
            return null;
        }

        #endregion

        #region 可使用方法
        /// <summary>
        /// 设置部门
        /// </summary>
        /// <param name="Employee">职员</param>
        /// <param name="Department">部门</param>
        /// <returns>返回结果集</returns>
        public ActionResultBase SetDepartment(Model.Employee Employee, Model.Department Department)
        {
            using (this.CMSContext)
            {
                try
                {
                    Employee.Department = Department;

                    this.CMSContext.Save<Model.Employee>(Employee);

                    this.CMSContext.DatabaseCacheManager.UpdateCache(Employee);

                    return this.Content("设置部门成功");
                }
                catch(Exception ex)
                {
                    return this.Content("设置部门失败！" + ex.Message);
                }
            }
        }

        /// <summary>
        /// 创建员工账号
        /// </summary>
        /// <param name="Employee">员工</param>
        /// <returns>返回结果集</returns>
        public ActionResultBase CreateEmployee(Model.Employee Employee)
        {
            using (this.CMSContext)
            {
                try
                {
                    this.CMSContext.New<Model.Employee>(Employee);

                    this.CMSContext.DatabaseCacheManager.UpdateCache(Employee);

                    return this.Content("创建职员成功");
                }
                catch (Exception ex) { return this.Content("创建职员失败！" + ex.Message); }
            }
        }
        /// <summary>
        /// 更新员工信息
        /// </summary>
        /// <param name="Employee">员工</param>
        /// <returns>返回布尔结果集</returns>
        public ActionResultBase UpdateEmployee(Model.Employee Employee)
        {
            using (this.CMSContext)
            {
                try
                {
                    this.CMSContext.Save<Model.Employee>(Employee);

                    this.CMSContext.DatabaseCacheManager.UpdateCache(Employee);

                    return this.Boolean(true);
                }
                catch (Exception ex) { return this.Boolean(false); }
            }
        }
        /// <summary>
        /// 删除员工
        /// </summary>
        /// <param name="Employee">员工</param>
        /// <returns>返回结果集</returns>
        public ActionResultBase DeleteEmployee(Model.Employee Employee)
        {
            using (this.CMSContext)
            {
                try
                {
                    this.CMSContext.Delete<Model.Employee>(Employee);

                    this.CMSContext.DatabaseCacheManager.DeleteCache(Employee);

                    return this.Content("删除职员成功");
                }
                catch (Exception ex) { throw ex; }
            }
        }

        public ActionResultBase GetEmployee(Guid Guid)
        {
            using (this.CMSContext)
            {
                ActionResultBase result = null;

                Database.Base.BaseCache<Interface.Model.IModel> baseCache = this.CacheManage[typeof(Model.Employee)];

                if (baseCache != null)
                {
                    foreach (Interface.Model.IModel model in baseCache)
                    {
                        Model.Employee tmpEmployee = model as Model.Employee;

                        if (tmpEmployee != null && tmpEmployee.ID == Guid)
                        {
                            result = new XMLResult(tmpEmployee);
                            break;
                        }
                    }

                    return result;
                }
                else
                {
                    GetAllEmployee();

                    return GetEmployee(Guid);
                }
                
            }
        }

        /// <summary>
        /// 获取所有员工
        /// </summary>
        /// <returns>返回员工集合</returns>
        public ActionResultCollectionBase<XMLResult> GetAllEmployee()
        {
            using (this.CMSContext)
            {
                try
                {
                    ICollection<Model.Employee> modelCollection = this.CMSContext.Sync<Model.Employee>(typeof(Model.Employee));

                    XMLCollectionResults results = new XMLCollectionResults();

                    foreach (Model.Employee e in modelCollection)
                    {
                        ActionResultBase result = new XMLResult(e);

                        results.Add(result as XMLResult);
                    }
                    return results;
                }
                catch (Exception ex) { throw ex; }
            }
        }
        /// <summary>
        /// 获取指定部门所有员工
        /// </summary>
        /// <param name="Department">部门</param>
        /// <returns>返回结果集</returns>
        public ActionResultCollectionBase<XMLResult> GetEmployeeByDepartment(Model.Department Department)
        {
            using (this.CMSContext)
            {
                XMLCollectionResults results = new XMLCollectionResults();

                try
                {
                        ICollection<Model.Employee> modelCollection = this.CMSContext.Sync<Model.Employee>(typeof(Model.Employee));

                        foreach (Model.Employee e in modelCollection)
                        {
                            if (e.Department.ID == Department.ID)
                            {
                                ActionResultBase result = new XMLResult(e);
                                results.Add(result as XMLResult);
                            }
                        }

                        this.CacheManage.UpdateCache(modelCollection);
                    //}
                    return results;
                }
                catch (Exception ex) 
                {
                    throw ex;
                }
            }
        }
        /// <summary>
        /// 获取该员工部门
        /// </summary>
        /// <param name="employee">员工模型</param>
        /// <returns>返回部门模型</returns>
        public ActionResultBase GetDepartmentForEmployee(CMS.Common.Model.Employee employee)
        {
            using (this.CMSContext)
            {
                try
                {
                    this.CMSContext.SyncSubType<CMS.Common.Model.Department>(employee);


                    //ActionResultBase result = new XMLResult(employee.Department);
                    //result.GetResult();

                    this.CacheManage.UpdateCache(employee);
                    return this.Xml(employee.Department);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool GetRightLevelForEmployee(CMS.Common.Model.Employee employee, out string error)
        {
            using (this.CMSContext)
            {
                bool result = false;

                error = string.Empty;

                try
                {
                    this.CMSContext.SyncSubType<CMS.Common.Model.RightLevel>(employee);
                    this.CacheManage.UpdateCache(employee);

                    result = true;
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                }
                finally
                {
                    
                }
                return result;
            }
        }

        /// <summary>
        /// 生成员工号
        /// </summary>
        /// <returns>返回员工号结果集</returns>
        public ActionResultBase GenerateEmployeeCode()
        {
            using (this.CMSContext)
            {
                try
                {
                    int index = this.CMSContext.SyncRowsNumber<CMS.Common.Model.Employee>(typeof(CMS.Common.Model.Employee));

                    string code = string.Empty;

                     CMS.Common.Utility.Core.Generater.CodeGenerater.GenerateCode(this.prefix,5,index, out code);

                    return  this.Content(code);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 获取员工所有可用状态
        /// </summary>
        /// <returns>返回状态集合</returns>
        public ActionResultCollectionBase<XMLResult> GetStatusOfEmployee()
        {
            using (this.CMSContext)
            {
                XMLCollectionResults results = new XMLCollectionResults();

                try
                {
                    AttributeEnumController controller = new AttributeEnumController();

                    results = controller.Sync<Model.UserStatus>();

                    controller.CacheManage.UpdateCache(results.GetModelResults() as ICollection<Model.UserStatus>);

                    return results;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 获取该员工职位
        /// </summary>
        /// <param name="employee">员工模型</param>
        /// <returns>返回职位模型</returns>
        public ActionResultBase GetPositionForEmployee(Model.Employee employee)
        {
            using (this.CMSContext)
            {
                try
                {
                    this.CMSContext.SyncSubType<CMS.Common.Model.Postion>(employee);

                    //ActionResultBase result = new XMLResult(employee.Position);

                    return this.Xml(employee.Position);
                    
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

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

    }
}
