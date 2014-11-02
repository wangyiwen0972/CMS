namespace CMS.Common.Model.Attribute
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field, Inherited= true)]
    public class ModelTableAttribute:Attribute
    {
        public string Name { get; set; }

        public string Display { get; set; }

        public ModelTableAttribute()
        {

        }
    }
}
