namespace CMS.WinForms.Background
{
    partial class BackgroundMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackgroundMain));
            this.pnBackgroundBT = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnBackgroundTop = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BasicSetting = new System.Windows.Forms.ToolStripDropDownButton();
            this.DishTypeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DishMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CookTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EmployeeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.沽清设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DishStyleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AdvanceSetting = new System.Windows.Forms.ToolStripDropDownButton();
            this.RestaurantManageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EntranceManageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RightManageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PrinterManageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSplitButton3 = new System.Windows.Forms.ToolStripDropDownButton();
            this.SalesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EntranceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSplitButton4 = new System.Windows.Forms.ToolStripDropDownButton();
            this.DailyReportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSplitButton5 = new System.Windows.Forms.ToolStripDropDownButton();
            this.软件信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.注销退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnBackgroundFill = new System.Windows.Forms.Panel();
            this.CardMachineManageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnBackgroundBT.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.pnBackgroundTop.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnBackgroundBT
            // 
            this.pnBackgroundBT.Controls.Add(this.statusStrip1);
            this.pnBackgroundBT.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnBackgroundBT.Location = new System.Drawing.Point(0, 681);
            this.pnBackgroundBT.Name = "pnBackgroundBT";
            this.pnBackgroundBT.Size = new System.Drawing.Size(1248, 25);
            this.pnBackgroundBT.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 3);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1248, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusLabel1.Text = "当前时间：";
            // 
            // pnBackgroundTop
            // 
            this.pnBackgroundTop.Controls.Add(this.toolStrip1);
            this.pnBackgroundTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnBackgroundTop.Location = new System.Drawing.Point(0, 0);
            this.pnBackgroundTop.Name = "pnBackgroundTop";
            this.pnBackgroundTop.Size = new System.Drawing.Size(1248, 43);
            this.pnBackgroundTop.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BasicSetting,
            this.AdvanceSetting,
            this.toolStripSplitButton3,
            this.toolStripSplitButton4,
            this.toolStripSplitButton5});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1248, 43);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BasicSetting
            // 
            this.BasicSetting.AutoSize = false;
            this.BasicSetting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.BasicSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DishTypeMenuItem,
            this.DishMenuItem,
            this.CookTypeToolStripMenuItem,
            this.EmployeeMenuItem,
            this.沽清设置ToolStripMenuItem,
            this.DishStyleMenuItem});
            this.BasicSetting.Image = ((System.Drawing.Image)(resources.GetObject("BasicSetting.Image")));
            this.BasicSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BasicSetting.Name = "BasicSetting";
            this.BasicSetting.Size = new System.Drawing.Size(100, 40);
            this.BasicSetting.Text = "基本设置(B)";
            // 
            // DishTypeMenuItem
            // 
            this.DishTypeMenuItem.Name = "DishTypeMenuItem";
            this.DishTypeMenuItem.Size = new System.Drawing.Size(152, 22);
            this.DishTypeMenuItem.Text = "大类设置";
            this.DishTypeMenuItem.Click += new System.EventHandler(this.DishTypeMenuItem_Click);
            // 
            // DishMenuItem
            // 
            this.DishMenuItem.Name = "DishMenuItem";
            this.DishMenuItem.Size = new System.Drawing.Size(152, 22);
            this.DishMenuItem.Text = "菜品设置";
            this.DishMenuItem.Click += new System.EventHandler(this.DishMenuItem_Click);
            // 
            // CookTypeToolStripMenuItem
            // 
            this.CookTypeToolStripMenuItem.Name = "CookTypeToolStripMenuItem";
            this.CookTypeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.CookTypeToolStripMenuItem.Text = "口味/要求";
            this.CookTypeToolStripMenuItem.Click += new System.EventHandler(this.CookTypeToolStripMenuItem_Click);
            // 
            // EmployeeMenuItem
            // 
            this.EmployeeMenuItem.Name = "EmployeeMenuItem";
            this.EmployeeMenuItem.Size = new System.Drawing.Size(152, 22);
            this.EmployeeMenuItem.Text = "员工管理";
            this.EmployeeMenuItem.Click += new System.EventHandler(this.EmployeeMenuItem_Click);
            // 
            // 沽清设置ToolStripMenuItem
            // 
            this.沽清设置ToolStripMenuItem.Name = "沽清设置ToolStripMenuItem";
            this.沽清设置ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.沽清设置ToolStripMenuItem.Text = "沽清设置";
            // 
            // DishStyleMenuItem
            // 
            this.DishStyleMenuItem.Name = "DishStyleMenuItem";
            this.DishStyleMenuItem.Size = new System.Drawing.Size(152, 22);
            this.DishStyleMenuItem.Text = "菜系设置";
            this.DishStyleMenuItem.Click += new System.EventHandler(this.DishStyleMenuItem_Click);
            // 
            // AdvanceSetting
            // 
            this.AdvanceSetting.AutoSize = false;
            this.AdvanceSetting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AdvanceSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RestaurantManageMenuItem,
            this.EntranceManageMenuItem,
            this.RightManageMenuItem,
            this.PrinterManageMenuItem,
            this.CardMachineManageMenuItem});
            this.AdvanceSetting.Image = ((System.Drawing.Image)(resources.GetObject("AdvanceSetting.Image")));
            this.AdvanceSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AdvanceSetting.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.AdvanceSetting.Name = "AdvanceSetting";
            this.AdvanceSetting.Size = new System.Drawing.Size(100, 40);
            this.AdvanceSetting.Text = "高级设置";
            // 
            // RestaurantManageMenuItem
            // 
            this.RestaurantManageMenuItem.Name = "RestaurantManageMenuItem";
            this.RestaurantManageMenuItem.Size = new System.Drawing.Size(152, 22);
            this.RestaurantManageMenuItem.Text = "门店信息";
            this.RestaurantManageMenuItem.Click += new System.EventHandler(this.RestaurantManageMenuItem_Click);
            // 
            // EntranceManageMenuItem
            // 
            this.EntranceManageMenuItem.Name = "EntranceManageMenuItem";
            this.EntranceManageMenuItem.Size = new System.Drawing.Size(152, 22);
            this.EntranceManageMenuItem.Text = "档口管理";
            this.EntranceManageMenuItem.Click += new System.EventHandler(this.EntranceManageMenuItem_Click);
            // 
            // RightManageMenuItem
            // 
            this.RightManageMenuItem.Name = "RightManageMenuItem";
            this.RightManageMenuItem.Size = new System.Drawing.Size(152, 22);
            this.RightManageMenuItem.Text = "权限管理";
            this.RightManageMenuItem.Click += new System.EventHandler(this.RightManageMenuItem_Click);
            // 
            // PrinterManageMenuItem
            // 
            this.PrinterManageMenuItem.Name = "PrinterManageMenuItem";
            this.PrinterManageMenuItem.Size = new System.Drawing.Size(152, 22);
            this.PrinterManageMenuItem.Text = "打印机管理";
            this.PrinterManageMenuItem.Click += new System.EventHandler(this.PrinterManageMenuItem_Click);
            // 
            // toolStripSplitButton3
            // 
            this.toolStripSplitButton3.AutoSize = false;
            this.toolStripSplitButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SalesMenuItem,
            this.EntranceMenuItem});
            this.toolStripSplitButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton3.Image")));
            this.toolStripSplitButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton3.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.toolStripSplitButton3.Name = "toolStripSplitButton3";
            this.toolStripSplitButton3.Size = new System.Drawing.Size(100, 40);
            this.toolStripSplitButton3.Text = "前台应用";
            // 
            // SalesMenuItem
            // 
            this.SalesMenuItem.Name = "SalesMenuItem";
            this.SalesMenuItem.Size = new System.Drawing.Size(152, 22);
            this.SalesMenuItem.Text = "收银";
            // 
            // EntranceMenuItem
            // 
            this.EntranceMenuItem.Name = "EntranceMenuItem";
            this.EntranceMenuItem.Size = new System.Drawing.Size(152, 22);
            this.EntranceMenuItem.Text = "档口";
            // 
            // toolStripSplitButton4
            // 
            this.toolStripSplitButton4.AutoSize = false;
            this.toolStripSplitButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DailyReportMenuItem});
            this.toolStripSplitButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton4.Image")));
            this.toolStripSplitButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton4.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.toolStripSplitButton4.Name = "toolStripSplitButton4";
            this.toolStripSplitButton4.Size = new System.Drawing.Size(100, 40);
            this.toolStripSplitButton4.Text = "报表查询";
            // 
            // DailyReportMenuItem
            // 
            this.DailyReportMenuItem.Name = "DailyReportMenuItem";
            this.DailyReportMenuItem.Size = new System.Drawing.Size(152, 22);
            this.DailyReportMenuItem.Text = "日报表";
            // 
            // toolStripSplitButton5
            // 
            this.toolStripSplitButton5.AutoSize = false;
            this.toolStripSplitButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.软件信息ToolStripMenuItem,
            this.注销退出ToolStripMenuItem});
            this.toolStripSplitButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton5.Image")));
            this.toolStripSplitButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton5.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.toolStripSplitButton5.Name = "toolStripSplitButton5";
            this.toolStripSplitButton5.Size = new System.Drawing.Size(100, 40);
            this.toolStripSplitButton5.Text = "帮助";
            // 
            // 软件信息ToolStripMenuItem
            // 
            this.软件信息ToolStripMenuItem.Name = "软件信息ToolStripMenuItem";
            this.软件信息ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.软件信息ToolStripMenuItem.Text = "软件信息";
            // 
            // 注销退出ToolStripMenuItem
            // 
            this.注销退出ToolStripMenuItem.Name = "注销退出ToolStripMenuItem";
            this.注销退出ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.注销退出ToolStripMenuItem.Text = "注销退出";
            // 
            // pnBackgroundFill
            // 
            this.pnBackgroundFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnBackgroundFill.Location = new System.Drawing.Point(0, 43);
            this.pnBackgroundFill.Name = "pnBackgroundFill";
            this.pnBackgroundFill.Size = new System.Drawing.Size(1248, 638);
            this.pnBackgroundFill.TabIndex = 2;
            // 
            // CardMachineManageMenuItem
            // 
            this.CardMachineManageMenuItem.Name = "CardMachineManageMenuItem";
            this.CardMachineManageMenuItem.Size = new System.Drawing.Size(152, 22);
            this.CardMachineManageMenuItem.Text = "卡机管理";
            this.CardMachineManageMenuItem.Click += new System.EventHandler(this.CardMachineManageMenuItem_Click);
            // 
            // BackgroundMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 706);
            this.Controls.Add(this.pnBackgroundFill);
            this.Controls.Add(this.pnBackgroundTop);
            this.Controls.Add(this.pnBackgroundBT);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.IsMdiContainer = true;
            this.Name = "BackgroundMain";
            this.Text = "CMS后台管理";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnBackgroundBT.ResumeLayout(false);
            this.pnBackgroundBT.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.pnBackgroundTop.ResumeLayout(false);
            this.pnBackgroundTop.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnBackgroundBT;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel pnBackgroundTop;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel pnBackgroundFill;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripDropDownButton BasicSetting;
        private System.Windows.Forms.ToolStripMenuItem DishTypeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DishMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CookTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EmployeeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 沽清设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton AdvanceSetting;
        private System.Windows.Forms.ToolStripMenuItem RestaurantManageMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EntranceManageMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RightManageMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PrinterManageMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripSplitButton3;
        private System.Windows.Forms.ToolStripMenuItem SalesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EntranceMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripSplitButton4;
        private System.Windows.Forms.ToolStripMenuItem DailyReportMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripSplitButton5;
        private System.Windows.Forms.ToolStripMenuItem 软件信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 注销退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DishStyleMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CardMachineManageMenuItem;
    }
}

