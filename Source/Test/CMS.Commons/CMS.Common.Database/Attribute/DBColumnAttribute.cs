namespace CMS.Common.Database.Attribute
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class DBColumnAttribute:Attribute
    {
        public string Name { get; private set; }

        public bool IsPrimaryKey { get; private set; }

        public string ForeignerKey { get; private set; }

        public Type ColumnType { get; private set; }

        public bool IsOrderby { get; private set; }

        public string Orderby { get; private set; }

        public DBColumnAttribute(string ColumnName, bool IsPrimaryKey, string ForeignerKey, Type ColumnType)
        {
            this.Name = ColumnName;
            this.IsPrimaryKey = IsPrimaryKey;
            this.ForeignerKey = ForeignerKey;
            this.ColumnType = ColumnType;
        }
        public DBColumnAttribute(string ColumnName)
            : this(ColumnName, false, string.Empty, typeof(string))
        {
        }

        public DBColumnAttribute(string ColumnName, bool IsPrimaryKey) : this(ColumnName, IsPrimaryKey,string.Empty,typeof(string)) { }

        public DBColumnAttribute(string ColumnName, bool IsPrimaryKey, string ForeignerKey) : this(ColumnName, IsPrimaryKey, ForeignerKey, typeof(string)) { }

    }
}
