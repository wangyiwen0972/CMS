using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Interface.Model;
using CMS.Interface.Module;

namespace CMS.Common.ViewResult.Core
{
    /// <summary>
    /// 代表显示用户界面结果集
    /// </summary>
    public class UIResult:Base.ActionResultBase
    {
        public IModule Module
        {
            get;
            internal set;
        }
            

        public UIResult(IModel Model, IModule Module)
            : base(Model)
        {
        }
    }
}
