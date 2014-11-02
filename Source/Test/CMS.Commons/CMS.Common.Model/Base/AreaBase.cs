using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Common.Model.Emun;

namespace CMS.Common.Model.Base
{
    public abstract class AreaBase
    {
        //区域名称
        public string Name;

        //区域所在楼层
        public int Floor;

        public int MaxTableCount;

        public ICollection<TableBase> TableCollection;

        public Base.UserBase Manager;

    }
}
