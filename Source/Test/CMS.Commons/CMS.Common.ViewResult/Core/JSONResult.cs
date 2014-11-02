namespace CMS.Common.ViewResult.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Runtime.Serialization.Json;
    using CMS.Interface.Model;
    using System.Xml;
    using CMS.Common.Utility.Core.Resolver;

    /// <summary>
    /// 代表JSON格式结果集
    /// </summary>
    public class JSONResult:Base.ActionResultBase
    {
        private JSONResolver resolver = null;

        public XMLResult ConvertToXmlResult()
        {
            return null;
        }

        public ContentResult ConvertToContentResult()
        {
            return null;
        }

        public JSONResult(IModel Model)
            : base(Model)
        {
        }

        public override void GetResult()
        {
            base.GetResult();

            using (resolver = new JSONResolver())
            {

            }
            
        }

    }
}
