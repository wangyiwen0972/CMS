namespace CMS.Common.Controller.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CMS.Common.ViewResult.Base;
    using CMS.Common.ViewResult.Core;
    using CMS.Interface.Model;

    public class DepartmentController:Controller.Base.BaseController
    {
        private static Dictionary<Guid, CMS.Common.Model.Department> dictDepartment = null;

        static DepartmentController()
        {
            using (Controller.Base.BaseController.dbContext)
            {
                dictDepartment = new Dictionary<Guid, Model.Department>();

                ICollection< Model.Department> departmentCollection = Controller.Base.BaseController.dbContext.SyncAttributeEnum<Model.Department>(typeof(Model.Department));

                if (dictDepartment != null && dictDepartment.Count > 0)
                {
                    foreach (Model.Department department in departmentCollection)
                    {
                        if (!dictDepartment.ContainsKey(department.ID))
                        {
                            dictDepartment[department.ID] = department;
                        }
                    }
                }
            }
        }

        protected override string GetConnectionString()
        {
            return !string.IsNullOrEmpty(this.CMSContext.ConnectionString) ? this.CMSContext.ConnectionString : string.Empty;
        }

        protected override string GetProvider()
        {
            return !string.IsNullOrEmpty(this.CMSContext.Provider) ? this.CMSContext.Provider : string.Empty;
        }

        /// <summary>
        /// 创建部门
        /// </summary>
        /// <param name="Department">部门</param>
        /// <returns>返回结果集</returns>
        public ActionResultBase New(CMS.Common.Model.Department Department)
        {
            using (this.CMSContext)
            {
                try
                {
                    this.CMSContext.NewAttributeEnum<CMS.Common.Model.Department>(Department);

                    return this.Content("新建部门成功");
                }
                catch(Exception ex)
                {
                    return this.Content("创建部门失败" + ex.Message);
                }
                finally
                {
                    this.CMSContext.DatabaseCacheManager.UpdateCache<CMS.Common.Model.Department>(Department);
                }
            }
        }
        /// <summary>
        /// 获取所有部门
        /// </summary>
        /// <returns>返回部门集合</returns>
        public ActionResultCollectionBase<XMLResult> GetAllDepartment()
        {
            using (this.CMSContext)
            {
                ICollection<Model.Department> modelCollection = null;
                try
                {
                    modelCollection = this.CMSContext.SyncAttributeEnum<Model.Department>(typeof(Model.Department));

                    XMLCollectionResults results = new XMLCollectionResults();

                    foreach (Model.Department e in modelCollection)
                    {
                        ActionResultBase result = new XMLResult(e);

                        results.Add(result as XMLResult);
                    }
                    return results;
                }
                catch (Exception ex) { throw ex; }
                finally
                {
                    this.CMSContext.DatabaseCacheManager.UpdateCache<Model.Department>(modelCollection);
                }
            }
        }
        public ActionResultCollectionBase<XMLResult> GetAllPosition()
        {
            using (this.CMSContext)
            {
                ICollection<Model.Postion> modelCollection = null;
                try
                {
                    modelCollection = this.CMSContext.SyncAttributeEnum<Model.Postion>(typeof(Model.Postion));

                    XMLCollectionResults results = new XMLCollectionResults();

                    foreach (Model.Postion e in modelCollection)
                    {
                        ActionResultBase result = new XMLResult(e);

                        results.Add(result as XMLResult);
                    }
                    return results;
                }
                catch (Exception ex) { throw ex; }
                finally
                {
                    this.CMSContext.DatabaseCacheManager.UpdateCache<Model.Postion>(modelCollection);
                }
            }
        } 
    }
}
