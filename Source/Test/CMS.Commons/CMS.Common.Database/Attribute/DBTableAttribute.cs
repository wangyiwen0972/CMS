namespace CMS.Common.Database.Attribute
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field, Inherited= true)]
    public class DBTableAttribute:Attribute
    {
        public string Name { get; private set; }

        public string Display { get; private set; }

        public DBTableAttribute(string TableName, string DisplayName)
        {
            this.Name = TableName;
            this.Display = DisplayName;
        }
    }
}
