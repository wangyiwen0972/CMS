using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Common.Model.Emun;
using CMS.Interface.Model;

namespace CMS.Common.Model.Base
{
    public abstract class TableBase:IModel
    {
        public Guid ID;

        //所在区域
        public AreaBase Area;
        //餐台名称或号码
        public string Name;
        //开台时间
        public DateTime? OpenTime;
        //闭台时间
        public DateTime? CloseTime;
        //餐台状态
        public Emun.Table.TableStatus Status;
        //最大使用人数
        public int MaxPerson;
        //使用时间
        public TimeSpan? ServiceTime;


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
