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
    using CMS.Interface.Model;
    using CMS.Module.Shell.Core;

    public partial class CategorySet : CMSForm
    {
        private Employee employee = null;

        private DishController controller = null;

        public CategorySet(Employee employee)
        {
            InitializeComponent();
            this.employee = employee;
            this.controller = this.ControllerManager[typeof(DishController)] as DishController;
            LoadDishType();
        }

        private void LoadDishType()
        {
            lvDishTypeList.Items.Clear();

            ICollection<IModel> modelCollection = this.controller.GetAllDishTypes().GetModelResults();

            ListViewItem lvt = null;

            foreach (IModel model in modelCollection)
            {
                DishType type = model as DishType;

                lvt = new ListViewItem(type.EnumCode);
                lvt.Tag = type.ID;
                lvt.SubItems.Add(type.EnumValue);

                lvt.SubItems.Add(type.Remark);
                lvDishTypeList.Items.Add(lvt);
            }

            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            CategorySetEdit CSE = new CategorySetEdit(employee);
            DialogResult result = CSE.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                LoadDishType();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem subItem in this.lvDishTypeList.Items)
            {
                if (subItem.Checked)
                {
                    
                }
            }
        }
    }
}
