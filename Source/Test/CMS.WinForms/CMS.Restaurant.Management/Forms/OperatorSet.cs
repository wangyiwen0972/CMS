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
    using CMS.Common.Controller.Core;
    using CMS.Common.Model;
    using CMS.Module.Shell.Core;

    public partial class OperatorSet : CMSForm
    {
        private Employee employee = null;

        private EmployeeController employeeController = null;
        private List<Employee> employeeCollection = null;

        public OperatorSet(Employee employee)
        {
            InitializeComponent();
            this.employeeCollection = new List<Employee>();
            this.employee = employee;
            this.employeeController = base.ControllerManager[typeof(EmployeeController)] as EmployeeController;

            this.LoadDataSourceCompleted += OperatorSet_LoadDataSourceCompleted;

            this.AddEmployeeToListview();
        }

        void OperatorSet_LoadDataSourceCompleted(object sender, EventArgs e)
        {
            if (sender is ListView)
            {
                ListView lView = sender as ListView;

                foreach (ListViewItem lvi in lView.Items)
                {
                    ListViewItem.ListViewSubItem subItem = lvi.SubItems[2];

                    subItem.Text = subItem.Text == "0" ? "男" : "女";
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            OperatorSetEdit frmEdit = new OperatorSetEdit();

            DialogResult dialog = frmEdit.ShowDialog();

            if (dialog == System.Windows.Forms.DialogResult.OK)
            {
                AddEmployeeToListview();
            }
        }

        private void AddEmployeeToListview()
        {
            this.lvEmployeeList.Items.Clear();

            this.employeeCollection = new List<Employee>();

            foreach (Employee tmpEmployee in this.employeeController.GetAllEmployee().GetModelResults())
            {
                this.employeeCollection.Add(tmpEmployee);
            }

            foreach (Employee employee in this.employeeCollection)
            {
                //ListViewItem lviEmployee = new ListViewItem(employee.Login);

                //ListViewItem.ListViewSubItem subFullName = new ListViewItem.ListViewSubItem(lviEmployee, employee.FullName);
                //ListViewItem.ListViewSubItem subSex = new ListViewItem.ListViewSubItem(lviEmployee, employee.Sex == 0 ? "男" : "女");

                employeeController.GetDepartmentForEmployee(employee);
                employeeController.GetPositionForEmployee(employee);

                

                //ListViewItem.ListViewSubItem subDepartment = new ListViewItem.ListViewSubItem(lviEmployee, employee.Department.EnumValue);

                //lviEmployee.SubItems.AddRange(new ListViewItem.ListViewSubItem[] { subFullName,subSex,subDepartment});

                //this.lvEmployeeList.Items.Add(lviEmployee);
            }
            base.LoadDataSource(this.employeeCollection, this.lvEmployeeList);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvEmployeeList.Items.Count == 0) { return; }
            foreach (ListViewItem lvi in this.lvEmployeeList.Items)
            {
                if (!lvi.Checked) continue;

                var employee = from m in this.employeeCollection where m.Login == lvi.Text select m;

                if (employee != null)
                {
                    try
                    {
                        employeeController.DeleteEmployee(employee.ElementAt(0));
                        this.employeeCollection.Remove(employee.ElementAt(0));
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            AddEmployeeToListview();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Employee employee = null;

            foreach (ListViewItem lvi in this.lvEmployeeList.Items)
            {
                if (!lvi.Checked) continue;
                var tmpEmployee = from m in this.employeeCollection where m.Login == lvi.Text select m;
                employee = tmpEmployee.ElementAt(0);
            }
            if (employee == null)
            {
                MessageBox.Show("请先选择！");
                return;
            }
             OperatorSetEdit frmOperator = new OperatorSetEdit(employee);
             DialogResult result = frmOperator.ShowDialog();
             if (result == System.Windows.Forms.DialogResult.OK)
             {
                 AddEmployeeToListview();
             }
        }

        private void lvEmployeeList_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            
        }
    }
}
