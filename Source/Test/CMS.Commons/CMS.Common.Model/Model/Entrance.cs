namespace CMS.Common.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CMS.Common.Model.Attribute;
    using CMS.Interface.Model;

    /// <summary>
    /// 档口模型
    /// </summary>
    [ModelTable(Name="Entrance")]
    public class Entrance:IModel
    {
        [ModelColumn(Name="GUID",IsPrimaryKey=true,ColumnType=typeof(Guid))]
        public Guid ID { get; set; }

        [ModelColumn(Name="EnterName")]
        public string EnterName { get; set; }

        [ModelTable(Name = "Machine")]
        [ModelColumn(ColumnType = typeof(Machine), ForeignerKey = "EntranceID", PrimaryKey = "GUID")]
        public ICollection<Machine> MachineCollection { get; set; }

        [ModelTable(Name = "EntranceOrder")]
        [ModelColumn(ForeignerKey = "EntranceID", ColumnType = typeof(EntranceOrder))]
        public ICollection<EntranceOrder> OrderCollection { get; set; }

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

        [ModelTable(Name = "EntranceLimitationDetail")]
        [ModelColumn(ForeignerKey = "EntranceID", ColumnType = typeof(EntranceLimitationDetail))]
        public ICollection<EntranceLimitationDetail> LimitationCollection { get; set; }

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
            return EnterName;
        }
    }
}
