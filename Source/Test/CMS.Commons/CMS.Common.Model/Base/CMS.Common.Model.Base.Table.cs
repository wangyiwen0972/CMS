using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Common.Model.Emun;

namespace CMS.Common.Model.Base
{
    public abstract class BaseTable
    {
        //所在区域
        public BaseArea Area;
        //餐台名称或号码
        public string Name;
        //开台时间
        public DateTime OpenTime;
        //闭台时间
        public DateTime CloseTime;
        //餐台状态
        public Emun.Table.TableStatus Status;

        public int MaxPerson;

    }
}
