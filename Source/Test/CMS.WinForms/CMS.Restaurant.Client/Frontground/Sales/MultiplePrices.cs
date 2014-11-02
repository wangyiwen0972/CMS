namespace CMS.Restaurant.Client.Sales
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using CMS.Module.Shell.Core;
    using CMS.Common.Model;
    using ControllerCore = CMS.Common.Controller.Core;
    using UtilityCore = CMS.Common.Utility.Core;
    using ResultCore = CMS.Common.ViewResult.Core;

    public partial class MultiplePrices : CMSForm
    {
        private ControllerCore.DishController dishController = null;

        private DishUnitPriceSetting selectedPirceSetting = null;
        public DishUnitPriceSetting SelectedPirceSetting
        {
            get { return selectedPirceSetting; }
        }

        public bool IsDisplayed { get; private set; }

        private Dish currentDish = null;

        private const int maxPriceCount = 4;

        public MultiplePrices(Dish dish):base()
        {
            this.currentDish = dish;
            this.dishController = this.ControllerManager[typeof(ControllerCore.DishController)] as ControllerCore.DishController;

            InitializeComponent();

            LoadPriceSettingToControl();
        }

        private void LoadPriceSettingToControl()
        {
            if (currentDish.UnitPriceSetting == null)
            {
                this.dishController.GetPriceUnitSettingCollection(currentDish);
            }

            if (currentDish.UnitPriceSetting != null && currentDish.UnitPriceSetting.Count > 0)
            {
                for (int i = 1; i <= currentDish.UnitPriceSetting.Count; i++)
                {
                    if (i == maxPriceCount) break;

                    DishUnitPriceSetting priceSetting = currentDish.UnitPriceSetting.ElementAt(i - 1);

                    this.dishController.GetUnitByPriceSetting(priceSetting);

                    #region
                    switch (i)
                    {
                        case 1:
                            {
                                btMultiplePricesUnit1.Visible = true;
                                lblPrice1.Visible = true;
                                lblPrice1.Text = currentDish.UnitPriceSetting.ElementAt(i - 1).Price.ToString();
                                lblUnit1.Visible = true;
                                lblUnit1.Text = currentDish.UnitPriceSetting.ElementAt(i - 1).UnitID.Name;
                                btMultiplePricesUnit1.Tag = currentDish.UnitPriceSetting.ElementAt(i - 1);
                                break;
                            }
                        case 2:
                            {
                                btMultiplePricesUnit2.Visible = true;
                                lblPrice2.Visible = true;
                                lblPrice2.Text = currentDish.UnitPriceSetting.ElementAt(i - 1).Price.ToString();
                                lblUnit2.Visible = true;
                                lblUnit2.Text = currentDish.UnitPriceSetting.ElementAt(i - 1).UnitID.Name;
                                btMultiplePricesUnit2.Tag = currentDish.UnitPriceSetting.ElementAt(i - 1);
                                break;
                            }
                        case 3:
                            {
                                btMultiplePricesUnit3.Visible = true;
                                lblPrice3.Visible = true;
                                lblPrice3.Text = currentDish.UnitPriceSetting.ElementAt(i - 1).Price.ToString();
                                lblUnit3.Visible = true;
                                lblUnit3.Text = currentDish.UnitPriceSetting.ElementAt(i - 1).UnitID.Name;
                                btMultiplePricesUnit3.Tag = currentDish.UnitPriceSetting.ElementAt(i - 1);
                                break;
                            }
                        case 4:
                            {
                                btMultiplePricesUnit4.Visible = true;
                                lblPrice4.Visible = true;
                                lblPrice4.Text = currentDish.UnitPriceSetting.ElementAt(i - 1).Price.ToString();
                                lblUnit4.Visible = true;
                                lblUnit4.Text = currentDish.UnitPriceSetting.ElementAt(i - 1).UnitID.Name;
                                btMultiplePricesUnit4.Tag = currentDish.UnitPriceSetting.ElementAt(i - 1);
                                break;
                            }
                    }
                    #endregion
                }
                IsDisplayed = true;
            }
            else
            {
                IsDisplayed = false;
            }
        }

        private void btMultiplePrices_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            this.selectedPirceSetting = button.Tag as DishUnitPriceSetting;

            this.Close();
        }

        


    }
}
