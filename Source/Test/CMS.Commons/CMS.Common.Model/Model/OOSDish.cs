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

    [ModelTable(Name = "OOSDishes")]
    public class OOSDish:IModel
    {
        [ModelColumn(Name = "DishID", IsPrimaryKey = true, ColumnType = typeof(Guid))]
        public Guid DishID { get; set; }

        [ModelColumn(Name = "Quantity", ColumnType = typeof(int))]
        public int Quantity { get; set; }

        [ModelColumn(Name = "MachineID", ColumnType = typeof(Guid))]
        public Guid MachineID { get; set; }

        [ModelColumn(Name = "LastUpdatedTime", ColumnType = typeof(DateTime))]
        public DateTime LastUpdatedTime { get; set; }


        [ModelTable(Name = "Employee", Display = "GUID")]
        [ModelColumn(Name = "LastUpdatedBy", ForeignerKey = "GUID", ColumnType = typeof(Guid))]
        public Employee LastUpdatedBy { get; set; }

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
            return DishID;
        }

        public string PrimaryName()
        {
            throw new NotImplementedException();
        }
    }
}
