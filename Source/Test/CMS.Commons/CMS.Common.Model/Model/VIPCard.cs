namespace CMS.Common.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CMS.Common.Model.Base;
    using CMS.Common.Model.Attribute;
    /// <summary>
    /// 会员卡
    /// </summary>
    [ModelTable(Name="CardDetail")]
    public class VIPCard : CouponCard
    {
        
        /// <summary>
        /// 余额
        /// </summary>
        [ModelColumn(Name = "Balance", ColumnType = typeof(decimal))]
        public decimal Balance { get; set; }


        /// <summary>
        /// 积分
        /// </summary>
        [ModelColumn(Name = "Points", ColumnType = typeof(decimal))]
        public decimal Points { get; set; }
    }

    
}
