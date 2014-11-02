namespace CMS.Common.Database.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CMS.Common.Database.Base;
    using CMS.Common.Model;
    using CMS.Interface.Model;

    public class DBCacheManager
    {
        private Dictionary<string, Base.BaseCache<IModel>> dictionaryCache = null;

        public DBCacheManager()
        {
            this.dictionaryCache = new Dictionary<string, Base.BaseCache<IModel>>();
        }

        public Base.BaseCache<IModel> this[string ModelFullName]
        {
            get
            {
                if (!dictionaryCache.ContainsKey(ModelFullName))
                {
                    return null;
                }
                return dictionaryCache[ModelFullName];
            }
        }

        /// <summary>
        /// 获取缓存中的模型集合
        /// </summary>
        /// <param name="type">模型类型</param>
        /// <returns>模型集合</returns>
        public Base.BaseCache<IModel> this[Type type]
        {
            get
            {
                string ModelFullName = type.FullName;

                if (!dictionaryCache.ContainsKey(ModelFullName))
                {
                    return null;
                }
                return dictionaryCache[ModelFullName];
            }
        }

        /// <summary>
        /// 更新缓存
        /// </summary>
        /// <param name="Models">模型集合</param>
        public void UpdateCache<T>(ICollection<T> Models) where T :class, IModel
        {
            if (Models != null && Models.Count > 0)
            {
                Type type = typeof(T);

                if (!this.dictionaryCache.ContainsKey(type.Name))
                {
                    this.dictionaryCache[type.Name] = new DBCache<IModel>();
                }

                ICollection<IModel> tmpCollection = new List<IModel>();

                foreach (IModel model in Models)
                {
                    tmpCollection.Add(model);
                }

                this.dictionaryCache[type.Name].Update(tmpCollection);
            }
        }

        /// <summary>
        /// 更新缓存
        /// </summary>
        /// <typeparam name="T">模型类型参数</typeparam>
        /// <param name="Model">模型</param>
        public void UpdateCache<T>(T Model) where T : IModel
        {
            Type type = typeof(T);

            DBCache<IModel> cache = null;

            if (!this.dictionaryCache.ContainsKey(type.Name))
            {
                this.dictionaryCache[type.Name] = new DBCache<IModel>();
                this.dictionaryCache[type.Name].Add(Model);
            }
            else
            {
                cache = this.dictionaryCache[type.Name] as DBCache<IModel>;

                if (cache[Model.PrimaryGuids()] == null)
                {
                    cache.Add(Model);
                }
                else
                {
                    cache.Remove(cache[Model.PrimaryGuids()]);
                    cache.Add(Model);
                }
            }
        }

        public void DeleteCache<T>(T Model) where T : IModel
        {
            Type type = typeof(T);

            DBCache<IModel> cache = null;

            if (!this.dictionaryCache.ContainsKey(type.Name))
            {
                return;
            }
            else
            {
                cache = this.dictionaryCache[type.Name] as DBCache<IModel>;

                if (cache[Model.PrimaryGuids()] == null)
                {
                    return;
                }
                else
                {
                    cache.Remove(cache[Model.PrimaryGuids()]);
                }
            }
        }

    }
}
