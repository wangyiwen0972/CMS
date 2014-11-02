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
    /// 优惠卡
    /// </summary>
    [ModelTable(Name="CardDetail")]
    public class CouponCard:CardBase
    {
        /// <summary>
        /// 折扣率
        /// </summary>
        [ModelTable(Name="CardType")]
        [ModelColumn(ForeignerKey="Discount",ColumnType= typeof(decimal))]
        public decimal Discount { get; set; }

        /// <summary>
        /// 开卡日期
        /// </summary>
        [ModelColumn(Name="StartDate",ColumnType=typeof(DateTime))]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// 到期日期
        /// </summary>
        [ModelColumn(Name="EndDate",ColumnType=typeof(DateTime))]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// 卡有效天数
        /// </summary>
        [ModelTable(Name="CardType")]
        [ModelColumn(ForeignerKey = "ValidDate", ColumnType = typeof(int))]
        public int ValidDate { get; set; }

        /// <summary>
        /// 适用范围
        /// </summary>
        public ICollection<DishType> UseScope { get; set; }

        public override void Exchange(CardBase Card)
        {
            throw new NotImplementedException();
        }
    }
}
