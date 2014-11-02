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
    /// <summary>
    /// 代表xml格式结果集类
    /// </summary>
    public class XMLResult:Base.ActionResultBase
    {
        private Utility.Base.BaseResolver resolver = null;

        private XmlDocument doc = null;

        /// <summary>
        /// 输出xml格式文档
        /// </summary>
        public XmlDocument Output
        {
            get
            {
                if (string.IsNullOrEmpty(this.Result))
                {
                    throw new Exception();
                }
                try
                {
                    doc.LoadXml(this.Result);
                }
                catch { }

                return doc;
            }
        }

        public XMLResult(IModel Model):base(Model)
        {
            this.doc = new XmlDocument();
        }

        public override void GetResult()
        {
            base.GetResult();

            this.Result = this.Model == null ? string.Empty : CMS.Common.Utility.Core.Reflector.ModelReflector.GetFullyInfoByModel(this.Model);
        }
    }
}
