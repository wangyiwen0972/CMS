namespace CMS.Common.Model.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.Linq.Mapping;
    using CMS.Common.Model.Emun.User;
    using CMS.Interface.Model;
    using CMS.Common.Model.Attribute;

    public abstract class UserBase:IModel
    {
        [ModelColumn(Name="GUID",IsPrimaryKey=true,ColumnType=typeof(Guid))]
        public Guid ID { get; set; }

        [ModelColumn(Name="FullName")]
        public string FullName { get; set; }

        [ModelColumn(Name = "Sex", ColumnType = typeof(int))]
        public int Sex { get; set; }

        [ModelColumn(Name = "Telephone")]
        public string Telephone { get; set; }

        [ModelColumn(Name = "Address")]
        public string Address { get; set; }

        [ModelColumn(Name = "Age",ColumnType=typeof(int))]
        public int Age { get; set; }

        [ModelColumn(Name = "Login")]
        public string Login { get; set; }

        [ModelColumn(Name = "Password")]
        public string Password { get; set; }

        [ModelTable(Name="AttributeEnum")]
        [ModelColumn(Name = "StatusID", ForeignerKey="GUID", ColumnType=typeof(Guid))]
        public Guid Status { get; set; }


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
            return this.FullName;
        }
    }
}
