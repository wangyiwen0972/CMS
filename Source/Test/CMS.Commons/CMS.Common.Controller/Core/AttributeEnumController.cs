namespace CMS.Common.Controller.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CMS.Common.ViewResult.Base;
    using CMS.Common.ViewResult;
    using CMS.Interface.Model;

    /// <summary>
    /// 枚举数据控制器
    /// </summary>
    public class AttributeEnumController:Base.BaseController
    {
        private const string tableName = "[AttributeEnum]";

        /// <summary>
        /// 新建枚举数据
        /// </summary>
        /// <typeparam name="T">枚举数据类型</typeparam>
        /// <param name="Model">模型实体</param>
        /// <returns>返回结果集</returns>
        public ActionResultBase New<T>(T Model) where T:class, IAttributeEnumModel
        {
            using (this.CMSContext)
            {
                try
                {
                    this.CMSContext.NewAttributeEnum<T>(Model);

                    return this.Content("新建系统数据成功！");
                }
                catch(Exception ex)
                {
                    throw ex;
                }

            }
        }
        /// <summary>
        /// 删除枚举数据
        /// </summary>
        /// <typeparam name="T">枚举数据类型</typeparam>
        /// <param name="Model"></param>
        /// <returns></returns>
        public ActionResultBase Delete<T>(T Model) where T : IAttributeEnumModel
        {
            return null;
        }

        /// <summary>
        /// 更新枚举数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Model"></param>
        /// <returns></returns>
        public ActionResultBase Update<T>(T Model) where T : IAttributeEnumModel
        {
            using (this.CMSContext)
            {
                try
                {
                    this.CMSContext.UpdateAttributeEnum<T>(Model);

                    return this.Xml<T>(Model);
                }
                catch (Exception ex)
                {
                    
                    throw;
                }
            }
        }

        public CMS.Common.ViewResult.Core.XMLCollectionResults Sync<T>() where T : class, IAttributeEnumModel
        {
            using (this.CMSContext)
            {
                try
                {
                    ICollection<T> modelCollection = this.CMSContext.SyncAttributeEnum<T>(typeof(T));
                    //ICollection<IModel> returnModel = new List<IModel>();
                    //foreach (T model in modelCollection)
                    //{
                    //    returnModel.Add(model as IModel);
                    //}

                    return this.Collection<T>(modelCollection);
                }
                catch(Exception ex)
                {
                    throw ex;
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
    }
}
