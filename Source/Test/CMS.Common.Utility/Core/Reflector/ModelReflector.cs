namespace CMS.Common.Utility.Core.Reflector
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using CMS.Common.Model;
    using CMS.Interface.Model;
    using System.Reflection;
    using System.Data.Linq.Mapping;

    /// <summary>
    /// 模型反射器
    /// </summary>
    public class ModelReflector
    {
        private  const string _formatRootNode = "<Model name='{0}'>{1}</Model>";
        private  const string _formatColumnsNode = "<Columns>{0}</Columns>";
        private  const string _formatColumnNode = "<Column name='{0}'>{1}</Column>";
        private  const string _formatValueNode = "<Value>{0}</Value>";
        private const string FORMATCOLUMNNODE = "<Column name='{0}' type='{1}' IsPrimaryKey='{2}'>{3}</Column>";

        protected const string modleAssembly = "CMS.Common.Model";

        private static Dictionary<string, string> _modelDictionary = null;

        static ModelReflector()
        {
            _modelDictionary = new Dictionary<string, string>();

            #region Add model types to dictionary
            //_modelDictionary["Dish"] = "CMS.Common.Model.Dish";
            //_modelDictionary["DishOrder"] = "CMS.Common.Model.DishOrder";
            //_modelDictionary["DishTable"] = "CMS.Common.Model.DishTable";
            //_modelDictionary["DishStyle"] = "CMS.Common.Model.DishStyle";
            //_modelDictionary["Employee"] = "CMS.Common.Model.Employee";
            //_modelDictionary["Invoice"] = "CMS.Common.Model.Invoice";
            //_modelDictionary["Recipe"] = "CMS.Common.Model.Recipe";
            //_modelDictionary["RechargeCard"] = "CMS.Common.Model.RechargeCard";
            //_modelDictionary["Customer"] = "CMS.Common.Model.Customer";
            //_modelDictionary["Department"] = "CMS.Common.Model.Department";
            //_modelDictionary["Customer"] = "CMS.Common.Model.Customer";
            //_modelDictionary["Unit"] = "CMS.Common.Model.Unit";
            //_modelDictionary["UserStatus"] = "CMS.Common.Model.UserStatus";
            //_modelDictionary["Operator"] = "CMS.Common.Model.Operator";
            //_modelDictionary["Postion"] = "CMS.Common.Model.Postion";
            //_modelDictionary["Right"] = "CMS.Common.Model.Right";
            //_modelDictionary["ShopHours"] = "CMS.Common.Model.ShopHours";
            //_modelDictionary["DishType"] = "CMS.Common.Model.DishType";
            //_modelDictionary["UnitType"] = "CMS.Common.Model.UnitType";
            //_modelDictionary["DishStatus"] = "CMS.Common.Model.DishStatus";
            //_modelDictionary["Entrance"] = "CMS.Common.Model.Entrance";
            //_modelDictionary["EntranceOrder"] = "CMS.Common.Model.EntranceOrder";
            //_modelDictionary["EntranceOrderDetail"] = "CMS.Common.Model.EntranceOrderDetail";
            //_modelDictionary["EntranceStatus"] = "CMS.Common.Model.EntranceStatus";
            #endregion

            Assembly assembly = Assembly.Load(modleAssembly);

            if (assembly == null) throw new Exception("Load assembly file failed!");

            Type[] types = assembly.GetTypes();

            _modelDictionary = new Dictionary<string, string>(types.Length);

            foreach (Type type in types)
            {
                if (!type.IsAbstract && type.IsClass)
                {
                    if (!_modelDictionary.ContainsKey(type.Name))
                    {
                        _modelDictionary[type.Name] = type.FullName;
                    }
                }
            }
        }

        /// <summary>
        /// 获取模型所有列
        /// </summary>
        /// <param name="Model">模型</param>
        /// <returns>返回模型字符串</returns>
        public static string GetColumnsByModel(IModel Model)
        {
            if (!ModelReflector._checkModel(Model))
            {
                throw new Exception("Not support corrent model!");
            }

            Type reflectType = Model.GetType();

            //获取该模型表名

            string tableName = ModelReflector._getTableName(reflectType);
            
            //获取该模型列名
            PropertyInfo[] properties = reflectType.GetProperties();

            if (properties != null && properties.Length > 0)
            {


                string columns = string.Empty;

                foreach (PropertyInfo property in properties)
                {
                    bool isColumn = string.IsNullOrEmpty(ModelReflector._getColumnName(property)) ? false : true;

                    if (!isColumn) continue;

                    bool isImodel = property.PropertyType.GetInterface("CMS.Interface.Model.IModel") == null ? false : true;

                    object obj = ModelReflector._getColumnValue(Model, property);

                    if (obj == null) continue;

                    if (property.PropertyType == typeof(string))
                    {
                        string value = obj.ToString();
                        columns += string.Format(ModelReflector.FORMATCOLUMNNODE, ModelReflector._getColumnName(property), typeof(string).Name, ModelReflector._checkIsPrimaryKey(property), value);
                    }
                    else if (property.PropertyType == typeof(Guid))
                    {
                        string value = obj.ToString();
                        columns += string.Format(ModelReflector.FORMATCOLUMNNODE, ModelReflector._getColumnName(property), typeof(Guid).Name, ModelReflector._checkIsPrimaryKey(property), value);
                    }
                    else if (property.PropertyType == typeof(DateTime))
                    {

                        string value = DateTime.Parse(obj.ToString()).ToString("yyyy-MM-dd hh:mm:ss");
                        columns += string.Format(ModelReflector.FORMATCOLUMNNODE, ModelReflector._getColumnName(property), typeof(DateTime).Name, ModelReflector._checkIsPrimaryKey(property), value);
                    }
                    else if (property.PropertyType == typeof(int))
                    {
                        string value = obj.ToString();
                        columns += string.Format(ModelReflector.FORMATCOLUMNNODE, ModelReflector._getColumnName(property), typeof(int).Name, ModelReflector._checkIsPrimaryKey(property), value);
                    }
                    else if (property.PropertyType == typeof(decimal))
                    {
                        string value = obj.ToString();
                        columns += string.Format(ModelReflector.FORMATCOLUMNNODE, ModelReflector._getColumnName(property), typeof(decimal).Name, ModelReflector._checkIsPrimaryKey(property), value);
                    }
                    else if (property.PropertyType == typeof(bool))
                    {
                        string value = obj.ToString();
                        columns += string.Format(ModelReflector.FORMATCOLUMNNODE, ModelReflector._getColumnName(property), typeof(bool).Name, ModelReflector._checkIsPrimaryKey(property), value);
                    }
                    else if (isImodel)
                    {
                        if (ModelReflector._getColumnValue(Model, property, true) == null)
                        {
                            continue;
                        }

                        string value = string.Empty;

                        value = ModelReflector._getColumnValue(Model, property, true).ToString();

                        columns += string.Format(ModelReflector.FORMATCOLUMNNODE, ModelReflector._getColumnName(property), typeof(Guid).Name, ModelReflector._checkIsPrimaryKey(property), value);
                    }
                }

                return string.Format(ModelReflector._formatRootNode, tableName, string.Format(ModelReflector._formatColumnsNode, columns));
            }
            else
            {
                throw new Exception("Fail to get properties for model");
            }
        }

        /// <summary>
        /// 获取模型所有列
        /// </summary>
        /// <param name="Model">模型</param>
        /// <returns>返回模型字符串</returns>
        public static string GetColumnsByModel(IAttributeEnumModel Model)
        {
            if (!ModelReflector._checkModel(Model))
            {
                throw new Exception("Not support corrent model!");
            }

            Type reflectType = Model.GetType();

            //获取该模型表名

            string tableName = ModelReflector._getTableName(reflectType);

            //获取该模型列名
            PropertyInfo[] properties = reflectType.GetProperties();

            if (properties != null && properties.Length > 0)
            {
                

                string columns = string.Empty;

                foreach (PropertyInfo property in properties)
                {
                    bool isImodel = property.PropertyType.GetInterface("CMS.Interface.Model.IModel") == null ? false : true; ;

                    if (property.PropertyType == typeof(string))
                    {
                        string value = ModelReflector._getColumnValue(Model, property) == null ? string.Empty : ModelReflector._getColumnValue(Model, property).ToString();
                        columns += string.Format(ModelReflector.FORMATCOLUMNNODE, ModelReflector._getColumnName(property),typeof(string).Name,ModelReflector._checkIsPrimaryKey(property), value);
                    }
                    else if (property.PropertyType == typeof(Guid))
                    {
                        string value = ModelReflector._getColumnValue(Model, property) == null ? Guid.Empty.ToString() : ModelReflector._getColumnValue(Model, property).ToString();
                        columns += string.Format(ModelReflector.FORMATCOLUMNNODE, ModelReflector._getColumnName(property), typeof(Guid).Name,ModelReflector._checkIsPrimaryKey(property), value);
                    }
                    else if (property.PropertyType == typeof(DateTime))
                    {
                        string value = ModelReflector._getColumnValue(Model, property).ToString();
                        columns += string.Format(ModelReflector.FORMATCOLUMNNODE, ModelReflector._getColumnName(property), typeof(DateTime).Name, ModelReflector._checkIsPrimaryKey(property),value);
                    }
                    else if (property.PropertyType == typeof(int))
                    {
                        string value = ModelReflector._getColumnValue(Model, property).ToString();
                        columns += string.Format(ModelReflector.FORMATCOLUMNNODE, ModelReflector._getColumnName(property), typeof(int).Name, ModelReflector._checkIsPrimaryKey(property),value);
                    }
                    else if (property.PropertyType == typeof(bool))
                    {
                        string value = ModelReflector._getColumnValue(Model, property).ToString();
                        columns += string.Format(ModelReflector.FORMATCOLUMNNODE, ModelReflector._getColumnName(property), typeof(bool).Name, ModelReflector._checkIsPrimaryKey(property), value);
                    }
                    else if (isImodel)
                    {
                        string value = ModelReflector._getColumnValue(Model, property,true).ToString();
                        columns += string.Format(ModelReflector.FORMATCOLUMNNODE, ModelReflector._getColumnName(property), typeof(Guid).Name,ModelReflector._checkIsPrimaryKey(property), value);
                    }
                }

                return string.Format(ModelReflector._formatRootNode, tableName, string.Format(ModelReflector._formatColumnsNode, columns));
            }
            else
            {
                throw new Exception("Fail to get properties for model");
            }
        }

        public static string GetFullyCollectionInfo<T>(ICollection<T> ModelCollection) where T: class,IModel
        {
            string root = "<root>{0}</root>";
            string temp = string.Empty;
            foreach (T model in ModelCollection)
            {
                temp += ModelReflector.GetFullyInfoByModel(model);
            }

            return string.Format(root, temp);
        }

        /// <summary>
        /// 获取模型实例详细信息
        /// </summary>
        /// <param name="Model">模型实例</param>
        /// <returns>返回模型字符串</returns>
        public static string GetFullyInfoByModel(IModel Model)
        {
            if (!ModelReflector._checkModel(Model))
            {
                throw new Exception("Not support corrent model!");
            }

            Type reflectType = Model.GetType();

            string tableName = ModelReflector._getTableName(reflectType);

            //Like this: <Model name=dish><Columns>{0}</Columns></Model>
            string sbInfo = string.Format(ModelReflector._formatRootNode,tableName,ModelReflector._formatColumnsNode);

            PropertyInfo[] properties = reflectType.GetProperties();

            if (properties != null && properties.Length > 0)
            {
                string columns = string.Empty;


                foreach (PropertyInfo property in properties)
                {
                    string value = string.Empty;

                    if (!_hasCustomAttribute(property))
                    {
                        continue;
                    }

                    //Like this: <Column name=guid><Value>{0}</Value></Column>
                    columns += string.Format(ModelReflector._formatColumnNode, ModelReflector._getColumnName(property),ModelReflector._formatValueNode);
                    object obj = ModelReflector._getColumnValue(Model, property);
                    if (obj is IModel)
                    {
                        value += ModelReflector.GetFullyInfoByModel(obj as IModel);
                    }
                    else
                    {
                        if (obj != null)
                        {
                            value  = obj.ToString();
                        }
                        else
                        {
                            value = "null";
                        }
                    }

                    columns = string.Format(columns, value);
                }
                sbInfo = string.Format(sbInfo, columns);
            }
            return sbInfo;
        }

        public static string GetFullyInfoByModel(IAttributeEnumModel Model)
        {
            string content = string.Empty;

            if (!ModelReflector._checkModel(Model))
            {
                throw new Exception("Not support corrent model!");
            }

            Type reflectType = Model.GetType();

            string tableName = ModelReflector._getTableName(reflectType);

            content = string.Format(ModelReflector._formatRootNode, tableName, ModelReflector._formatColumnsNode);

            PropertyInfo[] properties = reflectType.GetProperties();

            if (properties != null && properties.Length > 0)
            {
                string columns = string.Empty;

                foreach (PropertyInfo property in properties)
                {
                    string value = string.Empty;

                    if (!_hasCustomAttribute(property))
                    {
                        continue;
                    }

                    //Like this: <Column name=guid><Value>{0}</Value></Column>
                    columns += string.Format(ModelReflector._formatColumnNode, ModelReflector._getColumnName(property), ModelReflector._formatValueNode);
                    object obj = ModelReflector._getColumnValue(Model, property);
                    if (obj is IModel)
                    {
                        value += ModelReflector.GetFullyInfoByModel(obj as IModel);
                    }
                    else
                    {
                        if (obj != null)
                        {
                            value = obj.ToString();
                        }
                        else
                        {
                            value = "null";
                        }
                    }

                    columns = string.Format(columns, value);
                }
                content = string.Format(content, columns);
            }

            return content;
        }


        /// <summary>
        /// 验证模型是否合法
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns>返回True或者False</returns>
        private static bool _checkModel(IModel model)
        {
            Type reflectType = model.GetType();

            return string.IsNullOrEmpty(_modelDictionary[reflectType.Name]) ? false : true;
        }

        private static bool _checkIsPrimaryKey(FieldInfo property)
        {
            Model.Attribute.ModelColumnAttribute attribute = null;
            if(property.GetCustomAttributes(typeof(Model.Attribute.ModelColumnAttribute), true).Length > 0)
            {
                attribute = property.GetCustomAttributes(typeof(Model.Attribute.ModelColumnAttribute), true)[0] as Model.Attribute.ModelColumnAttribute;
            }
            if (attribute == null)
            {
                return false;
            }
            return attribute.IsPrimaryKey ? true : false;
        }

        private static bool _checkIsPrimaryKey(PropertyInfo property)
        {
            Model.Attribute.ModelColumnAttribute attribute = null;
            if(property.GetCustomAttributes(typeof(Model.Attribute.ModelColumnAttribute), true).Length > 0)
            {
                attribute = property.GetCustomAttributes(typeof(Model.Attribute.ModelColumnAttribute), true)[0] as Model.Attribute.ModelColumnAttribute;
            }
            if (attribute == null)
            {
                return false;
            }
            return attribute.IsPrimaryKey ? true : false;
        }

        private static bool _checkModel<T>(T model) where T : IModel
        {
            Type reflectType = model.GetType();

            return string.IsNullOrEmpty(_modelDictionary[reflectType.Name]) ? false : true;
        }

        private static bool _checkModel(IAttributeEnumModel model)
        {
            Type reflectType = model.GetType();

            return string.IsNullOrEmpty(_modelDictionary[reflectType.Name]) ? false : true;
        }

        private static string _getColumnName(FieldInfo property)
        {
            Model.Attribute.ModelColumnAttribute attribute = null;
            if(property.GetCustomAttributes(typeof(Model.Attribute.ModelColumnAttribute), true).Length > 0)
            {
                attribute = property.GetCustomAttributes(typeof(Model.Attribute.ModelColumnAttribute), true)[0] as Model.Attribute.ModelColumnAttribute;
            }

            return attribute == null ? string.Empty : attribute.Name;
        }

        private static string _getColumnName(PropertyInfo property)
        {
            Model.Attribute.ModelColumnAttribute attribute = null;
            if (property.GetCustomAttributes(typeof(Model.Attribute.ModelColumnAttribute), true).Length > 0)
            {
                attribute = property.GetCustomAttributes(typeof(Model.Attribute.ModelColumnAttribute), true)[0] as Model.Attribute.ModelColumnAttribute;
            }

            return attribute == null ? string.Empty : attribute.Name;
        }

        private static bool _hasCustomAttribute(FieldInfo feild)
        {
            object[] attribute = feild.GetCustomAttributes(true);

            return attribute != null && attribute.Length > 0 ? true : false;
        }

        private static bool _hasCustomAttribute(PropertyInfo feild)
        {
            object[] attribute = feild.GetCustomAttributes(true);

            return attribute.Length > 0 ? true : false;
        }

        private static string _getTableName(Type type)
        {
            Model.Attribute.ModelTableAttribute attribute = null;
            if (type.GetCustomAttributes(typeof(Model.Attribute.ModelTableAttribute), true).Length > 0)
            {
                attribute = type.GetCustomAttributes(typeof(Model.Attribute.ModelTableAttribute), true)[0] as Model.Attribute.ModelTableAttribute;
            }

            return attribute == null ? string.Empty : attribute.Name;
        }

        private static object _getColumnValue(IModel model, FieldInfo property)
        {
            object value = null;

            value = property.GetValue(model);

            return value;
        }

        private static object _getColumnValue(IModel model, PropertyInfo property)
        {
            object value = null;

            value = property.GetValue(model,null);

            return value;
        }

        private static object _getColumnValue(IAttributeEnumModel model, FieldInfo property)
        {
            object value = null;

            value = property.GetValue(model);

            return value;
        }

        private static object _getColumnValue(IAttributeEnumModel model, PropertyInfo property)
        {
            object value = null;

            value = property.GetValue(model,null);

            return value;
        }

        private static object _getColumnValue(IAttributeEnumModel model, PropertyInfo property,bool ischeck)
        {
            object value = null;

            Model.Attribute.ModelColumnAttribute attribute = null;
            if(property.GetCustomAttributes(typeof(Model.Attribute.ModelColumnAttribute), true).Length > 0)
            {
                attribute = property.GetCustomAttributes(typeof(Model.Attribute.ModelColumnAttribute), true) [0] as Model.Attribute.ModelColumnAttribute;
            }

            object subObject = property.GetValue(model,null);

            if (attribute != null && !string.IsNullOrEmpty(attribute.ForeignerKey))
            {
                string columnName = attribute.ForeignerKey;
                Type subType = subObject.GetType();
                PropertyInfo[] fields = subType.GetProperties();
                foreach (PropertyInfo field in fields)
                {
                    if (!string.IsNullOrEmpty(ModelReflector._getColumnName(field)))
                    {
                        if (ModelReflector._getColumnName(field) == columnName)
                        {
                            value = field.GetValue(subObject,null);
                            break;
                        }
                    }
                }
            }
            return value;
        }

        private static object _getColumnValue(IModel model, PropertyInfo property, bool ischeck)
        {
            object value = null;

            Model.Attribute.ModelColumnAttribute attribute = null;
            if (property.GetCustomAttributes(typeof(Model.Attribute.ModelColumnAttribute), true).Length > 0)
            {
                attribute = property.GetCustomAttributes(typeof(Model.Attribute.ModelColumnAttribute), true)[0] as Model.Attribute.ModelColumnAttribute;
            }
            object subObject = property.GetValue(model,null);
            if (subObject == null) return null;
            if (attribute != null && !string.IsNullOrEmpty(attribute.ForeignerKey))
            {
                string columnName = attribute.ForeignerKey;
                Type subType = subObject.GetType();
                PropertyInfo[] fields = subType.GetProperties();
                foreach (PropertyInfo field in fields)
                {
                    if (!string.IsNullOrEmpty(ModelReflector._getColumnName(field)))
                    {
                        if (ModelReflector._getColumnName(field).ToLower() == columnName.ToLower())
                        {
                            value = field.GetValue(subObject,null);
                            break;
                        }
                    }
                }
            }
            return value;
        }
        
    }
}
