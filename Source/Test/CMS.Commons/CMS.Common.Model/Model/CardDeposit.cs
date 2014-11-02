namespace CMS.Common.Model
{
    using System;
    using System.Collections.Generic;
    using CMS.Interface.Model;
    using CMS.Common.Model.Attribute;

    [ModelTable(Name = "CardDepositHistory")]
    public class CardDeposit:IModel
    {
        [ModelColumn(Name="GUID",IsPrimaryKey=true,ColumnType=typeof(Guid))]
        public Guid GUID { get; set; }

        [ModelTable(Name = "CardDetail")]
        [ModelColumn(Name = "DishID", ForeignerKey = "GUID", ColumnType = typeof(Guid))]     
        public Base.CardBase Card { get; set; }

        [ModelColumn(Name="AdjustedAmount",ColumnType=typeof(decimal))]
        public decimal AdjustedAmount { get; set; }

        [ModelColumn(Name = "ActualAmount", ColumnType = typeof(decimal))]
        public decimal ActualAmount { get; set; }

        [ModelTable(Name = "Employee")]
        [ModelColumn(Name = "CreatedBy", ForeignerKey = "GUID", ColumnType = typeof(Guid))]     
        public Employee CreatedBy { get; set; }

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
            throw new NotImplementedException();
        }


        public string PrimaryName()
        {
            throw new NotImplementedException();
        }
    }
}
