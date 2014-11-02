namespace CMS.WinForms.Background
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using CMS.Common.Controller.Core;
    using CMS.Common.Model;
    using CMS.Interface.Model;
    using CMS.Common.ViewResult.Core;
    using CMS.Module.Shell.Core;
    using System.Threading;
    using System.IO;

    public partial class OperatorSetEdit : CMSForm
    {
        private EmployeeController employeeController = null;
        private DepartmentController departController = null;

        private List<UserStatus> userStatusCollection = null;
        private List<Department> departmentCollection = null;
        private List<Postion> positionCollection = null;

        private BackgroundWorker worker = null;

        private Employee employee = null;

        public Employee NewEmployee
        {
            get;
            private set;
        }

        public OperatorSetEdit():this(null)
        {
        }

        public OperatorSetEdit(Employee employee)
        {
            InitializeComponent();
            this.employee = employee;

            this.worker = new BackgroundWorker();
            this.worker.DoWork += worker_DoWork;
            this.worker.RunWorkerCompleted += worker_RunWorkerCompleted;

            this.worker.RunWorkerAsync();
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ddlStatus.DisplayMember = "EnumValue";
            ddlStatus.ValueMember = "Guid";
            ddlStatus.DataSource = userStatusCollection;

            ddlDepartment.DisplayMember = "EnumValue";
            ddlDepartment.ValueMember = "Guid";
            ddlDepartment.DataSource = departmentCollection;

            ddlPosition.DisplayMember = "EnumValue";
            ddlPosition.ValueMember = "Guid";
            ddlPosition.DataSource = positionCollection;

            if (this.employee != null)
            {
                txtEmployeeCode.Text = this.employee.Login.Trim();
                txtFullName.Text = this.employee.FullName.Trim();
                txtAddress.Text = this.employee.Address.Trim();
                txtTelphone.Text = this.employee.Telephone.Trim();
                ddlDepartment.SelectedItem = this.employee.Department;
                ddlPosition.Text = this.employee.Position.EnumValue;
            }
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Init();
        }

        private void Init()
        {
            this.employeeController = this.ControllerManager[typeof(EmployeeController)] as EmployeeController;

            this.departController = this.ControllerManager[typeof(DepartmentController)] as DepartmentController;

            this.userStatusCollection = new List<UserStatus>();
            this.departmentCollection = new List<Department>();
            this.positionCollection = new List<Postion>();

            foreach(UserStatus status in this.employeeController.GetStatusOfEmployee().GetModelResults())
            {
                this.userStatusCollection.Add(status);
            }

            foreach (Department department in this.departController.GetAllDepartment().GetModelResults())
            {
                this.departmentCollection.Add(department);
            }

            foreach (Postion position in this.departController.GetAllPosition().GetModelResults())
            {
                this.positionCollection.Add(position);
            }
        }

        private void InitDepartment()
        {
            this.departController.GetAllDepartment();
        }

        private void InitPosition() { }

        private void InitStatus() { }

        private void btnGenerateCode_Click(object sender, EventArgs e)
        {
            txtEmployeeCode.Text = employeeController.GenerateEmployeeCode().Result;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmployeeCode.Text.Trim()))
            {
                    MessageBox.Show("员工号不能为空！请点击生成按钮！");
                MessageBox.Show("请确认密码是否正确！");
                return;
            }
            if (string.IsNullOrEmpty(txtFullName.Text.Trim()))
            {
                MessageBox.Show("员工姓名不能为空！");
                return;
            }

            if (this.employee != null)
            {
                try
                {
                    this.employee.FullName = txtFullName.Text;
                    this.employee.Address = txtAddress.Text;
                    this.employee.Sex = ddlSex.Text == "男" ? 1 : 0;
                    this.employee.Status = (ddlStatus.SelectedItem as UserStatus).ID;
                    this.employee.Telephone = txtTelphone.Text;
                    this.employee.Position = ddlPosition.SelectedItem as Postion;
                    this.employee.Department = ddlDepartment.SelectedItem as Department;
                    this.employee.Login = txtEmployeeCode.Text;
                    this.employee.Age = 20;
                    this.employee.Password = CMS.Common.Utility.Core.Common.Helper.GetMd5Hash(txtConfirmPassword.Text.Trim());

                    this.employeeController.UpdateEmployee(this.employee);
                }
                catch
                {
                }
            }
            else
            {
                Employee employee = new Employee()
                {
                    ID = Guid.NewGuid(),
                    FullName = txtFullName.Text,
                    Address = txtAddress.Text,
                    Sex = ddlSex.Text == "男" ? 1 : 0,
                    Status = (ddlStatus.SelectedItem as UserStatus).ID,
                    Telephone = txtTelphone.Text,
                    Position = ddlPosition.SelectedItem as Postion,
                    Department = ddlDepartment.SelectedItem as Department,
                    Login = txtEmployeeCode.Text,
                    Age = 20,
                    Password = CMS.Common.Utility.Core.Common.Helper.GetMd5Hash(txtConfirmPassword.Text.Trim())
                };
                try
                {
                    ContentResult result = this.employeeController.CreateEmployee(employee) as ContentResult;

                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btPhotopInsert_Click(object sender, EventArgs e)
        {
            string fileFullName = string.Empty;

            DialogResult result = fileDialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                fileFullName = fileDialog.FileName;
            }

            if (string.IsNullOrEmpty(fileFullName))
            {
                return;
            }

            Image img = Image.FromFile(fileFullName);

            this.pbPicture.Image = img;

        }
    }
}
