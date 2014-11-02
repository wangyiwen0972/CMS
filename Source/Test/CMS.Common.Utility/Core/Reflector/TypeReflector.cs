namespace CMS.Common.Utility.Core.Reflector
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Reflection;
    using System.Data.Linq.Mapping;
    using CMS.Interface.Model;
    using CMS.Common.Model;
    using CMS.Common.Model.Attribute;
    using System.Xml;

    public class TypeReflector
    {
        private  const string _formatRootNode = "<Model name='{0}'>{1}</Model>";
        private  const string _formatColumnsNode = "<Columns>{0}</Columns>";
        private const string _formatColumnNode = "<Column name='{0}' IsPrimaryKey='{1}' type='{2}'/>";
        private const string _formatColumnNodeLong = "<Column name='{0}' IsPrimaryKey='{1}' type='{2}' ForeignerKey='{3}' refer='{4}' display='{5}'/>";

        protected const string modleAssembly = "CMS.Common.Model";

        private static Dictionary<string, string> _modelDictionary = null;

        static TypeReflector()
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
            //_modelDictionary["Unit"] = "CMS.Common.Model.Unit";
            //_modelDictionary["Postion"] = "CMS.Common.Model.Postion";
            //_modelDictionary["UserStatus"] = "CMS.Common.Model.UserStatus";
            //_modelDictionary["Operator"] = "CMS.Common.Model.Operator";
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

        public static string GetColumnsByTypeTest(Type type)
        {
            if (!TypeReflector._checkModel(type))
            {
                throw new Exception("Not support corrent model!");
            }

            string tableName = (type.GetCustomAttributes(typeof(ModelTableAttribute),true)[0] as ModelTableAttribute).Name;

            string column = string.Empty;

            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                ModelColumnAttribute attribute = null;

                if (property.GetCustomAttributes(typeof(ModelColumnAttribute), true).Length > 0)
                {
                    attribute = property.GetCustomAttributes(typeof(ModelColumnAttribute), true)[0] as ModelColumnAttribute;
                }

                if (attribute == null || string.IsNullOrEmpty(attribute.Name)) continue;

                if (attribute != null)
                {
                    if (property.PropertyType == typeof(string))
                    {
                        string columnName = attribute.Name;
                        bool isPrimaryKey = attribute.IsPrimaryKey;
                        if (string.IsNullOrEmpty(attribute.ForeignerKey))
                        {
                            column += string.Format(_formatColumnNode, columnName, isPrimaryKey.ToString(), typeof(string).Name);
                        }
                        else
                        {
                            ModelTableAttribute referTable = property.GetCustomAttributes(typeof(ModelTableAttribute),true)[0] as ModelTableAttribute;
                            string referName = referTable.Name;
                            string referDisplay = referTable.Display;
                            column += string.Format(_formatColumnNodeLong, columnName, isPrimaryKey.ToString(), typeof(string).Name,attribute.ForeignerKey, referName,referDisplay);
                        }
                    }
                    else if (property.PropertyType == typeof(Guid))
                    {
                        string columnName = attribute.Name;
                        bool isPrimaryKey = attribute.IsPrimaryKey;
                        if (string.IsNullOrEmpty(attribute.ForeignerKey))
                        {
                            column += string.Format(_formatColumnNode, columnName, isPrimaryKey.ToString(), typeof(Guid).Name);
                        }
                        else
                        {
                            ModelTableAttribute referTable = property.GetCustomAttributes(typeof(ModelTableAttribute),true)[0] as ModelTableAttribute;
                            string referName = referTable.Name;
                            string referDisplay = referTable.Display;
                            column += string.Format(_formatColumnNodeLong, columnName, isPrimaryKey.ToString(), typeof(Guid).Name, attribute.ForeignerKey, referName, referDisplay);
                        }
                    }
                    else if (property.PropertyType == typeof(DateTime))
                    {
                        string columnName = attribute.Name;
                        bool isPrimaryKey = attribute.IsPrimaryKey;
                        if (string.IsNullOrEmpty(attribute.ForeignerKey))
                        {
                            column += string.Format(_formatColumnNode, columnName, isPrimaryKey.ToString(), typeof(DateTime).Name);
                        }
                        else
                        {
                            ModelTableAttribute referTable = property.GetCustomAttributes(typeof(ModelTableAttribute),true)[0] as ModelTableAttribute;
                            string referName = referTable.Name;
                            string referDisplay = referTable.Display;
                            column += string.Format(_formatColumnNodeLong, columnName, isPrimaryKey.ToString(), typeof(DateTime).Name, attribute.ForeignerKey, referName, referDisplay);
                        }
                        
                    }
                    else if (property.PropertyType == typeof(int))
                    {
                        string columnName = attribute.Name;
                        bool isPrimaryKey = attribute.IsPrimaryKey;
                        if (string.IsNullOrEmpty(attribute.ForeignerKey))
                        {
                            column += string.Format(_formatColumnNode, columnName, isPrimaryKey.ToString(), typeof(int).Name);
                        }
                        else
                        {
                            ModelTableAttribute referTable = property.GetCustomAttributes(typeof(ModelTableAttribute),true)[0] as ModelTableAttribute;
                            string referName = referTable.Name;
                            string referDisplay = referTable.Display;
                            column += string.Format(_formatColumnNodeLong, columnName, isPrimaryKey.ToString(), typeof(int).Name, attribute.ForeignerKey, referName, referDisplay);
                        }
                        
                    }
                    else
                    {
                        string columnName = attribute.Name;
                        bool isPrimaryKey = attribute.IsPrimaryKey;
                        if (string.IsNullOrEmpty(attribute.ForeignerKey))
                        {
                            column += string.Format(_formatColumnNode, columnName, isPrimaryKey.ToString(), attribute.ColumnType.Name);
                        }
                        else
                        {
                            ModelTableAttribute referTable = property.GetCustomAttributes(typeof(ModelTableAttribute),true)[0] as ModelTableAttribute;
                            string referName = referTable.Name;
                            string referDisplay = referTable.Display;
                            column += string.Format(_formatColumnNodeLong, columnName, isPrimaryKey.ToString(), attribute.ColumnType.Name, attribute.ForeignerKey, referName, referDisplay);
                        }
                        
                    }
                }
            }

            string columns = string.Format(_formatColumnsNode, column);

            return string.Format(_formatRootNode, tableName, columns);

        }

        public static string GetColumnsByType(Type type)
        {
            if (!TypeReflector._checkModel(type))
            {
                throw new Exception("Not support corrent model!");
            }

            string tableName = (type.GetCustomAttributes(typeof(ModelTableAttribute),true)[0] as ModelTableAttribute).Name;
            
            PropertyInfo[] properties = type.GetProperties();
            string column = string.Empty;
            foreach (PropertyInfo property in properties)
            {
                ModelColumnAttribute attribute = null;

                if (property.GetCustomAttributes(typeof(ModelColumnAttribute), true).Length > 0)
                {
                    attribute = property.GetCustomAttributes(typeof(ModelColumnAttribute), true)[0] as ModelColumnAttribute;
                }

                if (attribute == null || string.IsNullOrEmpty(attribute.Name)) continue;

                if (attribute != null)
                {
                    if (property.PropertyType == typeof(string) || property.PropertyType == typeof(bool))
                    {
                        string columnName = attribute.Name;
                        bool isPrimaryKey = attribute.IsPrimaryKey;
                        column += string.Format(_formatColumnNode, columnName, isPrimaryKey.ToString(),typeof(string).Name);
                    }
                    else if (property.PropertyType == typeof(Guid))
                    {
                        string columnName = attribute.Name;
                        bool isPrimaryKey = attribute.IsPrimaryKey;
                        column += string.Format(_formatColumnNode, columnName, isPrimaryKey.ToString(), typeof(Guid).Name);
                    }
                    else if (property.PropertyType == typeof(DateTime))
                    {
                        string columnName = attribute.Name;
                        bool isPrimaryKey = attribute.IsPrimaryKey;
                        column += string.Format(_formatColumnNode, columnName, isPrimaryKey.ToString(), typeof(DateTime).Name);
                    }
                    else if (property.PropertyType == typeof(int) || property.PropertyType == typeof(decimal))
                    {
                        string columnName = attribute.Name;
                        bool isPrimaryKey = attribute.IsPrimaryKey;
                        column += string.Format(_formatColumnNode, columnName, isPrimaryKey.ToString(), typeof(int).Name);
                    }
                    else if (property.PropertyType.GetInterface("CMS.Interface.Model.IModel") != null)
                    {
                        string columnName = attribute.Name;
                        bool isPrimaryKey = attribute.IsPrimaryKey;
                        column += string.Format(_formatColumnNode, columnName, isPrimaryKey.ToString(), typeof(Guid).Name);
                    }
                    
                }
            }
            string columns = string.Format(_formatColumnsNode, column);

            return string.Format(_formatRootNode, tableName, columns);
        }

        /// <summary>
        /// 验证模型是否合法
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns>返回True或者False</returns>
        private static bool _checkModel(Type type)
        {
            return string.IsNullOrEmpty(_modelDictionary[type.Name]) ? false : true;
        }
    }
}
