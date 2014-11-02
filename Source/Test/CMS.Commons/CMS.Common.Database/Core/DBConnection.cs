namespace CMS.Common.Database.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.Common;
    using System.Data;
    using SDC = System.Data.Common;

    internal class DBConnection:Base.BaseConnection
    {
        internal DBConnection(string Provide, string Conn)
            : base(Provide, Conn)
        {
        }

        protected override void Open()
        {
            
            try
            {
                if (dbconnection == null)
                {
                    base.Open();
                }

                if (dbconnection.State == System.Data.ConnectionState.Closed)
                {
                    dbconnection.Open();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Test(out string error)
        {
            bool resulte = false;
            error = string.Empty;
            try
            {
                using (dbconnection = dbProvider.CreateConnection())
                {
                    dbconnection.ConnectionString = this.connectstring;
                    dbconnection.Open();
                    resulte = true;
                }
            }
            catch (Exception ex) { error = ex.Message; }
            finally { dbconnection = null; }
            return resulte;
        }

        public override void Execute(string[] sqls)
        {
            if (sqls != null && sqls.Length > 0)
            {
                try
                {
                    this.Open();
                    dbtransaction = dbconnection.BeginTransaction();
                    
                    dbcommand.Transaction = dbtransaction;
                    foreach (string sql in sqls)
                    {
                        dbcommand.CommandType = System.Data.CommandType.Text;
                        dbcommand.CommandText = sql;
                        dbcommand.ExecuteNonQuery();
                    }
                    dbtransaction.Commit();
                    
                }
                catch (Exception ex)
                {
                    dbtransaction.Rollback();
                    throw;
                }
            }
        }

        public override void Execute(string procedure)
        {
            try
            {
                this.Open();
                dbtransaction = dbconnection.BeginTransaction();
                dbcommand.Transaction = dbtransaction;
                
                dbcommand.CommandType = System.Data.CommandType.StoredProcedure;
                dbcommand.CommandText = procedure;
                dbcommand.ExecuteNonQuery();
                dbtransaction.Commit();
            }
            catch (Exception)
            {
                dbtransaction.Rollback();
                throw;
            }
        }

        public override System.Data.DataSet GetDataSet(Base.BaseCommand[] commands)
        {
            DataSet ds = new DataSet();

            foreach (Base.BaseCommand cmd in commands)
            {
                if (cmd.Check())
                {
                    try
                    {
                        this.Open();

                        DataTable table = new DataTable(cmd.Table);

                        SDC.DbDataAdapter adapter = dbProvider.CreateDataAdapter();

                        this.dbcommand.CommandText = cmd.ToString();
                        this.dbcommand.CommandType = CommandType.Text;

                        adapter.SelectCommand = this.dbcommand;

                        adapter.Fill(table);

                        ds.Tables.Add(table);
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }
                }
            }

            return ds;
        }

        public override System.Data.DataSet GetDataSet(string[] sqls)
        {
            DataSet ds = new DataSet();

            foreach (string cmd in sqls)
            {

                try
                {
                    DataTable table = new DataTable();

                    SDC.DbDataAdapter adapter = dbProvider.CreateDataAdapter();

                    this.dbcommand.CommandType = CommandType.Text;

                    this.dbcommand.CommandText = cmd;

                    adapter.SelectCommand = this.dbcommand;

                    adapter.Fill(table);

                    ds.Tables.Add(table);
                }
                catch (Exception)
                {

                    throw;
                }
                
            }

            return ds;
        }

        public override System.Data.DataSet GetDataSet(string procedure,params DbParameter[] parameters)
        {
            DataSet ds = new DataSet();

            try
            {
                this.Open();

                DataTable table = new DataTable();

                SDC.DbDataAdapter adapter = dbProvider.CreateDataAdapter();

                this.dbcommand.CommandType = CommandType.StoredProcedure;

                this.dbcommand.CommandText = procedure;

                if (parameters != null || parameters.Length > 0)
                {
                    this.dbcommand.Parameters.AddRange(parameters);
                }

                adapter.SelectCommand = this.dbcommand;


                adapter.Fill(table);

                ds.Tables.Add(table);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                this.dbcommand.Parameters.Clear();
            }

            return ds;
        }

        public override void Rollback(Base.BaseCommand[] commands)
        {
            throw new NotImplementedException();
        }

        public override void Execute(Base.BaseCommand[] commands)
        {
            try
            {
                string[] sqls = new string[commands.Length];
                int index  = 0;
                foreach (Base.BaseCommand command in commands)
                {
                    sqls[index] = command.ToString();
                    index += 1;
                }
                this.Execute(sqls);

            }
            catch (Exception)
            {
                
                throw;
            }
           
        }

        public override void Execute(string procedure, params DbParameter[] parameters)
        {
            try
            {
                this.Open();
                dbtransaction = dbconnection.BeginTransaction();
                dbcommand.Transaction = dbtransaction;
                dbcommand.CommandType = System.Data.CommandType.StoredProcedure;
                dbcommand.CommandText = procedure;
                dbcommand.Parameters.AddRange(parameters);
                dbcommand.ExecuteNonQuery();
                dbtransaction.Commit();
            }
            catch (Exception)
            {
                dbtransaction.Rollback();
                throw;
            }
            finally
            {
                this.dbcommand.Parameters.Clear();
            }
        }

        internal override DbParameter createDbParameter()
        {
            return base.dbProvider.CreateParameter();
        }
    }
}
