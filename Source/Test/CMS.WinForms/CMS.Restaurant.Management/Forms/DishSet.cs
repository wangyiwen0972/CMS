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
    using CMS.Module.Shell.Core;
    using CMS.Common.Controller.Core;
    using CMS.Common.Model;
    using CMS.Common.ViewResult.Core;
    using System.Threading;

    public partial class DishSet : CMSForm
    {
        private DishController dishController = null;
        private List<Dish> dishList = null;
        private BackgroundWorker worker = null;

        public DishSet()
        {
            InitializeComponent();

            this.dishController = base.ControllerManager[typeof(DishController)] as DishController;
            this.dishList = new List<Dish>();
            
            worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;

            worker.RunWorkerAsync();
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.lvDishListview.Items.Clear();

            foreach (Dish dish in this.dishList)
            {
                this.CreateListViewItem(dish);
            }

            pbLoading.Visible = false;
        }

        private void CreateListViewItem(Dish dish)
        {
            ListViewItem dishItem = new ListViewItem(dish.Code);
            dishItem.Tag = dish;
            ListViewItem.ListViewSubItem subItemName = new ListViewItem.ListViewSubItem(dishItem, dish.Name);

            ListViewItem.ListViewSubItem subItemShotName = new ListViewItem.ListViewSubItem(dishItem, dish.ShortID);

            ListViewItem.ListViewSubItem subItemType = new ListViewItem.ListViewSubItem(dishItem, dish.Type.EnumValue);

            ListViewItem.ListViewSubItem subItemStyle = new ListViewItem.ListViewSubItem(dishItem, dish.Style.EnumValue);
            ListViewItem.ListViewSubItem subItemDiscount = new ListViewItem.ListViewSubItem(dishItem, dish.Discount.ToString());
            ListViewItem.ListViewSubItem subItemPic = new ListViewItem.ListViewSubItem(dishItem, dish.ImageUrl);
            ListViewItem.ListViewSubItem subItemStatus = new ListViewItem.ListViewSubItem(dishItem, dish.Status.EnumValue);
            ListViewItem.ListViewSubItem subItemIntroduction = new ListViewItem.ListViewSubItem(dishItem, dish.Introduction);

            dishItem.SubItems.AddRange(new ListViewItem.ListViewSubItem[] { subItemShotName, subItemName, subItemDiscount, subItemType, subItemStyle, subItemPic, subItemStatus, subItemIntroduction });

            lvDishListview.Items.Add(dishItem);
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            ICollection<DishType> dishTypes = this.dishController.GetAllDishTypeCollection();

            foreach (DishType type in dishTypes)
            {
                cbDishType.Items.Add(type);
            }
            cbDishType.DisplayMember = "enumvalue";
            cbDishType.ValueMember = "enumcode";

            cbDishType.SelectedIndex = 0;

            ICollection<Interface.Model.IModel> dishCollection = this.dishController.GetAllDishes().GetModelResults();

            this.dishList = new List<Dish>();
            foreach (Dish dish in dishCollection)
            {
                //获取菜品状态
                this.dishController.GetDishStatus(dish);
                //获取菜品菜系
                this.dishController.GetDishStyle(dish);
                //获取菜品大类
                this.dishController.GetDishType(dish);

                this.dishList.Add(dish);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            DishSetEdit dishSetEdit = new DishSetEdit();

            DialogResult result = dishSetEdit.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                worker.RunWorkerAsync();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in this.lvDishListview.Items)
            {
                if (lvi.Checked)
                {
                    try
                    {
                        this.dishController.DeleteDishByModel(lvi.Tag as Dish);
                    }
                    catch
                    {
                    }
                }
            }
            worker.RunWorkerAsync();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Dish selectedDish = null;

            foreach (ListViewItem lvi in this.lvDishListview.Items)
            {
                if (lvi.Checked)
                {
                    selectedDish = lvi.Tag as Dish;
                    break;
                }
            }
            if(selectedDish == null ) return;
            DishSetEdit dishSetEdit = new DishSetEdit(selectedDish);
            DialogResult result = dishSetEdit.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                worker.RunWorkerAsync();
            }
        }

        private void cbDishType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;

            if (cb.Text != "--全部--")
            {
                var lookup = from tp in dishList where tp.Type.EnumValue.Equals(cb.Text, StringComparison.CurrentCultureIgnoreCase) select tp;

                this.lvDishListview.Items.Clear();

                if (lookup.Count() > 0)
                {
                    foreach (Dish dish in lookup)
                    {
                        CreateListViewItem(dish);
                    }
                }
            }
            else
            {
                this.lvDishListview.Items.Clear();

                foreach (Dish dish in dishList)
                {
                    CreateListViewItem(dish);
                }
            }
        }

    }
}
