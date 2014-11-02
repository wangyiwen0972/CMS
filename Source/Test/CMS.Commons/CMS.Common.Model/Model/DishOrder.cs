using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Common.Model.Emun;
using CMS.Interface.Model;

namespace CMS.Common.Model
{
    public class DishOrder:IModel
    {
        public Guid ID { get; set; }

        /// <summary>
        /// 生成订单时间
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// 顾客人数
        /// </summary>
        public int CustomerCount { get; set; }

        /// <summary>
        /// 顾客信息
        /// </summary>
        public Customer Client { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNo { get; set; }

        /// <summary>
        /// 预定号
        /// </summary>
        public string PreOrderNo { get; set; }

        /// <summary>
        /// 餐桌
        /// </summary>
        public DishTable DishTable { get; set; }

        /// <summary>
        /// 开单员
        /// </summary>
        public Employee Staff { get; set; }

        /// <summary>
        /// 菜品列表
        /// </summary>
        public ICollection<Dish> DishCollection { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public OrderStatus Status;

        public static bool operator ==(DishOrder src, DishOrder dest)
        {
            return false;
        }

        public static bool operator !=(DishOrder src, DishOrder dest)
        {
            return false;
        }


        public int Compare(IModel Model)
        {
            throw new NotImplementedException();
        }

        public bool IsEqual(IModel Model)
        {
            throw new NotImplementedException();
        }




        public Guid PrimaryGuids()
        {
            throw new NotImplementedException();
        }


        public string PrimaryName()
        {
            throw new NotImplementedException();
        }
    }

    
}
