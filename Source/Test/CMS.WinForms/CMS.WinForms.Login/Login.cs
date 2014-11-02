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

    public partial class Login : CMSForm
    {
        private ControllerCore.EmployeeController employeeController = null;
        private ControllerCore.DepartmentController departController = null;

        public Login()
        {
            this.InitializeComponent();
            this.employeeController = base.ControllerManager[typeof(ControllerCore.EmployeeController)] as ControllerCore.EmployeeController;
            this.departController = base.ControllerManager[typeof(ControllerCore.DepartmentController)] as ControllerCore.DepartmentController;
            this.loadDepartment();
        }

        private void loadDepartment()
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

                employeeController.GetDepartmentForEmployee(employee);

                //Background.BackgroundMain bgMain = new BackgroundMain(employee);
                //this.Hide();
                //bgMain.ShowDialog();
                //this.Close();

                SalesMain main = new SalesMain(employee);
                this.Hide();
                main.ShowDialog();
                this.Close();

                //if (employee.Department.EnumCode.Equals("Market"))
                //{
                //    SalesMain main = new SalesMain(employee);
                //    this.Hide();
                //    main.ShowDialog();
                //    this.Close();
                //}
                //if (employee.Department.EnumCode.Equals("IT"))
                //{
                //    Background.BackgroundMain bgMain = new BackgroundMain(employee);
                //    this.Hide();
                //    bgMain.ShowDialog();
                //    this.Close();
                //}
            }
        }
    }
}
