using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Common.Model.Emun.Card
{
    public enum CardType
    {
        //打折卡
        DiscountCard,
        //会员卡
        VIPCard,
        //优惠券
        Coupon,
        //代金券
        Voucher,
        //充值卡
        RechargeCard,
        //临时
        TemporaryCard
    }

    public enum CardStatus
    {
        //遗失
        Lost,
        //损坏
        Broken,
        //激活状态
        Active,
        //未激活
        Inactive,
        //过期
        OverTime,
        //已注销
        Logout
    }
}
