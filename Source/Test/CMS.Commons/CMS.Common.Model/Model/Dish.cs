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

    [ModelTable(Name="Dish")]
    [Serializable()]
    public class Dish:IModel
    {
        /// <summary>
        /// 菜品唯一ID
        /// </summary>
        [ModelColumn(Name="GUID",IsPrimaryKey=true,ColumnType=typeof(Guid))]
        public Guid ID { get; set; }

        /// <summary>
        /// 短ID
        /// </summary>
        [ModelColumn(Name = "ShortID")]
        public string ShortID { get; set; }

        /// <summary>
        /// 食时ID
        /// </summary>
        [ModelTable(Name = "AttributeEnum")]
        [ModelColumn(Name = "ShopHoursID",ForeignerKey="GUID",ColumnType=typeof(Guid))]
        public ShopHours ShopHours { get; set; }

        private int discount = 100;

        /// <summary>
        /// 优惠比例
        /// </summary>
        [ModelColumn(Name = "Discount",ColumnType=typeof(int))]
        public int Discount { get { return discount; } set { discount = value; } }

        /// <summary>
        /// 助记码
        /// </summary>
        [ModelColumn(Name = "Code")]
        public string Code { get; set; }

        /// <summary>
        /// 菜品名称
        /// </summary>
        [ModelColumn(Name = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// 菜品显示名称
        /// </summary>
        [ModelColumn(Name = "Title")]
        public string Title { get; set; }

        /// <summary>
        /// 介绍
        /// </summary>
        [ModelColumn(Name = "Introduction")]
        public string Introduction { get; set; }

        /// <summary>
        /// 图片物理地址
        /// </summary>
        [ModelColumn(Name = "ImageUrl")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        [ModelTable(Name = "DishPrice")]
        [ModelColumn(ForeignerKey = "DishId", ColumnType = typeof(DishUnitPriceSetting))]
        public ICollection<DishUnitPriceSetting> UnitPriceSetting { get; set; }
        
        /// <summary>
        /// 菜系
        /// </summary>
        [ModelTable(Name="AttributeEnum")]
        [ModelColumn(Name = "StyleGUID",ForeignerKey="GUID",ColumnType=typeof(Guid))]
        public DishStyle Style { get; set; }

        /// <summary>
        /// 大类
        /// </summary>
        [ModelTable(Name = "AttributeEnum")]
        [ModelColumn(Name = "TypeGUID", ForeignerKey = "GUID", ColumnType = typeof(Guid))]
        public DishType Type { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [ModelTable(Name = "AttributeEnum")]
        [ModelColumn(Name = "StatusGUID", ForeignerKey = "GUID", ColumnType = typeof(Guid))]
        public DishStatus Status { get; set; }

        /// <summary>
        /// 食材列表
        /// </summary>
        [ModelTable(Name="AttributeEnum")]
        [ModelColumn(ForeignerKey = "GUID", ColumnType = typeof(Recipe))]
        public ICollection<Recipe> RecipeCollection { get; set; }

        /// <summary>
        /// 烧法
        /// </summary>
        [ModelTable(Name = "DishCookTypeDetail")]
        [ModelColumn(ForeignerKey = "GUID", ColumnType = typeof(CookType))]
        public ICollection<CookType> CookingType { get; set; }



        /// <summary>
        /// 创建人
        /// </summary>
        [ModelTable(Name = "Employee", Display = "GUID")]
        [ModelColumn(Name = "CreatedBy", ForeignerKey = "GUID", ColumnType = typeof(Guid))]
        [Column(Name = "CreatedBy", Expression = "GUID")]
        public Employee CreatedBy { set; get; }

        /// <summary>
        /// 修改人
        /// </summary>
        [Column(Name = "ChangedBy", Expression = "GUID")]
        [ModelTable(Name = "Employee", Display = "GUID")]
        [ModelColumn(Name = "ChangedBy", ForeignerKey = "GUID", ColumnType = typeof(Guid))]
        public Employee ChangedBy { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column(Name = "CreatedDate")]
        [ModelColumn(Name = "CreatedDate", ColumnType = typeof(DateTime))]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        [Column(Name = "ChangedDate")]
        [ModelColumn(Name = "ChangedDate", ColumnType = typeof(DateTime))]
        public DateTime ChangedDate { get; set; }

        /// <summary>
        /// 是否是时令价格
        /// </summary>
        [ModelColumn(Name = "IsSpecialPrice", ColumnType = typeof(bool))]
        public bool IsSpecialPrice { get; set; }
        

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
            return this.Name;
        }
    }
  
}
