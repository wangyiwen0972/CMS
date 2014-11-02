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

    public partial class CategorySetEdit : CMSForm
    {
        private Employee employee = null;

        public DishType Type { get; internal set; }

        private DishController controller = null;

        public CategorySetEdit(Employee employee)
        {
            InitializeComponent();

            this.employee = employee;
            this.controller = this.ControllerManager[typeof(DishController)] as DishController;
        }

        private void btCategorySetEditSave_Click(object sender, EventArgs e)
        {
            if (txtCode.Text.Length == 0)
            {
                MessageBox.Show("代码不能为空");
                return;
            }
            if (txtName.Text.Length == 0)
            {
                MessageBox.Show("名称不能为空");
                return;
            }

            try
            {
                DishType dishType = new DishType()
                {
                    ID = Guid.NewGuid(),
                    EnumCode = txtCode.Text,
                    EnumValue = txtName.Text,
                    Remark = txtRemark.Text
                };
                controller.CreateDishType(dishType);

                this.Type = dishType;

                MessageBox.Show("保存成功！");
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }             

    }
}
