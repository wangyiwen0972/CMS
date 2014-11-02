namespace CMS.Common.ViewResult.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CMS.Interface.Model;
    using System.Xml;
    using CMS.Common.Utility;

    public class ActionResultCollectionBase<T> : IEnumerable<T> where T : ActionResultBase
    {
        internal List<T> actionResultCollection = null;

        internal ActionResultCollectionBase()
        {
            this.actionResultCollection = new List<T>();
        }

        public T this[int index]
        {
            get 
            {
                if (this.actionResultCollection == null)
                {
                    throw new Exception("");
                }
                if (index < 0 || index >= this.actionResultCollection.Count)
                {
                    throw new IndexOutOfRangeException();
                }
                return this.actionResultCollection[index];
            }
        }

        public int Count
        {
            get { return actionResultCollection.Count; }
        }

        public void Add(T Result)
        {
            this.actionResultCollection.Add(Result);
        }

        public virtual string GetContentResults() 
        {
            string content = string.Empty;

            foreach (T result in actionResultCollection)
            {
                content += result.Result;
            }

            return content;
        }

        public virtual ICollection<IModel> GetModelResults()
        {
            ICollection<IModel> modelCollection = new List<IModel>();

            foreach (T result in this.actionResultCollection)
            {
                modelCollection.Add(result.Model);
            }
            return modelCollection;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return actionResultCollection.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return actionResultCollection.GetEnumerator();
        }
    }
}
