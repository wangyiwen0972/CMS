namespace CMS.Restaurant.Management
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
            this.LoadDishToControl();
        }

        private void LoadDishToControl()
        {
            if (this.dishModel != null)
            {
                txtCode.Text = this.dishModel.Code;
                txtDishName.Text = this.dishModel.Name;
                txtShortID.Text = this.dishModel.ShortID;
                txtTitle.Text = this.dishModel.Title;

                cbDishType.Text = this.dishModel.Type.EnumValue;
                cbStatus.Text = this.dishModel.Status.EnumValue;
                if (this.dishModel.Style != null) cbDishStyle.Text = this.dishModel.Style.EnumValue;

                try
                {
                    this.dishController.GetPriceUnitSettingCollection(this.dishModel);
                    if (this.dishModel.UnitPriceSetting != null && this.dishModel.UnitPriceSetting.Count > 0)
                    {
                        DishUnitPriceSetting priceSetting = this.dishModel.UnitPriceSetting.ElementAt(0);
                        txtPrice1.Text = priceSetting.Price.ToString("f2");
                        cbUnit1.Text = priceSetting.UnitID.Name;

                        if (this.dishModel.UnitPriceSetting.Count > 1)
                        {
                            priceSetting = this.dishModel.UnitPriceSetting.ElementAt(1);
                            txtPrice2.Text = priceSetting.Price.ToString("f2");
                            cbUnit2.Text = priceSetting.UnitID.Name;
                        }

                        if (this.dishModel.UnitPriceSetting.Count > 2)
                        {
                            priceSetting = this.dishModel.UnitPriceSetting.ElementAt(2);
                            txtPrice3.Text = priceSetting.Price.ToString("f2");
                            cbUnit3.Text = priceSetting.UnitID.Name;
                        }
                        if (this.dishModel.UnitPriceSetting.Count > 3)
                        {
                            priceSetting = this.dishModel.UnitPriceSetting.ElementAt(3);
                            txtPrice4.Text = priceSetting.Price.ToString("f2");
                            cbUnit4.Text = priceSetting.UnitID.Name;
                        }
                    }
                }
                catch
                {
                }
            }
        }

        private void FillCollectionToControl()
        {
            cbDishType.DisplayMember = DisplayMember;
            cbDishType.ValueMember = ValueMember;

            cbStatus.DisplayMember = DisplayMember;
            cbStatus.ValueMember = ValueMember;

            cbDishStyle.DisplayMember = DisplayMember;
            cbDishStyle.ValueMember = ValueMember;

            cbUnit1.DisplayMember = UnitDisplayMember;
            cbUnit1.ValueMember = UnitValueMember;

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
                cbUnit1.Items.Add(unit);
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
            //if (string.IsNullOrEmpty(cbDishStyle.Text))
            //{
            //    MessageBox.Show("菜品菜系不能为空！");
            //    return false;
            //}
            if (string.IsNullOrEmpty(cbUnit1.Text))
            {
                MessageBox.Show("菜品单位不能为空！");
                return false;
            }
            
            if (string.IsNullOrEmpty(cbUnit1.Text))
            {
                MessageBox.Show("菜品单位不能为空！");
                return false;
            }
            if (string.IsNullOrEmpty(txtPrice1.Text))
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
                    Price = Convert.ToDecimal(txtPrice1.Text),
                    UnitID = cbUnit1.SelectedItem as Unit
                };

                priceCollection.Add(priceSetting);

                if (cbUnit2.Enabled)
                {
                    priceSetting = new DishUnitPriceSetting()
                    {
                        GUID = Guid.NewGuid(),
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
                        GUID = Guid.NewGuid(),
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
                        GUID = Guid.NewGuid(),
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
            else
            {
                DishUnitPriceSetting previousPriceSetting = dish.UnitPriceSetting.ElementAt(0);

                DishUnitPriceSetting newPriceSetting = new DishUnitPriceSetting()
                {
                    GUID = previousPriceSetting.GUID,
                    DishID = previousPriceSetting.DishID,
                    Price = Convert.ToDecimal(txtPrice1.Text),
                    UnitID = cbUnit1.SelectedItem as Unit
                };
                priceCollection.Add(newPriceSetting);
                this.dishController.UpdatePriceForDish(dish, priceCollection);

                priceCollection.Clear();

                decimal price2 = decimal.Zero;

                if (dish.UnitPriceSetting.Count > 1)
                {
                    if (decimal.TryParse(txtPrice2.Text, out price2) && !string.IsNullOrEmpty(cbUnit2.Text))
                    {
                        previousPriceSetting = dish.UnitPriceSetting.ElementAt(1);

                        newPriceSetting = new DishUnitPriceSetting()
                        {
                            GUID = previousPriceSetting.GUID,
                            DishID = previousPriceSetting.DishID,
                            Price = Convert.ToDecimal(txtPrice2.Text),
                            UnitID = cbUnit2.SelectedItem as Unit
                        };
                        priceCollection.Add(newPriceSetting);
                        this.dishController.UpdatePriceForDish(dish, priceCollection);
                    }
                }
                else if (decimal.TryParse(txtPrice2.Text, out price2) && !string.IsNullOrEmpty(cbUnit2.Text))
                {
                    newPriceSetting = new DishUnitPriceSetting()
                    {
                        GUID = Guid.NewGuid(),
                        DishID = previousPriceSetting.DishID,
                        Price = Convert.ToDecimal(txtPrice2.Text),
                        UnitID = cbUnit2.SelectedItem as Unit
                    };
                    priceCollection.Add(newPriceSetting);
                    this.dishController.CreatePriceForDish(dish, priceCollection);
                }
                priceCollection.Clear();
                if (dish.UnitPriceSetting.Count > 2)
                {
                    if (decimal.TryParse(txtPrice3.Text, out price2) && !string.IsNullOrEmpty(cbUnit3.Text))
                    {
                        previousPriceSetting = dish.UnitPriceSetting.ElementAt(2);

                        newPriceSetting = new DishUnitPriceSetting()
                        {
                            GUID = previousPriceSetting.GUID,
                            DishID = previousPriceSetting.DishID,
                            Price = Convert.ToDecimal(txtPrice3.Text),
                            UnitID = cbUnit2.SelectedItem as Unit
                        };
                        priceCollection.Add(newPriceSetting);
                        this.dishController.UpdatePriceForDish(dish, priceCollection);
                    }
                }
                else if (decimal.TryParse(txtPrice3.Text, out price2) && !string.IsNullOrEmpty(cbUnit3.Text))
                {
                    newPriceSetting = new DishUnitPriceSetting()
                    {
                        GUID = Guid.NewGuid(),
                        DishID = previousPriceSetting.DishID,
                        Price = Convert.ToDecimal(txtPrice3.Text),
                        UnitID = cbUnit3.SelectedItem as Unit
                    };
                    priceCollection.Add(newPriceSetting);
                    this.dishController.CreatePriceForDish(dish, priceCollection);
                }
                priceCollection.Clear();
                if (dish.UnitPriceSetting.Count > 3)
                {
                    if (decimal.TryParse(txtPrice4.Text, out price2) && !string.IsNullOrEmpty(cbUnit4.Text))
                    {
                        previousPriceSetting = dish.UnitPriceSetting.ElementAt(3);

                        newPriceSetting = new DishUnitPriceSetting()
                        {
                            GUID = previousPriceSetting.GUID,
                            DishID = previousPriceSetting.DishID,
                            Price = Convert.ToDecimal(txtPrice3.Text),
                            UnitID = cbUnit4.SelectedItem as Unit
                        };
                        priceCollection.Add(newPriceSetting);
                        this.dishController.UpdatePriceForDish(dish, priceCollection);
                    }
                }
                else if (decimal.TryParse(txtPrice4.Text, out price2) && !string.IsNullOrEmpty(cbUnit4.Text))
                {
                    newPriceSetting = new DishUnitPriceSetting()
                    {
                        GUID = Guid.NewGuid(),
                        DishID = previousPriceSetting.DishID,
                        Price = Convert.ToDecimal(txtPrice4.Text),
                        UnitID = cbUnit4.SelectedItem as Unit
                    };
                    priceCollection.Add(newPriceSetting);

                    this.dishController.CreatePriceForDish(dish, priceCollection);
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
                        IsSpecialPrice = RBCurrentTrue.Checked == true ? true : false,
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
                    Dish updateDish = new Dish()
                    {
                        ID = dishModel.ID,
                        Code = dishModel.Code,
                        ImageUrl = pbDishImage.ImageLocation,
                        Introduction = rtbIntroduce.Text,
                        Name = txtDishName.Text,
                        ShortID = txtShortID.Text,
                        Status = cbStatus.SelectedItem as DishStatus,
                        Style = cbDishStyle.SelectedItem as DishStyle,
                        Title = txtTitle.Text,
                        Type = cbDishType.SelectedItem as DishType,
                        IsSpecialPrice = RBCurrentTrue.Checked == true ? true : false,
                        CreatedBy = this.Login,
                        CreatedDate = DateTime.Now,
                        ChangedBy = this.Login,
                        ChangedDate = DateTime.Now
                    };
                    this.dishController.GetPriceUnitSettingCollection(updateDish);


                    try
                    {
                        this.dishController.UpdateDish(updateDish);

                        this.PriceSettingCollection(updateDish);

                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
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

        private void RBCurrentTrue_Click(object sender, EventArgs e)
        {
            //foreach (Control control in pnPriceSetting.Controls)
            //{
            //    if(!(control is Label)) control.Enabled = false;
            //}
        }

        private void RBCurrentFalse_Click(object sender, EventArgs e)
        {
            cbUnit1.Enabled = true;
            txtPrice1.Enabled = true;
        }

        private void cbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            string txtPrice = "txtPrice{0}";
            string cbPrice = "cbEnable{0}";

            CheckBox nextPriceCheckBox = null;

            foreach (Control checkbox in this.pnPriceSetting.Controls)
            {
                if (checkbox is CheckBox)
                {
                    int index = 0;
                    if (int.TryParse(cb.Name.Substring(cb.Name.Length - 1, 1), out index))
                    {

                    }
                    if (checkbox.Name.Equals(string.Format(cbPrice, index + 1), StringComparison.CurrentCultureIgnoreCase))
                    {
                        nextPriceCheckBox = checkbox as CheckBox;
                        break;
                    }
                }
            }

            if (nextPriceCheckBox == null) return;

            foreach (Control box in this.pnPriceSetting.Controls)
            {
                if (box is TextBox)
                {
                    if (box.Name.Equals(string.Format(txtPrice, cb.Name.Substring(cb.Name.Length - 1, 1)), StringComparison.CurrentCultureIgnoreCase))
                    {
                        if (box.Text.Trim().Length > 0)
                        {
                            nextPriceCheckBox.Enabled = true;
                            break;
                        }
                    }
                }
            }

        }

        private void txtPrice1_Leave(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (string.IsNullOrEmpty(tb.Text))
            {
                return;
            }

            string cbUnit = "cbUnit{0}";

            string cbPrice = "cbEnable{0}";

            CheckBox nextPriceCheckBox = null;

            foreach (Control checkbox in this.pnPriceSetting.Controls)
            {
                if (checkbox is CheckBox)
                {
                    int index = 0;
                    if (int.TryParse(tb.Name.Substring(tb.Name.Length - 1, 1), out index))
                    {

                    }
                    if (checkbox.Name.Equals(string.Format(cbPrice, index + 1), StringComparison.CurrentCultureIgnoreCase))
                    {
                        nextPriceCheckBox = checkbox as CheckBox;
                        break;
                    }
                }
            }

            if (nextPriceCheckBox == null) return;

            foreach (Control box in this.pnPriceSetting.Controls)
            {
                if (box is ComboBox)
                {
                    if (box.Name.Equals(string.Format(cbUnit, tb.Name.Substring(tb.Name.Length - 1, 1)), StringComparison.CurrentCultureIgnoreCase))
                    {
                        if (box.Text.Trim().Length > 0)
                        {
                            nextPriceCheckBox.Enabled = true;
                            break;
                        }
                    }
                }
            }
        }

        

        

        





    }
}
