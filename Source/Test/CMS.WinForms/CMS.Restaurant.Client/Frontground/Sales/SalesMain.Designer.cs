namespace CMS.Restaurant.Client.Sales
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    partial class SalesMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesMain));
            this.panel3 = new System.Windows.Forms.Panel();
            this.tlpCategory = new System.Windows.Forms.TableLayoutPanel();
            this.tlp = new System.Windows.Forms.TableLayoutPanel();
            this.btnItemPrevious = new System.Windows.Forms.Button();
            this.btnItemNext = new System.Windows.Forms.Button();
            this.btnItemLast = new System.Windows.Forms.Button();
            this.btnItemFirst = new System.Windows.Forms.Button();
            this.tlpDish = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnTypeItemPrevious = new System.Windows.Forms.Button();
            this.btnTypeItemFirst = new System.Windows.Forms.Button();
            this.btnTypeItemLast = new System.Windows.Forms.Button();
            this.btnTypeItemNext = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Taste = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lbCardAmount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbOrderAmount = new System.Windows.Forms.Label();
            this.lbTotleSales = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.tlpFunction = new System.Windows.Forms.TableLayoutPanel();
            this.btDelete = new System.Windows.Forms.Button();
            this.btRequire = new System.Windows.Forms.Button();
            this.btNumber = new System.Windows.Forms.Button();
            this.btInsert = new System.Windows.Forms.Button();
            this.LblTimeSales = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSwapCard = new System.Windows.Forms.Button();
            this.btnAddMenu = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbEntrance = new System.Windows.Forms.Label();
            this.lbAmount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbSalse = new System.Windows.Forms.Label();
            this.lbEmployeeName = new System.Windows.Forms.Label();
            this.lbEmployeeNo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtCloseSale = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LblUserNo = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.refreshDishQuantity = new System.Windows.Forms.Timer(this.components);
            this.panel3.SuspendLayout();
            this.tlp.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel6.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tlpFunction.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tlpCategory);
            this.panel3.Controls.Add(this.tlp);
            this.panel3.Controls.Add(this.tlpDish);
            this.panel3.Controls.Add(this.tableLayoutPanel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(624, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(400, 768);
            this.panel3.TabIndex = 5;
            // 
            // tlpCategory
            // 
            this.tlpCategory.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tlpCategory.ColumnCount = 4;
            this.tlpCategory.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpCategory.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpCategory.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpCategory.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCategory.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tlpCategory.Location = new System.Drawing.Point(0, 435);
            this.tlpCategory.Name = "tlpCategory";
            this.tlpCategory.RowCount = 4;
            this.tlpCategory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpCategory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpCategory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpCategory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpCategory.Size = new System.Drawing.Size(400, 273);
            this.tlpCategory.TabIndex = 6;
            // 
            // tlp
            // 
            this.tlp.BackColor = System.Drawing.Color.Silver;
            this.tlp.ColumnCount = 4;
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp.Controls.Add(this.btnItemPrevious, 1, 0);
            this.tlp.Controls.Add(this.btnItemNext, 2, 0);
            this.tlp.Controls.Add(this.btnItemLast, 3, 0);
            this.tlp.Controls.Add(this.btnItemFirst, 0, 0);
            this.tlp.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlp.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tlp.Location = new System.Drawing.Point(0, 375);
            this.tlp.Name = "tlp";
            this.tlp.RowCount = 1;
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlp.Size = new System.Drawing.Size(400, 60);
            this.tlp.TabIndex = 4;
            // 
            // btnItemPrevious
            // 
            this.btnItemPrevious.BackColor = System.Drawing.Color.Chocolate;
            this.btnItemPrevious.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnItemPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnItemPrevious.Location = new System.Drawing.Point(103, 3);
            this.btnItemPrevious.Name = "btnItemPrevious";
            this.btnItemPrevious.Size = new System.Drawing.Size(94, 54);
            this.btnItemPrevious.TabIndex = 20;
            this.btnItemPrevious.Tag = "0";
            this.btnItemPrevious.Text = "上一页";
            this.btnItemPrevious.UseVisualStyleBackColor = false;
            this.btnItemPrevious.Click += new System.EventHandler(this.btnItemPrevious_Click);
            // 
            // btnItemNext
            // 
            this.btnItemNext.BackColor = System.Drawing.Color.Chocolate;
            this.btnItemNext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnItemNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnItemNext.Location = new System.Drawing.Point(203, 3);
            this.btnItemNext.Name = "btnItemNext";
            this.btnItemNext.Size = new System.Drawing.Size(94, 54);
            this.btnItemNext.TabIndex = 17;
            this.btnItemNext.Tag = "1";
            this.btnItemNext.Text = "下一页";
            this.btnItemNext.UseVisualStyleBackColor = false;
            this.btnItemNext.Click += new System.EventHandler(this.btnItemNext_Click);
            // 
            // btnItemLast
            // 
            this.btnItemLast.BackColor = System.Drawing.Color.Chocolate;
            this.btnItemLast.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnItemLast.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnItemLast.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnItemLast.Location = new System.Drawing.Point(303, 3);
            this.btnItemLast.Name = "btnItemLast";
            this.btnItemLast.Size = new System.Drawing.Size(94, 54);
            this.btnItemLast.TabIndex = 19;
            this.btnItemLast.Text = "末页";
            this.btnItemLast.UseVisualStyleBackColor = false;
            this.btnItemLast.Click += new System.EventHandler(this.btnItemLast_Click);
            // 
            // btnItemFirst
            // 
            this.btnItemFirst.BackColor = System.Drawing.Color.Chocolate;
            this.btnItemFirst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnItemFirst.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnItemFirst.Location = new System.Drawing.Point(3, 3);
            this.btnItemFirst.Name = "btnItemFirst";
            this.btnItemFirst.Size = new System.Drawing.Size(94, 54);
            this.btnItemFirst.TabIndex = 16;
            this.btnItemFirst.Tag = "0";
            this.btnItemFirst.Text = "首页";
            this.btnItemFirst.UseVisualStyleBackColor = false;
            this.btnItemFirst.Click += new System.EventHandler(this.btnItemFirst_Click);
            // 
            // tlpDish
            // 
            this.tlpDish.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tlpDish.ColumnCount = 4;
            this.tlpDish.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpDish.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpDish.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpDish.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpDish.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpDish.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tlpDish.ForeColor = System.Drawing.Color.Black;
            this.tlpDish.Location = new System.Drawing.Point(0, 0);
            this.tlpDish.Name = "tlpDish";
            this.tlpDish.RowCount = 5;
            this.tlpDish.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpDish.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpDish.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpDish.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpDish.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpDish.Size = new System.Drawing.Size(400, 375);
            this.tlpDish.TabIndex = 3;
            this.tlpDish.Paint += new System.Windows.Forms.PaintEventHandler(this.tlpDish_Paint_1);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Silver;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.btnTypeItemPrevious, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnTypeItemFirst, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnTypeItemLast, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnTypeItemNext, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 708);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(400, 60);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // btnTypeItemPrevious
            // 
            this.btnTypeItemPrevious.BackColor = System.Drawing.Color.Chocolate;
            this.btnTypeItemPrevious.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTypeItemPrevious.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTypeItemPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTypeItemPrevious.Location = new System.Drawing.Point(103, 3);
            this.btnTypeItemPrevious.Name = "btnTypeItemPrevious";
            this.btnTypeItemPrevious.Size = new System.Drawing.Size(94, 54);
            this.btnTypeItemPrevious.TabIndex = 13;
            this.btnTypeItemPrevious.Tag = "0";
            this.btnTypeItemPrevious.Text = "上一页";
            this.btnTypeItemPrevious.UseVisualStyleBackColor = false;
            this.btnTypeItemPrevious.Click += new System.EventHandler(this.btnTypeItemPrevious_Click);
            // 
            // btnTypeItemFirst
            // 
            this.btnTypeItemFirst.BackColor = System.Drawing.Color.Chocolate;
            this.btnTypeItemFirst.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTypeItemFirst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTypeItemFirst.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTypeItemFirst.Location = new System.Drawing.Point(3, 3);
            this.btnTypeItemFirst.Name = "btnTypeItemFirst";
            this.btnTypeItemFirst.Size = new System.Drawing.Size(94, 54);
            this.btnTypeItemFirst.TabIndex = 12;
            this.btnTypeItemFirst.Tag = "0";
            this.btnTypeItemFirst.Text = "首页";
            this.btnTypeItemFirst.UseVisualStyleBackColor = false;
            this.btnTypeItemFirst.Click += new System.EventHandler(this.btnTypeItemFirst_Click);
            // 
            // btnTypeItemLast
            // 
            this.btnTypeItemLast.BackColor = System.Drawing.Color.Chocolate;
            this.btnTypeItemLast.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTypeItemLast.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTypeItemLast.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTypeItemLast.Location = new System.Drawing.Point(303, 3);
            this.btnTypeItemLast.Name = "btnTypeItemLast";
            this.btnTypeItemLast.Size = new System.Drawing.Size(94, 54);
            this.btnTypeItemLast.TabIndex = 11;
            this.btnTypeItemLast.Text = "末页";
            this.btnTypeItemLast.UseVisualStyleBackColor = false;
            this.btnTypeItemLast.Click += new System.EventHandler(this.btnTypeItemLast_Click);
            // 
            // btnTypeItemNext
            // 
            this.btnTypeItemNext.BackColor = System.Drawing.Color.Chocolate;
            this.btnTypeItemNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTypeItemNext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTypeItemNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTypeItemNext.Location = new System.Drawing.Point(203, 3);
            this.btnTypeItemNext.Name = "btnTypeItemNext";
            this.btnTypeItemNext.Size = new System.Drawing.Size(94, 54);
            this.btnTypeItemNext.TabIndex = 10;
            this.btnTypeItemNext.Tag = "1";
            this.btnTypeItemNext.Text = "下一页";
            this.btnTypeItemNext.UseVisualStyleBackColor = false;
            this.btnTypeItemNext.Click += new System.EventHandler(this.btnTypeItemNext_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(624, 768);
            this.panel2.TabIndex = 6;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Index,
            this.Code,
            this.Title,
            this.Quantity,
            this.Price,
            this.Unit,
            this.Taste,
            this.Column7,
            this.Column8,
            this.Column9});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.Location = new System.Drawing.Point(0, 100);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(624, 479);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowLeave);
            this.dataGridView1.Leave += new System.EventHandler(this.dataGridView1_Leave);
            // 
            // Index
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Index.DefaultCellStyle = dataGridViewCellStyle6;
            this.Index.HeaderText = "序号";
            this.Index.Name = "Index";
            // 
            // Code
            // 
            this.Code.HeaderText = "代码";
            this.Code.Name = "Code";
            // 
            // Title
            // 
            this.Title.HeaderText = "品名";
            this.Title.Name = "Title";
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "数量";
            this.Quantity.Name = "Quantity";
            // 
            // Price
            // 
            this.Price.HeaderText = "单价";
            this.Price.Name = "Price";
            // 
            // Unit
            // 
            this.Unit.HeaderText = "单位";
            this.Unit.Name = "Unit";
            // 
            // Taste
            // 
            this.Taste.HeaderText = "口味/要求";
            this.Taste.Name = "Taste";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "操作员";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "入单时间";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "设备";
            this.Column9.Name = "Column9";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel6.Controls.Add(this.tableLayoutPanel2);
            this.panel6.Controls.Add(this.tlpFunction);
            this.panel6.Controls.Add(this.LblTimeSales);
            this.panel6.Controls.Add(this.tableLayoutPanel3);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 579);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(624, 189);
            this.panel6.TabIndex = 8;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.panel7, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel5, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(282, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(189, 189);
            this.tableLayoutPanel2.TabIndex = 10;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.DarkRed;
            this.panel7.Controls.Add(this.lbCardAmount);
            this.panel7.Controls.Add(this.label6);
            this.panel7.Controls.Add(this.lblBalance);
            this.panel7.Location = new System.Drawing.Point(3, 97);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(183, 88);
            this.panel7.TabIndex = 8;
            // 
            // lbCardAmount
            // 
            this.lbCardAmount.AutoSize = true;
            this.lbCardAmount.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbCardAmount.ForeColor = System.Drawing.Color.White;
            this.lbCardAmount.Location = new System.Drawing.Point(10, 47);
            this.lbCardAmount.Name = "lbCardAmount";
            this.lbCardAmount.Size = new System.Drawing.Size(153, 26);
            this.lbCardAmount.TabIndex = 2;
            this.lbCardAmount.Text = "lbCardAmount";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 12);
            this.label6.TabIndex = 1;
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBalance.ForeColor = System.Drawing.Color.White;
            this.lblBalance.Location = new System.Drawing.Point(38, 0);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(106, 26);
            this.lblBalance.TabIndex = 0;
            this.lblBalance.Text = "卡 内 金 额";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DarkRed;
            this.panel5.Controls.Add(this.lbOrderAmount);
            this.panel5.Controls.Add(this.lbTotleSales);
            this.panel5.Controls.Add(this.lblTotal);
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(183, 88);
            this.panel5.TabIndex = 7;
            // 
            // lbOrderAmount
            // 
            this.lbOrderAmount.AutoSize = true;
            this.lbOrderAmount.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbOrderAmount.ForeColor = System.Drawing.Color.White;
            this.lbOrderAmount.Location = new System.Drawing.Point(10, 44);
            this.lbOrderAmount.Name = "lbOrderAmount";
            this.lbOrderAmount.Size = new System.Drawing.Size(164, 26);
            this.lbOrderAmount.TabIndex = 2;
            this.lbOrderAmount.Text = "lbOrderAmount";
            // 
            // lbTotleSales
            // 
            this.lbTotleSales.AutoSize = true;
            this.lbTotleSales.Location = new System.Drawing.Point(45, 97);
            this.lbTotleSales.Name = "lbTotleSales";
            this.lbTotleSales.Size = new System.Drawing.Size(0, 12);
            this.lbTotleSales.TabIndex = 1;
            this.lbTotleSales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotal.ForeColor = System.Drawing.Color.White;
            this.lblTotal.Location = new System.Drawing.Point(38, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(106, 26);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "本 次 合 计";
            // 
            // tlpFunction
            // 
            this.tlpFunction.ColumnCount = 2;
            this.tlpFunction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFunction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFunction.Controls.Add(this.btDelete, 1, 1);
            this.tlpFunction.Controls.Add(this.btRequire, 0, 1);
            this.tlpFunction.Controls.Add(this.btNumber, 1, 0);
            this.tlpFunction.Controls.Add(this.btInsert, 0, 0);
            this.tlpFunction.Dock = System.Windows.Forms.DockStyle.Left;
            this.tlpFunction.Location = new System.Drawing.Point(0, 0);
            this.tlpFunction.Name = "tlpFunction";
            this.tlpFunction.RowCount = 2;
            this.tlpFunction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFunction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpFunction.Size = new System.Drawing.Size(282, 189);
            this.tlpFunction.TabIndex = 9;
            // 
            // btDelete
            // 
            this.btDelete.BackColor = System.Drawing.Color.Lime;
            this.btDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btDelete.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btDelete.Location = new System.Drawing.Point(144, 97);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(135, 89);
            this.btDelete.TabIndex = 3;
            this.btDelete.Text = "删 除";
            this.btDelete.UseVisualStyleBackColor = false;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btRequire
            // 
            this.btRequire.BackColor = System.Drawing.Color.Lime;
            this.btRequire.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btRequire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btRequire.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btRequire.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btRequire.Location = new System.Drawing.Point(3, 97);
            this.btRequire.Name = "btRequire";
            this.btRequire.Size = new System.Drawing.Size(135, 89);
            this.btRequire.TabIndex = 2;
            this.btRequire.Text = "做法 / 要求";
            this.btRequire.UseVisualStyleBackColor = false;
            this.btRequire.Click += new System.EventHandler(this.btRequire_Click);
            // 
            // btNumber
            // 
            this.btNumber.BackColor = System.Drawing.Color.Lime;
            this.btNumber.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btNumber.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btNumber.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btNumber.Location = new System.Drawing.Point(144, 3);
            this.btNumber.Name = "btNumber";
            this.btNumber.Size = new System.Drawing.Size(135, 88);
            this.btNumber.TabIndex = 1;
            this.btNumber.Text = "数 量";
            this.btNumber.UseVisualStyleBackColor = false;
            // 
            // btInsert
            // 
            this.btInsert.BackColor = System.Drawing.Color.Lime;
            this.btInsert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btInsert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btInsert.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btInsert.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btInsert.Location = new System.Drawing.Point(3, 3);
            this.btInsert.Name = "btInsert";
            this.btInsert.Size = new System.Drawing.Size(135, 88);
            this.btInsert.TabIndex = 0;
            this.btInsert.Text = "沽 清";
            this.btInsert.UseVisualStyleBackColor = false;
            this.btInsert.Click += new System.EventHandler(this.btInsert_Click);
            // 
            // LblTimeSales
            // 
            this.LblTimeSales.AutoSize = true;
            this.LblTimeSales.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblTimeSales.ForeColor = System.Drawing.Color.Maroon;
            this.LblTimeSales.Location = new System.Drawing.Point(35, 83);
            this.LblTimeSales.Name = "LblTimeSales";
            this.LblTimeSales.Size = new System.Drawing.Size(18, 26);
            this.LblTimeSales.TabIndex = 8;
            this.LblTimeSales.Text = " ";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.btnSwapCard, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnAddMenu, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(471, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(153, 189);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // btnSwapCard
            // 
            this.btnSwapCard.BackColor = System.Drawing.Color.Yellow;
            this.btnSwapCard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSwapCard.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSwapCard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSwapCard.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSwapCard.Location = new System.Drawing.Point(3, 3);
            this.btnSwapCard.Name = "btnSwapCard";
            this.btnSwapCard.Size = new System.Drawing.Size(147, 88);
            this.btnSwapCard.TabIndex = 0;
            this.btnSwapCard.Text = "刷 卡";
            this.btnSwapCard.UseVisualStyleBackColor = false;
            this.btnSwapCard.Click += new System.EventHandler(this.btnSwapCard_Click);
            // 
            // btnAddMenu
            // 
            this.btnAddMenu.BackColor = System.Drawing.Color.Yellow;
            this.btnAddMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddMenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAddMenu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddMenu.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddMenu.Location = new System.Drawing.Point(3, 97);
            this.btnAddMenu.Name = "btnAddMenu";
            this.btnAddMenu.Size = new System.Drawing.Size(147, 89);
            this.btnAddMenu.TabIndex = 1;
            this.btnAddMenu.Text = "入 单";
            this.btnAddMenu.UseVisualStyleBackColor = false;
            this.btnAddMenu.Click += new System.EventHandler(this.btnAddMenu_Click_1);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(435, 582);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(0, 183);
            this.panel4.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(45, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 27);
            this.label2.TabIndex = 0;
            this.label2.Text = "合 计 金 额";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.lbEntrance);
            this.panel1.Controls.Add(this.lbAmount);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lbSalse);
            this.panel1.Controls.Add(this.lbEmployeeName);
            this.panel1.Controls.Add(this.lbEmployeeNo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.BtCloseSale);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.LblUserNo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(624, 100);
            this.panel1.TabIndex = 0;
            // 
            // lbEntrance
            // 
            this.lbEntrance.AutoSize = true;
            this.lbEntrance.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbEntrance.Location = new System.Drawing.Point(370, 12);
            this.lbEntrance.Name = "lbEntrance";
            this.lbEntrance.Size = new System.Drawing.Size(114, 26);
            this.lbEntrance.TabIndex = 13;
            this.lbEntrance.Text = "lbEntrance";
            // 
            // lbAmount
            // 
            this.lbAmount.AutoSize = true;
            this.lbAmount.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbAmount.Location = new System.Drawing.Point(370, 60);
            this.lbAmount.Name = "lbAmount";
            this.lbAmount.Size = new System.Drawing.Size(108, 26);
            this.lbAmount.TabIndex = 12;
            this.lbAmount.Text = "lbAmount";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(277, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 26);
            this.label4.TabIndex = 11;
            this.label4.Text = "档   口：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.OrangeRed;
            this.label3.Location = new System.Drawing.Point(278, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 26);
            this.label3.TabIndex = 10;
            this.label3.Text = "营业额：";
            // 
            // lbSalse
            // 
            this.lbSalse.AutoSize = true;
            this.lbSalse.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSalse.ForeColor = System.Drawing.Color.DarkBlue;
            this.lbSalse.Location = new System.Drawing.Point(347, 56);
            this.lbSalse.Name = "lbSalse";
            this.lbSalse.Size = new System.Drawing.Size(0, 26);
            this.lbSalse.TabIndex = 8;
            // 
            // lbEmployeeName
            // 
            this.lbEmployeeName.AutoSize = true;
            this.lbEmployeeName.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbEmployeeName.Location = new System.Drawing.Point(157, 60);
            this.lbEmployeeName.Name = "lbEmployeeName";
            this.lbEmployeeName.Size = new System.Drawing.Size(182, 26);
            this.lbEmployeeName.TabIndex = 7;
            this.lbEmployeeName.Text = "lbEmployeeName";
            // 
            // lbEmployeeNo
            // 
            this.lbEmployeeNo.AutoSize = true;
            this.lbEmployeeNo.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbEmployeeNo.Location = new System.Drawing.Point(157, 12);
            this.lbEmployeeNo.Name = "lbEmployeeNo";
            this.lbEmployeeNo.Size = new System.Drawing.Size(153, 26);
            this.lbEmployeeNo.TabIndex = 6;
            this.lbEmployeeNo.Text = "lbEmployeeNo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(97, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 26);
            this.label1.TabIndex = 5;
            this.label1.Text = "姓名：";
            // 
            // BtCloseSale
            // 
            this.BtCloseSale.BackColor = System.Drawing.Color.IndianRed;
            this.BtCloseSale.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtCloseSale.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtCloseSale.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtCloseSale.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtCloseSale.Location = new System.Drawing.Point(477, 0);
            this.BtCloseSale.Name = "BtCloseSale";
            this.BtCloseSale.Size = new System.Drawing.Size(147, 100);
            this.BtCloseSale.TabIndex = 4;
            this.BtCloseSale.Text = "退出";
            this.BtCloseSale.UseVisualStyleBackColor = false;
            this.BtCloseSale.Click += new System.EventHandler(this.BtCloseSale_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // LblUserNo
            // 
            this.LblUserNo.AutoSize = true;
            this.LblUserNo.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblUserNo.Location = new System.Drawing.Point(97, 12);
            this.LblUserNo.Name = "LblUserNo";
            this.LblUserNo.Size = new System.Drawing.Size(69, 26);
            this.LblUserNo.TabIndex = 0;
            this.LblUserNo.Text = "工号：";
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 999;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // SalesMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SalesMain";
            this.Text = "CMS收银管理系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel3.ResumeLayout(false);
            this.tlp.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tlpFunction.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnTypeItemLast;
        private System.Windows.Forms.Button btnTypeItemNext;
        private System.Windows.Forms.TableLayoutPanel tlpDish;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtCloseSale;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LblUserNo;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lbEmployeeName;
        private System.Windows.Forms.Label lbEmployeeNo;
        private System.Windows.Forms.Label lbSalse;
        private System.Windows.Forms.Button btnTypeItemPrevious;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tlpCategory;
        private System.Windows.Forms.TableLayoutPanel tlp;
        private System.Windows.Forms.Button btnItemNext;
        private System.Windows.Forms.Button btnItemFirst;
        private System.Windows.Forms.Button btnTypeItemFirst;
        private System.Windows.Forms.Button btnItemPrevious;
        private System.Windows.Forms.Button btnItemLast;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TableLayoutPanel tlpFunction;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btRequire;
        private System.Windows.Forms.Button btNumber;
        private System.Windows.Forms.Button btInsert;
        private System.Windows.Forms.Label LblTimeSales;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lbTotleSales;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnSwapCard;
        private System.Windows.Forms.Button btnAddMenu;
        private Label label4;
        private Label lbAmount;
        private Label lbEntrance;
        private DataGridViewTextBoxColumn Index;
        private DataGridViewTextBoxColumn Code;
        private DataGridViewTextBoxColumn Title;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn Unit;
        private DataGridViewTextBoxColumn Taste;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column9;
        private Label lbOrderAmount;
        private Timer refreshDishQuantity;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel7;
        private Label lbCardAmount;
        private Label label6;
        private Label lblBalance;

    }
}

