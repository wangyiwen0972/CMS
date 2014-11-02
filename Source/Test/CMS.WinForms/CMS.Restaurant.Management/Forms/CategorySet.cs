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
                lvt.Tag = type;
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
            CategorySetEdit CSE = new CategorySetEdit();
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
                    try
                    {
                        DishType dishType = subItem.Tag as DishType;

                        if (Convert.ToBoolean(this.controller.IsDishTypeUsedByEntrance(dishType).Result))
                        {
                            this.controller.DeleteDishType(subItem.Tag as DishType);
                        }
                        else
                        {
                            MessageBox.Show("不能删除此大类，此大类已与档口关联！大类名称：" + dishType.EnumValue);
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            this.LoadDishType();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in this.lvDishTypeList.Items)
            {
                if (lvi.Checked)
                {
                    CategorySetEdit frmCategory = new CategorySetEdit(lvi.Tag as DishType);
                    DialogResult result = frmCategory.ShowDialog();

                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        this.LoadDishType();
                    }
                }
            }
        }
    }
}
