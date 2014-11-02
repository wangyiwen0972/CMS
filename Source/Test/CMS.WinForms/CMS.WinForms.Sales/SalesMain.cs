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
    
    public partial class SalesMain : Form
    {
        private Employee employee;

        private ControllerCore.DishController dishController;

        private ICollection<Dish> dishCollection = null;
        private ICollection<DishType> dishTypeCollection = null;

        private int iDishItemCurrentPage = 1;
        private int iDishTypeItemCurrentPage = 1;

        public SalesMain()
            : this(null)
        {
            
        }

        public SalesMain(Employee employee)
        {
            this.employee = employee;
            this.dishController = new ControllerCore.DishController(employee);

            InitializeComponent();

            this.Init();
            this.LoadDishCollection(this.iDishItemCurrentPage);
            this.LoadDishTypeCollection(this.iDishTypeItemCurrentPage);
        }

        private void InitPageButton()
        {
            
        }

        private void Init()
        {
            lbEmployeeNo.Text = this.employee.Login;
            lbEmployeeName.Text = this.employee.FullName;
        }

        /// <summary>
        /// 加载所有菜品
        /// </summary>
        private void LoadDishCollection(int ItemPageIndex)
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

            int index = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    int dishIndex = 4 * 4 * (ItemPageIndex - 1) + index;

                    if (dishIndex >= dishCollection.Count)
                    {
                        Button btn = CreateItemButton("btnDish", "未设定", i);
                        this.tlpDish.Controls.Add(btn, j, i);
                    }
                    else
                    {
                        Dish dish = dishCollection.ElementAt(dishIndex) as Dish;
                        
                        Button btn = CreateItemButton("btnDish", dish.Title, i);
                        btn.Enabled = true;    
                        btn.Click += ItemButton_Click;
                        this.tlpDish.Controls.Add(btn, j, i);
                    }
                    index += 1;
                }     
            }
        }

        private void LoadDishCollection(int ItemPageIndex,DishType type)
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

            var dutyDish = from d in dishCollection where d.Type.ID == type.ID select d;

            int index = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (index >= dutyDish.Count<Dish>())
                    {
                        Button btn = CreateItemButton("btnDish", "未设定", i);
                        this.tlpDish.Controls.Add(btn, j, i);
                    }
                    else
                    {
                        Dish dish = dutyDish.ElementAt(4 * 4 * (ItemPageIndex - 1)) as Dish;
                        if (dish.Type.ID == type.ID)
                        {
                            Button btn = CreateItemButton("btnDish", dish.Title, i);
                            btn.Enabled = true;
                            btn.Click += ItemButton_Click;
                            this.tlpDish.Controls.Add(btn, j, i);
                        }
                    }
                    index += 1;
                }
            }
        }

        private void LoadDishTypeCollection(int ItemTypePageIndex)
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

            int index = 0;

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i == 0 && j == 0 && ItemTypePageIndex == 1)
                    {
                        Button btn = new Button();
                        btn.Click += CatalogButton_Click;
                        btn.Text = "全部";
                        btn.Size = new System.Drawing.Size(150, 89);
                        btn.TabIndex = 0;
                        this.tlpCategory.Controls.Add(btn, j, i);
                    }
                    else if (index >= dishTypeCollection.Count + 1)
                    {
                        Button btn = CreateItemButton("btnDishType", "未设定", i);
                        this.tlpCategory.Controls.Add(btn, j, i);
                    }
                    else
                    {
                        DishType dishType = dishTypeCollection.ElementAt((4 * 2 * (ItemTypePageIndex - 1) + (index - 1))) as DishType;

                        Button btn = CreateItemButton("btnDishType", dishType.EnumValue, i);
                        btn.Enabled = true;
                        btn.Tag = dishType;
                        btn.Click += CatalogButton_Click;
                        this.tlpCategory.Controls.Add(btn, j, i);
                    }
                    index += 1;
                }
            }

        }

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
        //点击菜品按钮
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

        //点击大类按钮
        private void CatalogButton_Click(object obj, EventArgs e)
        {
            Button btn = obj as Button;

            this.iDishItemCurrentPage = 1;

            if (btn.Text == "全部")
            {
                CleanButtonForTablePanel(tlpDish);

                LoadDishCollection(this.iDishItemCurrentPage);
            }
            else
            {
                Guid typeId;

                Guid.TryParse(btn.Tag.ToString(), out typeId);

                if (Guid.Empty != typeId)
                {
                    CleanButtonForTablePanel(tlpDish);
                    #region
                    this.btnItemFirst.Tag = btn.Tag;
                    this.btnItemNext.Tag = btn.Tag;
                    this.btnItemPrevious.Tag = btn.Tag;
                    this.btnItemLast.Tag = btn.Tag;
                    #endregion
                    LoadDishCollection(this.iDishItemCurrentPage, btn.Tag as DishType);
                }
            }
        }
        //点击菜品分页按钮
        private void ItemPage_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            int pageCount = 0;

            DishType type = null;

            if (btn.Tag == null)
            {
                pageCount = this.dishCollection.Count / (4 * 4) + 1;
            }
            else
            {
                type = btn.Tag as DishType;

                var dishes = from d in this.dishCollection where d.Type.ID == type.ID select d;
                pageCount = dishes.Count<Dish>();
            }

            switch (btn.Text)
            {
                case "首页":
                    {
                        this.iDishItemCurrentPage = 1;

                        break;
                    }
                case "上一页":
                    {
                        this.iDishItemCurrentPage = this.iDishItemCurrentPage - 1;

                        break;
                    }
                case "下一页":
                    {
                        this.iDishItemCurrentPage = this.iDishItemCurrentPage + 1;

                        break;
                    }
                case "末页":
                    {
                        this.iDishItemCurrentPage = pageCount;

                        break;
                    }
            }

            CleanButtonForTablePanel(this.tlpDish);

            if (type == null)
            {
                LoadDishCollection(this.iDishItemCurrentPage);
            }
            else
            {
                LoadDishCollection(this.iDishItemCurrentPage, type);
            }
        }
        //点击大类分页按钮
        private void CatalogPage_Click(object obj, EventArgs e)
        {
            Button btn = obj as Button;

            int pageCount = this.dishTypeCollection.Count / (4 * 2);

            switch (btn.Text)
            {
                case "首页":
                    {
                        this.iDishTypeItemCurrentPage = 1;

                        break;
                    }
                case "上一页":
                    {
                        this.iDishTypeItemCurrentPage = this.iDishTypeItemCurrentPage - 1;

                        break;
                    }
                case "下一页":
                    {
                        this.iDishTypeItemCurrentPage = this.iDishTypeItemCurrentPage + 1;

                        break;
                    }
                case "末页":
                    {
                        this.iDishTypeItemCurrentPage = pageCount;

                        break;
                    }
            }

            LoadDishTypeCollection(this.iDishTypeItemCurrentPage);
        }
        //创建按钮
        private Button CreateItemButton(string name,string display,int index)
        {
            Button button = new Button();
            button.Dock = System.Windows.Forms.DockStyle.Fill;
            button.Enabled = false;
            button.Location = new System.Drawing.Point(159, 288);
            button.Name = string.Format("{0}{1}", name, index.ToString());
            button.Size = new System.Drawing.Size(150, 89);
            button.TabIndex = index;
            button.Dock = DockStyle.Fill;
            button.Text = display;
            button.UseVisualStyleBackColor = true;
            return button;
        }



        private void BtCloseSale_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CleanButtonForTablePanel(TableLayoutPanel Panel)
        {
            for(int i = 0;i < Panel.Controls.Count;i++)
            {
                if (Panel.Controls[i].Name.IndexOf("btnDish") > -1)
                {
                    Panel.Controls.RemoveAt(i);
                    i = 0;
                }
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

        }
    }
}
