namespace CMS.WinForms.Cash
{
    partial class CashMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CashMain));
            this.PanelMainLeft = new System.Windows.Forms.Panel();
            this.lbFullName = new System.Windows.Forms.Label();
            this.lbLogin = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label40 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.lbAllEntranceAmount = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.LBLName = new System.Windows.Forms.Label();
            this.LblTime = new System.Windows.Forms.Label();
            this.LBLNo = new System.Windows.Forms.Label();
            this.pictureBoxFace = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.TLPanelButton = new System.Windows.Forms.TableLayoutPanel();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.buttonBilling = new System.Windows.Forms.Button();
            this.buttonCheckout = new System.Windows.Forms.Button();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.TLPanelStatus = new System.Windows.Forms.TableLayoutPanel();
            this.amountTimer = new System.Windows.Forms.Timer(this.components);
            this.PanelMainLeft.SuspendLayout();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFace)).BeginInit();
            this.TLPanelButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelMainLeft
            // 
            this.PanelMainLeft.Controls.Add(this.lbFullName);
            this.PanelMainLeft.Controls.Add(this.lbLogin);
            this.PanelMainLeft.Controls.Add(this.button10);
            this.PanelMainLeft.Controls.Add(this.groupBox10);
            this.PanelMainLeft.Controls.Add(this.lbAllEntranceAmount);
            this.PanelMainLeft.Controls.Add(this.label37);
            this.PanelMainLeft.Controls.Add(this.LBLName);
            this.PanelMainLeft.Controls.Add(this.LblTime);
            this.PanelMainLeft.Controls.Add(this.LBLNo);
            this.PanelMainLeft.Controls.Add(this.pictureBoxFace);
            this.PanelMainLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelMainLeft.Location = new System.Drawing.Point(0, 0);
            this.PanelMainLeft.Name = "PanelMainLeft";
            this.PanelMainLeft.Size = new System.Drawing.Size(335, 745);
            this.PanelMainLeft.TabIndex = 0;
            this.PanelMainLeft.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelMainLeft_Paint);
            // 
            // lbFullName
            // 
            this.lbFullName.AutoSize = true;
            this.lbFullName.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbFullName.Location = new System.Drawing.Point(133, 348);
            this.lbFullName.Name = "lbFullName";
            this.lbFullName.Size = new System.Drawing.Size(0, 27);
            this.lbFullName.TabIndex = 11;
            // 
            // lbLogin
            // 
            this.lbLogin.AutoSize = true;
            this.lbLogin.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbLogin.Location = new System.Drawing.Point(133, 295);
            this.lbLogin.Name = "lbLogin";
            this.lbLogin.Size = new System.Drawing.Size(0, 27);
            this.lbLogin.TabIndex = 10;
            // 
            // button10
            // 
            this.button10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button10.ForeColor = System.Drawing.Color.Black;
            this.button10.Location = new System.Drawing.Point(125, 553);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(70, 70);
            this.button10.TabIndex = 9;
            this.button10.Text = "设 置";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.linkLabel1);
            this.groupBox10.Controls.Add(this.label40);
            this.groupBox10.Controls.Add(this.label39);
            this.groupBox10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox10.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox10.Location = new System.Drawing.Point(0, 639);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(335, 106);
            this.groupBox10.TabIndex = 8;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "软件信息";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(94, 71);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(123, 19);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "www.xxxxx.com";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label40.Location = new System.Drawing.Point(12, 74);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(82, 14);
            this.label40.TabIndex = 1;
            this.label40.Text = "公司网址：";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("楷体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label39.Location = new System.Drawing.Point(13, 45);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(170, 14);
            this.label39.TabIndex = 0;
            this.label39.Text = "联系电话： XXXXXXXXXX";
            // 
            // lbAllEntranceAmount
            // 
            this.lbAllEntranceAmount.AutoSize = true;
            this.lbAllEntranceAmount.Location = new System.Drawing.Point(120, 516);
            this.lbAllEntranceAmount.Name = "lbAllEntranceAmount";
            this.lbAllEntranceAmount.Size = new System.Drawing.Size(89, 12);
            this.lbAllEntranceAmount.TabIndex = 7;
            this.lbAllEntranceAmount.Text = "获取当前营业额";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.BackColor = System.Drawing.Color.LightYellow;
            this.label37.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label37.ForeColor = System.Drawing.Color.OrangeRed;
            this.label37.Location = new System.Drawing.Point(111, 456);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(99, 28);
            this.label37.TabIndex = 6;
            this.label37.Text = "营  业  额";
            // 
            // LBLName
            // 
            this.LBLName.AutoSize = true;
            this.LBLName.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LBLName.Location = new System.Drawing.Point(61, 347);
            this.LBLName.Name = "LBLName";
            this.LBLName.Size = new System.Drawing.Size(78, 27);
            this.LBLName.TabIndex = 5;
            this.LBLName.Text = "姓 名：";
            // 
            // LblTime
            // 
            this.LblTime.AutoSize = true;
            this.LblTime.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTime.ForeColor = System.Drawing.Color.Maroon;
            this.LblTime.Location = new System.Drawing.Point(61, 400);
            this.LblTime.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.LblTime.Name = "LblTime";
            this.LblTime.Size = new System.Drawing.Size(17, 26);
            this.LblTime.TabIndex = 4;
            this.LblTime.Text = ".";
            // 
            // LBLNo
            // 
            this.LBLNo.AutoSize = true;
            this.LBLNo.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LBLNo.Location = new System.Drawing.Point(61, 294);
            this.LBLNo.Name = "LBLNo";
            this.LBLNo.Size = new System.Drawing.Size(78, 27);
            this.LBLNo.TabIndex = 1;
            this.LBLNo.Text = "工 号：";
            // 
            // pictureBoxFace
            // 
            this.pictureBoxFace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBoxFace.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxFace.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxFace.Image")));
            this.pictureBoxFace.Location = new System.Drawing.Point(61, 46);
            this.pictureBoxFace.Name = "pictureBoxFace";
            this.pictureBoxFace.Size = new System.Drawing.Size(210, 210);
            this.pictureBoxFace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxFace.TabIndex = 0;
            this.pictureBoxFace.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 999;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TLPanelButton
            // 
            this.TLPanelButton.ColumnCount = 4;
            this.TLPanelButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TLPanelButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TLPanelButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TLPanelButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TLPanelButton.Controls.Add(this.buttonLogout, 0, 0);
            this.TLPanelButton.Controls.Add(this.buttonBilling, 3, 0);
            this.TLPanelButton.Controls.Add(this.buttonCheckout, 2, 0);
            this.TLPanelButton.Controls.Add(this.buttonPrint, 1, 0);
            this.TLPanelButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TLPanelButton.Location = new System.Drawing.Point(335, 645);
            this.TLPanelButton.Name = "TLPanelButton";
            this.TLPanelButton.RowCount = 1;
            this.TLPanelButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLPanelButton.Size = new System.Drawing.Size(929, 100);
            this.TLPanelButton.TabIndex = 1;
            // 
            // buttonLogout
            // 
            this.buttonLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLogout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLogout.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonLogout.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonLogout.ForeColor = System.Drawing.Color.Black;
            this.buttonLogout.Location = new System.Drawing.Point(3, 3);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(226, 94);
            this.buttonLogout.TabIndex = 8;
            this.buttonLogout.Text = "退出     （F4）";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // buttonBilling
            // 
            this.buttonBilling.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBilling.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonBilling.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonBilling.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonBilling.ForeColor = System.Drawing.Color.OrangeRed;
            this.buttonBilling.Location = new System.Drawing.Point(699, 3);
            this.buttonBilling.Name = "buttonBilling";
            this.buttonBilling.Size = new System.Drawing.Size(227, 94);
            this.buttonBilling.TabIndex = 6;
            this.buttonBilling.Text = "开卡     （F1）";
            this.buttonBilling.UseVisualStyleBackColor = true;
            this.buttonBilling.Click += new System.EventHandler(this.buttonBilling_Click);
            this.buttonBilling.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonBilling_Paint);
            // 
            // buttonCheckout
            // 
            this.buttonCheckout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCheckout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCheckout.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCheckout.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonCheckout.ForeColor = System.Drawing.Color.Crimson;
            this.buttonCheckout.Location = new System.Drawing.Point(467, 3);
            this.buttonCheckout.Name = "buttonCheckout";
            this.buttonCheckout.Size = new System.Drawing.Size(226, 94);
            this.buttonCheckout.TabIndex = 5;
            this.buttonCheckout.Text = "结账     （F2）";
            this.buttonCheckout.UseVisualStyleBackColor = true;
            this.buttonCheckout.Click += new System.EventHandler(this.buttonCheckout_Click);
            // 
            // buttonPrint
            // 
            this.buttonPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonPrint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonPrint.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonPrint.ForeColor = System.Drawing.Color.Green;
            this.buttonPrint.Location = new System.Drawing.Point(235, 3);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(226, 94);
            this.buttonPrint.TabIndex = 7;
            this.buttonPrint.Text = "打印     （F3）";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // TLPanelStatus
            // 
            this.TLPanelStatus.ColumnCount = 3;
            this.TLPanelStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33223F));
            this.TLPanelStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33223F));
            this.TLPanelStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33553F));
            this.TLPanelStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLPanelStatus.Location = new System.Drawing.Point(335, 0);
            this.TLPanelStatus.Name = "TLPanelStatus";
            this.TLPanelStatus.RowCount = 3;
            this.TLPanelStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TLPanelStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TLPanelStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TLPanelStatus.Size = new System.Drawing.Size(929, 645);
            this.TLPanelStatus.TabIndex = 2;
            // 
            // CashMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(1264, 745);
            this.Controls.Add(this.TLPanelStatus);
            this.Controls.Add(this.TLPanelButton);
            this.Controls.Add(this.PanelMainLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CashMain";
            this.Text = "CMS收银管理系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.PanelMainLeft.ResumeLayout(false);
            this.PanelMainLeft.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFace)).EndInit();
            this.TLPanelButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelMainLeft;
        private System.Windows.Forms.Label LBLNo;
        private System.Windows.Forms.PictureBox pictureBoxFace;
        private System.Windows.Forms.Label LblTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel TLPanelButton;
        private System.Windows.Forms.Button buttonBilling;
        private System.Windows.Forms.Button buttonCheckout;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.Label LBLName;
        private System.Windows.Forms.TableLayoutPanel TLPanelStatus;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label lbAllEntranceAmount;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Label lbFullName;
        private System.Windows.Forms.Label lbLogin;
        private System.Windows.Forms.Timer amountTimer;
    }
    
}

