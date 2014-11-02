
namespace CMS.Common.Utility.Core.Resolver
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CMS.Common.Model;
    using CMS.Interface.Model;
    using System.Xml;
    using System.Reflection;
    using System.Data;
    using System.IO;
    using System.Data.Linq.Mapping;

    public class DatasetResolver:Base.BaseResolver
    {

        #region public method
        public override string Serialize(Interface.Model.IModel Model)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 反序列化模型
        /// </summary>
        /// <param name="Content">模型内容（由Dataset生成的xml字符串）</param>
        /// <param name="ModelType">模型类型</param>
        /// <returns>返回模型</returns>
        public override Interface.Model.IModel DeSerialize(string Content, Type ModelType)
        {
            IModel model = null;

            //查询是否支持该模型
            if (!IsSupported(ModelType))
            {
                throw new Exception("Not support");
            }
            //获取Dataset数据集
            DataSet ds = this.GetDataByContent(Content);
            //加载模型程序集
            Assembly assembly = Assembly.Load(Base.BaseResolver.modleAssembly);

            //若程序集存在
            if (assembly != null)
            {
                //创建指定模型实例
                model = assembly.CreateInstance(this.supportModels[ModelType.Name]) as IModel;

                Type imodelType = model.GetType();

                //获取模型的表名
                if (string.IsNullOrEmpty(this.GetTableNameByModel(imodelType)))
                {
                    throw new Exception("");
                }
                //从数据集中获取模型的数据表
                DataTable dt = ds.Tables[this.GetTableNameByModel(imodelType)];

                foreach (DataRow dr in dt.Rows)
                {

                    //获取模型实例所有属性
                    PropertyInfo[] members = imodelType.GetProperties();
                    //通过模型xml，为该模型的所有属性赋值

                    foreach (PropertyInfo property in members)
                    {
                        //检查属性是否为类
                        if (IsClass(property))
                        {
                            //IModel subModel = assembly.CreateInstance(property.GetType().FullName) as IModel;

                            //subModel = this.DeSerialize(Content, property.GetType());

                            //if (subModel != null)
                            //{
                            //    property.SetValue(model, subModel);
                            //}
                        }
                        //如为集合
                        else if (property.GetType().IsGenericType)
                        {
                            //Type subModelType = property.GetType().GetGenericTypeDefinition();
                            //ICollection<IModel> modelCollection = this.DeSerializeAll(Content, subModelType);
                            //if (modelCollection != null)
                            //{
                            //    property.SetValue(model, modelCollection);
                            //}
                        }
                        else
                        {
                            Model.Attribute.ModelColumnAttribute columnAttribute = null;
                            if(property.GetCustomAttributes(typeof(Model.Attribute.ModelColumnAttribute), true).Length > 0)
                            {
                                columnAttribute = property.GetCustomAttributes(typeof(Model.Attribute.ModelColumnAttribute), true)[0] as Model.Attribute.ModelColumnAttribute;
                            }

                            if (property.PropertyType == typeof(string))
                            {
                                string value = dr[columnAttribute.Name].ToString();
                                property.SetValue(model, value, null);
                            }
                            else if (property.PropertyType == typeof(int))
                            {
                                int value = 0;
                                int.TryParse(dr[columnAttribute.Name].ToString(), out value);
                                property.SetValue(model, value, null);
                            }
                            else if (property.PropertyType == typeof(Guid))
                            {
                                Guid value = new Guid(dr[columnAttribute.Name].ToString());
                                property.SetValue(model, value, null);
                            }
                            else if (property.PropertyType == typeof(DateTime))
                            {
                                DateTime value;
                                DateTime.TryParse(dr[columnAttribute.Name].ToString(), out value);
                                property.SetValue(model, value, null);
                            }
                            else if (property.PropertyType == typeof(decimal))
                            {
                                decimal value = decimal.MinValue;
                                decimal.TryParse(dr[columnAttribute.Name].ToString(), out value);
                                property.SetValue(model, value, null);
                            }
                        }
                    }
                }

            }

            return model;
        }

        public override T DeSerialize<T>(string Content, T ModelType)
        {
            Type type = ModelType.GetType();

            return DeSerialize(Content, type) as T;
        }

        public override T DeSerialize<T>(string Content)
        {
            
            throw new NotImplementedException();
        }

        public override ICollection<T> DeSerializeAll<T>(string Content)
        {
            DataSet ds = this.GetDataByContent(Content);

            ICollection<T> modelMainCollection = new List<T>();

            Type type = typeof(T);

            if (ds == null || ds.Tables.Count < 1) return modelMainCollection;

            //foreach (DataTable dt in ds.Tables)
            //{
                string tableName = ds.Tables[0].TableName;

                if (!IsSupported(type.Name))
                {
                    return null;
                }

                Assembly assembly = Assembly.Load(Base.BaseResolver.modleAssembly);

                if (assembly != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        T model = assembly.CreateInstance(this.supportModels[type.Name]) as T;

                        Type imodelType = model.GetType();

                        PropertyInfo[] members = imodelType.GetProperties();
                        //通过模型xml，为该模型的所有属性赋值

                        foreach (PropertyInfo property in members)
                        {
                            //检查属性是否为类
                            if (IsClass(property))
                            {
                                //IModel subModel = assembly.CreateInstance(property.PropertyType.FullName) as IModel;

                                //subModel = this.DeSerialize(Content, property.PropertyType);

                                //if (subModel != null)
                                //{
                                //    property.SetValue(model, subModel);
                                //}
                            }
                            else if (property.PropertyType.IsGenericType)
                            {
                                //Model.Attribute.ModelColumnAttribute columnAttribute = property.GetCustomAttribute(typeof(Model.Attribute.ModelColumnAttribute)) as Model.Attribute.ModelColumnAttribute;

                                //Type subModelType = columnAttribute.ColumnType;
                                //ICollection<IModel> modelCollection = this.DeSerializeAll(Content, subModelType);
                                //if (modelCollection != null)
                                //{
                                //    property.SetValue(model, modelCollection);
                                //}
                            }
                            else
                            {
                                Model.Attribute.ModelColumnAttribute columnAttribute = null;
                                if(property.GetCustomAttributes(typeof(Model.Attribute.ModelColumnAttribute),true).Length > 0)
                                {
                                    columnAttribute = property.GetCustomAttributes(typeof(Model.Attribute.ModelColumnAttribute), true)[0] as Model.Attribute.ModelColumnAttribute;
                                }

                                if (columnAttribute == null || string.IsNullOrEmpty(columnAttribute.Name)) continue;

                                if (columnAttribute == null) continue;

                                if (property.PropertyType == typeof(string))
                                {
                                    string value = dr[columnAttribute.Name].ToString();
                                    property.SetValue(model, value, null);
                                }
                                else if (property.PropertyType == typeof(int))
                                {
                                    int value = 0;
                                    int.TryParse(dr[columnAttribute.Name].ToString(), out value);
                                    property.SetValue(model, value, null);
                                }
                                else if (property.PropertyType == typeof(Guid))
                                {
                                    Guid value = new Guid(dr[columnAttribute.Name].ToString());
                                    property.SetValue(model, value, null);
                                }
                                else if (property.PropertyType == typeof(DateTime))
                                {
                                    DateTime value;
                                    DateTime.TryParse(dr[columnAttribute.Name].ToString(), out value);
                                    property.SetValue(model, value, null);
                                }
                                else if (property.PropertyType == typeof(decimal))
                                {
                                    decimal value = decimal.MinValue;
                                    decimal.TryParse(dr[columnAttribute.Name].ToString(), out value);
                                    property.SetValue(model, value, null);
                                }
                                else if (property.PropertyType == typeof(bool))
                                {
                                    bool value = false;
                                    bool.TryParse(dr[columnAttribute.Name].ToString(), out value);
                                    property.SetValue(model, value, null);
                                }

                            }
                        }
                        modelMainCollection.Add(model);
                    }
                }

            //}

            return modelMainCollection;
        }

        /// <summary>
        /// 反序列化指定模型（多条）
        /// </summary>
        /// <param name="Content">数据集字符串</param>
        /// <param name="ModelType">模型类型</param>
        /// <returns></returns>
        public ICollection<IModel> DeSerializeAll(string Content, Type ModelType)
        {
            ICollection<IModel> modelCollection = new List<IModel>();

            if (!IsSupported(ModelType))
            {
                throw new Exception("Not support");
            }

            DataSet ds = GetDataByContent(Content);

            if (ds.Tables.Count == 0)
            {
                return modelCollection;
            }

            Assembly assembly = Assembly.Load(Base.BaseResolver.modleAssembly);

            if (assembly != null)
            {
                string tableName = this.GetTableNameByModel(ModelType);

                foreach (DataRow dr in ds.Tables[tableName].Rows)
                {
                    IModel model = assembly.CreateInstance(this.supportModels[ModelType.Name]) as IModel;

                    foreach (PropertyInfo property in ModelType.GetProperties())
                    {
                        if (IsClass(property))
                        {
                            //IModel subModel = assembly.CreateInstance(property.PropertyType.FullName) as IModel;

                            //subModel = this.DeSerialize(Content, property.PropertyType);

                            //if (subModel != null)
                            //{
                            //    property.SetValue(model, subModel);
                            //}
                        }
                        else if (IsGeneric(property))
                        {
                            //Type subModelType = property.GetType().GetGenericTypeDefinition();
                            //ICollection<IModel> submodelCollection = this.DeSerializeAll(Content, subModelType);
                            //if (submodelCollection != null)
                            //{
                            //    property.SetValue(model, submodelCollection);
                            //}
                        }
                        else
                        {
                            Model.Attribute.ModelColumnAttribute columnAttribute = null;
                            
                            if(property.GetCustomAttributes(typeof(Model.Attribute.ModelColumnAttribute), true).Length > 0)
                            {
                                columnAttribute = property.GetCustomAttributes(typeof(Model.Attribute.ModelColumnAttribute), true)[0] as Model.Attribute.ModelColumnAttribute;
                            }

                            if (this.IsString(property))
                            {
                                string value = dr[columnAttribute.Name].ToString();
                                property.SetValue(model, value, null);
                            }
                            else if (this.IsInt(property))
                            {
                                int value = 0;
                                int.TryParse(dr[columnAttribute.Name].ToString(), out value);
                                property.SetValue(model, value, null);
                            }
                            else if (this.IsGUID(property))
                            {
                                Guid value = new Guid(dr[columnAttribute.Name].ToString());
                                property.SetValue(model, value, null);
                            }
                            else if (IsDataTime(property))
                            {
                                DateTime value;
                                DateTime.TryParse(dr[columnAttribute.Name].ToString(), out value);
                                property.SetValue(model, value, null);
                            }
                            else if (IsDecimal(property))
                            {
                                decimal value = decimal.MinValue;
                                decimal.TryParse(dr[columnAttribute.Name].ToString(), out value);
                                property.SetValue(model, value, null);
                            }
                        }
                    }
                    modelCollection.Add(model);
                }
            }

            return modelCollection;
        }
        #endregion

        #region private method
        private DataSet GetDataByContent(string content)
        {
            DataSet ds = new DataSet();
            try
            {
                XmlDocument doc = new XmlDocument();

                doc.LoadXml(content);

                using (Stream stream = new MemoryStream(ASCIIEncoding.UTF32.GetBytes(doc.InnerXml)))
                {
                    ds.ReadXml(stream, XmlReadMode.Auto);
                }
            }
            catch
            {
            }

            return ds;
        }

        protected override bool IsClass(PropertyInfo Property)
        {
            if (Property.PropertyType.GetInterface("CMS.Interface.Model.IModel") !=  null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        public override string Serialize<T>(T Model)
        {
            throw new NotImplementedException();
        }

        public override string SerializeAll(ICollection<IModel> ModelCollection)
        {
            throw new NotImplementedException();
        }

        public string SerializeAll<T>(ICollection<T> ModelCollection)
        {
            return string.Empty;
        }
    }
}
