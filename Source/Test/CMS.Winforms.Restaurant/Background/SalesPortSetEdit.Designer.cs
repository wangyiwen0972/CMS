namespace CMS.WinForms.Background
{
    partial class SalesPortSetEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblGetSalesPortSelected = new System.Windows.Forms.Label();
            this.lblSalesPortis = new System.Windows.Forms.Label();
            this.btnSalesPortSetEditSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gbComputerList = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.chComputerListID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chComputerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.gbDishTypes = new System.Windows.Forms.GroupBox();
            this.cbCategory12 = new System.Windows.Forms.CheckBox();
            this.cbCategory11 = new System.Windows.Forms.CheckBox();
            this.cbCategory10 = new System.Windows.Forms.CheckBox();
            this.cbCategory6 = new System.Windows.Forms.CheckBox();
            this.cbCategory5 = new System.Windows.Forms.CheckBox();
            this.cbCategory4 = new System.Windows.Forms.CheckBox();
            this.cbCategory9 = new System.Windows.Forms.CheckBox();
            this.cbCategory18 = new System.Windows.Forms.CheckBox();
            this.cbCategory7 = new System.Windows.Forms.CheckBox();
            this.cbCategory3 = new System.Windows.Forms.CheckBox();
            this.cbCategory2 = new System.Windows.Forms.CheckBox();
            this.cbCategory1 = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gbComputerList.SuspendLayout();
            this.panel3.SuspendLayout();
            this.gbDishTypes.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblGetSalesPortSelected);
            this.panel1.Controls.Add(this.lblSalesPortis);
            this.panel1.Controls.Add(this.btnSalesPortSetEditSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 302);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(630, 75);
            this.panel1.TabIndex = 0;
            // 
            // lblGetSalesPortSelected
            // 
            this.lblGetSalesPortSelected.AutoSize = true;
            this.lblGetSalesPortSelected.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblGetSalesPortSelected.Location = new System.Drawing.Point(147, 30);
            this.lblGetSalesPortSelected.Name = "lblGetSalesPortSelected";
            this.lblGetSalesPortSelected.Size = new System.Drawing.Size(128, 17);
            this.lblGetSalesPortSelected.TabIndex = 8;
            this.lblGetSalesPortSelected.Text = "获取之前选中的档口名";
            // 
            // lblSalesPortis
            // 
            this.lblSalesPortis.AutoSize = true;
            this.lblSalesPortis.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSalesPortis.Location = new System.Drawing.Point(13, 30);
            this.lblSalesPortis.Name = "lblSalesPortis";
            this.lblSalesPortis.Size = new System.Drawing.Size(116, 17);
            this.lblSalesPortis.TabIndex = 7;
            this.lblSalesPortis.Text = "当前选择的当口是：";
            // 
            // btnSalesPortSetEditSave
            // 
            this.btnSalesPortSetEditSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalesPortSetEditSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSalesPortSetEditSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSalesPortSetEditSave.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSalesPortSetEditSave.ForeColor = System.Drawing.Color.DarkMagenta;
            this.btnSalesPortSetEditSave.Location = new System.Drawing.Point(510, 25);
            this.btnSalesPortSetEditSave.Name = "btnSalesPortSetEditSave";
            this.btnSalesPortSetEditSave.Size = new System.Drawing.Size(75, 27);
            this.btnSalesPortSetEditSave.TabIndex = 6;
            this.btnSalesPortSetEditSave.Text = "保存";
            this.btnSalesPortSetEditSave.UseVisualStyleBackColor = true;
            this.btnSalesPortSetEditSave.Click += new System.EventHandler(this.btnSalesPortSetEditSave_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gbComputerList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(220, 302);
            this.panel2.TabIndex = 1;
            // 
            // gbComputerList
            // 
            this.gbComputerList.Controls.Add(this.listView1);
            this.gbComputerList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbComputerList.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbComputerList.Location = new System.Drawing.Point(0, 0);
            this.gbComputerList.Name = "gbComputerList";
            this.gbComputerList.Size = new System.Drawing.Size(220, 302);
            this.gbComputerList.TabIndex = 0;
            this.gbComputerList.TabStop = false;
            this.gbComputerList.Text = "计算机列表";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chComputerListID,
            this.chComputerName});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(3, 22);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(214, 277);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // chComputerListID
            // 
            this.chComputerListID.Text = " 序号";
            this.chComputerListID.Width = 50;
            // 
            // chComputerName
            // 
            this.chComputerName.Text = "计算机名";
            this.chComputerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chComputerName.Width = 150;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.gbDishTypes);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(220, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(410, 302);
            this.panel3.TabIndex = 2;
            // 
            // gbDishTypes
            // 
            this.gbDishTypes.Controls.Add(this.cbCategory12);
            this.gbDishTypes.Controls.Add(this.cbCategory11);
            this.gbDishTypes.Controls.Add(this.cbCategory10);
            this.gbDishTypes.Controls.Add(this.cbCategory6);
            this.gbDishTypes.Controls.Add(this.cbCategory5);
            this.gbDishTypes.Controls.Add(this.cbCategory4);
            this.gbDishTypes.Controls.Add(this.cbCategory9);
            this.gbDishTypes.Controls.Add(this.cbCategory18);
            this.gbDishTypes.Controls.Add(this.cbCategory7);
            this.gbDishTypes.Controls.Add(this.cbCategory3);
            this.gbDishTypes.Controls.Add(this.cbCategory2);
            this.gbDishTypes.Controls.Add(this.cbCategory1);
            this.gbDishTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDishTypes.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbDishTypes.Location = new System.Drawing.Point(0, 0);
            this.gbDishTypes.Name = "gbDishTypes";
            this.gbDishTypes.Size = new System.Drawing.Size(410, 302);
            this.gbDishTypes.TabIndex = 1;
            this.gbDishTypes.TabStop = false;
            this.gbDishTypes.Text = "销售大类";
            // 
            // cbCategory12
            // 
            this.cbCategory12.AutoSize = true;
            this.cbCategory12.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbCategory12.Location = new System.Drawing.Point(290, 185);
            this.cbCategory12.Name = "cbCategory12";
            this.cbCategory12.Size = new System.Drawing.Size(111, 21);
            this.cbCategory12.TabIndex = 11;
            this.cbCategory12.Text = "若没有就不显示";
            this.cbCategory12.UseVisualStyleBackColor = true;
            // 
            // cbCategory11
            // 
            this.cbCategory11.AutoSize = true;
            this.cbCategory11.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbCategory11.Location = new System.Drawing.Point(160, 185);
            this.cbCategory11.Name = "cbCategory11";
            this.cbCategory11.Size = new System.Drawing.Size(89, 21);
            this.cbCategory11.TabIndex = 10;
            this.cbCategory11.Text = "获取大类12";
            this.cbCategory11.UseVisualStyleBackColor = true;
            // 
            // cbCategory10
            // 
            this.cbCategory10.AutoSize = true;
            this.cbCategory10.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbCategory10.Location = new System.Drawing.Point(30, 185);
            this.cbCategory10.Name = "cbCategory10";
            this.cbCategory10.Size = new System.Drawing.Size(89, 21);
            this.cbCategory10.TabIndex = 9;
            this.cbCategory10.Text = "获取大类11";
            this.cbCategory10.UseVisualStyleBackColor = true;
            // 
            // cbCategory6
            // 
            this.cbCategory6.AutoSize = true;
            this.cbCategory6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbCategory6.Location = new System.Drawing.Point(290, 85);
            this.cbCategory6.Name = "cbCategory6";
            this.cbCategory6.Size = new System.Drawing.Size(82, 21);
            this.cbCategory6.TabIndex = 8;
            this.cbCategory6.Text = "获取大类6";
            this.cbCategory6.UseVisualStyleBackColor = true;
            // 
            // cbCategory5
            // 
            this.cbCategory5.AutoSize = true;
            this.cbCategory5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbCategory5.Location = new System.Drawing.Point(160, 85);
            this.cbCategory5.Name = "cbCategory5";
            this.cbCategory5.Size = new System.Drawing.Size(82, 21);
            this.cbCategory5.TabIndex = 7;
            this.cbCategory5.Text = "获取大类5";
            this.cbCategory5.UseVisualStyleBackColor = true;
            // 
            // cbCategory4
            // 
            this.cbCategory4.AutoSize = true;
            this.cbCategory4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbCategory4.Location = new System.Drawing.Point(30, 85);
            this.cbCategory4.Name = "cbCategory4";
            this.cbCategory4.Size = new System.Drawing.Size(82, 21);
            this.cbCategory4.TabIndex = 6;
            this.cbCategory4.Text = "获取大类4";
            this.cbCategory4.UseVisualStyleBackColor = true;
            // 
            // cbCategory9
            // 
            this.cbCategory9.AutoSize = true;
            this.cbCategory9.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbCategory9.Location = new System.Drawing.Point(290, 135);
            this.cbCategory9.Name = "cbCategory9";
            this.cbCategory9.Size = new System.Drawing.Size(82, 21);
            this.cbCategory9.TabIndex = 5;
            this.cbCategory9.Text = "获取大类9";
            this.cbCategory9.UseVisualStyleBackColor = true;
            // 
            // cbCategory18
            // 
            this.cbCategory18.AutoSize = true;
            this.cbCategory18.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbCategory18.Location = new System.Drawing.Point(160, 135);
            this.cbCategory18.Name = "cbCategory18";
            this.cbCategory18.Size = new System.Drawing.Size(82, 21);
            this.cbCategory18.TabIndex = 4;
            this.cbCategory18.Text = "获取大类8";
            this.cbCategory18.UseVisualStyleBackColor = true;
            // 
            // cbCategory7
            // 
            this.cbCategory7.AutoSize = true;
            this.cbCategory7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbCategory7.Location = new System.Drawing.Point(30, 135);
            this.cbCategory7.Name = "cbCategory7";
            this.cbCategory7.Size = new System.Drawing.Size(82, 21);
            this.cbCategory7.TabIndex = 3;
            this.cbCategory7.Text = "获取大类7";
            this.cbCategory7.UseVisualStyleBackColor = true;
            // 
            // cbCategory3
            // 
            this.cbCategory3.AutoSize = true;
            this.cbCategory3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbCategory3.Location = new System.Drawing.Point(290, 35);
            this.cbCategory3.Name = "cbCategory3";
            this.cbCategory3.Size = new System.Drawing.Size(82, 21);
            this.cbCategory3.TabIndex = 2;
            this.cbCategory3.Text = "获取大类3";
            this.cbCategory3.UseVisualStyleBackColor = true;
            // 
            // cbCategory2
            // 
            this.cbCategory2.AutoSize = true;
            this.cbCategory2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbCategory2.Location = new System.Drawing.Point(160, 35);
            this.cbCategory2.Name = "cbCategory2";
            this.cbCategory2.Size = new System.Drawing.Size(82, 21);
            this.cbCategory2.TabIndex = 1;
            this.cbCategory2.Text = "获取大类2";
            this.cbCategory2.UseVisualStyleBackColor = true;
            // 
            // cbCategory1
            // 
            this.cbCategory1.AutoSize = true;
            this.cbCategory1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbCategory1.Location = new System.Drawing.Point(30, 35);
            this.cbCategory1.Name = "cbCategory1";
            this.cbCategory1.Size = new System.Drawing.Size(82, 21);
            this.cbCategory1.TabIndex = 0;
            this.cbCategory1.Text = "获取大类1";
            this.cbCategory1.UseVisualStyleBackColor = true;
            // 
            // SalesPortSetEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 377);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SalesPortSetEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "档口大类与计算机关联";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.gbComputerList.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.gbDishTypes.ResumeLayout(false);
            this.gbDishTypes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSalesPortSetEditSave;
        private System.Windows.Forms.GroupBox gbComputerList;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader chComputerListID;
        private System.Windows.Forms.ColumnHeader chComputerName;
        private System.Windows.Forms.GroupBox gbDishTypes;
        private System.Windows.Forms.Label lblGetSalesPortSelected;
        private System.Windows.Forms.Label lblSalesPortis;
        private System.Windows.Forms.CheckBox cbCategory12;
        private System.Windows.Forms.CheckBox cbCategory11;
        private System.Windows.Forms.CheckBox cbCategory10;
        private System.Windows.Forms.CheckBox cbCategory6;
        private System.Windows.Forms.CheckBox cbCategory5;
        private System.Windows.Forms.CheckBox cbCategory4;
        private System.Windows.Forms.CheckBox cbCategory9;
        private System.Windows.Forms.CheckBox cbCategory18;
        private System.Windows.Forms.CheckBox cbCategory7;
        private System.Windows.Forms.CheckBox cbCategory3;
        private System.Windows.Forms.CheckBox cbCategory2;
        private System.Windows.Forms.CheckBox cbCategory1;
    }
}