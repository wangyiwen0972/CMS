namespace CMS.Common.Database.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.XPath;
    using System.IO;
    using System.Data;

    public class SelectCommand:Base.BaseCommand
    {
        private const string setintvalue = "{0} {1} {2}";
        private const string setstringvalue = "{0} {1} '{2}'";

        internal DataSet result { get; private set; }

        internal SelectCommand(string Sentence):base(Sentence)
        {
        }

        public override void Execute(Base.BaseConnection Connection)
        {
            base.Execute(Connection);
        }

        public override string GetData(Base.BaseConnection Connection)
        {
            return base.GetData(Connection);
        }

        public override void Rollback(Base.BaseConnection Connection)
        {
            base.Rollback(Connection);
        }

        public  void AppendColumns(ICollection<KeyValuePair<string, object>> Columns)
        {
            throw new NotImplementedException();
        }


        public override void AppendColumns(XmlDocument Columns)
        {
            this.tableName = Columns.DocumentElement.Attributes[0].InnerText;

            base.AppendColumns(Columns);

            if (base.fields != null && base.fields.Length > 0)
            {
                this.sentence = string.Format(sentence,string.Join(",", base.fields), tableName);
                base.Status = Emun.CommandStatus.Initialized;
            }
        }

        public override string AppendWhereCommand(XmlDocument doc)
        {
            string xpath = "/root/Column";
            List<KeyValuePair<string, string>> dict = new List<KeyValuePair<string,string>>();
            XmlNodeList nodeList = doc.SelectNodes(xpath);

            foreach (XmlNode node in nodeList)
            {
                string column = node.Attributes["name"].InnerText;
                string dbtype = node.Attributes["type"].InnerText;
                string strOperator = node.Attributes["operator"].InnerText;

                string value = node.InnerText;

                DBContext.DBOperator dbOperator = DBContext.DBOperator.None;

                System.Enum.TryParse<DBContext.DBOperator>(strOperator, out dbOperator);

                switch (dbtype.ToLower())
                {
                    case "decimal":
                    case "int":
                        {

                            switch (dbOperator)
                            {
                                case DBContext.DBOperator.Equal:
                                    {
                                        dict.Add(new KeyValuePair<string,string>(column, string.Format(setintvalue, column, EQUAL, value)));
                                        break;
                                    }
                                case DBContext.DBOperator.Less:
                                    {
                                        dict.Add(new KeyValuePair<string,string>( column, string.Format(setintvalue, column, LESS, value)));
                                        break;
                                    }
                                case DBContext.DBOperator.LessEqual:
                                    {
                                        dict.Add(new KeyValuePair<string,string>(column, string.Format(setintvalue, column, LESSEQUAL, value)));
                                        break;
                                    }
                                case DBContext.DBOperator.More:
                                    {
                                        dict.Add(new KeyValuePair<string,string>(column, string.Format(setintvalue, column, MORE, value)));
                                        break;
                                    }
                                case DBContext.DBOperator.MoreEqual:
                                    {
                                        dict.Add(new KeyValuePair<string,string>(column, string.Format(setintvalue, column, MOREEQUAL, value)));
                                        break;
                                    }
                                case DBContext.DBOperator.None:
                                    {
                                        throw new Exception("Operator is not be supported!");
                                    }
                            }

                            
                            break;
                        }
                    case "datetime":
                    case "guid":
                    case "string":
                        {
                            switch (dbOperator)
                            {
                                case DBContext.DBOperator.Equal:
                                    {
                                        dict.Add(new KeyValuePair<string,string>(column, string.Format(setstringvalue, column, EQUAL, value)));
                                        break;
                                    }
                                case DBContext.DBOperator.Less:
                                    {
                                        dict.Add(new KeyValuePair<string,string>(column, string.Format(setstringvalue, column, LESS, value)));
                                        break;
                                    }
                                case DBContext.DBOperator.LessEqual:
                                    {
                                        dict.Add(new KeyValuePair<string,string>(column, string.Format(setstringvalue, column, LESSEQUAL, value)));
                                        break;
                                    }
                                case DBContext.DBOperator.More:
                                    {
                                        dict.Add(new KeyValuePair<string,string>(column, string.Format(setstringvalue, column, MORE, value)));
                                        break;
                                    }
                                case DBContext.DBOperator.MoreEqual:
                                    {
                                        dict.Add(new KeyValuePair<string,string>(column, string.Format(setstringvalue, column, MOREEQUAL, value)));
                                        break;
                                    }
                                case DBContext.DBOperator.None:
                                    {
                                        throw new Exception("Operator is not be supported!");
                                    }
                            }
                            break;
                        }
                    default:
                        {
                            switch (dbOperator)
                            {
                                case DBContext.DBOperator.Equal:
                                    {
                                        dict.Add(new KeyValuePair<string,string>(column, string.Format(setstringvalue, column, EQUAL, value)));
                                        break;
                                    }
                                case DBContext.DBOperator.Less:
                                    {
                                        dict.Add(new KeyValuePair<string,string>(column, string.Format(setstringvalue, column, LESS, value)));
                                        break;
                                    }
                                case DBContext.DBOperator.LessEqual:
                                    {
                                        dict.Add(new KeyValuePair<string,string>(column, string.Format(setstringvalue, column, LESSEQUAL, value)));
                                        break;
                                    }
                                case DBContext.DBOperator.More:
                                    {
                                        dict.Add(new KeyValuePair<string,string>(column, string.Format(setstringvalue, column, MORE, value)));
                                        break;
                                    }
                                case DBContext.DBOperator.MoreEqual:
                                    {
                                        dict.Add(new KeyValuePair<string,string>(column, string.Format(setstringvalue, column, MOREEQUAL, value)));
                                        break;
                                    }
                                case DBContext.DBOperator.None:
                                    {
                                        throw new Exception("Operator is not be supported!");
                                    }
                            }
                            break;
                        }
                }
            }

            StringBuilder temp = new StringBuilder();

            int index = 0;
            foreach (KeyValuePair<string, string> key in dict)
            {
                index++;

                temp.Append(key.Value);

                if (index < dict.Count)
                {
                    temp.Append(" and ");
                }

            }

            if (this.sentence.Contains(WHERE))
            {
                this.sentence = string.Format("{0} and {1}", this.sentence, temp.ToString());
            }
            else
            {
                this.sentence = string.Format("{0} {1} {2}", this.sentence, WHERE, temp.ToString());
            }

            return this.sentence;
        }

        public string AppendBetweenAndToCommand(string value1,string value2)
        {
            if (!this.Check())
            {
                throw new Exception("");
            }
            if (this.sentence.Contains(WHERE))
            {
                this.sentence = string.Format("{0} and ({1})", this.sentence, string.Format(BETWEEN, value1, value2));
            }
            else
            {
                this.sentence = string.Format("{0} {1} ({2})", this.sentence, WHERE, string.Format(BETWEEN, value1, value2));
            }

            return this.sentence;
        }

        public override void AppendOrderByCommand(string[] fields, bool isAsc)
        {
            base.AppendOrderByCommand(fields, isAsc);
        }

        public override bool Check()
        {
            if (!base.Check())
            {
                return false;
            }
            //if (fields == null || fields.Length == 0)
            //{
            //    return false;
            //}
            return true;
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        public override void AppendWhereCommand(KeyValuePair<string, object> Column)
        {
            throw new NotImplementedException();
        }

        public void AppendChildTable(SelectCommand childCommand)
        {

        }


        
    }

}
