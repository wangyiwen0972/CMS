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
    /// 档口订单明细模型
    /// </summary>
    [ModelTable(Name = "EntranceDishDetail")]
    public class EntranceOrderDetail:IModel
    {
        [ModelTable(Name="EntranceOrder")]
        [ModelColumn(Name = "OrderID", ForeignerKey = "GUID", IsPrimaryKey = true, ColumnType = typeof(Guid))]
        public Guid OrderID { get; set; }

        //[ModelTable(Name = "EntranceOrder")]
        //[ModelColumn(Name = "EntranceOrderID", ForeignerKey = "GUID", IsPrimaryKey=true, ColumnType = typeof(Guid))]
        //public EntranceOrder Order { get; set; }

        //public ICollection<Dish> DishCollection { get; set; }

        [ModelTable(Name = "Dish")]
        [ModelColumn(Name = "DishID", ForeignerKey = "GUID", ColumnType = typeof(Guid))]
        public Guid Dish { get; set; }

        [ModelColumn(Name = "Price", ColumnType = typeof(decimal))]
        public decimal Price { get; set; }

        [ModelColumn(Name = "Quantity", ColumnType = typeof(decimal))]
        public decimal Quantity { get; set; }

        [ModelColumn(Name = "Amount", ColumnType = typeof(decimal))]
        public decimal Amount { get; set; }

        [ModelColumn(Name = "Unit")]
        public string Unit { get; set; }

        [ModelTable(Name = "Employee")]
        [ModelColumn(Name = "CreatedBy", ForeignerKey = "GUID", ColumnType = typeof(Guid))]
        public Employee CreatedBy { get; set; }

        [ModelColumn(Name = "CreatedDate", ColumnType = typeof(DateTime))]
        public DateTime CreatedDate { get; set; }

        [ModelTable(Name = "Employee")]
        [ModelColumn(Name = "ChangedBy", ForeignerKey = "GUID", ColumnType = typeof(Guid))]
        public Employee ChangedBy { get; set; }

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
            return this.OrderID;
        }


        public string PrimaryName()
        {
            throw new NotImplementedException();
        }
    }
}
