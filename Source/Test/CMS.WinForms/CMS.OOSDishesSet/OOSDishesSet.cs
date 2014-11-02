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
using CMS.Interface.Model;
using CMS.Common.Model;
using CMS.Common.Controller.Core;
using CMS.WinForms.OSK;

namespace CMS.WinForms
{
    public partial class OOSDishesSet : CMSForm
    {
        private DishController dishController = null;
        private EntranceController entranceController = null;

        private ICollection<Dish> dishCollection = null;

        private Entrance entrance = null;

        public OOSDishesSet()
        {
            InitializeComponent();

            this.dishController = ControllerManager[typeof(DishController)] as DishController;
            this.entranceController = ControllerManager[typeof(EntranceController)] as EntranceController;

            LoadDataCollection();

            FillDataCollectionToControl();
        }

        private void LoadDataCollection()
        {
            if (entrance == null)
            {
                this.entrance = this.entranceController.GetEntrance(Machine.EntranceID).Model as Entrance;

                this.entranceController.GetLimitationCollection(this.entrance);

                foreach (EntranceLimitationDetail limitation in this.entrance.LimitationCollection)
                {
                    this.entranceController.GetDishTypeByLimitation(limitation);
                }
            }

            if (dishCollection == null)
            {
                dishCollection = new List<Dish>();

                ICollection<CMS.Interface.Model.IModel> dishes = this.dishController.GetAllDishes().GetModelResults();

                foreach (Dish model in dishes)
                {
                    if (model.Type == null)
                    {
                        this.dishController.GetDishType(model);
                    }

                    if (this.entrance.LimitationCollection != null)
                    {

                        var find = from c in this.entrance.LimitationCollection where model.Type.ID == c.DishType.ID select c;

                        if (find != null && find.Count() > 0)
                        {
                            dishCollection.Add(model);
                        }
                    }
                }
            }
            if (dishCollection != null)
            {
                foreach (Dish dish in dishCollection)
                {
                    this.dishController.GetOOSDish(dish);
                }
            }
        }

