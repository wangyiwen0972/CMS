namespace CMS.Common.Database.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using CMS.Interface.Model;


    /// <summary>
    /// 缓存基类
    /// </summary>
    public abstract class BaseCache<T> : IDisposable,IEnumerable<T> where T : IModel
    {
        protected Dictionary<string, TCache> dictModel = null;
        protected const int defaultInterval = 60000;

        protected long timerInterval = 100 * 60 * 5;
        //protected DateTime startTime;
        //protected DateTime endTime;

        protected object locker = new object();

        protected Timer timer = null;

        public int Interval
        {
            set;
            get;
        }

        public T this[Guid ID]
        {
            get 
            {
                if(dictModel!=null)
                {
                    foreach (KeyValuePair<string, TCache> key in dictModel)
                    {
                        Guid id = key.Value.Model.PrimaryGuids();
                        if (id.Equals(ID))
                        {
                            return key.Value.Model;
                        }
                    }
                }
                return default(T);
            }
        }

        public T this[string Name]
        {
            get
            {
                if (dictModel != null)
                {
                    foreach (KeyValuePair<string, TCache> key in dictModel)
                    {
                        string name = key.Value.Model.PrimaryName();
                        if (name.Equals(Name, StringComparison.InvariantCultureIgnoreCase))
                        {
                            return key.Value.Model;
                        }
                    }
                }
                return default(T);
            }
        }

        public BaseCache()
        {
            this.dictModel = new Dictionary<string, TCache>();
            this.timer = new Timer(new TimerCallback(CheckTCacheState),null,0,timerInterval);
        }

        protected void CheckTCacheState(object obj)
        {
            lock (locker)
            {
                if (this.dictModel == null || this.dictModel.Count == 0)
                {
                }
                else
                {
                    for (int i = 0; i < this.dictModel.Count; i++)
                    {
                        KeyValuePair<string, TCache> cache = this.dictModel.ElementAt(i);

                        TCache t = cache.Value;
                        if (this.IsTimeout(t))
                        {
                            this.dictModel.Remove(cache.Key);
                        }
                    }

                    //foreach (KeyValuePair<string, TCache> cache in this.dictModel)
                    //{
                    //    TCache t = cache.Value;
                    //    if (this.IsTimeout(t))
                    //    {
                    //        this.dictModel.Remove(cache.Key);
                    //    }
                    //}
                }
            }
        }

        public void Dispose()
        {
            if (dictModel != null)
            {
                dictModel.Clear();
            }

            dictModel = null;
        }

        public abstract void Add(T Model);

        public abstract void AddRange(ICollection<T> ModelCollection);

        public abstract void Remove(T Model);

        public abstract void RemoveAt(int Index);

        protected virtual bool IsTimeout(TCache tCache)
        {
            int interval = Interval == 0 ? defaultInterval : Interval;

            DateTime endTime = DateTime.Now;

            TimeSpan tSpan = endTime.Subtract(tCache.StartTime);

            return tSpan.TotalMilliseconds > interval ? true : false;
        }

        public virtual void Update(ICollection<T> ModelCollection)
        {
            foreach (T model in ModelCollection)
            {
                this.Add(model);
            }
        }

        public abstract T Copy();

        public abstract void Clear();

        public IEnumerator<T> GetEnumerator()
        {
            List<T> collection = new List<T>();

            foreach (KeyValuePair<string, TCache> key in this.dictModel)
            {
                collection.Add(key.Value.Model);
            }

            return collection.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public struct TCache
        {
            private T _model;

            public T Model
            {
                get { return _model; }
            }

            private DateTime _startTime;
            public DateTime StartTime
            {
                get { return _startTime; }
            }

            public TCache(T model)
            {
                this._model = model;
                this._startTime = DateTime.Now;
            }
        }
    }

    
}
