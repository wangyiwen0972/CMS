using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Common.Model.Emun
{
    /// <summary>
    /// 订单状态
    /// </summary>
    public enum OrderStatus
    {
        PreBooking,
        Booking,
        Booked,
        Completed
    }

    /// <summary>
    /// 打印方向
    /// </summary>
    public enum Direction
    {
        Horizontal,
        Vertical
    }
}
