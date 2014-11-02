namespace CMS.Common.Model
{
    using System;
    using System.Collections.Generic;
    using CMS.Interface.Model;
    using CMS.Common.Model.Attribute;

    [ModelTable(Name = "RestInfo")]
    public class RestInfo:IModel
    {
        [ModelColumn(Name = "GUID", IsPrimaryKey = true, ColumnType = typeof(Guid))]
        public Guid ID { get; set; }

        [ModelColumn(Name = "RestName")]
        public string RestName { get; set; }

        [ModelColumn(Name = "Telphone")]
        public string Telphone { get; set; }

        [ModelColumn(Name = "Addr")]
        public string Address { get; set; }

        [ModelColumn(Name = "TaxNo")]
        public string TaxNo { get; set; }

        [ModelColumn(Name = "RestDBIP")]
        public string RestDBIP { get; set; }



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
            return RestName;
        }
    }
}
