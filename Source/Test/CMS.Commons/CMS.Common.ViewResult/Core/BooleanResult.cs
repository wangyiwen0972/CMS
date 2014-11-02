namespace CMS.Common.ViewResult.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CMS.Interface.Model;

    public class BooleanResult : Base.ActionResultBase
    {
        private bool result = false;

        public BooleanResult(bool result)
            : base(null)
        {
            this.result = result;
        }

        public BooleanResult(IModel model, bool result):base(model)
        {
            this.result = result;
        }

        public override string Result
        {
            get
            {
                return result.ToString();
            }
            internal set
            {
                bool tmpResult = false;
                Boolean.TryParse(value, out tmpResult);
                base.Result = tmpResult.ToString();
            }
        }

        public override void GetResult()
        {
            Result = this.result.ToString();
        }

        
    }
}
