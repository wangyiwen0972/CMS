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
    using CMS.Common.Model;
    using CMS.Common.Controller.Core;
    using CMS.Module.Shell.Core;

    public partial class BackgroundMain : CMSForm
    {
        private Employee employee = null;

        public BackgroundMain():this(null)
        {
            
        }

        public BackgroundMain(Employee employee)
        {
            InitializeComponent();
            this.employee = employee;
        }

        private void BackgroundMain_Load(object sender, EventArgs e)
        {

        }

        private void DishTypeMenuItem_Click(object sender, EventArgs e)
        {
            CMS.WinForms.Background.CategorySet CS = new CategorySet(employee);
            CS.ShowDialog();
        }

        private void DishMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void CookTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void EmployeeMenuItem_Click(object sender, EventArgs e)
        {
            OperatorSet employeeForm = new OperatorSet(this.employee);
            employeeForm.ShowDialog();
        }

        private void DishStyleMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void RestaurantManageMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void EntranceManageMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void RightManageMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void PrinterManageMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void CardMachineManageMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
