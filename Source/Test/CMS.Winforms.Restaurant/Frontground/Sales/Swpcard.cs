namespace CMS.WinForms.Sales
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
    using CMS.Common.Model;
    using ControllerCore = CMS.Common.Controller.Core;
    using UtilityCore = CMS.Common.Utility.Core;
    using ResultCore = CMS.Common.ViewResult.Core;
    using CMS.Module.Printer.Core;
    using CMS.Module.Shell.Core;
    using CMS.Module.CardMachine;
    using CMS.WinForms.Cash;

    public partial class swipingcard : CMSForm
    {
        private ControllerCore.CardController cardController = null;

        

        private CMS.Common.Model.Base.CardBase card = null;
        public CMS.Common.Model.Base.CardBase Card
        {
            get { return card; }
        }

        public swipingcard()
        {
            InitializeComponent();

            this.cardController = this.ControllerManager[typeof(ControllerCore.CardController)] as ControllerCore.CardController;
                
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                this.card = this.cardController.ReadCardInfo().Model as CMS.Common.Model.Base.CardBase;

                if (this.card != null)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }


                //this.txt.Text = this.card.PrimaryName();

                //if (!string.IsNullOrEmpty(this.textBox1.Text))
                //{
                //    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                //    this.Close();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
