namespace CMS.Common.Controller.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Configuration;
    using CMS.Common.ViewResult.Core;
    using CMS.Common.ViewResult.Base;
    using CMS.Interface.Model;
    using CMS.Interface.Controller;
    using CMS.Interface.Module;
    using Utility = CMS.Common.Utility;
    using CMS.Common.Database.Core;
    using CMS.Common.Database.Base;
    //控制器基类
    public abstract class BaseController
    {
        //数据上下文
        protected static DBContext dbContext = null;
        //连接字符串
        protected readonly string connstring;

        protected readonly string provider;

        protected DBContext CMSContext
        {
            get { return BaseController.dbContext; }
        }

        public DBCacheManager CacheManage
        {
            get { return BaseController.dbContext.DatabaseCacheManager; }
        }

        static BaseController()
        {
            dbContext = new DBContext();
        }

        public BaseController()
        {
            connstring = this.GetConnectionString();
            provider = this.GetProvider();
            
        }

        //获取连接字符串
        protected abstract string GetConnectionString();

        //获取Provider
        protected abstract string GetProvider();

        /// <summary>
        /// 返回模型到UI界面
        /// </summary>
        /// <typeparam name="T">模型的类型</typeparam>
        /// <param name="Model">模型</param>
        /// <returns>返回模型到UI界面</returns>
        protected ActionResultBase View<T,V>(T Model,V View) where T : IModel where V : IModule
        {
            return null;
        }

        /// <summary>
        /// 返回字符串结果集
        /// </summary>
        /// <typeparam name="T">模型的类型</typeparam>
        /// <param name="Model">模型</param>
        /// <returns>返回模型字符串结果集</returns>
        protected ActionResultBase Content<T>(T Model) where T : IModel
        {
            try
            {
                ActionResultBase result = new ContentResult(Model);

                result.GetResult();

                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 返回字符串结果集
        /// </summary>
        /// <param name="Content">输出内容</param>
        /// <returns>返回字符串</returns>
        protected ActionResultBase Content(string Content)
        {
            ActionResultBase result = new ContentResult(Content);

            return result;
        }

        protected ActionResultBase Boolean(bool result)
        {
            ActionResultBase results = new BooleanResult(result);

            results.GetResult();

            return results;
        }

        protected ActionResultBase Boolean<T>(T Model, bool result) where T : IModel
        {
            try
            {
                ActionResultBase results = new BooleanResult(Model, result);

                results.GetResult();

                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 返回xml格式结果集
        /// </summary>
        /// <typeparam name="T">T必须继承Imodel接口类型</typeparam>
        /// <param name="Model">模型</param>
        /// <returns>返回xml结果集</returns>
        protected ActionResultBase Xml<T>(T Model) where T : IModel
        {
            ActionResultBase result = null;

            if (Model == null)
            {
                result = new XMLResult(null);
            }
            else
            {
                result = new XMLResult(Model);

                result.GetResult();

                this.CacheManage.UpdateCache<T>(Model);
            }
            
            return result;
        }

        protected ActionResultBase Xml(IAttributeEnumModel Model)
        {
            ActionResultBase result = null;
            if (Model == null)
            {
                result = new XMLResult(null);
            }
            else
            {
                result = new XMLResult(Model);
                result.GetResult();

                this.CacheManage.UpdateCache<IAttributeEnumModel>(Model);
            }
            return result;
        }

        /// <summary>
        /// 返回json格式结果集
        /// </summary>
        /// <typeparam name="T">T必须继承Imodel接口类型</typeparam>
        /// <param name="Model">模型</param>
        /// <returns>返回JSON结果集</returns>
        public ActionResultBase JOSN<T>(T Model) where T : IModel
        {
            ActionResultBase result = new JSONResult(Model);

            using (Utility.Base.BaseResolver Resolver = new Utility.Core.Resolver.JSONResolver())
            {
            }
            return result;
        }


        /// <summary>
        /// 返回模型到另一个控制器
        /// </summary>
        /// <typeparam name="T">模型的类型</typeparam>
        /// <typeparam name="T1">控制器的类型</typeparam>
        /// <param name="Model">模型</param>
        /// <param name="Controller">控制器</param>
        /// <returns>返回跳转结果</returns>
        protected ActionResultBase Redirect<T, C>(T Model, C Controller)
            where T : IModel
            where C : IController
        {
            return null;
        }

        /// <summary>
        /// 执行操作
        /// </summary>
        /// <typeparam name="T">模型的类型</typeparam>
        /// <param name="Model">模型</param>
        /// <param name="Method">执行的方法</param>
        /// <returns>返回执行结果集</returns>
        protected ActionResultBase Action<T>(T Model, Action<T> Method) where T : IModel
        {
            ActionResultBase result = new ActionResult(Model, Method as Func<IModel,bool>);

            result.GetResult();

            using (Utility.Base.BaseResolver Resolver = new Utility.Core.Resolver.XmlResolver())
            {
                
            }
            return result;
        }

        /// <summary>
        /// 执行操作
        /// </summary>
        /// <typeparam name="T">模型的类型</typeparam>
        /// <typeparam name="T1">模型的类型</typeparam>
        /// <param name="Model">模型</param>
        /// <param name="Method">执行的方法</param>
        /// <returns>返回执行结果集</returns>
        protected ActionResultBase Action<T, T1>(T Model, T1 Model1, Func<T, T1,bool> Method)
            where T : IModel
            where T1 : IModel
        {
            ActionResultBase result = new ActionResult(Model, Model1, Method as Func<IModel, IModel,bool>);

            result.GetResult();

            return result;
        }

        protected XMLCollectionResults Collection(ICollection<IModel> ModelCollection)
        {
            ActionResultCollectionBase<XMLResult> resultCollection = new XMLCollectionResults();

            foreach (IModel model in ModelCollection)
            {
                XMLResult result = new XMLResult(model);

                try
                {
                    result.GetResult();

                    resultCollection.Add(result);
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
            return resultCollection as XMLCollectionResults;
        }

        protected XMLCollectionResults Collection<T>(ICollection<T> ModelCollection) where T:IModel
        {
            ActionResultCollectionBase<XMLResult> resultCollection = new XMLCollectionResults();

            if (ModelCollection == null)
            {
                return resultCollection as XMLCollectionResults;
            }

            foreach (T model in ModelCollection)
            {
                XMLResult result = new XMLResult(model);

                try
                {
                    result.GetResult();

                    //update cache
                    if (model != null)
                    {
                        this.CacheManage.UpdateCache<T>(model);
                    }

                    resultCollection.Add(result);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return resultCollection as XMLCollectionResults;
        }

        protected void SyncSubType(IModel model, Type submodel)
        {
            try
            {
                this.CMSContext.SyncSubType(model, submodel);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
