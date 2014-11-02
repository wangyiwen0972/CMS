namespace CMS.Common.Database.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Reflection;
    using System.Xml;
    using System.Data;
    using System.Data.Common;
    using System.IO;
    using IModel = CMS.Interface.Model;
    using Utility = CMS.Common.Utility;
    using CMS.Common.Database.Core.Structure;

    /// <summary>
    /// 数据上下文类
    /// </summary>
    public class DBContext:Base.BaseContext
    {
        #region constructor
        public DBContext(string provider, string conn)
            : base(provider,conn)
        {
            
        }

        public DBContext()
            : base()
        {
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// 同步数据库
        /// </summary>
        /// <typeparam name="T">数据模型的类型</typeparam>
        /// <param name="type">数据模型</param>
        /// <returns>返回数据模型集合</returns>
        public override ICollection<T> Sync<T>(Type type)
        {
            ICollection<T> collection = base.Sync<T>(type);

            string fullname = type.FullName;

            Base.BaseCommand command = DBCommandFactory.CreateCommand(typeof(SelectCommand));

            string content = Utility.Core.Reflector.TypeReflector.GetColumnsByType(type);

            XmlDocument doc = new XmlDocument();

            if (!string.IsNullOrEmpty(content))
            {
                doc.LoadXml(content);
            }
            command.AppendColumns(doc);

            if (!command.Check())
            {
                throw new Exception("");
            }

            string returnContent = command.GetData(this.connection);

            if (returnContent  != "<NewDataSet />")
            {
                using (Utility.Core.Resolver.DatasetResolver resolver = new Utility.Core.Resolver.DatasetResolver())
                {
                    collection = resolver.DeSerializeAll<T>(returnContent);

                    XmlDocument xmlResult = new XmlDocument();

                    try
                    {
                        xmlResult.LoadXml(returnContent);
                    }
                    catch
                    {
                        return collection;
                    }

                    foreach (T model in collection)
                    {
                        CMS.Common.Model.Attribute.ModelTableAttribute tableAttribute = model.GetType().GetCustomAttributes(typeof(CMS.Common.Model.Attribute.ModelTableAttribute),true)[0] as Model.Attribute.ModelTableAttribute;

                        //获取子类型中的子类型
                        Type subType = model.GetType();
                        //创建子类型命令集合
                        List<Base.BaseCommand> subCommandCollection = new List<Base.BaseCommand>();

                        List<KeyValuePair<string, string>> primaryCollection = new List<KeyValuePair<string, string>>();
                        //获取类型的主键集
                        foreach (PropertyInfo property in subType.GetProperties())
                        {
                            CMS.Common.Model.Attribute.ModelColumnAttribute attribute = null;

                            if (property.GetCustomAttributes(typeof(CMS.Common.Model.Attribute.ModelColumnAttribute), true).Length > 0)
                            {
                                attribute = property.GetCustomAttributes(typeof(CMS.Common.Model.Attribute.ModelColumnAttribute), true)[0] as Model.Attribute.ModelColumnAttribute;
                            }

                            if (attribute != null && attribute.IsPrimaryKey)
                            {
                                string propertyName = attribute.Name;
                                string propertyValue = property.GetValue(model, null).ToString();

                                KeyValuePair<string, string> kvp = new KeyValuePair<string, string>(propertyName, propertyValue);

                                primaryCollection.Add(kvp);

                            }
                        }
                        //获取对象中的子对象
                        foreach (PropertyInfo property in subType.GetProperties())
                        {
                            if (property.PropertyType.GetInterface("CMS.Interface.Model.IModel") != null)
                            {
                                //SyncSubType(model, property.PropertyType);
                            }
                            else if (property.PropertyType.IsGenericType)
                            {
                                //#region 
                                ////明天调试这段
                                //CMS.Common.Model.Attribute.ModelTableAttribute subTableAttribute = property.GetCustomAttribute(typeof(CMS.Common.Model.Attribute.ModelTableAttribute)) as CMS.Common.Model.Attribute.ModelTableAttribute;

                                //CMS.Common.Model.Attribute.ModelColumnAttribute subColumnAttribute = property.GetCustomAttribute(typeof(CMS.Common.Model.Attribute.ModelColumnAttribute)) as CMS.Common.Model.Attribute.ModelColumnAttribute;

                                ////
                                //if (subColumnAttribute != null)
                                //{
                                //    Base.BaseCommand subCommand = DBCommandFactory.CreateCommand(typeof(SelectCommand));

                                //    string subContent = Utility.Core.Reflector.TypeReflector.GetColumnsByTypeTest(subColumnAttribute.ColumnType);

                                //    XmlDocument subDoc = new XmlDocument();
                                //    subDoc.LoadXml(subContent);

                                //    subCommand.AppendColumns(subDoc);

                                //    List<ConditionStructure> subConditionCollection = new List<ConditionStructure>();
                                //    if (!string.IsNullOrEmpty(subColumnAttribute.Name))
                                //    {
                                //        foreach (KeyValuePair<string, string> primary in primaryCollection)
                                //        {
                                //            string xpath = string.Format("/NewDataSet/{0}[{1}='{2}']/{3}", tableAttribute.Name, primary.Key, primary.Value, subColumnAttribute.Name);

                                //            XmlNode node = doc.SelectSingleNode(xpath);

                                //            if (node != null)
                                //            {
                                //                subConditionCollection.Add(new ConditionStructure(subColumnAttribute.ForeignerKey, node.InnerText, subColumnAttribute.ColumnType));
                                //            }
                                //        }
                                //    }
                                //    else
                                //    {
                                //        foreach (KeyValuePair<string, string> primary in primaryCollection)
                                //        {
                                //            subConditionCollection.Add(new ConditionStructure(subColumnAttribute.ForeignerKey, primary.Value, typeof(Guid)));
                                //        }
                                //    }
                                //    subCommand.AppendWhereCommand(createConditionForCommand(subConditionCollection));
                                //    string subResult = subCommand.GetData(this.connection);

                                //    ICollection<IModel.IModel> subTypeCollection = resolver.DeSerializeAll(subResult, subColumnAttribute.ColumnType);
                                    
                                //    property.SetValue(model, subTypeCollection);
                                //}
                            }
                        }
                    }

                    if (collection != null && collection.Count > 0)
                    {
                        dbCache.UpdateCache(collection);
                    }
                }

                return collection;
            }
            return null;
        }

        public override void SyncSubTypeCollection<T>(IModel.IModel model)
        {
            string fullname = typeof(T).FullName;

            Type modelType = model.GetType();

            PropertyInfo[] properties = modelType.GetProperties();

            List<KeyValuePair<string, string>> primaryCollection = new List<KeyValuePair<string, string>>();
            //获取类型的主键集
            foreach (PropertyInfo property in properties)
            {
                CMS.Common.Model.Attribute.ModelColumnAttribute attribute = null;

                if (property.GetCustomAttributes(typeof(CMS.Common.Model.Attribute.ModelColumnAttribute), true).Length > 0)
                {
                    attribute = property.GetCustomAttributes(typeof(CMS.Common.Model.Attribute.ModelColumnAttribute), true)[0] as Model.Attribute.ModelColumnAttribute;
                }

                if (attribute != null && attribute.IsPrimaryKey)
                {
                    string propertyName = attribute.Name;
                    string propertyValue = property.GetValue(model, null).ToString();

                    KeyValuePair<string, string> kvp = new KeyValuePair<string, string>(propertyName, propertyValue);

                    primaryCollection.Add(kvp);
                }
            }
            using (Utility.Core.Resolver.DatasetResolver resolver = new Utility.Core.Resolver.DatasetResolver())
            {
                foreach (PropertyInfo property in properties)
                {
                    CMS.Common.Model.Attribute.ModelColumnAttribute attributeColumn = null;

                    if (property.GetCustomAttributes(typeof(CMS.Common.Model.Attribute.ModelColumnAttribute),true).Length > 0)
                    {
                        attributeColumn = property.GetCustomAttributes(typeof(CMS.Common.Model.Attribute.ModelColumnAttribute),true)[0] as Model.Attribute.ModelColumnAttribute;
                    }

                    //CMS.Common.Model.Attribute.ModelTableAttribute attributeTable = property.GetCustomAttributes(typeof(CMS.Common.Model.Attribute.ModelTableAttribute),true)[0] as Model.Attribute.ModelTableAttribute;
                    if (attributeColumn == null) continue;
                    if (property.PropertyType.IsGenericType)
                    {
                        if (attributeColumn.ColumnType == typeof(T))
                        {
                            Base.BaseCommand subCommand = DBCommandFactory.CreateCommand(typeof(SelectCommand));

                            string subContent = Utility.Core.Reflector.TypeReflector.GetColumnsByTypeTest(attributeColumn.ColumnType);

                            XmlDocument subDoc = new XmlDocument();
                            subDoc.LoadXml(subContent);

                            subCommand.AppendColumns(subDoc);

                            List<DBConditionStructure> subConditionCollection = new List<DBConditionStructure>();

                            foreach (KeyValuePair<string, string> primary in primaryCollection)
                            {
                                //if (primary.Key == attributeColumn.ForeignerKey)
                                if (string.IsNullOrEmpty(attributeColumn.PrimaryKey))
                                {
                                    subConditionCollection.Add(new DBConditionStructure(attributeColumn.ForeignerKey, primary.Value, typeof(Guid)));
                                    break;
                                }
                                if(primary.Key == attributeColumn.PrimaryKey)
                                    subConditionCollection.Add(new DBConditionStructure(attributeColumn.ForeignerKey, primary.Value, typeof(Guid)));
                            }
                            subCommand.AppendWhereCommand(CreateConditionForCommand(subConditionCollection));

                            string subResult = subCommand.GetData(this.connection);

                            ICollection<T> subModelCollection = new List<T>();
                            foreach (IModel.IModel imodel in resolver.DeSerializeAll(subResult, attributeColumn.ColumnType))
                            {
                                subModelCollection.Add(imodel as T);
                            }

                            property.SetValue(model, subModelCollection,null);
                        }
                    }
                }
            }
        }

        public override void SaveAttributeEnum<T>(T model)
        {
            throw new NotImplementedException();
        }

        public override ICollection<T> SyncAttributeEnum<T>(Type type) 
        {
            //获取类型全名
            string fullname = type.FullName;

            ICollection<T> collection = null;

            //创建该类型命令对象
            Base.BaseCommand command = DBCommandFactory.CreateCommand(typeof(SelectCommand));
            //根据类型，生成该类型所有字段字符串
            string content = Utility.Core.Reflector.TypeReflector.GetColumnsByTypeTest(type);
            
            //初始化xml，并加载字段字符串
            XmlDocument doc = new XmlDocument();

            if (!string.IsNullOrEmpty(content))
            {
                doc.LoadXml(content);
            }
            //将字段添加到命令对象中
            command.AppendColumns(doc);

            Assembly assembly = Assembly.Load("CMS.Common.Model");
            //创建该类型实例
            T model = assembly.CreateInstance(type.FullName) as T;

            string columnName = "AttributeGuid";
            string columnValue = model.AttributeGuid.ToString();
            //创建attributeenum的条件语句
            DBConditionStructure attributeEnum = new DBConditionStructure(columnName, columnValue, typeof(Guid));
            //生成条件xml
            XmlDocument condition = CreateConditionForCommand(new List<DBConditionStructure>() { attributeEnum });

            command.AppendWhereCommand(condition);

            if (!command.Check())
            {
                throw new Exception("");
            }
            //执行command，返回查询结果
            string returnContent = string.Empty;
            try
            {
                returnContent = command.GetData(this.connection);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (!string.IsNullOrEmpty(returnContent))
            {
                using (Utility.Core.Resolver.DatasetResolver resolver = new Utility.Core.Resolver.DatasetResolver())
                {
                    //根据结果集，反序列化成model
                    collection = resolver.DeSerializeAll<T>(returnContent);

                    XmlDocument result = new XmlDocument();

                    result.LoadXml(returnContent);

                    //迭代结果集
                    foreach (T m in collection)
                    {
                        //获取子类型中的子类型
                        Type subType = m.GetType();
                        //创建子类型命令集合
                        List<Base.BaseCommand> subCommandCollection = new List<Base.BaseCommand>();

                        List<KeyValuePair<string, string>> primaryCollection = new List<KeyValuePair<string, string>>();
                        //获取类型的主键集
                        foreach (PropertyInfo property in subType.GetProperties())
                        {
                            CMS.Common.Model.Attribute.ModelColumnAttribute attribute = null;

                            if (property.GetCustomAttributes(typeof(CMS.Common.Model.Attribute.ModelColumnAttribute), true).Length > 0)
                            {
                                attribute = property.GetCustomAttributes(typeof(CMS.Common.Model.Attribute.ModelColumnAttribute), true)[0] as Model.Attribute.ModelColumnAttribute;
                            }

                            if (attribute != null && attribute.IsPrimaryKey)
                            {
                                string propertyName = attribute.Name;
                                string propertyValue = property.GetValue(m, null).ToString();

                                KeyValuePair<string, string> kvp = new KeyValuePair<string, string>(propertyName, propertyValue);

                                primaryCollection.Add(kvp);

                            }
                        }
                        //获取对象中的子对象
                        foreach (PropertyInfo property in subType.GetProperties())
                        {
                            if (property.PropertyType.GetInterface("CMS.Interface.Model.IModel") != null)
                            {
                                CMS.Common.Model.Attribute.ModelColumnAttribute attribute = null;

                                if (property.GetCustomAttributes(typeof(CMS.Common.Model.Attribute.ModelColumnAttribute), true).Length > 0)
                                {
                                    attribute = property.GetCustomAttributes(typeof(CMS.Common.Model.Attribute.ModelColumnAttribute), true)[0] as Model.Attribute.ModelColumnAttribute;
                                }

                                Base.BaseCommand subCommand = DBCommandFactory.CreateCommand(typeof(SelectCommand));

                                string subContent = Utility.Core.Reflector.TypeReflector.GetColumnsByTypeTest(property.PropertyType);

                                XmlDocument subDoc = new XmlDocument();
                                subDoc.LoadXml(subContent);

                                subCommand.AppendColumns(subDoc);

                                List<DBConditionStructure> subConditionCollection = new List<DBConditionStructure>();

                                foreach (KeyValuePair<string, string> primary in primaryCollection)
                                {
                                    string xpath = string.Format("/NewDataSet/AttributeEnum[{0}='{1}']/{2}", primary.Key, primary.Value, attribute.Name);

                                    XmlNode node = result.SelectSingleNode(xpath);

                                    if (node != null)
                                    {
                                        subConditionCollection.Add(new DBConditionStructure(attribute.ForeignerKey, node.InnerText, typeof(Guid)));
                                    }
                                }
                                subCommand.AppendWhereCommand(CreateConditionForCommand(subConditionCollection));

                                string subResult = subCommand.GetData(this.connection);

                                IModel.IModel subModel = resolver.DeSerialize(subResult, property.PropertyType);

                                property.SetValue(m, subModel,null);
                            }
                        }
                    }

                    if (collection != null && collection.Count > 0)
                    {
                        dbCache.UpdateCache(collection);
                    }
                }

                return collection;
            }
            else
            {
                
            }
            return collection;
        }

        /// <summary>
        /// 新增数据模型到数据库
        /// </summary>
        /// <typeparam name="T">数据模型的类型</typeparam>
        /// <param name="Model">数据模型</param>
        public override void New<T>(T model)
        {
            string content = Utility.Core.Reflector.ModelReflector.GetColumnsByModel(model);

            using (Utility.Core.Resolver.XmlResolver resolver = new Utility.Core.Resolver.XmlResolver())
            {
                //IModel.IModel imodel = resolver.DeSerialize(content, typeof(T));

                string temp = Utility.Core.Reflector.ModelReflector.GetColumnsByModel(model);

                XmlDocument doc = new XmlDocument();

                doc.LoadXml(temp);

                Base.BaseCommand command;

                command = DBCommandFactory.CreateCommand(typeof(InsertCommand)) as InsertCommand;

                command.AppendColumns(doc);

                if (!command.Check())
                {
                    throw new Exception("");
                }


                try
                {
                    this.connection.Execute(new Base.BaseCommand[] { command });

                    this.dbCache.UpdateCache(model);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    command.Dispose();
                }


            }
            
        }
        /// <summary>
        /// 保存已修改的数据模型到数据库
        /// </summary>
        /// <typeparam name="T">数据模型的类型</typeparam>
        /// <param name="Model">数据模型</param>
        public override void Save<T>(T Model)
        {
            string content = Utility.Core.Reflector.ModelReflector.GetColumnsByModel(Model);

            using (Utility.Core.Resolver.XmlResolver resolver = new Utility.Core.Resolver.XmlResolver())
            {
                string info = Utility.Core.Reflector.ModelReflector.GetColumnsByModel(Model);

                Base.BaseCommand update = DBCommandFactory.CreateCommand(typeof(UpdateCommand));
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(info);
                update.AppendColumns(doc);
                update.AppendWhereCommand(doc);
                try
                {
                    this.connection.Execute(new Base.BaseCommand[] { update });

                    this.dbCache.UpdateCache(Model);
                }
                catch (Exception)
                {   
                    throw;
                }
            }
        }
        /// <summary>
        /// 从数据库中删除已存在的数据模型
        /// </summary>
        /// <typeparam name="T">数据模型的类型</typeparam>
        /// <param name="Model">数据模型</param>
        public override void Delete<T>(T Model)
        {
            string content = Utility.Core.Reflector.ModelReflector.GetColumnsByModel(Model);

            using (Utility.Core.Resolver.XmlResolver resolver = new Utility.Core.Resolver.XmlResolver())
            {
                string info = Utility.Core.Reflector.ModelReflector.GetColumnsByModel(Model);

                Base.BaseCommand delete = DBCommandFactory.CreateCommand(typeof(DeleteCommand));
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(info);
                delete.AppendColumns(doc);
                delete.AppendWhereCommand(doc);
                try
                {
                    this.connection.Execute(new Base.BaseCommand[] { delete });

                    this.dbCache.UpdateCache(Model);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public override void NewAttributeEnum<T>(T model)
        {

            string content = Utility.Core.Reflector.ModelReflector.GetFullyInfoByModel(model);

            Base.BaseCommand command;

            using (Utility.Core.Resolver.XmlResolver resolver = new Utility.Core.Resolver.XmlResolver())
            {
                IModel.IModel imodel = resolver.DeSerialize(content, typeof(T));

                string temp = Utility.Core.Reflector.ModelReflector.GetColumnsByModel(model);

                XmlDocument doc = new XmlDocument();

                doc.LoadXml(temp);

                command = DBCommandFactory.CreateCommand(typeof(InsertCommand)) as InsertCommand;

                command.AppendColumns(doc);

                if (!command.Check())
                {
                    throw new Exception("");
                }
            }

            try
            {
                this.connection.Execute(new Base.BaseCommand[] { command });

                this.dbCache.UpdateCache(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command.Dispose();
            }
        }

        public void UpdateAttributeEnum<T>(T model) where T : IModel.IAttributeEnumModel
        {
            string content = Utility.Core.Reflector.ModelReflector.GetFullyInfoByModel(model);

            Base.BaseCommand command;

            using (Utility.Core.Resolver.XmlResolver resolver = new Utility.Core.Resolver.XmlResolver())
            {
                IModel.IModel imodel = resolver.DeSerialize(content, typeof(T));

                string temp = Utility.Core.Reflector.ModelReflector.GetColumnsByModel(model);

                XmlDocument doc = new XmlDocument();

                doc.LoadXml(temp);

                command = DBCommandFactory.CreateCommand(typeof(UpdateCommand)) as UpdateCommand;

                command.AppendColumns(doc);

                command.AppendWhereCommand(doc);

                if (!command.Check())
                {
                    throw new Exception("");
                }
            }

            try
            {
                this.connection.Execute(new Base.BaseCommand[] { command });

                this.dbCache.UpdateCache(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command.Dispose();
            }
        }

        public override void DeleteAttributeEnum<T>(T model) 
        {
            string content = Utility.Core.Reflector.ModelReflector.GetColumnsByModel(model);

            using (Utility.Core.Resolver.XmlResolver resolver = new Utility.Core.Resolver.XmlResolver())
            {
                string info = Utility.Core.Reflector.ModelReflector.GetColumnsByModel(model);

                Base.BaseCommand delete = DBCommandFactory.CreateCommand(typeof(DeleteCommand));
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(info);
                delete.AppendColumns(doc);
                delete.AppendWhereCommand(doc);
                try
                {
                    this.connection.Execute(new Base.BaseCommand[] { delete });

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }


        public override T SyncSingleAttributeEnum<T>(Type type)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Private methods
        private T SyncSubmodelFromModel<T>(string dataContent, Type subModel) where T : class, IModel.IModel
        {
            IModel.IModel model = null;

            using (CMS.Common.Utility.Core.Resolver.DatasetResolver resolver = new Utility.Core.Resolver.DatasetResolver())
            {
                model = resolver.DeSerialize(dataContent, subModel);
            }

            return model as T;
        }

        public static XmlDocument CreateConditionForCommand(List<DBConditionStructure> Conditions)
        {
            XmlDocument doc = new XmlDocument();

            XmlElement root = doc.CreateElement("root");

            foreach (DBConditionStructure structure in Conditions)
            {
                XmlElement column = doc.CreateElement("Column");
                column.SetAttribute("name",structure.columnName);
                column.SetAttribute("type", structure.columnType.Name);
                column.SetAttribute("operator", System.Enum.GetName(typeof(DBOperator), structure.dbOperator));
                column.InnerText = structure.columnValue;
                root.AppendChild(column);
            }

            doc.AppendChild(root);

            return doc;
        }

        public static XmlDocument CreateConditionForCommand(DBConditionStructure[] Conditions)
        {
            XmlDocument doc = new XmlDocument();

            XmlElement root = doc.CreateElement("root");

            foreach (DBConditionStructure structure in Conditions)
            {
                XmlElement column = doc.CreateElement("Column");
                column.SetAttribute("name", structure.columnName);
                column.SetAttribute("type", structure.columnType.Name);
                column.SetAttribute("operator", System.Enum.GetName(typeof(DBOperator), structure.dbOperator));
                column.InnerText = structure.columnValue;
                root.AppendChild(column);
            }

            doc.AppendChild(root);

            return doc;
        }

        public static DBConditionStructure CreateConditionStucture(System.Attribute attribute, string columnValue,DBOperator dbOperator, Type columnType)
        {
            CMS.Common.Model.Attribute.ModelColumnAttribute columnAttribute = attribute as CMS.Common.Model.Attribute.ModelColumnAttribute;

            string columnName = string.Empty;

            if (columnAttribute != null)
            {
                columnName = columnAttribute.Name;
                return new DBConditionStructure(columnName, columnValue, dbOperator,columnType);
            }
            else
            {
                throw new Exception("");
            }
            
        }
        #endregion

        #region enum
        public enum DBOperator
        {
            Less,
            LessEqual,
            More,
            MoreEqual,
            Equal,
            None
        }
        #endregion

        #region public methods
        /// <summary>
        /// Sync the sub type of model from database
        /// </summary>
        /// <param name="model">model instance</param>
        /// <param name="type">the type of sub model</param>
        public  void SyncSubType(IModel.IModel model, Type type)
        {
            string fullname = type.FullName;

            Type modelType = model.GetType();

            PropertyInfo[] properties = modelType.GetProperties();

            Base.BaseCommand command = DBCommandFactory.CreateCommand(typeof(SelectCommand));
            //根据类型，生成该类型所有字段字符串
            string columns = Utility.Core.Reflector.TypeReflector.GetColumnsByTypeTest(model.GetType());

            XmlDocument result = new XmlDocument();

            result.LoadXml(columns);

            command.AppendColumns(result);

            List<DBConditionStructure> ConditionCollection = new List<DBConditionStructure>();

            List<KeyValuePair<string, string>> primaryCollection = new List<KeyValuePair<string, string>>();
            //获取类型的主键集
            foreach (PropertyInfo property in properties)
            {
                CMS.Common.Model.Attribute.ModelColumnAttribute attribute = null;

                if (property.GetCustomAttributes(typeof(CMS.Common.Model.Attribute.ModelColumnAttribute), true).Length > 0)
                {
                    attribute = property.GetCustomAttributes(typeof(CMS.Common.Model.Attribute.ModelColumnAttribute), true)[0] as Model.Attribute.ModelColumnAttribute;
                }

                if (attribute != null && attribute.IsPrimaryKey)
                {
                    string propertyName = attribute.Name;
                    string propertyValue = property.GetValue(model, null).ToString();

                    KeyValuePair<string, string> kvp = new KeyValuePair<string, string>(propertyName, propertyValue);

                    primaryCollection.Add(kvp);
                    ConditionCollection.Add(new DBConditionStructure(propertyName, propertyValue, attribute.ColumnType));
                }
            }

            command.AppendWhereCommand(CreateConditionForCommand(ConditionCollection));

            string content = command.GetData(this.connection);

            result.LoadXml(content);

            CMS.Common.Model.Attribute.ModelTableAttribute tableAttribute = model.GetType().GetCustomAttributes(typeof(CMS.Common.Model.Attribute.ModelTableAttribute),true)[0] as Model.Attribute.ModelTableAttribute;

            using (Utility.Core.Resolver.DatasetResolver resolver = new Utility.Core.Resolver.DatasetResolver())
            {
                foreach (PropertyInfo property in properties)
                {
                    CMS.Common.Model.Attribute.ModelColumnAttribute attributeColumn = null;

                    if (property.GetCustomAttributes(typeof(CMS.Common.Model.Attribute.ModelColumnAttribute), true).Length > 0)
                    {
                        attributeColumn = property.GetCustomAttributes(typeof(CMS.Common.Model.Attribute.ModelColumnAttribute), true)[0] as Model.Attribute.ModelColumnAttribute;
                    }

                    CMS.Common.Model.Attribute.ModelTableAttribute attributeTable = null;
                    if (property.GetCustomAttributes(typeof(CMS.Common.Model.Attribute.ModelTableAttribute), true).Length > 0)
                    {
                        attributeTable = property.GetCustomAttributes(typeof(CMS.Common.Model.Attribute.ModelTableAttribute), true)[0] as Model.Attribute.ModelTableAttribute;
                    }
                    if (attributeColumn == null) continue;

                    if (property.PropertyType.GetInterface("CMS.Interface.Model.IModel") != null)
                    {
                        if (property.PropertyType == type)
                        {
                            Base.BaseCommand subCommand = DBCommandFactory.CreateCommand(typeof(SelectCommand));

                            string subContent = Utility.Core.Reflector.TypeReflector.GetColumnsByTypeTest(property.PropertyType);

                            XmlDocument subDoc = new XmlDocument();
                            subDoc.LoadXml(subContent);

                            subCommand.AppendColumns(subDoc);

                            List<DBConditionStructure> subConditionCollection = new List<DBConditionStructure>();

                            string xpathTemplate = "/NewDataSet/{0}[{1}]/{2}";
                            string xpathColumn = "{0}='{1}'";
                            string xpath = string.Empty;

                            for (int i = 0; i < primaryCollection.Count; i++)
                            {
                                if (i == primaryCollection.Count - 1)
                                {
                                    xpath += string.Format(xpathColumn, primaryCollection[i].Key, primaryCollection[i].Value);
                                }
                                else
                                {
                                    xpath += string.Format(xpathColumn, primaryCollection[i].Key, primaryCollection[i].Value) + " and ";
                                }
                            }
                            string temp = string.Format(xpathTemplate, tableAttribute.Name, xpath, attributeColumn.Name);
                            XmlNode node = result.SelectSingleNode(string.Format(xpathTemplate, tableAttribute.Name, xpath, attributeColumn.Name));

                            if (node != null)
                            {
                                subConditionCollection.Add(new DBConditionStructure(attributeColumn.ForeignerKey, node.InnerText, attributeColumn.ColumnType));
                            }

                            subCommand.AppendWhereCommand(CreateConditionForCommand(subConditionCollection));

                            string subResult = subCommand.GetData(this.connection);

                            IModel.IModel sub = resolver.DeSerialize(subResult, property.PropertyType);
                            //if (sub != null)
                            //{
                            //    foreach (PropertyInfo subsubProperty in sub.GetType().GetProperties())
                            //    {
                            //        this.SyncSubType(sub, subsubProperty.PropertyType);
                            //    }
                            //}
                            property.SetValue(model, sub,null);
                        }
                    }
                }
            }
        }

        public override void SyncSubType<T>(IModel.IModel model)
        {
            string fullname = typeof(T).FullName;

            Type modelType = model.GetType();

            PropertyInfo[] properties = modelType.GetProperties();

            Base.BaseCommand command = DBCommandFactory.CreateCommand(typeof(SelectCommand));
            //根据类型，生成该类型所有字段字符串
            string columns = Utility.Core.Reflector.TypeReflector.GetColumnsByTypeTest(model.GetType());
            
            XmlDocument result = new XmlDocument();

            result.LoadXml(columns);

            command.AppendColumns(result);

            List<DBConditionStructure> ConditionCollection = new List<DBConditionStructure>();

            List<KeyValuePair<string, string>> primaryCollection = new List<KeyValuePair<string, string>>();
            //获取类型的主键集
            foreach (PropertyInfo property in properties)
            {
                CMS.Common.Model.Attribute.ModelColumnAttribute attribute = null;

                if (property.GetCustomAttributes(typeof(CMS.Common.Model.Attribute.ModelColumnAttribute), true).Length > 0)
                {
                    attribute = property.GetCustomAttributes(typeof(CMS.Common.Model.Attribute.ModelColumnAttribute), true)[0] as Model.Attribute.ModelColumnAttribute;
                }

                if (attribute != null && attribute.IsPrimaryKey)
                {
                    string propertyName = attribute.Name;
                    string propertyValue = property.GetValue(model, null).ToString();

                    KeyValuePair<string, string> kvp = new KeyValuePair<string, string>(propertyName, propertyValue);

                    primaryCollection.Add(kvp);
                    ConditionCollection.Add(new DBConditionStructure(propertyName,propertyValue,attribute.ColumnType));
                }
            }

            command.AppendWhereCommand(CreateConditionForCommand(ConditionCollection));

            string content = command.GetData(this.connection);

            result.LoadXml(content);

            CMS.Common.Model.Attribute.ModelTableAttribute tableAttribute = model.GetType().GetCustomAttributes(typeof(CMS.Common.Model.Attribute.ModelTableAttribute),true)[0] as Model.Attribute.ModelTableAttribute;

            using (Utility.Core.Resolver.DatasetResolver resolver = new Utility.Core.Resolver.DatasetResolver())
            {
                foreach (PropertyInfo property in properties)
                {
                    CMS.Common.Model.Attribute.ModelColumnAttribute attributeColumn = null;

                    if (property.GetCustomAttributes(typeof(CMS.Common.Model.Attribute.ModelColumnAttribute), true).Length > 0)
                    {
                        attributeColumn = property.GetCustomAttributes(typeof(CMS.Common.Model.Attribute.ModelColumnAttribute), true)[0] as Model.Attribute.ModelColumnAttribute;
                    }

                    CMS.Common.Model.Attribute.ModelTableAttribute attributeTable = null;
                    if(property.GetCustomAttributes(typeof(CMS.Common.Model.Attribute.ModelTableAttribute), true).Length > 0)
                    {
                        attributeTable = property.GetCustomAttributes(typeof(CMS.Common.Model.Attribute.ModelTableAttribute), true)[0] as Model.Attribute.ModelTableAttribute;
                    }
                    if (attributeColumn == null) continue;
                    if (property.PropertyType.GetInterface("CMS.Interface.Model.IModel") != null)
                    {
                        if (property.PropertyType == typeof(T))
                        {
                            Base.BaseCommand subCommand = DBCommandFactory.CreateCommand(typeof(SelectCommand));

                            string subContent = Utility.Core.Reflector.TypeReflector.GetColumnsByTypeTest(property.PropertyType);

                            XmlDocument subDoc = new XmlDocument();
                            subDoc.LoadXml(subContent);

                            subCommand.AppendColumns(subDoc);

                            List<DBConditionStructure> subConditionCollection = new List<DBConditionStructure>();

                            string xpathTemplate = "/NewDataSet/{0}[{1}]/{2}";
                            string xpathColumn = "{0}='{1}'";
                            string xpath = string.Empty;

                            for(int i = 0;i < primaryCollection.Count;i++)
                            {
                                if(i == primaryCollection.Count -1)
                                {
                                    xpath += string.Format(xpathColumn,primaryCollection[i].Key,primaryCollection[i].Value);
                                }
                                else
                                {
                                    xpath += string.Format(xpathColumn,primaryCollection[i].Key,primaryCollection[i].Value) + " and ";
                                }
                            }
                            string temp = string.Format(xpathTemplate, tableAttribute.Name, xpath, attributeColumn.Name);
                            XmlNode node = result.SelectSingleNode(string.Format(xpathTemplate,tableAttribute.Name,xpath,attributeColumn.Name));

                            if (node != null)
                            {
                                subConditionCollection.Add(new DBConditionStructure(attributeColumn.ForeignerKey, node.InnerText, attributeColumn.ColumnType));
                            }

                            subCommand.AppendWhereCommand(CreateConditionForCommand(subConditionCollection));

                            string subResult = subCommand.GetData(this.connection);

                            IModel.IModel sub = resolver.DeSerialize(subResult, property.PropertyType);

                            property.SetValue(model, sub,null);
                        }
                    }
                }
            }
        }

        public override int SyncRowsNumber<T>(Type type)
        {
            int iResult = -1;

            object instance = null;

            bool isAttributeModel = false;
            if (type.GetInterfaces().Length > 0)
            {
                isAttributeModel = type.GetInterfaces().Contains(typeof(CMS.Interface.Model.IAttributeEnumModel));
            }

            if(isAttributeModel) instance = Activator.CreateInstance(type);

            CMS.Common.Model.Attribute.ModelTableAttribute tableAttribute = null;
            if(type.GetCustomAttributes(typeof(CMS.Common.Model.Attribute.ModelTableAttribute),true).Length > 0)
            {
                tableAttribute = type.GetCustomAttributes(typeof(CMS.Common.Model.Attribute.ModelTableAttribute), true)[0] as CMS.Common.Model.Attribute.ModelTableAttribute; 
            }

            string primaryKey = string.Empty;

            if (tableAttribute != null && !string.IsNullOrEmpty(tableAttribute.Name))
            {
                string procedure = "sp_get_rownumbers";

                PropertyInfo[] properties = type.GetProperties();

                Guid attributeGuid = Guid.Empty;

                foreach (PropertyInfo property in properties)
                {
                    CMS.Common.Model.Attribute.ModelColumnAttribute columnAttribute = null;

                    if (isAttributeModel && property.Name == "AttributeGuid")
                    {
                        Guid.TryParse(property.GetValue(instance, null).ToString(), out attributeGuid);
                    }

                    if (property.GetCustomAttributes(typeof(CMS.Common.Model.Attribute.ModelColumnAttribute), true).Length > 0)
                    {
                        columnAttribute = property.GetCustomAttributes(typeof(CMS.Common.Model.Attribute.ModelColumnAttribute), true)[0] as Model.Attribute.ModelColumnAttribute;
                    }

                    if (columnAttribute != null && columnAttribute.IsPrimaryKey)
                    {
                        primaryKey = columnAttribute.Name;
                        //break;
                    }
                }

                if (string.IsNullOrEmpty(primaryKey))
                {
                    return -1;
                }

                DbParameter table_name = this.connection.createDbParameter();
                table_name.ParameterName = "@table_name";
                table_name.DbType = DbType.String;
                table_name.Size = 255;
                table_name.Value = tableAttribute.Name;

                DbParameter column_name = this.connection.createDbParameter();
                column_name.ParameterName = "@column_name";
                column_name.DbType = DbType.String;
                column_name.Size = 255;
                column_name.Value = primaryKey;

                DbParameter attribute_guid = this.connection.createDbParameter();
                attribute_guid.ParameterName = "@attribute_guid";
                attribute_guid.DbType = DbType.String;
                attribute_guid.Size = 255;

                if (attributeGuid != Guid.Empty)
                {
                    attribute_guid.Value = attributeGuid.ToString();
                }
                else
                {
                    attribute_guid.Value = DBNull.Value;
                }

                DbParameter[] parameters = new DbParameter[3]{table_name,column_name,attribute_guid};

                DataSet ds = this.connection.GetDataSet(procedure, parameters);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    object result = ds.Tables[0].Rows[0][0];
                    int.TryParse(result.ToString(), out iResult);
                }
            }
            return iResult;
        }

        /// <summary>
        /// Sync the specific count record from database
        /// </summary>
        /// <typeparam name="T">generic type</typeparam>
        /// <param name="type">instance type</param>
        /// <param name="fields"></param>
        /// <param name="pageIndex"></param>
        /// <param name="displayCount"></param>
        /// <returns></returns>
        public override ICollection<T> Sync<T>(Type type,string[] displayFields, int pageIndex, int displayCount)
        {
            ICollection<T> collection = base.Sync<T>(type, displayFields, pageIndex, displayCount);

            CMS.Common.Model.Attribute.ModelTableAttribute tableAttribute = null;

            if (type.GetCustomAttributes(typeof(CMS.Common.Model.Attribute.ModelTableAttribute), true).Length > 0)
            {
                tableAttribute = type.GetCustomAttributes(typeof(CMS.Common.Model.Attribute.ModelTableAttribute), true)[0] as CMS.Common.Model.Attribute.ModelTableAttribute;
            }

            if (tableAttribute != null && !string.IsNullOrEmpty(tableAttribute.Name))
            {
                string procedure = "sp_get_record";

                string columns = Utility.Core.Reflector.TypeReflector.GetColumnsByTypeTest(type);

                string orders = string.Join(",", displayFields);

                DbParameter table_name = this.connection.createDbParameter();
                table_name.ParameterName = "@TableName";
                table_name.DbType = DbType.String;
                table_name.Size = 255;
                table_name.Value = tableAttribute.Name;

                DbParameter column_name = this.connection.createDbParameter();
                column_name.ParameterName = "@Fields";
                column_name.Value = columns;

                DbParameter order_fields = this.connection.createDbParameter();
                order_fields.ParameterName = "@OrderField";
                order_fields.Value = orders;

                DbParameter order_type = this.connection.createDbParameter();
                order_type.ParameterName = "@OrderType";
                order_type.Value = 1;

                DbParameter[] parameters = new DbParameter[4] { table_name, column_name, order_fields, order_type };

                DataSet ds = this.connection.GetDataSet(procedure, parameters);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    string content = string.Empty;

                    using (Stream stream = new MemoryStream())
                    {
                        ds.WriteXml(stream);

                        stream.Position = 0;

                        using (StreamReader reader = new StreamReader(stream))
                        {

                            content = reader.ReadToEnd();
                        }
                    }

                    using (Utility.Core.Resolver.XmlResolver xr = new Utility.Core.Resolver.XmlResolver())
                    {
                        collection = xr.DeSerializeAll<T>(content);
                    }
                }
            }

            return collection;
        }

        public override ICollection<T> Sync<T>(Type type, XmlDocument conditions)
        {
            ICollection<T> collection = base.Sync<T>(type, conditions);

            string fullname = type.FullName;

            Base.BaseCommand command = DBCommandFactory.CreateCommand(typeof(SelectCommand));

            string content = Utility.Core.Reflector.TypeReflector.GetColumnsByType(type);

            XmlDocument doc = new XmlDocument();

            if (!string.IsNullOrEmpty(content))
            {
                doc.LoadXml(content);
            }
            command.AppendColumns(doc);

            command.AppendWhereCommand(conditions);

            if (!command.Check())
            {
                throw new Exception("");
            }

            string returnContent = command.GetData(this.connection);

            if (returnContent!="<NewDataSet />")
            {
                using (Utility.Core.Resolver.DatasetResolver resolver = new Utility.Core.Resolver.DatasetResolver())
                {
                    collection = resolver.DeSerializeAll<T>(returnContent);

                    if (collection != null && collection.Count > 0)
                    {
                        dbCache.UpdateCache(collection);
                    }
                }

                return collection;
            }

            return collection;
        }

        public override void SyncSubTypeCollection<T>(IModel.IModel model, System.Xml.XmlDocument conditions)
        {
            string fullname = typeof(T).FullName;

            Type modelType = model.GetType();

            PropertyInfo[] properties = modelType.GetProperties();

            List<KeyValuePair<string, string>> primaryCollection = new List<KeyValuePair<string, string>>();
            //获取类型的主键集
            foreach (PropertyInfo property in properties)
            {
                CMS.Common.Model.Attribute.ModelColumnAttribute attribute = null;

                if (property.GetCustomAttributes(typeof(CMS.Common.Model.Attribute.ModelColumnAttribute), true).Length > 0)
                {
                    attribute = property.GetCustomAttributes(typeof(CMS.Common.Model.Attribute.ModelColumnAttribute), true)[0] as Model.Attribute.ModelColumnAttribute;
                }

                if (attribute != null && attribute.IsPrimaryKey)
                {
                    string propertyName = attribute.Name;
                    string propertyValue = property.GetValue(model, null).ToString();

                    KeyValuePair<string, string> kvp = new KeyValuePair<string, string>(propertyName, propertyValue);

                    primaryCollection.Add(kvp);
                }
            }
            using (Utility.Core.Resolver.DatasetResolver resolver = new Utility.Core.Resolver.DatasetResolver())
            {
                foreach (PropertyInfo property in properties)
                {
                    CMS.Common.Model.Attribute.ModelColumnAttribute attributeColumn = null;

                    if (property.GetCustomAttributes(typeof(CMS.Common.Model.Attribute.ModelColumnAttribute), true).Length > 0)
                    {
                        attributeColumn = property.GetCustomAttributes(typeof(CMS.Common.Model.Attribute.ModelColumnAttribute), true)[0] as Model.Attribute.ModelColumnAttribute;
                    }

                    //CMS.Common.Model.Attribute.ModelTableAttribute attributeTable = property.GetCustomAttributes(typeof(CMS.Common.Model.Attribute.ModelTableAttribute),true)[0] as Model.Attribute.ModelTableAttribute;
                    if (attributeColumn == null) continue;
                    if (property.PropertyType.IsGenericType)
                    {
                        if (attributeColumn.ColumnType == typeof(T))
                        {
                            Base.BaseCommand subCommand = DBCommandFactory.CreateCommand(typeof(SelectCommand));

                            string subContent = Utility.Core.Reflector.TypeReflector.GetColumnsByTypeTest(attributeColumn.ColumnType);

                            XmlDocument subDoc = new XmlDocument();
                            subDoc.LoadXml(subContent);

                            subCommand.AppendColumns(subDoc);

                            List<DBConditionStructure> subConditionCollection = new List<DBConditionStructure>();

                            foreach (KeyValuePair<string, string> primary in primaryCollection)
                            {
                                //if (primary.Key == attributeColumn.ForeignerKey)
                                if (string.IsNullOrEmpty(attributeColumn.PrimaryKey))
                                {
                                    subConditionCollection.Add(new DBConditionStructure(attributeColumn.ForeignerKey, primary.Value, typeof(Guid)));
                                    break;
                                }
                                if (primary.Key == attributeColumn.PrimaryKey)
                                    subConditionCollection.Add(new DBConditionStructure(attributeColumn.ForeignerKey, primary.Value, typeof(Guid)));
                            }
                            subCommand.AppendWhereCommand(CreateConditionForCommand(subConditionCollection));

                            subCommand.AppendWhereCommand(conditions);

                            string subResult = subCommand.GetData(this.connection);

                            ICollection<T> subModelCollection = new List<T>();
                            foreach (IModel.IModel imodel in resolver.DeSerializeAll(subResult, attributeColumn.ColumnType))
                            {
                                subModelCollection.Add(imodel as T);
                            }

                            property.SetValue(model, subModelCollection, null);
                        }
                    }
                }
            }
        }
        #endregion

        #region static methods
        public static string ConvertDBOperatorToString(DBOperator dbOperator)
        {
            switch (dbOperator)
            {
                case DBContext.DBOperator.Equal:
                    {
                        return "=";
                    }
                case DBContext.DBOperator.Less:
                    {
                        return "<";
                    }
                case DBOperator.LessEqual:
                    {
                        return "<=";
                    }
                case DBOperator.More:
                    {
                        return ">";
                    }
                case DBOperator.MoreEqual:
                    {
                        return ">=";
                    }
                case DBOperator.None:
                default:
                    {
                        throw new Exception("No operator");
                    }

            }
        }
        #endregion
    }
}
