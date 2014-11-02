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

    [ModelTable(Name="DepartmentDetail")]
    public class DepartmentDetail:CMS.Interface.Model.IModel
    {
        [ModelColumn(Name="GUID",IsPrimaryKey=true,ColumnType=typeof(Guid))]
        public Guid ID { get; set; }

        [ModelTable(Name="AttributeEnum")]
        [ModelColumn(Name="DepartmentID",ForeignerKey="GUID",ColumnType=typeof(Guid))]
        public Department Department { get; set; }

        [ModelTable(Name = "Employee")]
        [ModelColumn(Name = "EmployeeID", ForeignerKey = "GUID", ColumnType = typeof(Guid))]
        public ICollection<Employee> EmployeeCollection { get; set; }

        public int Compare(Interface.Model.IModel Model)
        {
            throw new NotImplementedException();
        }

        public bool IsEqual(Interface.Model.IModel Model)
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
