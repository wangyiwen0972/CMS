namespace CMS.Common.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Net.NetworkInformation;
    using CMS.Interface.Model;
    using CMS.Common.Model.Attribute;

    [ModelTable(Name = "EntranceLimitationDetail")]
    public class EntranceLimitationDetail:IModel
    {
        [ModelColumn(Name = "GUID", IsPrimaryKey = true, ColumnType = typeof(Guid))]
        public Guid ID { get; set; }

        [ModelTable(Name = "Entrance")]
        [ModelColumn(Name = "EntranceID", ForeignerKey = "GUID", ColumnType = typeof(Guid))]
        //[ModelColumn(Name = "EntranceID", ColumnType = typeof(Guid))]
        public Entrance Entrance { get; set; }

        [ModelTable(Name = "AttributeEnum")]
        [ModelColumn(Name = "DishTypeID", ForeignerKey = "GUID", ColumnType = typeof(Guid))]
        public DishType DishType { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [ModelTable(Name = "Employee", Display = "GUID")]
        [ModelColumn(Name = "CreatedBy", ForeignerKey = "GUID", ColumnType = typeof(Guid))]
        public Employee CreatedBy { set; get; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [ModelColumn(Name = "CreatedDate", ColumnType = typeof(DateTime))]
        public DateTime CreatedDate { get; set; }

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
            return Entrance.EnterName;
        }
    }
}
