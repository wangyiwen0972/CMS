namespace CMS.Common.Database.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;


    public class UpdateCommand:Base.BaseCommand
    {
        private const string setintvalue = "{0} = {1}";
        private const string setstringvalue = "{0} = '{1}'";

        internal UpdateCommand(string Sentence):base(Sentence)
        {
        }


        #region Not supported
        public void AppendColumns(ICollection<KeyValuePair<string, object>> Columns)
        {
            throw new NotImplementedException();
        }

        public override void AppendWhereCommand(KeyValuePair<string, object> Column)
        {
            throw new NotImplementedException();
        }

        public override void AppendOrderByCommand(string[] fields, bool isAsc)
        {
            throw new NotImplementedException();
        }

        public  void AppendOrderByCommand(bool isAsc)
        {
            throw new NotImplementedException();
        }
        #endregion

        public override string AppendWhereCommand(XmlDocument doc)
        {
            //string condition = base.AppendWhereCommand(doc);
            //if (!string.IsNullOrEmpty(condition))
            //{
            //    return string.Format("{0} {1} {2}", this.sentence, WHERE, condition);
            //}
            //else
            //{
            //    return string.Empty;
            //}

            string xpath = "/Model/Columns/Column[@IsPrimaryKey='True']";
            Dictionary<string, string> dict = new Dictionary<string, string>();
            XmlNodeList nodeList = doc.SelectNodes(xpath);

            foreach (XmlNode node in nodeList)
            {
                string column = node.Attributes["name"].InnerText;
                string dbtype = node.Attributes["type"].InnerText;

                string value = node.InnerText;
                switch (dbtype.ToLower())
                {
                    case "decimal":
                    case "int":
                        {

                            dict.Add(column, string.Format(setintvalue, column, value));
                            break;
                        }
                    case "datetime":
                    case "guid":
                    case "string":
                        {
                            dict.Add(column, string.Format(setstringvalue, column, value));
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
                    temp.Append("and ");
                }
                
            }

            this.sentence = string.Format("{0} {1} {2}", this.sentence, WHERE, temp.ToString());

            return this.sentence;
        }    

        public override void AppendColumns(System.Xml.XmlDocument Columns)
        {
            this.tableName = Columns.DocumentElement.Attributes[0].InnerText;

            Dictionary<string,string> dict = new Dictionary<string,string>();

            base.AppendColumns(Columns);

            if (fields != null && fields.Length > 0)
            {

                foreach (string field in fields)
                {
                    string xpath = string.Format(xpathValues, tableName, field);
                    XmlNode node = Columns.SelectSingleNode(xpath);
                    if (node != null)
                    {
                        string dbType = node.Attributes[dbTypeAttribute].InnerText;
                        string value = node.InnerText;
                        switch (dbType.ToLower())
                        {
                            case "decimal":
                            case "int32":
                            case "int16":
                            case "int":
                                {
                                    
                                    dict.Add(field, string.Format(setintvalue, field, value));
                                    break;
                                }
                            case "datetime":
                            case "guid":
                            case "string":
                                {
                                    dict.Add(field, string.Format(setstringvalue, field, value));
                                    break;
                                }
                        }
                    }
                }

                StringBuilder temp = new StringBuilder();

                int index = 0;
                foreach (KeyValuePair<string, string> key in dict)
                {
                    temp.Append(key.Value);

                    if (index < dict.Count)
                    {
                        temp.Append(',');
                    }
                    index++;
                }

                this.sentence = string.Format(this.sentence, tableName, temp.ToString()).TrimEnd(',');
                base.Status = Emun.CommandStatus.Initialized;
            }
        }

        public override bool Check()
        {
            return base.Check();

        }

        public override void Execute(Base.BaseConnection Connection)
        {
            base.Execute(Connection);
        }

        public override void Rollback(Base.BaseConnection Connection)
        {
            base.Rollback(Connection);
        }


        public override void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
