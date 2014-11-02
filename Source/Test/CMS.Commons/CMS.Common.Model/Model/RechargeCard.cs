namespace CMS.Common.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CMS.Common.Model.Emun.Card;
    using CMS.Common.Model.Attribute;

    /// <summary>
    /// 充值卡
    /// </summary>
    [ModelTable(Name="CardDetail")]
    public class RechargeCard : CouponCard
    {
        /// <summary>
        /// 卡内金额
        /// </summary>
        [ModelColumn(Name="Balance")]
        public decimal Amount { get; set; }

        [ModelColumn(Name = "ActuallyBalance")]
        public decimal ActuallyAmount { get; set; }

        [ModelTable(Name = "CardDepositHistory")]
        [ModelColumn(ColumnType = typeof(CardDeposit), ForeignerKey = "GUID", PrimaryKey = "GUID")]
        public ICollection<CardDeposit> DepositHistory { get; set; }

        /// <summary>
        /// 积分
        /// </summary>
        //[ModelColumn(Name = "Points", ColumnType = typeof(decimal))]
        //public decimal Points { get; set; }

        public override void Exchange(Base.CardBase Card)
        {
            base.Exchange(Card);
        }
    }
}
