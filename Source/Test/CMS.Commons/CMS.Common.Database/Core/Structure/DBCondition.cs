using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMS.Common.Database.Core;

namespace CMS.Common.Database.Core.Structure
{
    public class DBConditionStructure
    {
        internal string columnName { get; private set; }
        internal string columnValue { get; private set; }
        internal Type columnType { get; private set; }
        internal CMS.Common.Database.Core.DBContext.DBOperator dbOperator { get; private set; }

        internal DBConditionStructure(string columnName, string columnValue, CMS.Common.Database.Core.DBContext.DBOperator dbOperator, Type columnType)
        {
            this.columnName = columnName;
            this.columnValue = columnValue;
            this.columnType = columnType;
            this.dbOperator = dbOperator;
        }
        internal DBConditionStructure(string columnName, string columnValue)
            : this(columnName, columnValue, CMS.Common.Database.Core.DBContext.DBOperator.Equal, typeof(string))
        {
        }
        internal DBConditionStructure(string columnName, string columnValue, Type columnType)
            : this(columnName, columnValue, CMS.Common.Database.Core.DBContext.DBOperator.Equal, columnType)
        {
        }

        public string AddConditionWithAnd(DBConditionStructure otherCondition)
        {
            return string.Format("({0} {1} {2})", this.ToString(), "and",  otherCondition.ToString());
        }

        public string AddConditionWithOr(DBConditionStructure otherCondition)
        {
            return string.Format("({0} {1} {2})", this.ToString(), "or", otherCondition.ToString());
        }

        public override string ToString()
        {
            string condString = string.Empty;

            if (!string.IsNullOrEmpty(columnName))
            {
                switch (columnType.Name)
                {
                    case "int":
                    case "decimal":
                        {
                            condString = string.Format("{0} {1} {2}", columnName, DBContext.ConvertDBOperatorToString(dbOperator), columnValue);
                            break;
                        }
                    case "string":
                    default:
                        {
                            condString = string.Format("{0} {1} '{1}'", DBContext.ConvertDBOperatorToString(dbOperator), columnValue);
                            break;
                        }
                }
            }

            return condString;
        }

    }
}
