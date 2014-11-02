namespace CMS.Common.ViewResult.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CMS.Interface.Model;
    using System.Xml;
    using CMS.Common.Utility;

    public class CollectionResult:Base.ActionResultBase
    {
        private ICollection<IModel> modelCollection;

        public CollectionResult(ICollection<IModel> ModelCollection) : base(null) { }

        public override string Result
        {
            get
            {
                return base.Result;
            }
            internal set
            {
                base.Result = value;
            }
        }

        public override IModel Model
        {
            get
            {
                return base.Model;
            }
            internal set
            {
                base.Model = value;
            }
        }

        public override void GetResult()
        {
            base.GetResult();
        }
    }
}
