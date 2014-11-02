namespace CMS.Common.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.Linq.Mapping;
    using System.Data;
    using CMS.Interface.Model;
    using CMS.Common.Model.Attribute;

    #region 烧法类型
    /// <summary>
    /// 烧法类型
    /// </summary>
    [Table(Name = "AttributeEnum")]
    public class CookType : IAttributeEnumModel
    {

        private Guid attributeGuid;
        /// <summary>
        /// 菜品
        /// </summary>
        [Column(Name = "AttributeGuid")]
        public Guid AttributeGuid
        {
            get
            {
                return Guid.Parse("903fa1e2-34c3-49af-b181-e1acdfe919c0");
            }
            set
            {
                attributeGuid = value;
            }
        }

        private Guid id;

        [Column(Name = "Guid")]
        public Guid ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        private string enumValue;

        /// <summary>
        /// 烧法名称（如红烧）
        /// </summary>
        [Column(Name = "EnumValue")]
        public string EnumValue
        {
            get
            {
                return enumValue;
            }
            set
            {
                enumValue = value;
            }
        }

        private string enumCode;

        /// <summary>
        /// 烧法助记码
        /// </summary>
        [Column(Name = "EnumCode")]
        public string EnumCode
        {
            get
            {
                return enumCode;
            }
            set
            {
                enumCode = value;
            }
        }

        private string remark;

        /// <summary>
        /// 烧法介绍
        /// </summary>
        [Column(Name = "Remark")]
        public string Remark
        {
            get
            {
                return remark;
            }
            set
            {
                remark = value;
            }
        }

        private DateTime createdDate;

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return createdDate;
            }
            set
            {
                createdDate = value;
            }
        }

        private DateTime changedDate;

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime ChangedDate
        {
            get
            {
                return changedDate;
            }
            set
            {
                changedDate = value;
            }
        }

        private IModel createdBy;

        /// <summary>
        /// 创建人
        /// </summary>
        public IModel CreatedBy
        {
            get { return createdBy; }
            set { createdBy = value; }
        }

        private IModel changedBy;
        /// <summary>
        /// 修改人
        /// </summary>
        public IModel ChangedBy
        {
            get { return changedBy; }
            set { changedBy = value; }
        }

        public int Compare(IModel Model)
        {
            throw new NotImplementedException();
        }

        public bool IsEqual(IModel Model)
        {
            throw new NotImplementedException();
        }

        public Guid PrimaryGuids()
        {
            return this.ID;
        }


        public string PrimaryName()
        {
            return this.EnumValue;
        }
    }
    #endregion

    #region 菜系
    /// <summary>
    /// 菜系
    /// </summary>
    [ModelTable(Name = "AttributeEnum")]
    [Table(Name = "AttributeEnum")]
    public class DishStyle : IAttributeEnumModel
    {
        private Guid attributeGuid;
        /// <summary>
        /// 菜品
        /// </summary>
        [Column(Name = "AttributeGuid")]
        [ModelColumn(Name = "AttributeGuid", ColumnType = typeof(Guid))]
        public Guid AttributeGuid
        {
            get
            {
                return Guid.Parse("10dbc541-5fe0-4733-b81c-577215c936b2");
            }
            set
            {
                attributeGuid = value;
            }
        }

        private Guid id;

        [Column(Name = "Guid", IsPrimaryKey = true)]
        [ModelColumn(Name = "Guid", IsPrimaryKey = true, ColumnType = typeof(Guid))]
        public Guid ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        private string enumValue;


        [Column(Name = "EnumValue")]
        [ModelColumn(Name = "EnumValue")]
        public string EnumValue
        {
            get
            {
                return enumValue;
            }
            set
            {
                enumValue = value;
            }
        }

        private string enumCode;

        [Column(Name = "EnumCode")]
        [ModelColumn(Name = "EnumCode")]
        public string EnumCode
        {
            get
            {
                return enumCode;
            }
            set
            {
                enumCode = value;
            }
        }

        private string remark;

        [Column(Name = "Remark")]
        [ModelColumn(Name = "Remark")]
        public string Remark
        {
            get
            {
                return remark;
            }
            set
            {
                remark = value;
            }
        }

        public int Compare(IModel Model)
        {
            throw new NotImplementedException();
        }

        public bool IsEqual(IModel Model)
        {
            throw new NotImplementedException();
        }

        public Guid PrimaryGuids()
        {
            return this.ID;
        }


        public string PrimaryName()
        {
            return EnumValue;
        }
    }
    #endregion

    #region 菜品大类
    /// <summary>
    /// 菜系大类
    /// </summary>
    [ModelTable(Name = "AttributeEnum")]
    public class DishType : IAttributeEnumModel
    {
        [ModelColumn(Name = "Guid", IsPrimaryKey = true, ColumnType = typeof(Guid))]
        public Guid ID
        {
            get;
            set;
        }

        private Guid attributeGuid;
        [ModelColumn(Name = "AttributeGuid", ColumnType = typeof(Guid))]
        public Guid AttributeGuid
        {
            get { return Guid.Parse("f43dbe54-c5df-4f26-99ee-2b1579b5f731"); }
            set { attributeGuid = value; }
        }

        [ModelColumn(Name = "EnumValue")]
        public string EnumValue
        {
            get;
            set;
        }
        [ModelColumn(Name = "EnumCode")]
        public string EnumCode
        {
            get;
            set;
        }
        [ModelColumn(Name = "Remark")]
        public string Remark
        {
            get;
            set;
        }

        public int Compare(IModel Model)
        {
            throw new NotImplementedException();
        }

        public bool IsEqual(IModel Model)
        {
            throw new NotImplementedException();
        }

        public Guid PrimaryGuids()
        {
            return ID;
        }


        public string PrimaryName()
        {
            return this.EnumValue;
        }
    }
    #endregion

    #region 用户状态
    [ModelTable(Name = "AttributeEnum")]
    public class UserStatus : IAttributeEnumModel
    {
        [ModelColumnAttribute(Name = "GUID", IsPrimaryKey = true, ColumnType = typeof(Guid))]
        public Guid ID
        {
            get;
            set;
        }
        private Guid attributeGuid;
        [ModelColumn(Name = "AttributeGuid", ColumnType = typeof(Guid))]
        public Guid AttributeGuid
        {
            get
            {
                return Guid.Parse("9921d4b7-96f3-40f3-a7dc-03acc8b28d92");
            }
            set { attributeGuid = value; }
        }
        [ModelColumn(Name = "EnumValue")]
        public string EnumValue
        {
            get;
            set;
        }
        [ModelColumn(Name = "EnumCode")]
        public string EnumCode
        {
            get;
            set;
        }
        [ModelColumn(Name = "Remark")]
        public string Remark
        {
            get;
            set;
        }

        //private Employee createdBy;

        ///// <summary>
        ///// 创建人
        ///// </summary>
        //[ModelTable(Name = "Employee", Display = "GUID")]
        //[ModelColumn(Name = "CreatedBy", ForeignerKey = "GUID", ColumnType = typeof(Guid))]
        //[Column(Name = "CreatedBy", Expression = "GUID")]
        //public Employee CreatedBy
        //{
        //    get { return createdBy; }
        //    set { createdBy = value; }
        //}

        //private Employee changedBy;
        ///// <summary>
        ///// 修改人
        ///// </summary>
        //[Column(Name = "ChangedBy", Expression = "GUID")]
        //[ModelTable(Name = "Employee", Display = "GUID")]
        //[ModelColumn(Name = "ChangedBy", ForeignerKey = "GUID", ColumnType = typeof(Guid))]
        //public Employee ChangedBy
        //{
        //    get { return changedBy; }
        //    set { changedBy = value; }
        //}

        public int Compare(IModel Model)
        {
            throw new NotImplementedException();
        }

        public bool IsEqual(IModel Model)
        {
            throw new NotImplementedException();
        }

        public Guid PrimaryGuids()
        {
            return this.ID;
        }


        public string PrimaryName()
        {
            return this.EnumValue;
        }
    }
    #endregion

    #region 职位
    [ModelTable(Name = "AttributeEnum")]
    public class Postion : IAttributeEnumModel, IModel
    {
        [ModelColumn(Name = "Guid", IsPrimaryKey = true, ColumnType = typeof(Guid))]
        public Guid ID
        {
            get;
            set;
        }
        private Guid attributeGuid;
        [ModelColumn(Name = "AttributeGuid", ColumnType = typeof(Guid))]
        public Guid AttributeGuid
        {
            get
            {
                return Guid.Parse("847b9633-4924-4dcb-a31a-cfac8a4edf46");
            }
            set { attributeGuid = value; }
        }
        [ModelColumn(Name = "EnumValue")]
        public string EnumValue
        {
            get;
            set;
        }
        [ModelColumn(Name = "EnumCode")]
        public string EnumCode
        {
            get;
            set;
        }
        [ModelColumn(Name = "Remark")]
        public string Remark
        {
            get;
            set;
        }

        public int Compare(IModel Model)
        {
            throw new NotImplementedException();
        }

        public bool IsEqual(IModel Model)
        {
            throw new NotImplementedException();
        }

        public Guid PrimaryGuids()
        {
            return this.ID;
        }


        public string PrimaryName()
        {
            return this.EnumValue;
        }
    }
    #endregion

    #region 操作
    [ModelTable(Name = "AttributeEnum")]
    public class Operator : IAttributeEnumModel
    {
        [ModelColumn(Name = "Guid", IsPrimaryKey = true, ColumnType = typeof(Guid))]
        public Guid ID
        {
            get;
            set;
        }

        private Guid attributeGuid;
        [ModelColumn(Name = "AttributeGuid", ColumnType = typeof(Guid))]
        public Guid AttributeGuid
        {
            get
            {
                return Guid.Parse("b160db2a-f1a3-49fc-93f4-1b24ad0cddd8");
            }
            set { attributeGuid = value; }
        }
        [ModelColumn(Name = "EnumValue")]
        public string EnumValue
        {
            get;
            set;
        }
        [ModelColumn(Name = "EnumCode")]
        public string EnumCode
        {
            get;
            set;
        }
        [ModelColumn(Name = "Remark")]
        public string Remark
        {
            get;
            set;
        }

        public int Compare(IModel Model)
        {
            throw new NotImplementedException();
        }

        public bool IsEqual(IModel Model)
        {
            throw new NotImplementedException();
        }

        public Guid PrimaryGuids()
        {
            return this.ID;
        }


        public string PrimaryName()
        {
            return this.EnumValue;
        }
    }
    #endregion

    #region 权限
    [ModelTable(Name = "AttributeEnum")]
    public class Right : IAttributeEnumModel
    {
        [ModelColumn(Name = "Guid", IsPrimaryKey = true, ColumnType = typeof(Guid))]
        public Guid ID
        {
            get;
            set;
        }
        private Guid attributeGuid;
        [ModelColumn(Name = "AttributeGuid", ColumnType = typeof(Guid))]
        public Guid AttributeGuid
        {
            get { return Guid.Parse("d18b5c03-e90f-4d03-ac21-90fad43f55b7"); }
            set { attributeGuid = value; }
        }

        [ModelColumn(Name = "EnumValue")]
        public string EnumValue
        {
            get;
            set;
        }
        [ModelColumn(Name = "EnumCode")]
        public string EnumCode
        {
            get;
            set;
        }
        [ModelColumn(Name = "Remark")]
        public string Remark
        {
            get;
            set;
        }

        public int Compare(IModel Model)
        {
            throw new NotImplementedException();
        }

        public bool IsEqual(IModel Model)
        {
            throw new NotImplementedException();
        }

        public Guid PrimaryGuids()
        {
            return this.ID;
        }


        public string PrimaryName()
        {
            return this.EnumValue;
        }
    }
    #endregion

    #region 部门
    [ModelTable(Name = "AttributeEnum")]
    public class Department : IAttributeEnumModel
    {
        [ModelColumn(Name = "Guid", IsPrimaryKey = true, ColumnType = typeof(Guid))]
        public Guid ID
        {
            get;
            set;
        }

        private Guid attributeGuid;
        [ModelColumn(Name = "AttributeGuid", ColumnType = typeof(Guid))]
        public Guid AttributeGuid
        {
            get { return Guid.Parse("847fb494-2ed1-4c24-8206-127de59e2c69"); }
            set { attributeGuid = value; }
        }

        [ModelColumn(Name = "EnumValue")]
        public string EnumValue
        {
            get;
            set;
        }
        [ModelColumn(Name = "EnumCode")]
        public string EnumCode
        {
            get;
            set;
        }
        [ModelColumn(Name = "Remark")]
        public string Remark
        {
            get;
            set;
        }

        public int Compare(IModel Model)
        {
            throw new NotImplementedException();
        }

        public bool IsEqual(IModel Model)
        {
            throw new NotImplementedException();
        }

        public Guid PrimaryGuids()
        {
            return ID;
        }


        public string PrimaryName()
        {
            return this.EnumValue;
        }
    }
    #endregion

    #region 食时
    [ModelTable(Name = "AttributeEnum")]
    public class ShopHours : IAttributeEnumModel
    {

        [ModelColumn(Name = "Guid", IsPrimaryKey = true, ColumnType = typeof(Guid))]
        public Guid ID
        {
            get;
            set;
        }

        private Guid attributeGuid;
        [ModelColumn(Name = "AttributeGuid", ColumnType = typeof(Guid))]
        public Guid AttributeGuid
        {
            get { return Guid.Parse("41837427-FCC1-4F61-960E-CC1DC4CC1959"); }
            set { attributeGuid = value; }
        }

        [ModelColumn(Name = "EnumValue")]
        public string EnumValue
        {
            get;
            set;
        }
        [ModelColumn(Name = "EnumCode")]
        public string EnumCode
        {
            get;
            set;
        }
        [ModelColumn(Name = "Remark")]
        public string Remark
        {
            get;
            set;
        }

        public int Compare(IModel Model)
        {
            throw new NotImplementedException();
        }

        public bool IsEqual(IModel Model)
        {
            throw new NotImplementedException();
        }

        public Guid PrimaryGuids()
        {
            return this.ID;
        }


        public string PrimaryName()
        {
            return this.EnumValue;
        }
    }
    #endregion

    #region 单位类型
    [ModelTable(Name = "AttributeEnum")]
    public class UnitType : IAttributeEnumModel
    {

        [ModelColumn(Name = "Guid", IsPrimaryKey = true, ColumnType = typeof(Guid))]
        public Guid ID
        {
            get;
            set;
        }

        private Guid attributeGuid;
        [ModelColumn(Name = "AttributeGuid", ColumnType = typeof(Guid))]
        public Guid AttributeGuid
        {
            get { return Guid.Parse("10b92dab-8c6c-49fd-9bef-5b96d43d0aab"); }
            set { attributeGuid = value; }
        }

        [ModelColumn(Name = "EnumValue")]
        public string EnumValue
        {
            get;
            set;
        }
        [ModelColumn(Name = "EnumCode")]
        public string EnumCode
        {
            get;
            set;
        }
        [ModelColumn(Name = "Remark")]
        public string Remark
        {
            get;
            set;
        }

        public int Compare(IModel Model)
        {
            throw new NotImplementedException();
        }

        public bool IsEqual(IModel Model)
        {
            throw new NotImplementedException();
        }

        public Guid PrimaryGuids()
        {
            return this.ID;
        }


        public string PrimaryName()
        {
            return this.EnumValue;
        }
    }
    #endregion

    #region 菜品状态
    [ModelTable(Name = "AttributeEnum")]
    public class DishStatus : IAttributeEnumModel
    {

        [ModelColumn(Name = "Guid", IsPrimaryKey = true, ColumnType = typeof(Guid))]
        public Guid ID
        {
            get;
            set;
        }

        private Guid attributeGuid;
        [ModelColumn(Name = "AttributeGuid", ColumnType = typeof(Guid))]
        public Guid AttributeGuid
        {
            get { return Guid.Parse("1aca1b13-3db8-4943-9b89-ed3290953838"); }
            set { attributeGuid = value; }
        }

        [ModelColumn(Name = "EnumValue")]
        public string EnumValue
        {
            get;
            set;
        }
        [ModelColumn(Name = "EnumCode")]
        public string EnumCode
        {
            get;
            set;
        }
        [ModelColumn(Name = "Remark")]
        public string Remark
        {
            get;
            set;
        }

        public int Compare(IModel Model)
        {
            throw new NotImplementedException();
        }

        public bool IsEqual(IModel Model)
        {
            throw new NotImplementedException();
        }

        public Guid PrimaryGuids()
        {
            return this.ID;
        }


        public string PrimaryName()
        {
            return this.EnumValue;
        }
    }
    #endregion

    #region 档口状态
    [ModelTable(Name = "AttributeEnum")]
    public class EntranceStatus : IAttributeEnumModel
    {
        [ModelColumn(Name = "Guid", IsPrimaryKey = true, ColumnType = typeof(Guid))]
        public Guid ID { get; set; }

        private Guid attributeGuid;
        [ModelColumn(Name = "AttributeGuid", ColumnType = typeof(Guid))]
        public Guid AttributeGuid
        {
            get { return Guid.Parse("b609c8b3-4e53-4901-b393-c7b705706be4"); }
            set { attributeGuid = value; }
        }

        [ModelColumn(Name = "EnumValue")]
        public string EnumValue { get; set; }

        [ModelColumn(Name = "EnumCode")]
        public string EnumCode { get; set; }

        [ModelColumn(Name = "Remark")]
        public string Remark { get; set; }

        public int Compare(IModel Model)
        {
            throw new NotImplementedException();
        }

        public bool IsEqual(IModel Model)
        {
            throw new NotImplementedException();
        }

        public Guid PrimaryGuids()
        {
            return this.ID;
        }


        public string PrimaryName()
        {
            return this.EnumValue;
        }
    }

    #endregion

    #region 卡片状态
    [ModelTable(Name = "AttributeEnum")]
    public class CardStatus : IAttributeEnumModel
    {
        [ModelColumn(Name = "Guid", IsPrimaryKey = true, ColumnType = typeof(Guid))]
        public Guid ID { get; set; }

        private Guid attributeGuid;
        [ModelColumn(Name = "AttributeGuid", ColumnType = typeof(Guid))]
        public Guid AttributeGuid
        {
            get { return Guid.Parse("41c9ac72-f017-4867-8696-2c361d1865b7"); }
            set { attributeGuid = value; }
        }

        [ModelColumn(Name = "EnumValue")]
        public string EnumValue { get; set; }

        [ModelColumn(Name = "EnumCode")]
        public string EnumCode { get; set; }

        [ModelColumn(Name = "Remark")]
        public string Remark { get; set; }

        public int Compare(IModel Model)
        {
            throw new NotImplementedException();
        }

        public bool IsEqual(IModel Model)
        {
            throw new NotImplementedException();
        }

        public Guid PrimaryGuids()
        {
            return this.ID;
        }


        public string PrimaryName()
        {
            return this.EnumValue;
        }
    }
    #endregion

    #region 销售订单状态
    [ModelTable(Name = "AttributeEnum")]
    public class SalesStatus : IAttributeEnumModel
    {
        [ModelColumn(Name = "Guid", IsPrimaryKey = true, ColumnType = typeof(Guid))]
        public Guid ID { get; set; }

        private Guid attributeGuid;
        [ModelColumn(Name = "AttributeGuid", ColumnType = typeof(Guid))]
        public Guid AttributeGuid
        {
            get { return Guid.Parse("416cafc7-248c-4bb3-b3f3-6cbb1cce0feb"); }
            set { attributeGuid = value; }
        }

        [ModelColumn(Name = "EnumValue")]
        public string EnumValue { get; set; }

        [ModelColumn(Name = "EnumCode")]
        public string EnumCode { get; set; }

        [ModelColumn(Name = "Remark")]
        public string Remark { get; set; }

        public int Compare(IModel Model)
        {
            throw new NotImplementedException();
        }

        public bool IsEqual(IModel Model)
        {
            throw new NotImplementedException();
        }

        public Guid PrimaryGuids()
        {
            return this.ID;
        }


        public string PrimaryName()
        {
            return this.EnumValue;
        }
    }
    #endregion

    #region 档口订单状态
    [ModelTable(Name = "AttributeEnum")]
    public class EntranceOrderStatus : IAttributeEnumModel
    {
        [ModelColumn(Name = "Guid", IsPrimaryKey = true, ColumnType = typeof(Guid))]
        public Guid ID { get; set; }

        private Guid attributeGuid;
        [ModelColumn(Name = "AttributeGuid", ColumnType = typeof(Guid))]
        public Guid AttributeGuid
        {
            get { return Guid.Parse("416cafc7-248c-4bb3-b3f3-6cbb1cce0feb"); }
            set { attributeGuid = value; }
        }

        [ModelColumn(Name = "EnumValue")]
        public string EnumValue { get; set; }

        [ModelColumn(Name = "EnumCode")]
        public string EnumCode { get; set; }

        [ModelColumn(Name = "Remark")]
        public string Remark { get; set; }

        public int Compare(IModel Model)
        {
            throw new NotImplementedException();
        }

        public bool IsEqual(IModel Model)
        {
            throw new NotImplementedException();
        }

        public Guid PrimaryGuids()
        {
            return this.ID;
        }


        public string PrimaryName()
        {
            return this.EnumValue;
        }
    }
        #endregion
    
    #region 权限等级
    [ModelTable(Name = "AttributeEnum")]
    public class RightLevel : IAttributeEnumModel
    {
        [ModelColumn(Name = "Guid", IsPrimaryKey = true, ColumnType = typeof(Guid))]
        public Guid ID { get; set; }

        private Guid attributeGuid;
        [ModelColumn(Name = "AttributeGuid", ColumnType = typeof(Guid))]
        public Guid AttributeGuid
        {
            get { return Guid.Parse("4b1db81d-25f3-42ed-b744-b7d6b7a32a75"); }
            set { attributeGuid = value; }
        }

        [ModelColumn(Name = "EnumValue")]
        public string EnumValue { get; set; }

        [ModelColumn(Name = "EnumCode")]
        public string EnumCode { get; set; }

        [ModelColumn(Name = "Remark")]
        public string Remark { get; set; }

        public int Compare(IModel Model)
        {
            throw new NotImplementedException();
        }

        public bool IsEqual(IModel Model)
        {
            throw new NotImplementedException();
        }

        public Guid PrimaryGuids()
        {
            return this.ID;
        }


        public string PrimaryName()
        {
            return this.EnumValue;
        }
    }
#endregion
}

