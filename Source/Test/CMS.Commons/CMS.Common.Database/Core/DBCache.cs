namespace CMS.Common.Database.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CMS.Interface.Model;

    public class DBCache<T> : Base.BaseCache<T>, IEnumerable<T> where T : IModel
    {
        public override void Add(T Model)
        {
            lock (locker)
            {
                if (!this.dictModel.ContainsKey(Model.PrimaryGuids().ToString()))
                {
                    this.dictModel[Model.PrimaryGuids().ToString()] = new CMS.Common.Database.Base.BaseCache<T>.TCache(Model);
                }
                else
                {
                    this.Remove(Model);

                    this.Add(Model);
                }
            }
        }

        public override void AddRange(ICollection<T> ModelCollection)
        {
            foreach (T model in ModelCollection)
            {
                Add(model);
            }
        }

        public override void Remove(T Model)
        {
            lock (locker)
            {
                if (this.dictModel.ContainsKey(Model.PrimaryGuids().ToString()))
                {
                    this.dictModel.Remove(Model.PrimaryGuids().ToString());
                }
            }
        }

        public override void RemoveAt(int Index)
        {
            throw new NotImplementedException();
        }

        public override T Copy()
        {
            throw new NotImplementedException();
        }

        public override void Clear()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