        private void FillDataCollectionToControl()
        {
            Font font = new System.Drawing.Font("微软雅黑", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            

            foreach (Dish dish in this.dishCollection)
            {
                OOSDish oosDish = this.dishController.GetOOSDish(dish);

                if (oosDish == null)
                {
                    int index = dataGridView1.Rows.Add();

                    DataGridViewRow row = dataGridView1.Rows[index];

                    row.Tag = dish;

                    row.ReadOnly = true;
                    row.Cells[0].Value = dish.Name;
                    row.Cells[1].Value = "...";
                    row.Cells[2].Value = "...";
                    row.Cells[3].Value = "...";
                    row.Cells[4].Value = "创建";
                }
                else
                {
                    int index = dataGridView1.Rows.Add();

                    DataGridViewRow row = dataGridView1.Rows[index];
                    row.Tag = dish;

                    row.ReadOnly = true;
                    row.Cells[0].Value = dish.Name;
                    row.Cells[1].Value = oosDish.Quantity;
                    row.Cells[1].ReadOnly = false;
                    row.Cells[2].Value = oosDish.LastUpdatedTime.ToString("yyyy-MM-dd hh:mm:ss");
                    row.Cells[3].Value = oosDish.LastUpdatedBy.FullName;
                    row.Cells[4].Value = "更新";
                }
                
            }
        }

        void btn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void UpdateOOSDish()
        {

        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            bool isFound = false;

            //foreach (ListViewItem lvi in this.listView1.Items)
            //{
            //    Rectangle rect = lvi.GetBounds(ItemBoundsPortion.ItemOnly);
            //    if (rect.Contains(e.Location))
            //    {
            //        Rectangle subRect = lvi.SubItems[0].Bounds;
            //        if (subRect.Contains(e.Location))
            //        {
            //            if (!frmOSK.Visible)
            //            {
            //                int x = this.Left - frmOSK.Width / 4;

            //                int txtYPoint = this.listView1.PointToScreen(e.Location).Y;

            //                frmOSK.Location = new Point(x, txtYPoint + this.listView1.Height);

            //                frmOSK.Visible = true;

            //                isFound = true;
            //                break;
            //            }
            //        }
            //    }
            //}
            if (!isFound)
            {
                frmOSK.Visible = false;
            }
                
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            //bool isFound = false;

            //if (e.IsSelected)
            //{
            //    if (e.Item.SubItems[1].Bounds.Contains(e.Item.Position))
            //    {
            //        if (!frmOSK.Visible)
            //        {
            //            int x = this.Left - frmOSK.Width / 4;

            //            int txtYPoint = this.listView1.PointToScreen(e.Item.Position).Y;

            //            frmOSK.Location = new Point(x, txtYPoint + this.listView1.Height);

            //            frmOSK.Visible = true;

            //            isFound = true;
            //        }
            //    }
            //}
            //if (!isFound)
            //{
            //    this.frmOSK.Visible = false;
            //}
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                if (row.Cells[4].Value.ToString() == "更新")
                {
                    Dish dish = row.Tag as Dish;

                    int iQuantity;

                    if (!int.TryParse(row.Cells[1].Value.ToString(), out iQuantity))
                    {
                        MessageBox.Show("必须输入有效数字!");
                        row.Cells[1].Value = string.Empty;
                        dataGridView1.CurrentCell = row.Cells[1];
                        row.DataGridView.EditMode = DataGridViewEditMode.EditOnEnter;
                        row.DataGridView.BeginEdit(true);
                        return;
                    }

                    OOSDish oosDish = new OOSDish()
                    {
                        DishID = dish.ID,
                        LastUpdatedBy = this.Login,
                        LastUpdatedTime = DateTime.Now,
                        MachineID = Machine.ID,
                        Quantity = Convert.ToInt16(row.Cells[1].Value)
                    };

                    OOSDish oldOOSDish = this.dishController.GetOOSDish(dish);
                    if (oldOOSDish == null)
                    {
                        this.dishController.CreateOOSDish(dish, oosDish);
                    }
                    else
                    {
                        if (oldOOSDish.Quantity != oosDish.Quantity)
                        {
                            this.dishController.UpdateOOSDish(dish, oosDish);
                        }
                    }

                    row.Cells[2].Value = oosDish.LastUpdatedTime.ToString("yyyy-MM-dd hh:mm:ss");
                    row.Cells[3].Value = this.Login.FullName;
                }
                else
                {
                    row.Cells[1].ReadOnly = false;
                    row.Cells[1].Value = string.Empty;
                    dataGridView1.CurrentCell = row.Cells[1];
                    row.DataGridView.EditMode = DataGridViewEditMode.EditOnEnter;
                    row.DataGridView.BeginEdit(true);
                }
            }
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!e.Cancel)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                Rectangle rect = row.Cells[e.ColumnIndex].ContentBounds;
                Point point = dataGridView1.PointToScreen(rect.Location);

                int height = rect.Height == 0 ? 20 * (e.RowIndex + 1 + 1 + 1) : rect.Height * (e.RowIndex + 1 + 1 + 1);

                frmOSK.Location = new Point(point.X, point.Y + height);
                frmOSK.Visible = true;
            }
            else
            {
                frmOSK.Visible = false;
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

            int iQuantity;

            if (int.TryParse(row.Cells[1].Value.ToString(), out iQuantity))
            {
                row.Cells[4].Value = "更新";
                if (frmOSK.Visible) frmOSK.Visible = false;
            }
            else
            {
                if (frmOSK.Visible) frmOSK.Visible = false;

                MessageBox.Show("请填入有效数字!");

                if (row.DataGridView.CancelEdit())
                {
                    row.Cells[1].Value = 0;
                }
            }
            

        }

    }
}
