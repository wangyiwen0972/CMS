namespace CMS.Restaurant.Management
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
    using CMS.Restaurant.Client.Cash;

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
            this.Init();
        }

        private void Init()
        {
            string errorMessage = string.Empty;

            this.BasicSetting.Enabled = CheckRightLevel(2, out errorMessage);
            this.AdvanceSetting.Enabled = CheckRightLevel(3, out errorMessage);
            this.ClientForm.Enabled = CheckRightLevel(3, out errorMessage);
            this.ReportForm.Enabled = CheckRightLevel(3, out errorMessage);
            this.CardForm.Enabled = CheckRightLevel(3, out errorMessage);
        }

        private bool CheckRightLevel(int needsRightLevel, out string error)
        {
            bool result = false;
            error = string.Empty;

            if (this.employee != null)
            {
                CMS.Common.Model.Emun.Level rightLevel;

                if (Enum.TryParse<CMS.Common.Model.Emun.Level>(this.employee.Level.EnumCode, out rightLevel))
                {
                    if ((int)rightLevel < needsRightLevel)
                    {
                        error = string.Format("您的权限不足，当前权限为{0}!", rightLevel);
                    }
                    else
                    {
                        result = true;
                    }
                }
                else
                {
                    error = string.Format(string.Format("非法的权限格式!"));
                }
            }
            return result;
        }

        private void BackgroundMain_Load(object sender, EventArgs e)
        {

        }

        private void DishTypeMenuItem_Click(object sender, EventArgs e)
        {
            CategorySet CS = new CategorySet(employee);
            CS.ShowDialog();
        }

        private void DishMenuItem_Click(object sender, EventArgs e)
        {
            DishSet frmDishSet = new DishSet();
            frmDishSet.ShowDialog();
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
            SalesPortSet frmPort = new SalesPortSet();
            frmPort.ShowDialog();
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

        private void EntranceMenuItem_Click(object sender, EventArgs e)
        {
            CashMain cashWindow = new CashMain();
            cashWindow.ShowDialog();
        }

        private void SalesMenuItem_Click(object sender, EventArgs e)
        {
            CashMain frmCash = new CashMain();
            frmCash.ShowDialog();
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {

        }
    }
}
