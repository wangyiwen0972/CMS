namespace CMS.Common.Model.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CMS.Common.Model.Emun.Card;
    using CMS.Interface.Model;
    using CMS.Common.Model.Attribute;

    [ModelTable(Name = "CardDetail")]
    public abstract class CardBase:IModel
    {
        /// <summary>
        /// 唯一ID
        /// </summary>
        [ModelColumn(Name="GUID",IsPrimaryKey=true,ColumnType=typeof(Guid))]
        public Guid ID { get; set; }

        [ModelTable(Name="CardType")]
        [ModelColumn(Name="CardTypeID",ForeignerKey="GUID",ColumnType= typeof(Guid))]
        public CardTypes CardType { get; set; }

        public decimal Cost { get; set; }

        public CardType Type { get; set; }

        /// <summary>
        /// 卡片状态
        /// </summary>
        [ModelTable(Name = "AttributeEnum")]
        [ModelColumn(Name = "CardStatusID", ForeignerKey = "GUID", ColumnType = typeof(Guid))]
        public CMS.Common.Model.CardStatus Status { get; set; }

        [ModelTable(Name = "Employee")]
        [ModelColumn(Name = "CreatedBy", ForeignerKey = "GUID", ColumnType = typeof(Guid))]
        public Employee CreatedBy { get; set; }

        /// <summary>
        /// 序列号
        /// </summary>
        [ModelColumn(Name = "SeriesNumber")]
        public string SeriesNumber { get; set; }

        public abstract void Exchange(CardBase Card);

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
            return SeriesNumber;
        }
    }
}
