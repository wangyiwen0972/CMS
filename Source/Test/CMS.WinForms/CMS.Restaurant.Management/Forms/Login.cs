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
    using ControllerCore = CMS.Common.Controller.Core;
    using UtilityCore = CMS.Common.Utility.Core;
    using ResultCore = CMS.Common.ViewResult.Core;
    using CMS.Module.Shell.Core;
    using CMS.WinForms.OSK;
    using CMS.Restaurant.Client;

    public partial class Login : CMSForm
    {
        private ControllerCore.EmployeeController employeeController = null;
        private ControllerCore.DepartmentController departController = null;
        private ControllerCore.MachineController machineController = null;

        private const int WS_EX_TOOLWINDOW = 0x00000080;
        private const int WS_EX_NOACTIVATE = 0x08000000;

        public Login()
        {
            this.InitializeComponent();

            if (base.ControllerManager == null)
            {
                MessageBox.Show("Initialize failed! Please check log file!");
                return;
            }

            this.employeeController = base.ControllerManager[typeof(ControllerCore.EmployeeController)] as ControllerCore.EmployeeController;
            this.departController = base.ControllerManager[typeof(ControllerCore.DepartmentController)] as ControllerCore.DepartmentController;
            this.machineController = base.ControllerManager[typeof(ControllerCore.MachineController)] as ControllerCore.MachineController;
            this.loadDepartment();
        }

        private void loadDepartment()
        {
            try
            {
                ICollection<Interface.Model.IModel> departmentCollection = this.departController.GetAllDepartment().GetModelResults();

                ICollection<Department> dp = new List<Department>();

                foreach (Department depart in departmentCollection)
                {
                    dp.Add(depart);
                }

                this.cbDepartment.DisplayMember = "EnumValue";
                this.cbDepartment.ValueMember = "ID";
                this.cbDepartment.DataSource = dp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string strLogin = this.txtLogin.Text.Trim();
            string strPassword = this.txtPassword.Text.Trim();

            string errorMessage = string.Empty;

            if (strLogin.Length == 0 || strPassword.Length == 0)
            {
                errorMessage = "请输入用户名及密码";

                MessageBox.Show(errorMessage);
                return;
            }

            ResultCore.BooleanResult result = this.employeeController.LogIn(strLogin, strPassword) as ResultCore.BooleanResult;

            bool isValid = false;

            bool.TryParse(result.Result, out isValid);

            if (isValid)
            {
                Employee employee = result.Model as Employee;

                this.employeeController.GetDepartmentForEmployee(employee);

                this.employeeController.GetDepartmentForEmployee(employee);

                if (!this.employeeController.GetRightLevelForEmployee(employee, out errorMessage))
                {
                    MessageBox.Show(errorMessage);
                    return;
                }
                
                CMS.Common.Model.Emun.Level rightLevel;

                if (!Enum.TryParse<CMS.Common.Model.Emun.Level>(employee.Level.EnumCode, out rightLevel))
                {
                    errorMessage = "权限格式不正确!";

                    MessageBox.Show(errorMessage);
                    return;
                }
                if ((int)rightLevel < 2)
                {
                    errorMessage = "您的权限不足，当前权限为{0}";

                    MessageBox.Show(string.Format(errorMessage,rightLevel));
                    return;
                }
                CMSForm.SetCurrentEmployee(employee);

                BackgroundMain bgMain = new BackgroundMain(employee);
                this.Hide();
                bgMain.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("用户名或密码错误");
                return;
            }
        }

        private void txtLogin_Click(object sender, EventArgs e)
        {
            if (!frmOSK.Visible)
            {
                int x = this.Left - frmOSK.Width / 4;

                int txtYPoint = txtLogin.PointToScreen(txtLogin.Location).Y;

                frmOSK.Location = new Point(x, txtYPoint + txtLogin.Height);

                frmOSK.Visible = true;
            }
        }

        private void txtLogin_Leave(object sender, EventArgs e)
        {
            frmOSK.Visible = false;
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            if (!frmOSK.Visible)
            {
                frmOSK.Visible = true;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            frmOSK.Visible = false;
        }
    }
}
