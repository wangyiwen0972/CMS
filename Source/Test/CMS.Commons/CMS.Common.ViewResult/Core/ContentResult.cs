namespace CMS.Common.ViewResult.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CMS.Interface.Model;
    using System.Reflection;

    /// <summary>
    /// 代表字符串结果集
    /// </summary>
    public class ContentResult:Base.ActionResultBase
    {
        private StringBuilder result = null;

        private const string CONTENT_FORMAT = "{0}: {1} \n\r";

        public override string Result
        {
            get { return result.ToString(); }
        }

        public ContentResult(IModel Model)
            : base(Model)
        {
        }

        public ContentResult(string content)
            : base(null)
        {
            this.result = new StringBuilder(content);
        }

        public override void GetResult() 
        {
            if (this.Model == null &&  string.IsNullOrEmpty(Result)) { throw new NullReferenceException(); }

            if (this.Model == null) { return; }

            Type modelType = this.Model.GetType();

            this.result = new StringBuilder();

            foreach (PropertyInfo prop in modelType.GetProperties())
            {
                this.result.AppendFormat(CONTENT_FORMAT, prop.Name, prop.GetValue(this.Model,null));
            }
        }

    }
}
