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
    /// <summary>
    /// 单位类
    /// </summary>
    [ModelTable(Name="Unit")]
    public class Unit : IModel
    {
        /// <summary>
        /// 唯一ID
        /// </summary>
        [ModelColumn(Name = "GUID", IsPrimaryKey = true)]
        public Guid ID { get; set; }

        /// <summary>
        /// 单位助记号
        /// </summary>
        [ModelColumn(Name = "Code")]
        public string Code { get; set; }

        /// <summary>
        /// 单位名称
        /// </summary>
        [ModelColumn(Name = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// 单位类型
        /// </summary>
        [ModelTable(Name = "AttributeEnum")]
        [ModelColumn(Name = "UnitTypeID", ForeignerKey = "GUID", ColumnType = typeof(Guid))]
        public UnitType UnitType { get; set; }

        /// <summary>
        /// 转换单位
        /// </summary>
        /// <param name="srcUnit">原单位</param>
        /// <param name="destUnit">目的单位</param>
        /// <returns>转换后的值</returns>
        public static decimal Convert(Unit srcUnit, Unit destUnit)
        {
            return Decimal.MinValue;
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
            return Name;
        }
    }
}
