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

    public class XMLCollectionResults:Base.ActionResultCollectionBase<XMLResult>
    {
        private XmlDocument doc = null;

        public XMLCollectionResults(XMLResult[] Results)
            : base()
        {
            this.doc = new XmlDocument();
            if(Results != null && Results.Length > 0)
                this.actionResultCollection.AddRange(Results);

        }

        public XMLCollectionResults()
            : this(null)
        {
        }

        public override string GetContentResults()
        {
            if (this.Count == 0) return string.Empty;

            foreach (XMLResult result in this.actionResultCollection)
            {
                result.GetResult();

                doc.AppendChild(result.Output);
            }
            return doc.InnerXml;
        }

        public override ICollection<IModel> GetModelResults()
        {
            ICollection<IModel> modelCollection = new List<IModel>();

            foreach (XMLResult result in this.actionResultCollection)
            {
                modelCollection.Add(result.Model);
            }

            return modelCollection;
        }
    }
}
