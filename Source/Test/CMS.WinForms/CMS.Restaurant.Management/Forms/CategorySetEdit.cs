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

    public partial class CategorySetEdit : CMSForm
    {
        private Employee employee = null;

        public DishType Type { get; internal set; }

        private DishController controller = null;

        public CategorySetEdit():this(null)
        {
            
        }

        public CategorySetEdit(DishType dishType)
        {
            InitializeComponent();
            this.Type = dishType;
            this.employee = Login;
            this.controller = this.ControllerManager[typeof(DishController)] as DishController;

            if (dishType != null)
            {
                this.txtCode.Text = dishType.EnumCode;
                this.txtName.Text = dishType.EnumValue;
                this.txtRemark.Text = dishType.Remark;
            }
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
                if (this.Type == null)
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
                }
                else
                {
                    this.Type.EnumCode = txtCode.Text;
                    this.Type.EnumValue = txtName.Text;
                    this.Type.Remark = txtRemark.Text;

                    controller.UpdateDishType(this.Type);
                }

                MessageBox.Show("保存成功！");

                this.DialogResult = System.Windows.Forms.DialogResult.OK;

                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }

        private void btnCreateCode_Click(object sender, EventArgs e)
        {
            string code = this.controller.GenerateDishTypeCode().Result;

            txtCode.Text = code.Trim();
        }             

    }
}
