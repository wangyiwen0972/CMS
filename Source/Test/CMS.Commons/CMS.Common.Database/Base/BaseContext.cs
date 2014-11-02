namespace CMS.Common.Database.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CMS.Common.Model;
    using CMS.Interface.Model;
    using CMS.Common.Database.Core;
    using CMS.Common.Database.Emun;
    using System.Configuration;

    public abstract class BaseContext:IDisposable
    {
        internal BaseConnection connection = null;

        //上下文状态
        protected ContextStatus status = ContextStatus.None;

        //数据库缓存
        protected DBCacheManager dbCache = null;

        private const int maxRecord = 1000;

        public DBCacheManager DatabaseCacheManager
        {
            get { return dbCache; }
            internal set { dbCache = value; }
        }

        public ContextStatus Status
        {
            get { return status; }
            protected set{status = value;}
        }

        public string ConnectionString
        {
            get { return this.conn; }
        }

        public string Provider
        {
            get { return this.provider; }
        }

        protected string conn = string.Empty;
        protected string provider = string.Empty;

        public BaseContext()
        {
            string connectstring = ConfigurationManager.ConnectionStrings[0].ConnectionString;

            string dbType = ConfigurationManager.AppSettings.Get("dbType");
            

            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["dbType"]) && !string.IsNullOrEmpty(ConfigurationManager.ConnectionStrings["conn"].ConnectionString))
            {
                this.conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
                this.provider = ConfigurationManager.AppSettings["dbType"];
                this.connection = new DBConnection(this.provider, this.conn);
                this.dbCache = new DBCacheManager();
            }
        }

        public BaseContext(string provider,string conn)
        {
            this.provider = provider;
            this.conn = conn; 
        }

        private void Init()
        {
            this.connection = new DBConnection(this.provider, this.conn);
        }

        //保存模型到数据库
        public abstract void Save<T>(T model) where T : class,IModel;
        //新建模型到数据库
        public abstract void New<T>(T model) where T : class,IModel;
        //从数据库中删除指定模型
        public abstract void Delete<T>(T model) where T :class, IModel;
        //从数据库同步指定数据模型
        public virtual ICollection<T> Sync<T>(Type type) where T :class, IModel
        {
            status = ContextStatus.Syncing;

            List<T> collection = new List<T>(maxRecord);

            return collection;
        }

        public virtual ICollection<T> Sync<T>(Type type, string[] fields, int pageIndex, int displayCount) where T : class, IModel
        {
            status = ContextStatus.Syncing;

            List<T> collection = new List<T>(displayCount);

            return collection;
        }

        public virtual ICollection<T> Sync<T>(Type type, System.Xml.XmlDocument conditions) where T : class, IModel
        {
            status = ContextStatus.Syncing;

            List<T> collection = new List<T>(maxRecord);

            return collection;
        }

        //获取模型中集合类
        public abstract void SyncSubTypeCollection<T>(IModel model) where T : class,IModel;

        public abstract void SyncSubTypeCollection<T>(IModel model, System.Xml.XmlDocument conditions) where T : class,IModel;

        public abstract void SyncSubType<T>(IModel model) where T : class,IModel;

        public abstract void SaveAttributeEnum<T>(T model) where T :class, IAttributeEnumModel;

        public abstract void NewAttributeEnum<T>(T model) where T : class,IAttributeEnumModel;

        public abstract void DeleteAttributeEnum<T>(T model) where T : class,IAttributeEnumModel;

        public abstract ICollection<T> SyncAttributeEnum<T>(Type type) where T : class,IAttributeEnumModel;

        public abstract T SyncSingleAttributeEnum<T>(Type type) where T : class,IAttributeEnumModel;

        public abstract int SyncRowsNumber<T>(Type type) where T : class,IModel;

        public virtual bool TestConnection(out string error)
        {
            return connection.Test(out error);
        }

        public void Dispose()
        {
            
            
        }
    }
}
