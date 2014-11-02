namespace CMS.WinForms.Cash
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using CMS.WinForms.Cash;
    using CMS.WinForms.Sales;
    using CMS.Module.Shell.Core;
    using CMS.Common.Controller.Core;
    using CMS.Common.Model;
    using CMS.Common.ViewResult.Core;
    using CMS.Module.CardMachine;

    public partial class swipingcard :CMSForm
    {
        private CMS.Common.Model.Base.CardBase card = null;

        private CardController cardController = null;

        public CMS.Common.Model.Base.CardBase Card
        {
            get { return card; }
        }

        public swipingcard():base()
        {
            InitializeComponent();

            this.cardController = this.ControllerManager[typeof(CardController)] as CardController;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            try
            {
                

                this.card = this.cardController.ReadCardInfo().Model as CMS.Common.Model.Base.CardBase;

                this.txtCardNo.Text = this.card.SeriesNumber;

                if (!string.IsNullOrEmpty(this.txtCardNo.Text))
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
