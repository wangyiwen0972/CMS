namespace CMS.Common.Database.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;

    public class DeleteCommand:Base.BaseCommand
    {
        private const string setintvalue = "{0} = {1}";
        private const string setstringvalue = "{0} = '{1}'";

        internal DeleteCommand(string Sentence):base(Sentence)
        {
        }

        public override void AppendWhereCommand(KeyValuePair<string, object> Column)
        {
            throw new NotImplementedException();
        }

        public override void AppendColumns(XmlDocument Columns)
        {
            this.tableName = Columns.DocumentElement.Attributes[0].InnerText;

            Dictionary<string, string> dict = new Dictionary<string, string>();

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

        public override string AppendWhereCommand(XmlDocument doc)
        {
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

        public override bool Check()
        {
            return base.Check();
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
