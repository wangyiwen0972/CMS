namespace CMS.Common.Controller.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CMS.Common.ViewResult.Core;
    using CMS.Common.ViewResult.Base;
    using CMS.Common.Model;

    //餐台控制器
    public class DishTableController
    {
        private Model.DishTable dishTable = null;

        //开台
        public ActionResultBase Open()
        {
            return null;
        }

        public ActionResultBase Open(Customer Customer)
        {
            return null;
        }
        //关台
        public ActionResultBase Close()
        {
            return null;
        }
        //清理
        public ActionResultBase Clean()
        {
            return null;
        }
        //换台
        public ActionResultBase ReplaceTable(Model.DishTable oldTable, Model.DishTable newTable)
        {
            return null;
        }
    }
}
