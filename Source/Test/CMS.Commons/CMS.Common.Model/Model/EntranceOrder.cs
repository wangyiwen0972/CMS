namespace CMS.Common.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CMS.Interface.Model;
    using CMS.Common.Model.Attribute;

    /// <summary>
    /// 档口订单模型
    /// </summary>
    [ModelTable(Name="EntranceOrder")]
    public class EntranceOrder : IModel
    {
        [ModelColumn(Name="GUID",IsPrimaryKey=true,ColumnType= typeof(Guid))]
        public Guid ID { get; set; }

        [ModelColumn(Name = "OrderNo")]
        public string OrderNo { get; set; }

        [ModelColumn(Name = "SalesID",ColumnType = typeof(Guid))]
        public Guid SalesID { get; set; }

        [ModelColumn(Name="Amount",ColumnType=typeof(decimal))]
        public decimal Amount { get; set; }

        [ModelColumn(Name="PayAmount",ColumnType=typeof(decimal))]
        public decimal PayAmount { get; set; }

        [ModelColumn(Name="IsUseCard",ColumnType=typeof(Boolean))]
        public bool IsUseCard { get; set; }

        [ModelTable(Name="CardDetail")]
        [ModelColumn(Name="CardID",ForeignerKey="GUID",ColumnType=typeof(Guid))]
        public Guid CardID { get; set; }

        [ModelTable(Name = "Entrance")]
        [ModelColumn(Name = "EntranceID", ForeignerKey = "GUID", ColumnType = typeof(Guid))]
        public Guid EntranceID { get; set; }

        [ModelTable(Name = "AttributeEnum")]
        [ModelColumn(Name = "Status", ForeignerKey = "GUID", ColumnType = typeof(Guid))]
        public EntranceStatus Status { get; set; }

        [ModelColumn(Name = "PrintFlag", ColumnType = typeof(Boolean))]
        public bool PrintFlag { get; set; }

        [ModelColumn(Name = "Machine", ColumnType = typeof(Guid))]
        public Guid Machine { get; set; }

        [ModelTable(Name = "Employee")]
        [ModelColumn(Name = "Operator", ForeignerKey="GUID", ColumnType = typeof(Guid))]
        public Employee Operator { get; set; }

        [ModelTable(Name = "Employee")]
        [ModelColumn(Name = "CreatedBy", ForeignerKey = "GUID", ColumnType = typeof(Guid))]
        public Employee CreatedBy { get; set; }

        [ModelColumn(Name="CreatedDate",ColumnType=typeof(DateTime))]
        public DateTime CreatedDate { get; set; }

        [ModelTable(Name = "Employee")]
        [ModelColumn(Name = "ChangedBy", ForeignerKey = "GUID", ColumnType = typeof(Guid))]
        public Employee ChangedBy { get; set; }

        [ModelColumn(Name = "ChangedDate", ColumnType = typeof(DateTime))]
        public DateTime ChangedDate { get; set; }

        [ModelTable(Name = "EntranceOrderDetail")]
        [ModelColumn(ColumnType = typeof(EntranceOrderDetail), ForeignerKey = "OrderID", PrimaryKey = "GUID")]
        public ICollection<EntranceOrderDetail> OrderDetail { get; set; }

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
            return this.OrderNo;
        }
    }
}
