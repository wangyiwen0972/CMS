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
    using CMS.Interface.Model;
    using CMS.Common.ViewResult.Core;
    using CMS.Module.Shell.Core;

    public partial class OperatorSetEdit : CMSForm
    {
        private EmployeeController employeeController = null;
        private DepartmentController departController = null;

        private Employee employee = null;

        public Employee NewEmployee
        {
            get;
            private set;
        }


        public OperatorSetEdit(Employee employee)
        {
            InitializeComponent();
            this.employee = employee;
            this.Init();
        }

        private void Init()
        {
            this.employeeController = this.ControllerManager[typeof(EmployeeController)] as EmployeeController;

            this.departController = this.ControllerManager[typeof(DepartmentController)] as DepartmentController;

            ICollection<IModel> statusCollection = this.employeeController.GetAllEmployeeStatus().GetModelResults();

            ICollection<UserStatus> statusList = new List<UserStatus>();

            foreach (UserStatus status in statusCollection)
            {
                statusList.Add(status);
            }
            ddlStatus.DisplayMember = "EnumValue";
            ddlStatus.ValueMember = "Guid";
            ddlStatus.DataSource = statusList;
            
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
            Employee employee = new Employee()
            {
                ID = Guid.NewGuid(),
                Sex = (int)ddlSex.SelectedValue,
                Status = (Guid)ddlStatus.SelectedValue,
                Telephone = txtTelphone.Text
                
            };
        }
    }
}
