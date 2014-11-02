namespace CMS.Interface.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;



    public interface IAttributeEnumModel:IModel
    {
        Guid ID { get; set; }

        Guid AttributeGuid { get; set; }

        string EnumValue { get; set; }

        string EnumCode { get; set; }

        string Remark { get; set; }
    }
}
