namespace CMS.Common.Utility.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Reflection;
    using System.Xml;
    using CMS.Interface.Model;
    using CMS.Common.Model;
    using System.Data.Linq.Mapping;

    public abstract class BaseResolver:IDisposable
    {
        protected Dictionary<string, string> supportModels = null;

        protected const string modleAssembly = "CMS.Common.Model";

        public BaseResolver()
        {
            this.Init();
        }

        protected virtual void Init()
        {
            Assembly assembly = Assembly.Load(modleAssembly);

            if (assembly == null) throw new Exception("Load assembly file failed!");

            Type[] types = assembly.GetTypes();

            this.supportModels = new Dictionary<string, string>(types.Length);

            foreach (Type type in types)
            {
                if (!type.IsAbstract && type.IsClass)
                {
                    if (!this.supportModels.ContainsKey(type.Name))
                    {
                        this.supportModels[type.Name] = type.FullName;
                    }
                }
            }
        }

        public abstract string Serialize(IModel Model);

        public abstract string Serialize<T>(T Model) where T : class,IModel;

        public abstract string SerializeAll(ICollection<IModel> ModelCollection);

        public abstract IModel DeSerialize(string Content, Type ModelType);

        public abstract T DeSerialize<T>(string Content, T ModelType) where T : class, IModel;

        public abstract T DeSerialize<T>(string Content) where T :class, IModel;

        public abstract ICollection<T> DeSerializeAll<T>(string Content) where T :class, IModel;

        protected virtual bool IsClass(PropertyInfo Property)
        {
            if (Property.GetType().IsClass || Property.PropertyType == typeof(string))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected virtual bool IsGeneric(PropertyInfo Property)
        {
            return Property.GetType().IsGenericType;
        }

        protected virtual Type GetPropertyType(PropertyInfo Property)
        {
            return Property.PropertyType;
        }

        protected bool IsString(PropertyInfo Property)
        {
            return Property.PropertyType == typeof(string) ? true : false;
        }

        protected bool IsGUID(PropertyInfo Property)
        {
            return Property.PropertyType == typeof(Guid) ? true : false;
        }

        protected bool IsDataTime(PropertyInfo Property)
        {
            return Property.PropertyType == typeof(DateTime) ? true : false;
        }

        protected bool IsInt(PropertyInfo Property)
        {
            return Property.PropertyType == typeof(int) || Property.PropertyType == typeof(Int32) || Property.PropertyType == typeof(Int64) ? true : false;
        }

        protected bool IsDecimal(PropertyInfo Property)
        {
            return Property.PropertyType == typeof(decimal) ? true : false;
        }

        protected virtual string GetTableNameByModel(IModel Model)
        {
            Type type = Model.GetType();

            return GetTableNameByModel(type);
        }
        protected virtual string GetTableNameByModel(Type ModelType)
        {
            Model.Attribute.ModelTableAttribute attribute = null;
            if(ModelType.GetCustomAttributes(typeof(Model.Attribute.ModelTableAttribute),true).Length > 0)
            {
                attribute = ModelType.GetCustomAttributes(typeof(Model.Attribute.ModelTableAttribute), true)[0] as Model.Attribute.ModelTableAttribute;
            }

            return attribute == null ? string.Empty : attribute.Name;
        }


        protected bool IsSupported(IModel Model)
        {
            return IsSupported(Model.GetType());
        }

        protected bool IsSupported(Type ModelType)
        {
            return IsSupported(ModelType.Name);
        }

        protected bool IsSupported(string ModleName)
        {
            if (!this.supportModels.ContainsKey(ModleName))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Dispose()
        {
           
        }
    }
}
