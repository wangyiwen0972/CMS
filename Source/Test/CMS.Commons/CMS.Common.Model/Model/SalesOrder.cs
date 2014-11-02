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

    [ModelTable(Name = "SalesOrder")]
    public class SalesOrder:IModel
    {
        [ModelColumn(Name = "GUID", ColumnType = typeof(Guid))]
        public Guid ID { get; set; }

        [ModelColumn(Name = "SalesID", IsPrimaryKey = true, ColumnType = typeof(Guid))]
        public Guid SalesID { get; set; }

        [ModelColumn(Name = "SalesNo")]
        public string SalesNo { get; set; }

        [ModelColumn(Name = "CardID", ColumnType = typeof(Guid))]
        public Guid CardID { get; set; }

        [ModelColumn(Name = "EntranceID", ColumnType = typeof(Guid))]
        public Guid EntranceID { get; set; }

        [ModelColumn(Name = "Status", ColumnType = typeof(Guid))]
        public Guid SalesStatus { get; set; }

        [ModelTable(Name = "EntranceOrder")]
        [ModelColumn(ForeignerKey = "SalesID", ColumnType = typeof(EntranceOrder))]
        public ICollection<EntranceOrder> OrderCollection { get; set; }

        [ModelTable(Name = "Employee", Display = "GUID")]
        [ModelColumn(Name = "CreatedBy", ForeignerKey = "GUID", ColumnType = typeof(Guid))]
        public Employee CreatedBy { get; set; }

        [ModelTable(Name = "Employee", Display = "GUID")]
        [ModelColumn(Name = "ChangedBy", ForeignerKey = "GUID", ColumnType = typeof(Guid))]
        public Employee ChangedBy { get; set; }

        [ModelColumn(Name = "CreatedDate", ColumnType = typeof(DateTime))]
        public DateTime CreatedDate { get; set; }

        [ModelColumn(Name = "ChangedDate", ColumnType = typeof(DateTime))]
        public DateTime ChangedDate { get; set; }

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
            return this.SalesID;
        }

        public string PrimaryName()
        {
            return this.SalesNo;
        }
    }
}
