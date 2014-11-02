namespace CMS.Common.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.Linq.Mapping;
    using CMS.Interface.Model;

    [Table(Name="Customer")]
    public class Customer:Base.UserBase
    {
        //积分
        [Column(Name = "Points")]
        public Int32 Points { get; set; }
    }
}
