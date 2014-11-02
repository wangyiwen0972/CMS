namespace CMS.Common.Model.Attribute
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class ModelColumnAttribute:Attribute
    {
        public string Name { get; set; }

        public bool IsPrimaryKey { get; set; }

        public string ForeignerKey { get; set; }

        public Type ColumnType { get; set; }

        public string PrimaryKey { get; set; }

        public bool IsOrderby { get; set; }

        public string Orderby { get; set; }
        

        public ModelColumnAttribute():this(string.Empty,false,string.Empty,string.Empty, typeof(string)) { }

        public ModelColumnAttribute(string ColumnName, bool IsPrimaryKey, string PrimaryKey, string ForeignerKey, Type ColumnType)
        {
            this.Name = ColumnName;
            this.IsPrimaryKey = IsPrimaryKey;
            this.ForeignerKey = ForeignerKey;
            this.ColumnType = ColumnType;
            this.PrimaryKey = PrimaryKey;
        }
        public ModelColumnAttribute(string ColumnName)
            : this(ColumnName, false, string.Empty, string.Empty, typeof(string))
        {
        }

        public ModelColumnAttribute(string ColumnName, bool IsPrimaryKey) : this(ColumnName, IsPrimaryKey,string.Empty,string.Empty,typeof(string)) { }

        public ModelColumnAttribute(string ColumnName, bool IsPrimaryKey, string PrimaryKey, string ForeignerKey) : this(ColumnName, IsPrimaryKey, PrimaryKey,ForeignerKey, typeof(string)) { }

    }
}
