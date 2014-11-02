namespace CMS.WinForms.Background
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Configuration;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using CMS.Common.Model;
    using CMS.Common.Controller.Core;
    using CMS.Common.Utility.Core.Generater;

    public partial class DishSetEdit : CMS.Module.Shell.Core.CMSForm
    {
        private Dish dishModel = null;
        private DishController dishController = null;

        private const string DisplayMember = "EnumValue";
        private const string ValueMember = "EnumCode";

        private const string UnitDisplayMember = "Name";
        private const string UnitValueMember = "Code";

        private readonly string imageRoot;

        public Dish DishModel
        {
            get { return dishModel; }
        }

        public DishSetEdit():this(null)
        {
            
        }

        public DishSetEdit(Dish dish)
            : base()
        {
            this.dishModel = dish;
            this.dishController = this.ControllerManager[typeof(DishController)] as DishController;

            this.imageRoot = ConfigurationManager.AppSettings["imageRoot"];

            

            InitializeComponent();

            this.FillCollectionToControl();
        }

        private void FillCollectionToControl()
        {
            cbDishType.DisplayMember = DisplayMember;
            cbDishType.ValueMember = ValueMember;

            cbStatus.DisplayMember = DisplayMember;
            cbStatus.ValueMember = ValueMember;

            cbDishStyle.DisplayMember = DisplayMember;
            cbDishStyle.ValueMember = ValueMember;

            cbUnit.DisplayMember = UnitDisplayMember;
            cbUnit.ValueMember = UnitValueMember;

            cbUnit2.DisplayMember = UnitDisplayMember;
            cbUnit2.ValueMember = UnitValueMember;

            cbUnit3.DisplayMember = UnitDisplayMember;
            cbUnit3.ValueMember = UnitValueMember;

            cbUnit4.DisplayMember = UnitDisplayMember;
            cbUnit4.ValueMember = UnitValueMember;

            foreach (DishType type in this.dishController.GetAllDishTypes().GetModelResults())
            {
                cbDishType.Items.Add(type);
            }

            foreach (DishStatus status in this.dishController.GetAllDishStatus().GetModelResults())
            {
                cbStatus.Items.Add(status);
            }

            foreach (DishStyle style in this.dishController.GetAllDishStyles().GetModelResults())
            {
                cbDishStyle.Items.Add(style);
            }

            foreach (Unit unit in this.dishController.GetAllUnit().GetModelResults())
            {
                cbUnit.Items.Add(unit);
                cbUnit2.Items.Add(unit);
                cbUnit3.Items.Add(unit);
                cbUnit4.Items.Add(unit);
            }

        }

        private void DishSetEdit_Load(object sender, EventArgs e)
        {

        }

        private bool Validate()
        {
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                MessageBox.Show("菜品代码不能为空！");
                return false;
            }
            if (string.IsNullOrEmpty(cbStatus.Text))
            {
                MessageBox.Show("菜品状态不能为空！");
                return false;
            }
            if (string.IsNullOrEmpty(txtDishName.Text))
            {
                MessageBox.Show("菜品名称不能为空！");
                return false;
            }
            if (string.IsNullOrEmpty(txtShortID.Text))
            {
                MessageBox.Show("菜品助记码不能为空！");
                return false;
            }
            if (string.IsNullOrEmpty(cbDishType.Text))
            {
                MessageBox.Show("菜品大类不能为空！");
                return false;
            }
            if (string.IsNullOrEmpty(cbDishStyle.Text))
            {
                MessageBox.Show("菜品菜系不能为空！");
                return false;
            }
            if (string.IsNullOrEmpty(cbUnit.Text))
            {
                MessageBox.Show("菜品单位不能为空！");
                return false;
            }
            if (string.IsNullOrEmpty(cbUnit.Text))
            {
                MessageBox.Show("菜品单位不能为空！");
                return false;
            }
            if (string.IsNullOrEmpty(txtPrice.Text))
            {
                MessageBox.Show("菜品单价不能为空！");
                return false;
            }
            return true;
        }

        private ICollection<DishUnitPriceSetting> PriceSettingCollection(Dish dish)
        {
            List<DishUnitPriceSetting> priceCollection = new List<DishUnitPriceSetting>();

            if (dish.UnitPriceSetting == null || dish.UnitPriceSetting.Count == 0)
            {
                DishUnitPriceSetting priceSetting = new DishUnitPriceSetting()
                {
                    GUID = Guid.NewGuid(),
                    DishID = dish.ID,
                    Price = Convert.ToDecimal(txtPrice.Text),
                    UnitID = cbUnit.SelectedItem as Unit
                };

                priceCollection.Add(priceSetting);

                if (cbUnit2.Enabled)
                {
                    priceSetting = new DishUnitPriceSetting()
                    {
                        DishID = dish.ID,
                        Price = Convert.ToDecimal(txtPrice2.Text),
                        UnitID = cbUnit2.SelectedItem as Unit
                    };
                    priceCollection.Add(priceSetting);
                }
                else
                {
                    return priceCollection;
                }

                if (cbUnit3.Enabled)
                {
                    priceSetting = new DishUnitPriceSetting()
                    {
                        DishID = dish.ID,
                        Price = Convert.ToDecimal(txtPrice3.Text),
                        UnitID = cbUnit2.SelectedItem as Unit
                    };
                    priceCollection.Add(priceSetting);
                }
                else
                {
                    return priceCollection;
                }

                if (cbUnit4.Enabled)
                {
                    priceSetting = new DishUnitPriceSetting()
                    {
                        DishID = dish.ID,
                        Price = Convert.ToDecimal(txtPrice4.Text),
                        UnitID = cbUnit4.SelectedItem as Unit
                    };
                    priceCollection.Add(priceSetting);
                }
                else
                {
                    return priceCollection;
                }
            }
            return priceCollection;
        }

        private void Save()
        {
            if (Validate())
            {
                if (dishModel == null)
                {
                    dishModel = new Dish()
                    {
                        ID = Guid.NewGuid(),
                        Code = txtCode.Text,
                        ImageUrl = string.IsNullOrEmpty(pbDishImage.ImageLocation) ? "" : pbDishImage.ImageLocation,
                        Introduction = rtbIntroduce.Text,
                        Name = txtDishName.Text,
                        ShortID = txtShortID.Text,
                        Status = cbStatus.SelectedItem as DishStatus,
                        Style = cbDishStyle.SelectedItem as DishStyle,
                        Title = string.IsNullOrEmpty(txtTitle.Text) ? "" : txtTitle.Text,
                        Type = cbDishType.SelectedItem as DishType,
                        CreatedBy = this.Login,
                        CreatedDate = DateTime.Now,
                        ChangedBy = this.Login,
                        ChangedDate = DateTime.Now
                    };

                    ICollection<DishUnitPriceSetting> priceCollection = this.PriceSettingCollection(dishModel);

                    dishModel.UnitPriceSetting = priceCollection;

                    try
                    {
                        this.dishController.CreateDish(dishModel);

                        this.dishController.CreatePriceForDish(dishModel, priceCollection);

                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else
                {
                    dishModel = new Dish()
                    {
                        ImageUrl = pbDishImage.ImageLocation,
                        Introduction = rtbIntroduce.Text,
                        Name = txtDishName.Text,
                        ShortID = txtShortID.Text,
                        Status = cbStatus.SelectedItem as DishStatus,
                        Style = cbDishStyle.SelectedItem as DishStyle,
                        Title = txtTitle.Text,
                        Type = cbDishType.SelectedItem as DishType,
                        CreatedBy = this.Login,
                        CreatedDate = DateTime.Now,
                        ChangedBy = this.Login,
                        ChangedDate = DateTime.Now
                    };

                    ICollection<DishUnitPriceSetting> priceCollection = this.PriceSettingCollection(dishModel);
                    dishModel.UnitPriceSetting = priceCollection;

                    try
                    {
                        this.dishController.UpdateDish(dishModel);

                        this.dishController.UpdatePriceForDish(dishModel, priceCollection);
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }

               
            }
        }

        #region control event
        private void btnCode_Click(object sender, EventArgs e)
        {
            try
            {
                string code = this.dishController.GenerateDishCode().Result;
                txtCode.Text = code.Trim();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnShortID_Click(object sender, EventArgs e)
        {
            try
            {
                string code = this.dishController.GenerateDishShortID(txtDishName.Text).Result;
                txtShortID.Text = code.Trim();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void cbEnable2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cbCheck = sender as CheckBox;
            if (cbCheck.Checked)
            {
                txtPrice2.Enabled = true;
                cbUnit2.Enabled = true;
            }
            else
            {
                txtPrice2.Enabled = false ;
                cbUnit2.Enabled = false;
            }
        }

        private void cbEnable3_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cbCheck = sender as CheckBox;
            if (cbCheck.Checked)
            {
                txtPrice3.Enabled = true;
                cbUnit3.Enabled = true;
            }
            else
            {
                txtPrice3.Enabled = false;
                cbUnit3.Enabled = false;
            }
        }

        private void cbEnable4_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cbCheck = sender as CheckBox;
            if (cbCheck.Checked)
            {
                txtPrice4.Enabled = true;
                cbUnit4.Enabled = true;
            }
            else
            {
                txtPrice4.Enabled = false;
                cbUnit4.Enabled = false;
            }
        }

        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        

        

        





    }
}
