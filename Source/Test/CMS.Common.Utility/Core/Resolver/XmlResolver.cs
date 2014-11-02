namespace CMS.Common.Utility.Core.Resolver
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Runtime.Serialization.Json;
    using System.Reflection;
    using CMS.Interface.Model;
    using System.Xml;
    using System.Data.Linq.Mapping;

    /// <summary>
    /// xml解析器
    /// </summary>
    public class XmlResolver:Base.BaseResolver
    {
        private const string MODELXPATH = "//Model[@name='{0}']";
        private const string COLUMNXPATH = "//Column[@name='{0}']";
        private const string VALUEXPATH = "./value";

        /// <summary>
        /// 序列化模型
        /// </summary>
        /// <param name="Model">模型借口</param>
        /// <returns>返回模型字符串</returns>
        public override string Serialize(IModel Model)
        {
            return "";
        }

        public override string Serialize<T>(T Model) 
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 反序列化单个模型
        /// </summary>
        /// <param name="Content">模型字符串</param>
        /// <param name="ModelType">模型的类型</param>
        /// <returns>返回模型实例</returns>
        public override IModel DeSerialize(string Content, Type ModelType)
        {
            XmlDocument doc = new XmlDocument();

            IModel model = null;

            try
            {
                //生成模型xml
                doc.LoadXml(Content);
            }
            catch (Exception)
            {
                throw;
            }
            //通过模型名称，检查是否支持该模型
            if (!this.supportModels.ContainsKey(ModelType.Name))
            {
                throw new Exception("Can't deserialize this type!");
            }
            else
            {
                //加载模型程序集
                Assembly assembly = Assembly.Load(Base.BaseResolver.modleAssembly);
                if (assembly != null)
                {
                    //创建指定模型实例
                    model = assembly.CreateInstance(this.supportModels[ModelType.Name]) as IModel;

                    Type imodelType = model.GetType();

                    Model.Attribute.ModelTableAttribute tableAttribute = imodelType.GetCustomAttributes(typeof(Model.Attribute.ModelTableAttribute),true)[0] as Model.Attribute.ModelTableAttribute;

                    //获取模型实例所有属性
                    PropertyInfo[] members = imodelType.GetProperties();
                    //通过模型xml，为该模型的所有属性赋值
                    foreach (PropertyInfo property in members)
                    {
                        bool isImodel = false;

                        Type type = property.PropertyType.GetInterface("CMS.Interface.Model.IModel");

                        isImodel = type == null ? false : true;

                        //检查属性是否为类
                        if (isImodel)
                        {
                            string xpath = string.Format(COLUMNXPATH, _getColumnName(property));

                            XmlNode node = doc.SelectSingleNode(xpath);

                            if (node == null) continue;

                            IModel subModel = this.DeSerialize(node.SelectSingleNode("Value").InnerXml, property.PropertyType);

                            property.SetValue(model, subModel,null);
                        }
                        else
                        {
                            //获取自定义属性
                            Model.Attribute.ModelColumnAttribute columnAttribute = null;

                            if( property.GetCustomAttributes(typeof(Model.Attribute.ModelColumnAttribute),true).Length > 0)
                            {
                                columnAttribute = property.GetCustomAttributes(typeof(Model.Attribute.ModelColumnAttribute), true)[0] as Model.Attribute.ModelColumnAttribute;
                            }
                            
                            if (columnAttribute == null)
                            {
                                continue;
                            }

                            string fieldName = columnAttribute.Name;

                            string xpath = string.Format("/Model[@name='{0}']/Columns/Column[@name='{1}']/Value", tableAttribute.Name, columnAttribute.Name);

                            if (property.PropertyType == typeof(string))
                            {
                                string value = doc.DocumentElement.SelectSingleNode(xpath).InnerText;
                                property.SetValue(model, value,null);
                            }
                            else if (property.PropertyType == typeof(int))
                            {
                                int value = 0;
                                int.TryParse(doc.DocumentElement.SelectSingleNode(xpath).InnerText, out value);
                                property.SetValue(model, value,null);
                            }
                            else if (property.PropertyType == typeof(Guid))
                            {
                                XmlNode node = doc.SelectSingleNode(xpath);

                                Guid value = new Guid(doc.SelectSingleNode(xpath).InnerText);
                                property.SetValue(model, value,null);
                            }
                            else if (property.PropertyType == typeof(DateTime))
                            {
                                DateTime value;
                                DateTime.TryParse(doc.DocumentElement.SelectSingleNode(xpath).InnerText, out value);
                                property.SetValue(model, value,null);
                            }
                            else if (property.PropertyType == typeof(decimal))
                            {
                                decimal value = decimal.MinValue;
                                decimal.TryParse(doc.DocumentElement.SelectSingleNode(xpath).InnerText, out value);
                                property.SetValue(model, value,null);
                            }

                        }            
                    }
                }
            }
            return model;
        }

        public override T DeSerialize<T>(string Content, T ModelType)
        {
            throw new NotImplementedException();
        }

        public override  ICollection<T> DeSerializeAll<T>(string Content)
        {
            try
            {
                Type type = typeof(T);
                string mainModelName = type.Name;

                

                if (!this.supportModels.ContainsKey(mainModelName))
                {
                }

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(Content);

                //加载模型程序集
                Assembly assembly = Assembly.Load(Base.BaseResolver.modleAssembly);
                if (assembly == null)
                {
                }

                XmlNode mainModelNode = doc.SelectSingleNode(string.Format("/Model[@name='{0}']", mainModelName));

                XmlNodeList subModelNodes = mainModelNode.SelectNodes("./Model");

                if (subModelNodes == null || subModelNodes.Count == 0)
                {
                    T model = assembly.CreateInstance(this.supportModels[type.Name]) as T;
                    
                }

                

            }
            catch
            {
            }
            return null;
        }

        public override T DeSerialize<T>(string Content)
        {
            throw new NotImplementedException();
        }



        public override string SerializeAll(ICollection<IModel> ModelCollection)
        {
            throw new NotImplementedException();
        }


        private string _getColumnName(PropertyInfo property)
        {
            Model.Attribute.ModelColumnAttribute attribute = null;
            if(property.GetCustomAttributes(typeof(Model.Attribute.ModelColumnAttribute), true).Length > 0)
            {
                attribute = property.GetCustomAttributes(typeof(Model.Attribute.ModelColumnAttribute), true)[0] as Model.Attribute.ModelColumnAttribute;
            }

            return attribute == null ? string.Empty : attribute.Name;
        }
    }

    
}
