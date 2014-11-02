namespace CMS.WinForms.Cash
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using CMS.Module.Shell.Core;
    using ViewResultBase = CMS.Common.ViewResult.Base;
    using CMS.Common.ViewResult.Core;
    using ModelBase = CMS.Common.Model.Base;
    using CMS.Common.Model;
    using CMS.Module.CardMachine;
    using CMS.Common.Controller.Core;

    public partial class CardClose : CMSForm
    {
        private CardController cardController = null;

        private OrderController orderController = null;

        private CMS.Common.Model.Base.CardBase card = null;

        private CMS.Interface.Model.IModel salesOrder = null;
        
        public CardClose()
        {
            InitializeComponent();

            this.cardController = this.ControllerManager[typeof(CardController)] as CardController;

            this.orderController = this.ControllerManager[typeof(OrderController)] as OrderController;

            this.Init();

        }

        public CMS.Common.Model.Base.CardBase Card
        {
            get { return card; }
        }

        private void Init()
        {
            try
            {
                ICollection<CMS.Interface.Model.IModel> statusCollection = this.orderController.GetSalesStatusCollection().GetModelResults();



                this.card = this.cardController.ReadCardInfo().Model as CMS.Common.Model.Base.CardBase;

                SalesStatus status = orderController.getSalesStatus(OrderController.SALES_STATUS_ACTIVE);
                salesOrder = this.orderController.GetSalesOrderBySalesStatus(Card, status).Model;

                if (salesOrder == null)
                {
                    MessageBox.Show("Cannot find sales order record from database!");
                    this.Close();
                }

                decimal amount = decimal.Zero;

                foreach (EntranceOrder order in this.orderController.GetOrderCollectionBySalesOrder(this.salesOrder as SalesOrder).GetModelResults())
                {
                    amount += order.Amount;
                }

                lbCardType.Text = this.card.CardType.TypeCName;
                lbNumber.Text = (salesOrder as SalesOrder).SalesNo;
                lbAmount.Text = amount.ToString();

                if (this.card is TemporaryCard)
                {

                    lbCash.Text = (this.card as TemporaryCard).Amount.ToString();
                    lbMoney.Text = ((this.card as TemporaryCard).Amount - amount).ToString();

                    if ((this.card as TemporaryCard).Amount < amount)
                    {
                        throw new Exception("您的当前余额少于消费！需补收！");
                    }
                }
                if (this.card is RechargeCard)
                {
                    lbCash.Text = (this.card as RechargeCard).Amount.ToString();
                    lbMoney.Text = ((this.card as RechargeCard).Amount - amount).ToString();

                    if ((this.card as RechargeCard).Amount < amount)
                    {
                        throw new Exception("您的当前余额少于消费！需补收！");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            try
            {
                ICollection<CMS.Interface.Model.IModel> statusCollection = this.orderController.GetSalesStatusCollection().GetModelResults();

                foreach (SalesStatus status in statusCollection)
                {
                    if (status.EnumCode.Equals("active", StringComparison.CurrentCultureIgnoreCase))
                    {
                        salesOrder = this.orderController.GetSalesOrderBySalesStatus(Card, status).Model as SalesOrder;
                        break;
                    }
                }

                orderController.GetOrderCollectionBySalesOrder(salesOrder as SalesOrder);

                this.cardController.InactiveCard(card);

                this.orderController.CheckOut(card);

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                throw new Exception("结账失败！错误信息：" + ex.Message);
            }
        }
    }
}
