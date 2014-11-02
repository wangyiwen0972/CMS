namespace CMS.WinForms.Background
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
    using CMS.Common.Controller.Core;
    using CMS.Common.Model;
    using CMS.Module.Shell.Core;

    public partial class OperatorSet : CMSForm
    {
        private Employee employee = null;

        public OperatorSet(Employee employee)
        {
            InitializeComponent();
            this.employee = employee;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            OperatorSetEdit frmEdit = new OperatorSetEdit(this.employee);

            DialogResult dialog = frmEdit.ShowDialog();

            if (dialog == System.Windows.Forms.DialogResult.OK)
            {
            }

        }
    }
}
