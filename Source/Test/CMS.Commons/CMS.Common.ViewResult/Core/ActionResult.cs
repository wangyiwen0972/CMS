namespace CMS.Common.ViewResult.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CMS.Interface.Model;


    /// <summary>
    /// 代表执行一个方法结果集
    /// </summary>
    public class ActionResult: Base.ActionResultBase
    {

        private Func<IModel,bool> action = null;

        private Func<IModel, IModel,bool> action1 = null;

        private IModel model1 = null;


        public ActionResult(IModel model, Func<IModel,bool> action)
            : base(model)
        {
            this.action = action;
        }

        public ActionResult(IModel model, IModel model1, Func<IModel,IModel,bool> action)
            : base(model)
        {
            this.action1 = action;
            this.model1 = model1;
        }

        public override void GetResult()
        {
            base.GetResult();

            if (this.action != null && this.Model != null)
            {
                this.Result = this.action(this.Model) ? "true" :"false";

                return;
            }
            if (this.action1 != null && this.Model == null && this.model1 == null)
            {
                bool success = this.action1(this.Model, this.model1);

                this.Result = success ? "true" : "false";

                return;
            }
        }
    }
}
