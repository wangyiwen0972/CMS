namespace CMS.Common.Database.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.Sql;
    using System.Xml;
    using System.Xml.XPath;
    using System.IO;

    public abstract class BaseCommand : IDisposable
    {
        protected string sentence = string.Empty;

        protected string tableName = string.Empty;

        protected string[] fields;

        protected string[] conditionFields;

        protected CMS.Common.Database.Emun.CommandStatus commandStatus = Emun.CommandStatus.None;

        #region Const
        protected const string xpathColumns = "/Model[@name='{0}']/Columns/Column";
        protected const string xpathValues = "/Model[@name='{0}']/Columns/Column[@name='{1}']";
        protected const string xpathColumn = "./Column";
        protected const string xpathValue = "./Value";

        protected const string AND = "and";
        protected const string OR = "or";
        protected const string HAVING = "having";
        protected const string COUNT = "count(*)";
        protected const string WHERE = "where";
        protected const string ORDERBY = "order by";
        protected const string ASC = "asc";
        protected const string DESC = "desc";
        protected const string LIKE = "like";
        protected const string STARTSYMBOL = "*";
        protected const string COMMASYMBOL = ",";
        protected const string BETWEEN = "between '{0}' and '{1}'";
        protected const string LESS = "<";
        protected const string LESSEQUAL = "<=";
        protected const string MORE = ">";
        protected const string MOREEQUAL = ">=";
        protected const string EQUAL = "=";
        

        protected const string nameAttribute = "name";
        protected const string dbTypeAttribute = "type";
        protected const string valueAttribute = "value";
        #endregion

        #region Properties
        public bool HasCondition
        {
            get
            {
                return conditionFields == null || conditionFields.Length == 0 ? false : true;
            }
        }

        public bool HasFilter
        {
            get { return false; }
        }

        public bool HasGroupBy
        {
            get { return false; }
        }

        public bool HasLike
        {
            get { return false; }
        }

        public string Table
        {
            set { tableName = value; }
            get { return tableName; }
        }

        public CMS.Common.Database.Emun.CommandStatus Status
        {
            get { return commandStatus; }
            internal set { commandStatus = value; }
        }     


        #endregion
        internal BaseCommand(string Sentence)
        {
            sentence = Sentence;
        }

        public virtual void AppendColumns(XmlDocument Columns)
        {
            if (Check())
            {
                XmlNodeList columnListNode = Columns.SelectNodes(string.Format(xpathColumns, tableName));
                if (columnListNode != null && columnListNode.Count > 0)
                {
                    this.fields = new string[columnListNode.Count];

                    for (int i = 0; i < columnListNode.Count; i++)
                    {
                        string columnName = columnListNode[i].Attributes[nameAttribute].InnerText;
                        if (!string.IsNullOrEmpty(columnName))
                        {
                            this.fields[i] = columnName;
                        }
                    }
                }
            }
        }

        public abstract void AppendWhereCommand(KeyValuePair<string, object> Column);

        #region Generate where sentence
        public virtual string AppendWhereCommand(XmlDocument doc)
        {
            XPathNavigator navigator = doc.CreateNavigator();
            XPathNodeIterator iterator = navigator.Select("/");
            string whereSentence = string.Empty;
            while (iterator.MoveNext())
            {
                if (iterator.Current.NodeType == XPathNodeType.Element)
                {
                    switch (iterator.Current.Name)
                    {
                        case "operator":
                            {
                                whereSentence = this.CreateOperator(navigator);
                                break;
                            }
                        case "column":
                            {
                                whereSentence = this.CreateColumn(navigator);
                                break;
                            }
                    }
                }
            }
            return whereSentence;
        }

        private string CreateColumn(XPathNavigator navigator)
        {
            string name = navigator.GetAttribute(nameAttribute, "");
            string value = navigator.GetAttribute(valueAttribute, "");
            string dbtype = navigator.GetAttribute(dbTypeAttribute, "");
            string sentence = string.Empty;
            switch (dbtype)
            {
                case "int":
                    {
                        sentence = string.Format("{0}={1}", name, value);
                        break;
                    }
                case "string":
                default:
                    {
                        sentence = string.Format("{0}='{1}'", name, value);
                        break;
                    }
            }
            return sentence;
        }

        private string CreateGroup(XPathNavigator navigator, string operate)
        {
            string sentence = "(";

            XPathNavigator copyNavigator = navigator.CreateNavigator();

            while (navigator.MoveToChild(XPathNodeType.Element))
            {
                if (navigator.Name == "column")
                {
                    if (navigator.CreateNavigator().MoveToNext())
                    {
                        sentence += string.Format("{0} {1} ", this.CreateColumn(navigator), operate);
                    }
                    else
                    {
                        sentence += this.CreateColumn(navigator);
                    }

                }
                else if (navigator.Name == "operator")
                {
                    sentence += this.CreateOperator(navigator);
                }
                while (navigator.MoveToNext())
                {
                    if (navigator.Name == "column")
                    {
                        if (navigator.CreateNavigator().MoveToNext())
                        {
                            sentence += string.Format("{0} {1} ", this.CreateColumn(navigator), operate);
                        }
                        else
                        {
                            sentence += this.CreateColumn(navigator);
                        }

                    }
                    else if (navigator.Name == "operator")
                    {
                        sentence += this.CreateOperator(navigator);
                    }
                    else if (navigator.Name == "group")
                    {
                        sentence += this.CreateGroup(navigator, operate);
                    }
                }
            }

            return sentence + ")";
        }

        private string CreateOperator(XPathNavigator navigator)
        {
            string sentence = string.Empty;
            string operate = navigator.GetAttribute(nameAttribute, "");
            XPathNavigator copyNavigator = null;
            while (navigator.MoveToChild(XPathNodeType.Element))
            {
                if (navigator.Name == "column")
                {
                    sentence += string.Format("{0} {1}", this.CreateColumn(navigator), operate);
                }
                else if (navigator.Name == "group")
                {
                    if (navigator.CreateNavigator().MoveToNext())
                    {
                        copyNavigator = navigator.CreateNavigator();
                        sentence += string.Format("{0} {1} ", this.CreateGroup(navigator, operate), operate);
                    }
                    else
                    {
                        sentence += this.CreateGroup(navigator, operate);
                    }

                }

            }
            if (copyNavigator != null)
            {
                while (copyNavigator.MoveToNext())
                {
                    if (copyNavigator.NodeType == XPathNodeType.Element)
                    {
                        if (copyNavigator.Name == "column")
                        {
                            if (copyNavigator.CreateNavigator().MoveToNext())
                            {
                                sentence += string.Format("{0} {1}", this.CreateColumn(copyNavigator), operate);
                            }
                            else
                            {
                                sentence += this.CreateColumn(copyNavigator);
                            }
                        }
                        else if (copyNavigator.Name == "opterator")
                        {
                            sentence += this.CreateGroup(copyNavigator, operate);
                        }
                        else if (copyNavigator.Name == "group")
                        {
                            sentence += this.CreateGroup(copyNavigator, operate);
                        }
                    }
                }
            }
            return sentence;
        }

        #endregion

        //为sql语句添加排序orderby
        public virtual void AppendOrderByCommand(string[] fields, bool isAsc)
        {
            if (Check())
            {
                this.sentence = string.Format("{0} {1} {2} {3}", this.sentence, ORDERBY, string.Join(",", fields), isAsc == true ? ASC : DESC);
            }
        }

        //检查命令是否有效
        public virtual bool Check()
        {
            if (string.IsNullOrEmpty(this.sentence))
            {
                return false;
            }
            if (string.IsNullOrEmpty(this.tableName))
            {
                return false;
            }
            //if (commandStatus == Emun.CommandStatus.None)
            //{
            //    return false;
            //}
            return true;
        }
        

        //执行
        public virtual void Execute(BaseConnection Connection)
        {
            if (Connection != null)
            {
                try
                {
                    Connection.Execute(new BaseCommand[] { this });
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {

                }
            }
        }

        public virtual string GetData(BaseConnection Connection)
        {
            System.Data.DataSet dataset = null;
            string content = string.Empty;
            if (Connection != null)
            {
                try
                {
                    dataset = Connection.GetDataSet(new BaseCommand[] { this });
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {

                }

                using (Stream stream = new MemoryStream())
                {
                    dataset.WriteXml(stream);

                    stream.Position = 0;

                    using (StreamReader reader = new StreamReader(stream))
                    {
                        
                        content = reader.ReadToEnd();
                    }
                }
            }
            return content;
        }

        //回滚
        public virtual void Rollback(BaseConnection Connection)
        {
            if (Connection != null)
            {
                try
                {
                    Connection.Rollback(new BaseCommand[] { this });
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                }
            }
        }
        //释放资源
        public abstract void Dispose();

        public override string ToString()
        {
            return this.sentence;
        }


    }
}
