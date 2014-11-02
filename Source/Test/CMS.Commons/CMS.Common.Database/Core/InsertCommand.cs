namespace CMS.Common.Database.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Data;

    public class InsertCommand:Base.BaseCommand
    {

        internal InsertCommand(string Sentence)
            : base(Sentence)
        {
            
        }

        public void AppendColumns(ICollection<KeyValuePair<string, object>> Columns)
        {
            if (string.IsNullOrEmpty(tableName))
            {
                throw new Exception("Need table name first!");
            }

            if (Columns == null || Columns.Count == 0)
            {
                throw new Exception("");
            }
            string columns = string.Empty;

            string values = string.Empty;

            foreach (KeyValuePair<string, object> column in Columns)
            {
                columns += string.Format("{0},", column.Key);

                if (column.Value is int)
                {
                    values += string.Format("{0},", column.Value);
                }
                else
                {
                    values += string.Format("'{0}',", column.Value);  
                }
            }

            columns = "(" + columns.TrimEnd(',') + ")";

            values = "(" + values.TrimEnd(',') + ")";

            this.sentence = string.Format(this.sentence, base.Table, columns, values);

            base.Status = Emun.CommandStatus.Initialized;
        }

        public override void AppendColumns(System.Xml.XmlDocument doc)
        {
            List<KeyValuePair<string, object>> columns = new List<KeyValuePair<string, object>>();

            XmlNodeList columnsNodes = null;

            if (doc != null)
            {
                this.tableName = doc.DocumentElement.Attributes[0].InnerText;


                columnsNodes = doc.SelectNodes(string.Format(xpathColumns,tableName));

                if (columnsNodes.Count > 0)
                {
                    KeyValuePair<string, object> kvp = new KeyValuePair<string,object>();
                    foreach (XmlNode node in columnsNodes)
                    {
                        string key = node.Attributes[nameAttribute].InnerText;

                        object value;

                        switch ((DbType)Enum.Parse(typeof(DbType), node.Attributes[dbTypeAttribute].InnerText))
                        {
                            case DbType.Int32:
                            case DbType.Int16:
                                {
                                    value = int.Parse(node.InnerText);
                                    kvp = new KeyValuePair<string, object>(key, value);
                                    
                                    break;
                                }
                            case DbType.Decimal:
                                {
                                    value = decimal.Parse(node.InnerText);
                                    kvp = new KeyValuePair<string, object>(key, value);
                                    break;
                                }
                            case DbType.Boolean:
                                {
                                    value = node.InnerText;
                                    kvp = new KeyValuePair<string, object>(key, value);
                                    break;
                                }
                            case DbType.DateTime:
                                {
                                    value = node.InnerText;
                                    kvp = new KeyValuePair<string, object>(key, value);

                                    break;
                                }
                            case DbType.String:
                                {
                                    value = node.InnerText;
                                    kvp = new KeyValuePair<string, object>(key, value);

                                    break;
                                }
                            case DbType.Guid:
                                {
                                    value = node.InnerText;
                                    kvp = new KeyValuePair<string, object>(key, value);
                                    break;
                                }
                        }

                        columns.Add(kvp);
                    }
                }
                this.AppendColumns(columns);
            }
        }

        public override void Execute(Base.BaseConnection connection)
        {
            base.Execute(connection);
        }

        public override void Rollback(Base.BaseConnection connection)
        {
            base.Rollback(connection);
        }

        #region 不支持的方法

        public override void AppendOrderByCommand(string[] fields, bool isAsc)
        {
            throw new NotImplementedException();
        }

        public override string AppendWhereCommand(XmlDocument doc)
        {
            throw new NotImplementedException();
        }

        public override string GetData(Base.BaseConnection Connection)
        {
            throw new NotImplementedException();
        }

        public override void AppendWhereCommand(KeyValuePair<string, object> Column)
        {
            throw new NotImplementedException();
        }

        #endregion




        public override bool Check()
        {
            return base.Check();
        }

        public override void Dispose()
        {
            
        }
    }
}
