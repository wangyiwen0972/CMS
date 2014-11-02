namespace CMS.WinForms.Login
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
    using CMS.WinForms.Sales;
    using CMS.WinForms.Background;
    using CMS.Module.Shell.Core;
    using CMS.WinForms.OSK;

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

            if (strLogin.Length == 0 || strPassword.Length == 0)
            {
                MessageBox.Show("请输入用户名及密码");
                return;
            }

            ResultCore.BooleanResult result = this.employeeController.LogIn(strLogin, strPassword) as ResultCore.BooleanResult;

            bool isValid = false;

            bool.TryParse(result.Result, out isValid);

            if (isValid)
            {
                Employee employee = result.Model as Employee;

                this.employeeController.GetDepartmentForEmployee(employee);

                employeeController.GetDepartmentForEmployee(employee);

                CMSForm.SetCurrentEmployee(employee);

                if (employee.Department.EnumValue == "IT部")
                {
                    Background.BackgroundMain bgMain = new BackgroundMain(employee);
                    this.Hide();
                    bgMain.ShowDialog();
                    this.Close();
                }
                else if (employee.Department.EnumValue == "销售部")
                {
                    Machine machine = this.machineController.GetMachine(System.Environment.GetEnvironmentVariable("ComputerName")).Model as Machine;

                    if (machine == null)
                    {
                        MessageBox.Show("该主机还未与挡口关联，请联系管理员");
                        return;
                    }
                    CMSForm.SetCurrentMachine(machine);
                    SalesMain main = new SalesMain(employee);
                    this.Hide();
                    main.ShowDialog();
                    this.Close();
                }
                else
                {
                    Cash.CashMain frmCash = new Cash.CashMain();
                    this.Hide();
                    frmCash.ShowDialog();
                    this.Close();
                }
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
            this.frmOSK.Visible = false;
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            if (!this.frmOSK.Visible)
            {
                this.frmOSK.Visible = true;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            this.frmOSK.Visible = false;
        }
    }
}
