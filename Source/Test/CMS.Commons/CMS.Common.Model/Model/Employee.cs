namespace CMS.Common.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CMS.Common.Model.Emun;
    using System.Data.Linq.Mapping;
    using CMS.Common.Model.Attribute;
    /// <summary>
    /// 职员类
    /// </summary>
    [Table(Name="Employee")]
    [ModelTable(Name="Employee")]
    public class Employee:Base.UserBase,CMS.Interface.Model.IModel
    {
        /// <summary>
        /// 操作权限（可以有多个操作权限）
        /// </summary>
        public ICollection<Emun.Action> Actions;

        /// <summary>
        /// 职员的职位（可同时兼备多个职位）
        /// </summary>
        //public ICollection<Emun.Position> Positions;

        [ModelColumn(Name = "PositionID", ForeignerKey = "Guid", ColumnType = typeof(Guid))]
        [ModelTable(Name = "AttributeEnum")]
        public Postion Position { get; set; } 

        /// <summary>
        /// 部门
        /// </summary>
        [ModelColumn(Name = "DepartmentID", ForeignerKey = "Guid", ColumnType = typeof(Guid))]
        [ModelTable(Name = "AttributeEnum")]
        public Department Department { get; set; }

        /// <summary>
        /// 权限等级
        /// </summary>
        [ModelColumn(Name = "LevelID", ForeignerKey = "Guid", ColumnType = typeof(Guid))]
        [ModelTable(Name = "AttributeEnum")]
        public RightLevel Level { get; set; }

    }
}
