namespace CMS.Restaurant.Client.Sales
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Windows.Forms;
    using CMS.Common.Model;
    using ControllerCore = CMS.Common.Controller.Core;
    using UtilityCore = CMS.Common.Utility.Core;
    using ResultCore = CMS.Common.ViewResult.Core;
    using CMS.Module.Printer.Core;
    using CMS.Module.Shell.Core;
    using CMS.Module.CardMachine;
    using CMS.Restaurant.Client.Cash;
    using CMS.WinForms;
    
    public partial class SalesMain : CMSForm
    {
        private Employee employee;

        private ControllerCore.DishController dishController;
        private ControllerCore.EntranceController entranceController;
        private ControllerCore.OrderController orderController;
        private ControllerCore.CardController cardController;

        private ICollection<Dish> dishCollection = null;
        private ICollection<DishType> dishTypeCollection = null;
        private DishType currentType = null;
        private Entrance entrance = null;
        private CMS.Common.Model.Base.CardBase currentCard = null;

        private int iDishItemCurrentPage = 1;
        private int iDishTypeItemCurrentPage = 1;

        private decimal Amount = 0;

        public SalesMain()
            : this(null)
        {
            
        }

        public SalesMain(Employee employee)
        {
            this.employee = employee;
            this.dishController = new ControllerCore.DishController(employee);
            this.entranceController = this.ControllerManager[typeof(ControllerCore.EntranceController)] as ControllerCore.EntranceController;
            this.orderController = this.ControllerManager[typeof(ControllerCore.OrderController)] as ControllerCore.OrderController;
            this.cardController = this.ControllerManager[typeof(ControllerCore.CardController)] as ControllerCore.CardController;

            InitializeComponent();

            this.refreshDishQuantity.Interval = 30 * 1000;
            this.refreshDishQuantity.Tick += refreshDishQuantity_Tick;

            this.LoadDataCollection();

            this.FillDishCollectionToControl(this.iDishItemCurrentPage);
            this.FillDishTypeCollectionToControl(this.iDishTypeItemCurrentPage);
            InitPageButton();
            this.Init();
            this.refreshDishQuantity.Start();
        }

        void refreshDishQuantity_Tick(object sender, EventArgs e)
        {
            foreach (Button button in this.tlpDish.Controls)
            {
                if (button.Enabled)
                {
                    Dish dish = button.Tag as Dish;

                    OOSDish oosDish = this.dishController.GetOOSDish(dish);

                    if (oosDish == null) continue;

                    button.Text = oosDish == null ? button.Text : string.Format("{0}({1})", dish.Name, oosDish.Quantity);

                    if (oosDish.Quantity == 0)
                    {
                        button.Enabled = false;
                    }
                }
            }
        }

        #region Get models from database
        /// <summary>
        /// 加载所有菜品大类
        /// </summary>
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

                ICollection<CMS.Interface.Model.IModel> dishes = (this.dishController.GetAllDishes() as ResultCore.XMLCollectionResults).GetModelResults();

                foreach (Dish model in dishes)
                {
                    if (model.Type == null)
                    {
                        this.dishController.GetDishType(model);
                    }

                    var find = from c in this.entrance.LimitationCollection where model.Type.ID == c.DishType.ID select c;

                    if (find != null && find.Count() > 0)
                    {
                        dishCollection.Add(model);
                    }
                }
            }
            if (dishTypeCollection == null)
            {
                dishTypeCollection = new List<DishType>();

                //ICollection<CMS.Interface.Model.IModel> dishTypes = (this.dishController.GetAllDishTypes() as ResultCore.XMLCollectionResults).GetModelResults();

                foreach (EntranceLimitationDetail model in this.entrance.LimitationCollection)
                {
                    dishTypeCollection.Add(model.DishType);
                }
            }
            
        }
        #endregion

        #region Fill models to Table Layout Panel
        private int FillDishCollectionToControl(int DishItemPage)
        {
            return this.FillDishCollectionToControl(DishItemPage, null);
        }

        private int FillDishCollectionToControl(int DishItemPage, DishType dishType)
        {
            //clear table panel for dish
            this.tlpDish.Controls.Clear();

            //reset current page index
            this.iDishItemCurrentPage = 1;

            int min = (DishItemPage - 1) * this.tlpDish.ColumnCount * this.tlpDish.RowCount, max = DishItemPage * this.tlpDish.ColumnCount * this.tlpDish.RowCount;

            int index = 0;

            int displayCount = this.tlpDish.ColumnCount * this.tlpDish.RowCount;

            var lookup = dishType == null ? this.dishCollection : (from d in this.dishCollection where d.Type.ID == dishType.ID select d).ToList();

            for (int i = min; i < max; i++)
            {
                if (i >= lookup.Count) break;

                int rowNumber = index / this.tlpDish.ColumnCount;
                int columnNumber = index % this.tlpDish.ColumnCount;
                Dish dish = lookup.ElementAt(i);

                OOSDish oosDish = this.dishController.GetOOSDish(dish);

                index += 1;

                Button btn = CreateItemButton("btnDish", dish.Name, index);
                btn.Tag = dish;
                btn.Text = oosDish == null ? btn.Text : string.Format("{0}({1})", btn.Text, oosDish.Quantity);
                btn.Click += ItemButton_Click;
                if (oosDish != null)
                {
                    btn.Enabled = oosDish.Quantity < 1 ? false : true;
                }
                
                this.tlpDish.Controls.Add(btn, columnNumber, rowNumber);
            }

            //create undefined buttons to fully fill dish panel

            CreateUndefinedButtonForPanel(this.tlpDish);

            this.tlpDish.Tag = dishType;

            return lookup.Count;
        }

        private int FillDishTypeCollectionToControl(int DishTypeItemPage)
        {
            this.tlpCategory.Controls.Clear();

            //reset current dish type page index
            this.iDishTypeItemCurrentPage = 1;

            int min = (DishTypeItemPage - 1) * this.tlpCategory.ColumnCount * this.tlpCategory.RowCount, max = DishTypeItemPage * this.tlpCategory.ColumnCount * this.tlpCategory.RowCount;

            int index = 0;

            for (int i = min; i <= max; i++)
            {
                int rowNumber = index / this.tlpCategory.ColumnCount;
                int columnNumber = index % this.tlpCategory.ColumnCount;

                if (index == 0 && DishTypeItemPage == 1)
                {
                    Button btnCatalogAll = CreateItemButton("btnDishTypeAll", this.resourceManager.GetString("DisplayAllItem"), index);
                    btnCatalogAll.Click += CatalogButton_Click;
                    this.tlpCategory.Controls.Add(btnCatalogAll, columnNumber, rowNumber);
                    
                }
                else if (i > dishTypeCollection.Count) break;
                else
                {
                    DishType dishType = this.dishTypeCollection.ElementAt(index - 1);

                    Button btn = CreateItemButton("btnDishType", dishType.EnumValue, index - 1);
                    btn.Click += CatalogButton_Click;
                    btn.Tag = dishType;
                    this.tlpCategory.Controls.Add(btn, columnNumber, rowNumber);
                }

                index++;
            }

            
            CreateUndefinedButtonForPanel(this.tlpCategory);

            return this.dishTypeCollection.Count;
        }
        #endregion

        private void InitPageButton()
        {
            if (this.dishCollection == null)
            {
                this.btnItemFirst.Enabled = false;
                this.btnItemLast.Enabled = false;
                this.btnItemNext.Enabled = false;
                this.btnItemPrevious.Enabled = false;
                return;
            }
            if (this.dishCollection.Count > this.tlpDish.RowCount * this.tlpDish.ColumnCount)
            {
                this.btnItemFirst.Enabled = true;
                this.btnItemLast.Enabled = true;
                this.btnItemLast.Tag = this.dishCollection.Count % (this.tlpDish.RowCount * this.tlpDish.ColumnCount) == 0 ? this.dishCollection.Count / (this.tlpDish.RowCount * this.tlpDish.ColumnCount) : (this.dishCollection.Count / (this.tlpDish.RowCount * this.tlpDish.ColumnCount)) + 1;
                this.btnItemNext.Enabled = true;
                this.btnItemPrevious.Enabled = false;
            }
            else
            {
                this.btnItemFirst.Enabled = true;
                this.btnItemLast.Enabled = false;
                this.btnItemNext.Enabled = false;
                this.btnItemPrevious.Enabled = false;
            }
            if (this.dishTypeCollection.Count > this.tlpCategory.RowCount * this.tlpCategory.ColumnCount)
            {
                this.btnTypeItemNext.Enabled = true;
                this.btnTypeItemLast.Enabled = true;
                this.btnTypeItemLast.Tag = this.dishTypeCollection.Count % (this.tlpCategory.RowCount * this.tlpCategory.ColumnCount) == 0 ? this.dishTypeCollection.Count / (this.tlpCategory.RowCount * this.tlpCategory.ColumnCount) : (this.dishTypeCollection.Count / (this.tlpCategory.RowCount * this.tlpCategory.ColumnCount)) + 1;
            }
            else
            {
                this.btnTypeItemNext.Enabled = false;
                this.btnTypeItemPrevious.Enabled = false;
                this.btnTypeItemLast.Enabled = false;
            }
        }

        /// <summary>
        /// Initialize panel for form
        /// </summary>
        private void Init()
        {
            lbEmployeeNo.Text = this.employee.Login;
            lbEmployeeName.Text = this.employee.FullName;
            
            lbEntrance.Text = this.entrance.EnterName;

            int screenHeight = SystemInformation.WorkingArea.Height;

            this.tlpDish.Height = screenHeight / 2;

            this.tlp.Location = new Point(this.tlpDish.Location.X, this.tlpDish.Height);
            this.tlpCategory.Location = new Point(this.tlpDish.Location.X, this.tlpDish.Height + this.tlp.Height);
            this.tlpCategory.Height = screenHeight - this.tlpDish.Height;

            this.btnItemLast.Tag = this.dishCollection.Count;
            this.btnTypeItemLast.Tag = this.dishTypeCollection.Count;

            //First time launch, get sales amount from database for the machine
            decimal decAmount = decimal.Zero;
            if (decimal.TryParse(this.entranceController.GetSalesRevenueByMachine(Machine, DateTime.Now, DateTime.Now).Result, out decAmount))
            {
                lbAmount.Text = decAmount.ToString("f2");
            }
            else
            {
                lbAmount.Text = "获取失败";
            }
            

            lbOrderAmount.Text = decimal.Zero.ToString();

            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                row.ReadOnly = true;
            }
        }

        

        #region 控件触发事件

        private void btnSwapCard_Click(object sender, System.EventArgs e)
        {
            //try
            //{
            //    CardTypes cardType = cardController.GetAllCardTypes().ElementAt(0).Model as CardTypes;

            //    CardStatus cardStatus = cardController.GetAllCardStatus().ElementAt(0).Model as CardStatus;

            //    RechargeCard card = new RechargeCard()
            //    {
            //        ID = Guid.NewGuid(),
            //        Amount = 0,
            //        CardType = cardType,
            //        Cost = 10,
            //        CreatedBy = Login,
            //        Discount = 10,
            //        ValidDate = 180,
            //        Points = 0,
            //        StartDate = DateTime.Now,
            //        EndDate = DateTime.Now.AddDays(180),
            //        Status = cardStatus,
            //        Type = Common.Model.Emun.Card.CardType.RechargeCard,
            //        SeriesNumber = "2938DB0D"
            //    };

            //    this.cardController.CreateCard(card);
            //}
            //catch
            //{
            //}

            swipingcard frmCard = new swipingcard();

            DialogResult result = frmCard.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                this.currentCard = frmCard.Card;

                if (this.currentCard.Type == Common.Model.Emun.Card.CardType.TemporaryCard)
                {
                    this.lbCardAmount.Text = (this.currentCard as TemporaryCard).Amount.ToString("f2");
                }
                else
                {
                    this.lbCardAmount.Text = (this.currentCard as RechargeCard).Amount.ToString("f2");
                }

                this.lbOrderAmount.Text = computeAmount();
            }
            else
            {
                MessageBox.Show("读取卡片信息失败");
            }
        }

        private void btnAddMenu_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private bool CheckQuantity(Dish dish)
        {
            OOSDish oosDish = this.dishController.GetOOSDish(dish);
            int iCount = 0;
            if (oosDish != null)
            {
                foreach (DataGridViewRow selectRow in this.dataGridView1.Rows)
                {
                    Dish selectedDish = selectRow.Tag as Dish;

                    if (selectedDish.ID.Equals(dish.ID))
                    {
                        int i;
                        int.TryParse(selectRow.Cells[3].Value.ToString(), out i);
                        iCount += i;
                    }
                }

                if (oosDish.Quantity == 0 || (oosDish.Quantity - iCount) < 1)
                {
                    return false;
                }
            }

            return true;
        }

        private bool CheckCardBalance(decimal Price)
        {
            decimal currentAmount = decimal.Zero;

            if (decimal.TryParse(lbOrderAmount.Text, out currentAmount))
            {
                decimal cardBalance = decimal.Zero;
                switch (this.currentCard.Type)
                {
                    case Common.Model.Emun.Card.CardType.TemporaryCard:
                        {
                            cardBalance = (this.currentCard as TemporaryCard).Amount;
                            break;
                        }
                    case Common.Model.Emun.Card.CardType.VIPCard:
                        {
                            cardBalance = (this.currentCard as RechargeCard).Amount;
                            break;
                        }
                }
                return cardBalance < (currentAmount + Price) ? false : true;
            }
            return false;
        }

        //点击菜品按钮
        private void ItemButton_Click(object obj, EventArgs e)
        {
            if (this.currentCard == null)
            {
                MessageBox.Show("请先刷卡！");
                return;
            }

            Button btn = obj as Button;

            Dish dish = btn.Tag as Dish;

            if (dish != null)
            {
                if (!CheckQuantity(dish))
                {
                    MessageBox.Show("不能添加菜品，库存量不足");
                    return;
                }
                
                if (dish.UnitPriceSetting == null)
                {
                    this.dishController.GetPriceUnitSettingCollection(dish);
                }

                DishUnitPriceSetting priceSetting = null;

                if (dish.UnitPriceSetting.Count == 1)
                {
                    priceSetting = dish.UnitPriceSetting.ElementAt(0);
                }
                else
                {
                    MultiplePrices frmPrice = new MultiplePrices(dish);

                    if(frmPrice.IsDisplayed)
                        frmPrice.ShowDialog();

                   priceSetting = frmPrice.SelectedPirceSetting;

                   frmPrice.Close();
                }

                if (priceSetting == null)
                {
                    MessageBox.Show("未获取到价格");
                    return;
                }

                decimal decPrice = 1 * priceSetting.Price;

                if (!CheckCardBalance(decPrice))
                {
                    MessageBox.Show("当前余额不足，请去前台充值!");
                    return;
                }

                this.dishController.GetUnitByPriceSetting(priceSetting);

                int index = dataGridView1.Rows.Add();

                DataGridViewRow row = dataGridView1.Rows[index];
                
                row.ReadOnly = true;
                row.Cells[0].Value = index + 1;
                row.Cells[1].Value = dish.ShortID;
                row.Cells[2].Value = dish.Name;
                row.Cells[3].Value = 1;
                row.Cells[3].ReadOnly = false;
                row.Cells[4].Value = priceSetting.Price;
                row.Cells[4].Tag = priceSetting.Price;
                row.Cells[5].Value = priceSetting.UnitID.Name;
                row.Cells[7].Value = Login.FullName;
                row.Cells[8].Value = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                row.Cells[9].Value = Machine.MachineName;
                row.Tag = dish;

                this.dataGridView1.CurrentCell = row.Cells[4];
            }
        }

        //点击大类按钮
        private void CatalogButton_Click(object obj, EventArgs e)
        {
            Button btn = obj as Button;

            DishType dishType = btn.Tag as DishType;

            this.iDishItemCurrentPage = 1;

            if (btn.Text == this.resourceManager.GetString("DisplayAllItem"))
            {
                FillDishCollectionToControl(this.iDishItemCurrentPage);

                currentType = null;
            }
            else
            {
                if (dishType != null)
                {
                    int count = FillDishCollectionToControl(this.iDishItemCurrentPage, dishType);

                    iDishItemCurrentPage = 1;
                    #region
                    this.btnItemFirst.Tag = 1;
                    this.btnItemNext.Tag = count > this.tlpDish.RowCount * this.tlpDish.ColumnCount ? iDishItemCurrentPage + 1 : -1;
                    this.btnItemNext.Enabled = count > this.tlpDish.RowCount * this.tlpDish.ColumnCount ? true : false;
                    this.btnItemPrevious.Tag = -1;
                    this.btnItemPrevious.Enabled = false;
                    this.btnItemLast.Tag  = count % this.tlpDish.RowCount * this.tlpDish.ColumnCount == 0 ? count / this.tlpDish.RowCount * this.tlpDish.ColumnCount : (count / this.tlpDish.RowCount * this.tlpDish.ColumnCount) + 1;
                    this.btnItemLast.Enabled = count > (int)this.btnItemLast.Tag * this.tlpDish.RowCount * this.tlpDish.ColumnCount ? true : false;
                    #endregion

                    currentType = dishType;
                }
            }
        }
        //点击大类分页按钮
        private void CatalogPage_Click(object obj, EventArgs e)
        {
            
        }
        //创建按钮
        private Button CreateItemButton(string name,string display,int index)
        {
            Button button = new Button();
            button.Location = new System.Drawing.Point(159, 288);
            button.Name = string.Format("{0}_{1}", name, index.ToString());
            button.Size = new System.Drawing.Size(150, 45);
            button.TabIndex = index;
            button.Dock = DockStyle.Fill;
            button.Text = display;
            button.UseVisualStyleBackColor = true;
            button.BackColor = Color.BurlyWood;
            button.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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

        private void btnUndefined_Click(object sender, EventArgs e)
        {
            Button btnSender = sender as Button;

            //if (btnSender.Name.IndexOf("DishType") > -1)
            //{
            //    CMS.WinForms.Background.CategorySetEdit frmCategorSet = new Background.CategorySetEdit();
            //    DialogResult result = frmCategorSet.ShowDialog();
            //    if (result == System.Windows.Forms.DialogResult.OK)
            //    {
            //        btnSender.Text = frmCategorSet.Type.EnumValue;
            //        btnSender.Click -= btnUndefined_Click;
            //        btnSender.Click += ItemButton_Click;

            //        ActiveNextUndefinedButton(this.tlpDish, btnSender);
            //    }
            //}
            //else
            //{
            //    CMS.WinForms.Background.DishSetEdit frmDishSet = new Background.DishSetEdit();
            //    DialogResult result = frmDishSet.ShowDialog();
            //    if (result == System.Windows.Forms.DialogResult.OK)
            //    {
            //        Button btn = sender as Button;
            //        btn.Text = frmDishSet.DishModel.Name;
            //        btn.Click -= btnUndefined_Click;
            //        btn.Click += ItemButton_Click;

            //        ActiveNextUndefinedButton(this.tlpCategory, btnSender);
            //    }
            //}
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.LblTimeSales.Text = DateTime.Now.ToString();
        }
        #endregion

        private void ActiveNextUndefinedButton(TableLayoutPanel panel, Button currrentButton)
        {
            bool find = false;
            int columnIndex = 0, rowIndex = 0;
            for (int i = 0; i < panel.RowCount; i++)
            {
                for (int j = 0; j < panel.ColumnCount; j++)
                {
                    Button btn = panel.GetControlFromPosition(j, i) as Button;
                    if (btn == null) break;
                    if (btn.Equals(currrentButton))
                    {
                        columnIndex = j;
                        rowIndex = i;
                        find = true;
                        break;
                    }
                }
            }
            if (find)
            {
                if (columnIndex == panel.ColumnCount && rowIndex == panel.RowCount)
                {
                    
                }
                else
                {
                }
            }
        }

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

        //Check in card event
        private void btnAddMenu_Click_1(object sender, EventArgs e)
        {
            //Check card if it is inactive
            if (this.currentCard == null)
            {
                MessageBox.Show("请先刷卡！");
                return;
            }

            //Try to get active status model
            SalesStatus activeStatus = null;

            activeStatus = orderController.getSalesStatus(ControllerCore.OrderController.SALES_STATUS_ACTIVE);
            // the balance of current card
            decimal cardBalance = decimal.Zero;

            //set sales order model
            CMS.Interface.Model.IModel salesOrder = null;
            //Get sales order model from database. If customer opened a card, there is a sales order in database with active status
            CMS.Common.ViewResult.Base.ActionResultBase actionResult = this.orderController.GetSalesOrderBySalesStatus(this.currentCard, activeStatus);

            //Meaning that this is first order of the card today 
            if (actionResult == null || actionResult.Model == null)
            {
                MessageBox.Show("您还未开卡，请去前台开卡！");

                //clear grid viewer
                this.dataGridView1.Rows.Clear();

                //clear current card if it really is active
                this.currentCard = null;

                //set lable amount to zero
                this.lbOrderAmount.Text = decimal.Zero.ToString("f2");

                return;
            }

            //got a sales order model
            salesOrder = actionResult.Model;
            //reflesh this order amount dishes selected
            this.lbOrderAmount.Text = computeAmount();
            //set a variable in order to save order amount
            decimal tmpAmount = decimal.Zero;

            decimal.TryParse(this.lbOrderAmount.Text, out tmpAmount);

            //Create a new order
            EntranceOrder order = new EntranceOrder()
            {
                ID = Guid.NewGuid(),
                OrderNo = this.orderController.GenerateOrderCode().Result,
                Amount = tmpAmount,
                CardID = currentCard.ID,
                ChangedBy = Login,
                ChangedDate = DateTime.Now,
                CreatedBy = Login,
                CreatedDate = DateTime.Now,
                EntranceID = entrance.ID,
                IsUseCard = true,
                Machine = Machine.ID,
                Operator = Login,
                OrderDetail = null,
                PayAmount = tmpAmount,
                PrintFlag = false,
                SalesID = (salesOrder as SalesOrder).SalesID
            };
            // try to get order collection
            ICollection<CMS.Interface.Model.IModel> orderCollection = this.orderController.GetOrderCollectionBySalesOrder(salesOrder as SalesOrder).GetModelResults();

            decimal paidAmount = decimal.Zero;
            //if we already have orders before, plus previous amount
            if (orderCollection != null || orderCollection.Count > 0)
            {
                foreach (EntranceOrder entranceOrder in orderCollection)
                {
                    paidAmount += entranceOrder.Amount;
                }
            }

            //check current card type
            if (this.currentCard is TemporaryCard)
            {
                cardBalance = (this.currentCard as TemporaryCard).Amount - (order.Amount + paidAmount);
                //check the balance of card
                if (cardBalance < 0)
                {
                    MessageBox.Show(string.Format("当前卡内余额为：{0}, 消费金额为：{1}, 当前金额未能支付，请去前台充值", (this.currentCard as TemporaryCard).Amount - paidAmount, order.Amount));
                    return;
                }
                
            }

            if (this.currentCard is RechargeCard)
            {
                cardBalance = (this.currentCard as RechargeCard).Amount - (order.Amount + paidAmount);
                if (cardBalance < 0)
                {
                    MessageBox.Show(string.Format("当前卡内余额为：{0}, 消费金额为：{1}, 当前金额未能支付，请去前台充值", (this.currentCard as RechargeCard).Amount - paidAmount, order.Amount));
                    return;
                }
                
            }
            //create collection for order details
            List<EntranceOrderDetail> detailCollection = new List<EntranceOrderDetail>();

            System.Xml.XmlDocument xmlDocument = new System.Xml.XmlDocument();

            //Loop to dish we selected
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    Dish dish = row.Tag as Dish;

                    decimal price = 0;
                    //the price of dish
                    decimal.TryParse(row.Cells[4].Value.ToString(), out price);
                    decimal quantity = 1;
                    //the quantity of dish
                    decimal.TryParse(row.Cells[3].Value.ToString(), out quantity);
                    //the amount of order
                    decimal amount = price * quantity;

                    EntranceOrderDetail orderDetail = new EntranceOrderDetail()
                    {
                        Dish = dish.ID,
                        OrderID = order.ID,
                        Price = price,
                        Quantity = quantity,
                        Unit = row.Cells[5].Value.ToString(),
                        Amount = amount,
                        CreatedBy = Login,
                        CreatedDate = DateTime.Now,
                        ChangedBy = Login,
                        ChangedDate = DateTime.Now
                    };
                    decimal totalAmount = decimal.Zero;

                    if (decimal.TryParse(lbAmount.Text, out totalAmount))
                    {
                        totalAmount += order.Amount;
                        //update data for total amount
                        lbAmount.Text = totalAmount.ToString("f2");
                    }

                    detailCollection.Add(orderDetail);
                }
            }
            //Set detailed dish for order
            order.OrderDetail = detailCollection;

            try
            {
                //Save entrance order for entance
                this.entranceController.CreateEntranceOrder(entrance, order);
                //save detailed dish for order
                this.entranceController.AddDishesForOrder(order, detailCollection);

                foreach (EntranceOrderDetail detail in detailCollection)
                {
                    OOSDish oosDish = this.dishController.GetOOSDish(detail.Dish);
                    if (oosDish == null) continue;
                    int iQuantity;
                    int.TryParse(detail.Quantity.ToString(), out iQuantity);
                    OOSDish newOOSDish = new OOSDish()
                    {
                        DishID = oosDish.DishID,
                        LastUpdatedBy = Login,
                        LastUpdatedTime = DateTime.Now,
                        MachineID = Machine.ID,
                        Quantity = oosDish.Quantity - iQuantity
                    };
                    this.dishController.UpdateOOSDish(detail.Dish, newOOSDish);
                }

                //get the first printer we set on config
                string printer1Name = System.Configuration.ConfigurationManager.AppSettings["printer1"];
                string printer2Name = System.Configuration.ConfigurationManager.AppSettings["printer2"];

                short printer1Copies = 1;
                short printer2Copies = 1;

                XmlDocument configXml = new XmlDocument();
                try
                {
                    configXml.Load(System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.PerUserRoaming).FilePath);

                    string xpath = string.Format("/configuration/appSettings/add[@key='{0}']","printer1");
                    XmlNode printer1Node = configXml.SelectSingleNode(xpath);
                    if (printer1Node != null)
                    {
                        printer1Name = printer1Node.Attributes["value"].InnerText;
                        if(printer1Node.Attributes["copies"] != null)
                            short.TryParse(printer1Node.Attributes["copies"].InnerText, out printer1Copies);
                    }
                    xpath = string.Format("/configuration/appSettings/add[@key='{0}']", "printer2");
                    XmlNode printer2Node = configXml.SelectSingleNode(xpath);
                    if (printer2Node != null)
                    {
                        printer2Name = printer2Node.Attributes["value"].InnerText;
                        if (printer2Node.Attributes["copies"] != null)
                            short.TryParse(printer2Node.Attributes["copies"].InnerText, out printer2Copies);
                    }
                }
                catch
                {
                }
                
                if (!string.IsNullOrEmpty(printer1Name))
                {
                    //point to the printer by name
                    CMS.Module.Printer.Core.Printer printer1 = new Module.Printer.Core.Printer(printer1Name);
                    //convert order model to xml doc
                    xmlDocument = ConvertTo(order);
                    //transform xml to string
                    printer1.ApplyTemplate(xmlDocument, string.Format(@"{0}\{1}", Environment.CurrentDirectory, @"Template\SalesTemplate.xslt"));

                    printer1.SetCopies(printer1Copies);
                    //just print doc
                    printer1.Print();
                    //apply the sec printer
                }
  
                if (!string.IsNullOrEmpty(printer2Name))
                {
                    CMS.Module.Printer.Core.Printer printer2 = new Module.Printer.Core.Printer(printer2Name);
                    xmlDocument = ConvertTo(order, (salesOrder as SalesOrder).PrimaryName(), cardBalance);
                    printer2.ApplyTemplate(xmlDocument, string.Format(@"{0}\{1}", Environment.CurrentDirectory, @"Template\CheckoutTemplate.xslt"));

                    printer2.SetCopies(printer2Copies);
                    printer2.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //clear grid viewer
                this.dataGridView1.Rows.Clear();

                //clear current card
                this.currentCard = null;
                //
                this.lbOrderAmount.Text = decimal.Zero.ToString("f2");
            }
        }

        #region Dish page button click event
        private void btnItemFirst_Click(object sender, EventArgs e)
        {
            this.iDishItemCurrentPage = 1;
            this.btnItemPrevious.Enabled = false;
            int count = this.FillDishCollectionToControl(this.iDishItemCurrentPage, currentType);

            if (count > this.tlpDish.RowCount * this.tlpDish.ColumnCount)
            {
                this.btnItemNext.Enabled = true;
                this.btnItemNext.Tag = this.iDishItemCurrentPage + 1;
                this.btnItemLast.Enabled = true;
                this.btnItemLast.Tag = count % this.tlpDish.RowCount * this.tlpDish.ColumnCount == 0 ? count / this.tlpDish.RowCount * this.tlpDish.ColumnCount : (count / this.tlpDish.RowCount * this.tlpDish.ColumnCount) + 1;
            }
            else
            {
                this.btnItemNext.Enabled = false;
                this.btnItemLast.Enabled = false;
            }
        }

        private void btnItemPrevious_Click(object sender, EventArgs e)
        {
            this.iDishItemCurrentPage -= 1;

            #region
            this.btnItemFirst.Tag = 1;
            this.btnItemPrevious.Tag = this.iDishItemCurrentPage - 1;
            this.btnItemNext.Tag = this.iDishItemCurrentPage + 1;
            #endregion

            int count = this.FillDishCollectionToControl(this.iDishItemCurrentPage, currentType);

            if (count > this.tlpDish.RowCount * this.tlpDish.ColumnCount)
            {
                this.btnItemPrevious.Enabled = count > (int)this.btnItemPrevious.Tag * this.tlpDish.RowCount * this.tlpDish.ColumnCount ? true : false;
                this.btnItemNext.Enabled = count > (int)this.btnItemNext.Tag * this.tlpDish.RowCount * this.tlpDish.ColumnCount ? true : false;
                
                this.btnItemLast.Tag = count % this.tlpDish.RowCount * this.tlpDish.ColumnCount == 0 ? count / this.tlpDish.RowCount * this.tlpDish.ColumnCount : (count / this.tlpDish.RowCount * this.tlpDish.ColumnCount) + 1;
                this.btnItemLast.Enabled = count > (int)this.btnItemLast.Tag * this.tlpDish.RowCount * this.tlpDish.ColumnCount ? true : false; 
            }
            else
            {
                this.btnItemPrevious.Enabled = false;
                this.btnItemNext.Enabled = false;
                this.btnItemLast.Enabled = false;
            }
        }

        private void btnItemNext_Click(object sender, EventArgs e)
        {
            this.iDishItemCurrentPage += 1;

            #region
            this.btnItemFirst.Tag = 1;
            this.btnItemPrevious.Tag = this.iDishItemCurrentPage - 1;
            this.btnItemNext.Tag = this.iDishItemCurrentPage + 1;
            #endregion

            int count = this.FillDishCollectionToControl(this.iDishItemCurrentPage, currentType);

            if (count > this.tlpDish.RowCount * this.tlpDish.ColumnCount)
            {
                this.btnItemPrevious.Enabled = count > (int)this.btnItemPrevious.Tag * this.tlpDish.RowCount * this.tlpDish.ColumnCount ? true : false;
                this.btnItemNext.Enabled = count > (int)this.btnItemNext.Tag * this.tlpDish.RowCount * this.tlpDish.ColumnCount ? true : false;

                this.btnItemLast.Tag = count % this.tlpDish.RowCount * this.tlpDish.ColumnCount == 0 ? count / this.tlpDish.RowCount * this.tlpDish.ColumnCount : (count / this.tlpDish.RowCount * this.tlpDish.ColumnCount) + 1;
                this.btnItemLast.Enabled = count > (int)this.btnItemLast.Tag * this.tlpDish.RowCount * this.tlpDish.ColumnCount ? true : false;
            }
            else
            {
                this.btnItemPrevious.Enabled = false;
                this.btnItemNext.Enabled = false;
                this.btnItemLast.Enabled = false;
            }
        }

        private void btnItemLast_Click(object sender, EventArgs e)
        {
            this.iDishItemCurrentPage = (int)(sender as Button).Tag;

            #region
            this.btnItemFirst.Tag = 1;
            this.btnItemPrevious.Tag = this.iDishItemCurrentPage - 1;
            this.btnItemNext.Tag = -1;  
            this.btnItemLast.Tag = this.iDishItemCurrentPage;
            #endregion

            int count = this.FillDishCollectionToControl(this.iDishItemCurrentPage, currentType);

            if (count > this.tlpDish.RowCount * this.tlpDish.ColumnCount)
            {
                this.btnItemFirst.Enabled = true;
                this.btnItemPrevious.Enabled = count > (int)this.btnItemPrevious.Tag * this.tlpDish.RowCount * this.tlpDish.ColumnCount ? true : false;
                this.btnItemNext.Enabled = count > (int)this.btnItemNext.Tag * this.tlpDish.RowCount * this.tlpDish.ColumnCount ? true : false;

                this.btnItemLast.Tag = count % this.tlpDish.RowCount * this.tlpDish.ColumnCount == 0 ? count / this.tlpDish.RowCount * this.tlpDish.ColumnCount : (count / this.tlpDish.RowCount * this.tlpDish.ColumnCount) + 1;
                this.btnItemLast.Enabled = count > (int)this.btnItemLast.Tag * this.tlpDish.RowCount * this.tlpDish.ColumnCount ? true : false;
            }
            else
            {
                this.btnItemPrevious.Enabled = false;
                this.btnItemNext.Enabled = false;
                this.btnItemLast.Enabled = false;
            }
        }
        #endregion

        #region create control for the form
        private void CreateUndefinedButtonForPanel(TableLayoutPanel panel)
        {

            int count = panel.Controls.Count;

            int rowCount = 0, columnCount = 0;

            string buttonName = panel.Name.IndexOf("Category") > -1 ? "btnDishTypeUndefined" : "btnDishUndefined";

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

            int index = 0;


            for (int j = columnCount; j < panel.ColumnCount; j++)
            {
                Button btnUndefined = CreateItemButton(buttonName, this.resourceManager.GetString("Undefined"), index);
                btnUndefined.Click += btnUndefined_Click;
                //if (index != 0) 
                btnUndefined.Enabled = false;
                panel.Controls.Add(btnUndefined, j, rowCount);

                index += 1;
            }
            for (int i = rowCount + 1; i < panel.RowCount; i++)
            {
                for (int j = 0; j < panel.ColumnCount; j++)
                {
                    Button btnUndefined = CreateItemButton(buttonName, this.resourceManager.GetString("Undefined"), index);
                    btnUndefined.Click += btnUndefined_Click;
                    //if (index != 0) 
                    btnUndefined.Enabled = false;
                    panel.Controls.Add(btnUndefined, j, i);

                    index += 1;
                }
            }
        }


        #endregion

        #region Type page button click event
        private void btnTypeItemFirst_Click(object sender, EventArgs e)
        {
            this.iDishTypeItemCurrentPage = 1;
            this.btnTypeItemPrevious.Enabled = false;
            this.btnTypeItemPrevious.Tag = -1;
            int count = this.FillDishTypeCollectionToControl(this.iDishTypeItemCurrentPage);

            if (count > this.tlpDish.RowCount * this.tlpDish.ColumnCount)
            {
                this.btnTypeItemNext.Enabled = true;
                this.btnTypeItemNext.Tag = this.iDishTypeItemCurrentPage + 1;
                this.btnItemLast.Enabled = true;
                this.btnItemLast.Tag = count % this.tlpCategory.RowCount * this.tlpCategory.ColumnCount == 0 ? count / this.tlpCategory.RowCount * this.tlpCategory.ColumnCount : (count / this.tlpCategory.RowCount * this.tlpCategory.ColumnCount) + 1;
            }
            else
            {
                this.btnTypeItemNext.Enabled = false;
                this.btnItemLast.Enabled = false;
            }
        }

        private void btnTypeItemPrevious_Click(object sender, EventArgs e)
        {
            this.iDishTypeItemCurrentPage -= 1;

            #region
            this.btnTypeItemFirst.Tag = 1;
            this.btnTypeItemPrevious.Tag = this.iDishTypeItemCurrentPage - 1;
            this.btnTypeItemNext.Tag = this.iDishTypeItemCurrentPage + 1;
            #endregion

            int count = this.FillDishTypeCollectionToControl(this.iDishTypeItemCurrentPage);

            if (count > this.tlpCategory.RowCount * this.tlpCategory.ColumnCount)
            {
                this.btnTypeItemPrevious.Enabled = count > (int)this.btnTypeItemPrevious.Tag * this.tlpCategory.RowCount * this.tlpCategory.ColumnCount ? true : false;
                this.btnTypeItemPrevious.Tag = this.btnTypeItemPrevious.Enabled ? this.iDishTypeItemCurrentPage - 1 : -1;
                this.btnTypeItemNext.Enabled = count > (int)this.btnTypeItemNext.Tag * this.tlpCategory.RowCount * this.tlpCategory.ColumnCount ? true : false;
                this.btnTypeItemNext.Tag = this.btnTypeItemNext.Enabled ? this.iDishTypeItemCurrentPage + 1 : -1;
                this.btnItemLast.Tag = count % this.tlpCategory.RowCount * this.tlpCategory.ColumnCount == 0 ? count / this.tlpCategory.RowCount * this.tlpCategory.ColumnCount : (count / this.tlpCategory.RowCount * this.tlpCategory.ColumnCount) + 1;
                this.btnItemLast.Enabled = true;
            }
            else
            {
                this.btnTypeItemNext.Enabled = false;
                this.btnTypeItemPrevious.Enabled = false;
                this.btnTypeItemLast.Enabled = false;
            }
        }

        private void btnTypeItemNext_Click(object sender, EventArgs e)
        {
            this.iDishTypeItemCurrentPage += 1;

            #region
            this.btnTypeItemFirst.Tag = 1;
            this.btnTypeItemPrevious.Tag = this.iDishTypeItemCurrentPage - 1;
            this.btnTypeItemNext.Tag = this.iDishTypeItemCurrentPage + 1;
            #endregion

            int count = this.FillDishTypeCollectionToControl(this.iDishTypeItemCurrentPage);

            if (count > this.tlpCategory.RowCount * this.tlpCategory.ColumnCount)
            {
                this.btnTypeItemPrevious.Enabled = count > (int)this.btnTypeItemPrevious.Tag * this.tlpCategory.RowCount * this.tlpCategory.ColumnCount ? true : false;
                this.btnTypeItemPrevious.Tag = this.btnTypeItemPrevious.Enabled ? this.iDishTypeItemCurrentPage - 1 : -1;
                this.btnTypeItemNext.Enabled = count > (int)this.btnTypeItemNext.Tag * this.tlpCategory.RowCount * this.tlpCategory.ColumnCount ? true : false;
                this.btnTypeItemNext.Tag = this.btnTypeItemNext.Enabled ? this.iDishTypeItemCurrentPage + 1 : -1;
                this.btnItemLast.Tag = count % this.tlpCategory.RowCount * this.tlpCategory.ColumnCount == 0 ? count / this.tlpCategory.RowCount * this.tlpCategory.ColumnCount : (count / this.tlpCategory.RowCount * this.tlpCategory.ColumnCount) + 1;
                this.btnItemLast.Enabled = true;
            }
            else
            {
                this.btnTypeItemNext.Enabled = false;
                this.btnTypeItemPrevious.Enabled = false;
                this.btnTypeItemLast.Enabled = false;
            }
        }

        private void btnTypeItemLast_Click(object sender, EventArgs e)
        {
            this.iDishTypeItemCurrentPage = (int)(sender as Button).Tag;

            #region
            this.btnTypeItemFirst.Tag = 1;
            this.btnTypeItemPrevious.Tag = this.iDishTypeItemCurrentPage - 1;
            this.btnTypeItemNext.Tag = this.iDishTypeItemCurrentPage + 1;
            #endregion

            int count = this.FillDishTypeCollectionToControl(this.iDishTypeItemCurrentPage);

            if (count > this.tlpCategory.RowCount * this.tlpCategory.ColumnCount)
            {
                this.btnTypeItemPrevious.Enabled = count > (int)this.btnTypeItemPrevious.Tag * this.tlpCategory.RowCount * this.tlpCategory.ColumnCount ? true : false;
                this.btnTypeItemPrevious.Tag = this.btnTypeItemPrevious.Enabled ? this.iDishTypeItemCurrentPage - 1 : -1;
                this.btnTypeItemNext.Enabled = count > (int)this.btnTypeItemNext.Tag * this.tlpCategory.RowCount * this.tlpCategory.ColumnCount ? true : false;
                this.btnTypeItemNext.Tag = this.btnTypeItemNext.Enabled ? this.iDishTypeItemCurrentPage + 1 : -1;
                this.btnItemLast.Tag = count % this.tlpCategory.RowCount * this.tlpCategory.ColumnCount == 0 ? count / this.tlpCategory.RowCount * this.tlpCategory.ColumnCount : (count / this.tlpCategory.RowCount * this.tlpCategory.ColumnCount) + 1;
                this.btnItemLast.Enabled = true;
            }
            else
            {
                this.btnTypeItemNext.Enabled = false;
                this.btnTypeItemPrevious.Enabled = false;
                this.btnTypeItemLast.Enabled = false;
            }
        }
        #endregion

        private System.Xml.XmlDocument ConvertTo(EntranceOrder order, string salesNo, decimal cardBalance)
        {
            if (order == null || order.OrderDetail == null || order.OrderDetail.Count < 1)
            {
                throw new Exception("");
            }
            System.Xml.XmlDocument xmlDocument = new System.Xml.XmlDocument();

            XmlElement orderElement = xmlDocument.CreateElement("order");

            XmlAttribute nameAttribute = xmlDocument.CreateAttribute("name");
            nameAttribute.InnerText = order.OrderNo;
            orderElement.Attributes.Append(nameAttribute);

            XmlAttribute orderAttribute = xmlDocument.CreateAttribute("orderno");
            orderAttribute.InnerText = order.OrderNo;
            orderElement.Attributes.Append(orderAttribute);

            XmlAttribute salseAttribute = xmlDocument.CreateAttribute("salse");
            salseAttribute.InnerText = salesNo;
            orderElement.Attributes.Append(salseAttribute);

            XmlAttribute operatorAttribute = xmlDocument.CreateAttribute("operator");
            operatorAttribute.InnerText = order.Operator.FullName;
            orderElement.Attributes.Append(operatorAttribute);

            XmlAttribute dateAttribute = xmlDocument.CreateAttribute("date");
            dateAttribute.InnerText = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            orderElement.Attributes.Append(dateAttribute);

            XmlAttribute entranceAttribute = xmlDocument.CreateAttribute("entrance");
            entranceAttribute.InnerText = (this.entranceController.GetEntrance(order.EntranceID).Model as Entrance).EnterName;
            orderElement.Attributes.Append(entranceAttribute);

            XmlAttribute machineAttribute = xmlDocument.CreateAttribute("machine");
            machineAttribute.InnerText = Machine.MachineName;
            orderElement.Attributes.Append(machineAttribute);

            XmlAttribute amountAttribute = xmlDocument.CreateAttribute("amount");
            amountAttribute.InnerText = order.Amount.ToString();
            orderElement.Attributes.Append(amountAttribute);

            XmlAttribute cardBalanceAttribute = xmlDocument.CreateAttribute("cardBalance");
            cardBalanceAttribute.InnerText = cardBalance.ToString();
            orderElement.Attributes.Append(cardBalanceAttribute);

            xmlDocument.AppendChild(orderElement);

            foreach (EntranceOrderDetail detail in order.OrderDetail)
            {
                Dish dish = this.dishController.GetDishByID(detail.Dish).Model as Dish;

                XmlElement dishElement = xmlDocument.CreateElement("dish");
                dishElement.SetAttribute("name", dish.Name);

                XmlElement priceElement = xmlDocument.CreateElement("price");
                priceElement.InnerText = detail.Price.ToString();

                XmlElement quantityElement = xmlDocument.CreateElement("quantity");
                quantityElement.InnerText = detail.Quantity.ToString();

                XmlElement amountElement = xmlDocument.CreateElement("amount");
                amountElement.InnerText = detail.Amount.ToString("f2");

                XmlElement unitElement = xmlDocument.CreateElement("unit");
                unitElement.InnerText = detail.Unit;

                dishElement.AppendChild(priceElement);
                dishElement.AppendChild(quantityElement);
                dishElement.AppendChild(amountElement);
                dishElement.AppendChild(unitElement);

                orderElement.AppendChild(dishElement);
            }

            return xmlDocument;
        }

        private System.Xml.XmlDocument ConvertTo(EntranceOrder order)
        {
            if (order == null || order.OrderDetail == null || order.OrderDetail.Count < 1)
            {
                throw new Exception("");
            }
            System.Xml.XmlDocument xmlDocument = new System.Xml.XmlDocument();

            XmlElement orderElement = xmlDocument.CreateElement("order");

            XmlAttribute nameAttribute = xmlDocument.CreateAttribute("name");
            nameAttribute.InnerText = order.OrderNo;
            orderElement.Attributes.Append(nameAttribute);

            XmlAttribute orderAttribute = xmlDocument.CreateAttribute("order");
            orderAttribute.InnerText = order.OrderNo;
            orderElement.Attributes.Append(orderAttribute);

            XmlAttribute operatorAttribute = xmlDocument.CreateAttribute("operator");
            operatorAttribute.InnerText = order.Operator.FullName;
            orderElement.Attributes.Append(operatorAttribute);

            XmlAttribute dateAttribute = xmlDocument.CreateAttribute("date");
            dateAttribute.InnerText = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            orderElement.Attributes.Append(dateAttribute);

            XmlAttribute entranceAttribute = xmlDocument.CreateAttribute("entrance");
            entranceAttribute.InnerText = (this.entranceController.GetEntrance(order.EntranceID).Model as Entrance).EnterName;
            orderElement.Attributes.Append(entranceAttribute);

            XmlAttribute machineAttribute = xmlDocument.CreateAttribute("machine");
            machineAttribute.InnerText = Machine.MachineName;
            orderElement.Attributes.Append(machineAttribute);

            XmlAttribute amountAttribute = xmlDocument.CreateAttribute("amount");
            amountAttribute.InnerText = order.Amount.ToString("f2");
            orderElement.Attributes.Append(amountAttribute);

            xmlDocument.AppendChild(orderElement);

            foreach(EntranceOrderDetail detail in order.OrderDetail)
            {
                Dish dish = this.dishController.GetDishByID(detail.Dish).Model as Dish;

                XmlElement dishElement = xmlDocument.CreateElement("dish");
                dishElement.SetAttribute("name", dish.Name);

                XmlElement priceElement = xmlDocument.CreateElement("price");
                priceElement.InnerText = detail.Price.ToString();

                XmlElement quantityElement = xmlDocument.CreateElement("quantity");
                quantityElement.InnerText = detail.Quantity.ToString();

                XmlElement amountElement = xmlDocument.CreateElement("amount");
                amountElement.InnerText = detail.Amount.ToString();

                XmlElement unitElement = xmlDocument.CreateElement("unit");
                unitElement.InnerText = detail.Unit;

                dishElement.AppendChild(priceElement);
                dishElement.AppendChild(quantityElement);
                dishElement.AppendChild(amountElement);
                dishElement.AppendChild(unitElement);

                orderElement.AppendChild(dishElement);
            }
            
            return xmlDocument;
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView gridView = sender as DataGridView;

            Dish tmpDish = null;
            
            if (e.ColumnIndex == 4)
            {
                if (gridView.Rows[e.RowIndex].IsNewRow)
                {
                    return;
                }

                string dishCode = gridView.Rows[e.RowIndex].Cells[1].Value.ToString();

                var lookup = (from dish in this.dishCollection where dish.Code == dishCode select dish).ToList();

                if (lookup.Count > 0) tmpDish = lookup.First();

                if (tmpDish == null)
                {
                    //MessageBox.Show("There is no price data to be set. You can set price directly.");
                }
                else
                {
                    if(tmpDish.UnitPriceSetting == null)
                        this.dishController.GetPriceUnitSettingCollection(tmpDish);

                    if (tmpDish.UnitPriceSetting.Count == 1)
                    {
                        DishUnitPriceSetting price = tmpDish.UnitPriceSetting.ElementAt(0);

                        this.dishController.GetUnitByPriceSetting(price);

                        gridView.Rows[e.RowIndex].Cells[4].Value = string.Format("{0}", price.Price);
                        gridView.Rows[e.RowIndex].Cells[4].Tag = price;
                        
                        gridView.Rows[e.RowIndex].Cells[5].Value = string.Format("{0}", price.UnitID.Name);
                    }
                    else
                    {
                        MultiplePrices frmPrices = new MultiplePrices(tmpDish);

                        if (!frmPrices.IsDisplayed)
                        {
                            frmPrices.Dispose();
                        }
                        else
                        {
                            frmPrices.ShowDialog();

                            if (frmPrices.SelectedPirceSetting != null)
                            {
                                gridView.Rows[e.RowIndex].Cells[4].Value = string.Format("{0}", frmPrices.SelectedPirceSetting.Price.ToString());
                                gridView.Rows[e.RowIndex].Cells[4].Tag = frmPrices.SelectedPirceSetting.Price;
                                gridView.Rows[e.RowIndex].Cells[5].Value = string.Format("{0}", frmPrices.SelectedPirceSetting.UnitID.Name);

                            }
                        }
                    }
                }
                return;
            }
            if (e.RowIndex == 5)
            {
                
            }
        }

        private string computeAmount()
        {
            decimal amount = decimal.Zero;

            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    decimal price = 0;
                    if(row.Cells[4].Value != null) decimal.TryParse(row.Cells[4].Value.ToString(), out price);

                    decimal unit = 1;
                    decimal.TryParse(row.Cells[3].Value.ToString(), out unit);

                    amount += unit * price;
                }
            }

            return amount.ToString("f2");
        }

        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            this.lbOrderAmount.Text = computeAmount();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                if (!row.IsNewRow && row.Selected)
                {
                    this.dataGridView1.Rows.Remove(row);
                }
            }
            this.lbOrderAmount.Text = computeAmount();
        }

        private void dataGridView1_Leave(object sender, EventArgs e)
        {
            this.lbOrderAmount.Text = computeAmount();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            if (row.Selected)
            {
                row.Selected = false;
            }
            else
            {
                row.Selected = true;
            }
        }

        private void btInsert_Click(object sender, EventArgs e)
        {
            OOSDishesSet frmOOSDish = new OOSDishesSet();
            frmOOSDish.Show();
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!e.Cancel)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                Rectangle rect = row.Cells[e.ColumnIndex].ContentBounds;
                Point point = dataGridView1.PointToScreen(rect.Location);

                int height = rect.Height == 0 ? 20 * (e.RowIndex + 1 + 1 + 1 + 1) : rect.Height * (e.RowIndex + 1 + 1 + 1 + 1);

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
            Dish dish = row.Tag as Dish;

            OOSDish oosDish = this.dishController.GetOOSDish(dish);

            int iCount = 0;

            if (int.TryParse(row.Cells[e.ColumnIndex].Value.ToString(), out iCount))
            {
                if (iCount > oosDish.Quantity)
                {
                    MessageBox.Show(string.Format("所点菜品数量大于已有数量，请重新输入"));
                    row.Cells[e.ColumnIndex].Value = 1;
                }
                lbOrderAmount.Text = computeAmount();
            }
            else
            {
                MessageBox.Show("请输入有效的数值！");
                row.Cells[e.ColumnIndex].Value = 1;
            }
            decimal decPrice = decimal.Zero;
            decimal decAmount = decimal.Zero;
            if (decimal.TryParse(row.Cells[4].Value.ToString(), out decPrice))
            {
                decAmount = iCount * decPrice;
            }
            if (!CheckCardBalance(decAmount))
            {
                MessageBox.Show("当前余额不足，请去前台充值！");
                row.Cells[e.ColumnIndex].Value = 1;
            }
            if (frmOSK.Visible) frmOSK.Visible = false;
        }

        private void btRequire_Click(object sender, EventArgs e)
        {
            
        }
        
        
    }
}
