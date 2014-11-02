namespace CMS.WinForms.Sales
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
    using ControllerCore = CMS.Common.Controller.Core;
    using UtilityCore = CMS.Common.Utility.Core;
    using ResultCore = CMS.Common.ViewResult.Core;
    using CMS.Module.Printer.Core;
    using CMS.Module.Shell.Core;
    
    public partial class SalesMain : CMSForm
    {
        private Employee employee;

        private ControllerCore.DishController dishController;

        private ICollection<Dish> dishCollection = null;
        private ICollection<DishType> dishTypeCollection = null;

        private const int DisplayColumnCount = 4;
        private const int speed = 1;

        private bool isTop = true;

        private Timer timer = new Timer();

        public SalesMain()
            : this(null)
        {
            
        }

        public SalesMain(Employee employee)
        {
            this.employee = employee;
            this.dishController = this.ControllerManager[typeof(ControllerCore.DishController)] as ControllerCore.DishController;

            InitializeComponent();

            this.LoadDataCollection();
            
            this.Init();

            FillDishCollectionToControl();

            FillDishTypeCollectionToControl();
        }


        private void Init()
        {
            tlpDish.ColumnCount = DisplayColumnCount;
            tlpCategory.ColumnCount = DisplayColumnCount;

            lbEmployeeNo.Text = this.employee.Login;
            lbEmployeeName.Text = this.employee.FullName;

            #region compute panel position
            int screenHeight = SystemInformation.WorkingArea.Height;

            this.tlpDish.Height = screenHeight / 2;

            this.tlp.Location = new Point(this.tlpDish.Location.X, this.tlpDish.Height);
            this.tlpCategory.Location = new Point(this.tlpDish.Location.X, this.tlpDish.Height + this.tlp.Height);
            this.tlpCategory.Height = screenHeight - this.tlpDish.Height;
            
            
            #endregion

            timer.Tick +=timer_Tick;
            timer.Interval = 50;
        }


        #region Get models from database
        /// <summary>
        /// 加载所有菜品大类
        /// </summary>
        private void LoadDataCollection()
        {
            if (dishCollection == null)
            {
                dishCollection = new List<Dish>();

                ICollection<CMS.Interface.Model.IModel> dishes = (this.dishController.GetAllDishes() as ResultCore.XMLCollectionResults).GetModelResults();

                foreach (CMS.Interface.Model.IModel model in dishes)
                {
                    dishCollection.Add(model as Dish);
                }
            }
            if (dishTypeCollection == null)
            {
                dishTypeCollection = new List<DishType>();

                ICollection<CMS.Interface.Model.IModel> dishTypes = (this.dishController.GetAllDishTypes() as ResultCore.XMLCollectionResults).GetModelResults();

                foreach (CMS.Interface.Model.IModel model in dishTypes)
                {
                    dishTypeCollection.Add(model as DishType);
                }
            }
        }
        #endregion

        #region Fill models to Table Layout Panel
        private void FillDishCollectionToControl()
        {
            this.tlpDish.Controls.Clear();

            int iRowCount = this.dishCollection.Count / this.tlpDish.ColumnCount;

            iRowCount = this.dishCollection.Count % this.tlpDish.ColumnCount == 0 ? iRowCount : iRowCount + 1;

            int index = 0;

            for (int j = 0; j < iRowCount; j++)
            {
                for (int i = 0; i < this.tlpDish.ColumnCount; i++)
                {
                    if (index == dishCollection.Count)
                    {
                        Button btn = CreateItemButton("btnDishUndefined", this.resourceManager.GetString("Undefined"), index);
                        btn.Click += btnUndefined_Click;
                        this.tlpDish.Controls.Add(btn, i, j);
                        break;
                    }
                    else
                    {
                        Dish dish = dishCollection.ElementAt(index) as Dish;

                        Button btn = CreateItemButton("btnDish", dish.Title, index);
                        btn.Click += ItemButton_Click;
                        this.tlpDish.Controls.Add(btn, i, j);
                    }
                    index++;
                }
            }
        }

        private void btnUndefined_Click(object sender, EventArgs e)
        {
            Button btnSender = sender as Button;

            if (btnSender.Name.IndexOf("DishType") > -1)
            {
                CMS.WinForms.Background.CategorySetEdit frmCategorSet = new Background.CategorySetEdit(this.employee);
                DialogResult result = frmCategorSet.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    btnSender.Text = frmCategorSet.Type.EnumValue;
                    btnSender.Click -= btnUndefined_Click;
                    btnSender.Click += ItemButton_Click;
                }
            }
            else
            {
                CMS.WinForms.Background.DishSetEdit frmDishSet = new Background.DishSetEdit();
                DialogResult result = frmDishSet.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    Button btn = sender as Button;
                    btn.Text = frmDishSet.DishModel.Name;
                    btn.Click -= btnUndefined_Click;
                    btn.Click += ItemButton_Click;
                }
            }
        }

        private void FillDishCollectionToControl(DishType dishType)
        {
            this.tlpDish.Controls.Clear();

            int index = 0;

            int rowNumber = index / this.tlpDish.ColumnCount;
            int colunNumber = index % this.tlpDish.ColumnCount;

            foreach (Dish dish in dishCollection)
            {
                if (dish.Type == null) this.dishController.GetDishType(dish);

                if (dish.Type.ID != dishType.ID) continue;
                else
                {
                    index += 1;

                    Button btn = CreateItemButton("btnDish", dish.Title, index);
                    btn.Click += ItemButton_Click;
                    this.tlpDish.Controls.Add(btn, colunNumber,rowNumber + 1);
                }
            }

            Button btnUndefined = CreateItemButton("btnDishUndefined", this.resourceManager.GetString("Undefined"), index);
            btnUndefined.Click += btnUndefined_Click;
            CreateUndefinedButtonForPanel(this.tlpDish, btnUndefined);
        }

        private void FillDishTypeCollectionToControl()
        {
            this.tlpCategory.Controls.Clear();

            int iRowCount = this.dishTypeCollection.Count / this.tlpCategory.ColumnCount;

            iRowCount = this.dishTypeCollection.Count % this.tlpCategory.ColumnCount == 0 ? iRowCount : iRowCount + 1;

            int index = 0;

            for (int j = 0; j < iRowCount; j++)
            {
                
                for (int i = 0; i < this.tlpDish.ColumnCount; i++)
                {
                    if (index == 0)
                    {
                        Button btnCatalogAll = CreateItemButton("btnDishTypeAll", this.resourceManager.GetString("All"), index);
                        btnCatalogAll.Click += CatalogButton_Click;
                        this.tlpCategory.Controls.Add(btnCatalogAll, i, j);
                    }
                    else if (index == dishTypeCollection.Count) break;
                    else
                    {
                        DishType dishType = dishTypeCollection.ElementAt(index) as DishType;

                        Button btn = CreateItemButton("btnDishType", dishType.EnumValue, index);
                        btn.Click += CatalogButton_Click;
                        btn.Tag = dishType;
                        this.tlpCategory.Controls.Add(btn, i, j);
                    }
                    index++;
                }
            }

            Button btnUndefined = CreateItemButton("btnDishTypeUndefinedType", this.resourceManager.GetString("Undefined"), index);
            btnUndefined.Click +=btnUndefined_Click;
            CreateUndefinedButtonForPanel(this.tlpCategory, btnUndefined);
        }
        #endregion

        #region 控件触发事件

        private void btnSwapCard_Click(object sender, System.EventArgs e)
        {
            CardOpen openCard = new CardOpen();

            DialogResult dialog = openCard.ShowDialog();

            if (dialog == System.Windows.Forms.DialogResult.OK)
            {

            }
        }

        private void btnAddMenu_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }
        //Click dish button
        private void ItemButton_Click(object obj, EventArgs e)
        {
            Button btn = obj as Button;
            Dish dish = null;
            foreach (Dish selected in dishCollection)
            {
                if (btn.Text == selected.Title)
                {
                    dish = selected;
                    break;
                }
            }
            if (dish != null)
            {
                int index = dataGridView1.Rows.Add();
                DataGridViewRow row = dataGridView1.Rows[index];
                row.Cells[0].Value = dataGridView1.NewRowIndex;
                row.Cells[1].Value = dish.ShortID;
                row.Cells[2].Value = dish.Title;
                row.Cells[3].Value = 1;
            }
        }

        //Click catalog button
        private void CatalogButton_Click(object obj, EventArgs e)
        {
            Button btn = obj as Button;

            CleanButtonForTablePanel(tlpDish);

            if (btn.Text == this.resourceManager.GetString("All"))
            {
                FillDishCollectionToControl();
            }
            else
            {
                Guid typeId;

                Guid.TryParse((btn.Tag as DishType).ID.ToString(), out typeId);

                if (Guid.Empty != typeId)
                {
                    var type = (from dt in this.dishTypeCollection where dt.ID == typeId select dt).ElementAtOrDefault(0);

                    FillDishCollectionToControl(type);
                }
            }
        }
        
        //create buttons for panel
        private Button CreateItemButton(string name,string display,int index)
        {
            Button button = new Button();
            button.Enabled = true;
            button.Name = string.Format("{0}{1}", name, index.ToString());
            button.Size = new System.Drawing.Size(150, 89);
            button.TabIndex = index;
            button.Text = display;
            button.UseVisualStyleBackColor = true;
            button.BackColor = Color.BurlyWood;
            button.Dock = DockStyle.Fill;
            return button;
        }

        private void CreateUndefinedButtonForPanel(TableLayoutPanel panel, Button button)
        {
            int count = panel.Controls.Count;

            int rowCount = 0, columnCount = 0;

            if (count == 0)
            {
                //do nothing
            }
            if (count % panel.ColumnCount == 0)
            {
                rowCount = count / panel.ColumnCount;
                columnCount = 0;
            }
            else
            {
                rowCount = count / panel.ColumnCount;
                columnCount = count % panel.ColumnCount;
            }

            panel.Controls.Add(button, columnCount, rowCount);

        }

        private void BtCloseSale_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CleanButtonForTablePanel(TableLayoutPanel Panel)
        {
            for (int i = 0; i < Panel.Controls.Count; i++)
            {
                Panel.Controls.RemoveAt(i);
                i = 0;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.LblTimeSales.Text = DateTime.Now.ToString();
        }
        #endregion

        private void tlpDish_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(0, 0, this.tlpDish.Width, this.tlpDish.Height);
            System.Drawing.Color color1 = System.Drawing.Color.FromArgb(155, 128, 0);
            System.Drawing.Color color2 = System.Drawing.Color.FromArgb(255, 128, 9);
            System.Drawing.Drawing2D.LinearGradientBrush p = new System.Drawing.Drawing2D.LinearGradientBrush(rect, color1, color2, 0, true);

            e.Graphics.FillRectangle(p, 0, 0, this.Width, this.Height);
        }

        private void tlpDish_Paint_1(object sender, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(0, 0, this.tlpDish.Width, this.tlpDish.Height);
            System.Drawing.Color color1 = System.Drawing.Color.FromArgb(155, 128, 0);
            System.Drawing.Color color2 = System.Drawing.Color.FromArgb(255, 128, 9);
            System.Drawing.Drawing2D.LinearGradientBrush p = new System.Drawing.Drawing2D.LinearGradientBrush(rect, color1, color2, 0, true);

            e.Graphics.FillRectangle(p, 0, 0, this.Width, this.Height);
        }

        private void btnAddMenu_Click_1(object sender, EventArgs e)
        {
            CMS.Module.Printer.Core.Printer printer = new Module.Printer.Core.Printer("LPT1");
            printer.Preview();
        }

        private void btnScroll_Click(object sender, EventArgs e)
        {
            int heiht = this.tlpCategory.Height;

            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            this.move(100, this.isTop);
        }

        private void move(int increase, bool isTop)
        {
            int y = isTop ? this.tlp.Location.Y + increase : this.tlp.Location.Y - increase;
            if (isTop)
            {
                if (y > (this.panel3.Location.Y + this.panel3.Height - this.tlp.Height))
                {
                    y = this.panel3.Location.Y + this.panel3.Height - this.tlp.Height;
                    this.timer.Stop();

                    this.isTop = this.isTop == true ? false : true;
                }

                y = y > (this.panel3.Location.Y + this.panel3.Height) ? (this.panel3.Location.Y + this.panel3.Height) : y;
            }
            else
            {
                if (y < (this.panel3.Height - this.tlpDish.Height - this.tlp.Height))
                {
                    this.timer.Stop();

                    this.isTop = this.isTop == true ? false : true;
                }

                y = y < (this.panel3.Height - this.tlpDish.Height - this.tlp.Height) ? (this.panel3.Height - this.tlpDish.Height - this.tlp.Height) : y;
            }

            this.tlp.Location = new Point(this.tlp.Location.X, y);

            this.tlp.Refresh();
        }

        private void tlp_LocationChanged(object sender, EventArgs e)
        {
            this.tlpDish.Height = this.tlpDish.Height + 100;
        }
    }
}
