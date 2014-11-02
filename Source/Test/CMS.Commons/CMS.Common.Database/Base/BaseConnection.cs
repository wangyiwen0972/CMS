namespace CMS.Common.Database.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.Common;
    using System.Data;

    public abstract class BaseConnection:IDisposable
    {
        private const string DBTYPE = "dbType";

        protected DbProviderFactory dbProvider = null;
        protected string providerName = string.Empty;
        protected string connectstring = string.Empty;
        internal DbConnection dbconnection = null;
        internal DbCommand dbcommand = null;
        internal DbTransaction dbtransaction = null;

        public BaseConnection(string provider, string conn)
        {
            this.connectstring = conn;

            this.providerName = provider;

            this.dbProvider = DbProviderFactories.GetFactory(this.providerName);
        }


        protected virtual void Open()
        {
            this.dbconnection = this.dbProvider.CreateConnection();
            this.dbconnection.ConnectionString = this.connectstring;
            this.dbcommand = this.dbProvider.CreateCommand();
            this.dbcommand.Connection = this.dbconnection;
        }


        protected virtual void Close()
        {
            if (dbProvider != null) dbProvider = null;
            if (dbconnection != null)
            {
                if (dbconnection.State != System.Data.ConnectionState.Closed)
                {
                    dbconnection.Close();
                }
            }
            dbconnection = null;
            dbcommand = null;
        }

        public abstract bool Test(out string error);

        public abstract void Execute(string[] sqls);

        public abstract DataSet GetDataSet(string[] sqls);

        public abstract DataSet GetDataSet(BaseCommand[] commands);

        public abstract DataSet GetDataSet(string procedure,params DbParameter[] parameters);

        public abstract void Execute(BaseCommand[] commands);

        public abstract void Execute(string procedure);

        public abstract void Execute(string procedure, params DbParameter[] parameters);

        public abstract void Rollback(BaseCommand[] commands);

        internal abstract DbParameter createDbParameter();

        public void Dispose()
        {
            this.Close();
        }

    }
}
