namespace CMS.Common.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CMS.Common.Model.Attribute;
    using CMS.Interface.Model;

    [ModelTable(Name="DishPrice")]
    public class DishUnitPriceSetting:IModel
    {
        [ModelColumn(Name = "GUID", IsPrimaryKey = true, ColumnType = typeof(Guid))]
        public Guid GUID { get; set; }

        [ModelTable(Name="Dish")]
        [ModelColumn(Name = "DishID", ForeignerKey="GUID", ColumnType = typeof(Guid))]        
        public Guid DishID { get; set; }

        [ModelTable(Name="Unit")]
        [ModelColumn(Name="UnitID",ForeignerKey="GUID",ColumnType=typeof(Guid))]
        public Unit UnitID { get; set; }

        [ModelColumn(Name="Price",ColumnType=typeof(decimal))]
        public decimal Price { get; set; }

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
            return GUID;
        }


        public string PrimaryName()
        {
            throw new NotImplementedException();
        }
    }
}
