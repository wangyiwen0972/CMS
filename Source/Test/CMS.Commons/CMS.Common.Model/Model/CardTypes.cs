namespace CMS.Common.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CMS.Common.Model.Attribute;
    using CMS.Interface.Model;

    [ModelTable(Name="CardType")]
    public class CardTypes:IModel
    {
        [ModelColumn(Name="GUID",IsPrimaryKey=true,ColumnType=typeof(Guid))]
        public Guid ID { get; set; }
        
        [ModelColumn(Name="TypeEName")]
        public string TypeEName { get; set; }

        [ModelColumn(Name = "TypeCName")]
        public string TypeCName { get; set; }

        [ModelColumn(Name = "ValidDate",ColumnType=typeof(int))]
        public int ValidDate { get; set; }

        [ModelColumn(Name = "Discount", ColumnType = typeof(decimal))]
        public decimal Discount { get; set; }

        [ModelColumn(Name = "Cost", ColumnType = typeof(decimal))]
        public decimal Cost { get; set; }

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
            throw new NotImplementedException();
        }
    }
}
