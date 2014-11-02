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

    [ModelTable(Name = "Machine")]
    public class Machine:IModel
    {
        [ModelColumn(Name = "GUID", IsPrimaryKey = true, ColumnType = typeof(Guid))]
        public Guid ID { get; set; }

        [ModelColumn(Name = "MachineName")]
        public string MachineName { get; set; }

        [ModelColumn(Name = "MachineMAC")]
        public string MachineMAC { get; set; }

        [ModelColumn(Name = "MachineIP")]
        public string MachineIP { get; set; }

        [ModelColumn(Name = "IsRelated",ColumnType=typeof(bool))]
        public bool IsRelated { get; set; }

        [ModelColumn(Name = "EntranceID",ColumnType = typeof(Guid))]
        public Guid EntranceID { get; set; }

        public int Compare(IModel Model)
        {
            throw new NotImplementedException();
        }

        public bool IsEqual(IModel Model)
        {
            throw new NotImplementedException();
        }

        Guid IModel.PrimaryGuids()
        {
            return this.ID;
        }


        public string PrimaryName()
        {
            return MachineName;
        }
    }
}
