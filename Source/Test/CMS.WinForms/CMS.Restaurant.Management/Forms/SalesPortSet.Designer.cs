namespace CMS.Restaurant.Management
{
    partial class SalesPortSet
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
            this.lvComputerInfo = new System.Windows.Forms.ListView();
            this.chComputerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chIPAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chMACAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chRelatedStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.chSalesPortID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSalesPortName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSalesPortMachine = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSalesPortCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSalesPortBrowseBt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSalesPortStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSalesPortEdit = new System.Windows.Forms.Button();
            this.btnSalesPortDelete = new System.Windows.Forms.Button();
            this.btnSalesPortNew = new System.Windows.Forms.Button();
            this.tbSalesPortName = new System.Windows.Forms.TextBox();
            this.btGetComputer = new System.Windows.Forms.Button();
            this.lblSalesPortName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lvComputerInfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 338);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(683, 200);
            this.panel1.TabIndex = 0;
            // 
            // lvComputerInfo
            // 
            this.lvComputerInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chComputerName,
            this.chIPAddress,
            this.chMACAddress,
            this.chRelatedStatus});
            this.lvComputerInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvComputerInfo.FullRowSelect = true;
            this.lvComputerInfo.Location = new System.Drawing.Point(0, 0);
            this.lvComputerInfo.Name = "lvComputerInfo";
            this.lvComputerInfo.Size = new System.Drawing.Size(683, 200);
            this.lvComputerInfo.TabIndex = 0;
            this.lvComputerInfo.UseCompatibleStateImageBehavior = false;
            this.lvComputerInfo.View = System.Windows.Forms.View.Details;
            // 
            // chComputerName
            // 
            this.chComputerName.Text = "      计算机名";
            this.chComputerName.Width = 120;
            // 
            // chIPAddress
            // 
            this.chIPAddress.Text = "IP地址";
            this.chIPAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chIPAddress.Width = 170;
            // 
            // chMACAddress
            // 
            this.chMACAddress.Text = "MAC地址";
            this.chMACAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chMACAddress.Width = 170;
            // 
            // chRelatedStatus
            // 
            this.chRelatedStatus.Text = "关联状态";
            this.chRelatedStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chRelatedStatus.Width = 80;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.listView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(683, 250);
            this.panel2.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.ForeColor = System.Drawing.Color.DarkMagenta;
            this.btnSearch.Location = new System.Drawing.Point(434, 211);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 27);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelete.ForeColor = System.Drawing.Color.DarkMagenta;
            this.btnDelete.Location = new System.Drawing.Point(596, 211);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 27);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Enabled = false;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.DarkMagenta;
            this.button1.Location = new System.Drawing.Point(515, 211);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 27);
            this.button1.TabIndex = 6;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chSalesPortID,
            this.chSalesPortName,
            this.chSalesPortMachine,
            this.chSalesPortCategory,
            this.chSalesPortBrowseBt,
            this.chSalesPortStatus});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(683, 205);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            // 
            // chSalesPortID
            // 
            this.chSalesPortID.Text = " 序号";
            this.chSalesPortID.Width = 50;
            // 
            // chSalesPortName
            // 
            this.chSalesPortName.Text = "名称";
            this.chSalesPortName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chSalesPortName.Width = 150;
            // 
            // chSalesPortMachine
            // 
            this.chSalesPortMachine.Text = "计算机信息";
            this.chSalesPortMachine.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chSalesPortMachine.Width = 170;
            // 
            // chSalesPortCategory
            // 
            this.chSalesPortCategory.Text = "关联大类";
            this.chSalesPortCategory.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chSalesPortCategory.Width = 196;
            // 
            // chSalesPortBrowseBt
            // 
            this.chSalesPortBrowseBt.Text = "选择";
            this.chSalesPortBrowseBt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chSalesPortBrowseBt.Width = 50;
            // 
            // chSalesPortStatus
            // 
            this.chSalesPortStatus.Text = "状态";
            this.chSalesPortStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSalesPortEdit);
            this.panel3.Controls.Add(this.btnSalesPortDelete);
            this.panel3.Controls.Add(this.btnSalesPortNew);
            this.panel3.Controls.Add(this.tbSalesPortName);
            this.panel3.Controls.Add(this.btGetComputer);
            this.panel3.Controls.Add(this.lblSalesPortName);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 250);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(683, 88);
            this.panel3.TabIndex = 1;
            // 
            // btnSalesPortEdit
            // 
            this.btnSalesPortEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalesPortEdit.Enabled = false;
            this.btnSalesPortEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSalesPortEdit.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSalesPortEdit.ForeColor = System.Drawing.Color.DarkMagenta;
            this.btnSalesPortEdit.Location = new System.Drawing.Point(596, 29);
            this.btnSalesPortEdit.Name = "btnSalesPortEdit";
            this.btnSalesPortEdit.Size = new System.Drawing.Size(75, 27);
            this.btnSalesPortEdit.TabIndex = 5;
            this.btnSalesPortEdit.Text = "编辑";
            this.btnSalesPortEdit.UseVisualStyleBackColor = true;
            // 
            // btnSalesPortDelete
            // 
            this.btnSalesPortDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalesPortDelete.Enabled = false;
            this.btnSalesPortDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSalesPortDelete.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSalesPortDelete.ForeColor = System.Drawing.Color.DarkMagenta;
            this.btnSalesPortDelete.Location = new System.Drawing.Point(515, 29);
            this.btnSalesPortDelete.Name = "btnSalesPortDelete";
            this.btnSalesPortDelete.Size = new System.Drawing.Size(75, 27);
            this.btnSalesPortDelete.TabIndex = 4;
            this.btnSalesPortDelete.Text = "删除";
            this.btnSalesPortDelete.UseVisualStyleBackColor = true;
            // 
            // btnSalesPortNew
            // 
            this.btnSalesPortNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalesPortNew.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSalesPortNew.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSalesPortNew.ForeColor = System.Drawing.Color.DarkMagenta;
            this.btnSalesPortNew.Location = new System.Drawing.Point(434, 29);
            this.btnSalesPortNew.Name = "btnSalesPortNew";
            this.btnSalesPortNew.Size = new System.Drawing.Size(75, 27);
            this.btnSalesPortNew.TabIndex = 3;
            this.btnSalesPortNew.Text = "新增";
            this.btnSalesPortNew.UseVisualStyleBackColor = true;
            this.btnSalesPortNew.Click += new System.EventHandler(this.btnSalesPortNew_Click);
            // 
            // tbSalesPortName
            // 
            this.tbSalesPortName.Location = new System.Drawing.Point(285, 35);
            this.tbSalesPortName.Name = "tbSalesPortName";
            this.tbSalesPortName.Size = new System.Drawing.Size(125, 21);
            this.tbSalesPortName.TabIndex = 2;
            // 
            // btGetComputer
            // 
            this.btGetComputer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btGetComputer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btGetComputer.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btGetComputer.Location = new System.Drawing.Point(0, 0);
            this.btGetComputer.Name = "btGetComputer";
            this.btGetComputer.Size = new System.Drawing.Size(89, 88);
            this.btGetComputer.TabIndex = 1;
            this.btGetComputer.Text = "获取在线计算机信息";
            this.btGetComputer.UseVisualStyleBackColor = true;
            this.btGetComputer.Click += new System.EventHandler(this.btGetComputer_Click);
            // 
            // lblSalesPortName
            // 
            this.lblSalesPortName.AutoSize = true;
            this.lblSalesPortName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSalesPortName.Location = new System.Drawing.Point(205, 31);
            this.lblSalesPortName.Name = "lblSalesPortName";
            this.lblSalesPortName.Size = new System.Drawing.Size(74, 22);
            this.lblSalesPortName.TabIndex = 0;
            this.lblSalesPortName.Text = "档口名：";
            // 
            // SalesPortSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 538);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SalesPortSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "档口设置";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lvComputerInfo;
        private System.Windows.Forms.ColumnHeader chComputerName;
        private System.Windows.Forms.ColumnHeader chIPAddress;
        private System.Windows.Forms.ColumnHeader chMACAddress;
        private System.Windows.Forms.ColumnHeader chRelatedStatus;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader chSalesPortID;
        private System.Windows.Forms.ColumnHeader chSalesPortName;
        private System.Windows.Forms.ColumnHeader chSalesPortMachine;
        private System.Windows.Forms.ColumnHeader chSalesPortCategory;
        private System.Windows.Forms.ColumnHeader chSalesPortBrowseBt;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox tbSalesPortName;
        private System.Windows.Forms.Button btGetComputer;
        private System.Windows.Forms.Label lblSalesPortName;
        private System.Windows.Forms.Button btnSalesPortEdit;
        private System.Windows.Forms.Button btnSalesPortDelete;
        private System.Windows.Forms.Button btnSalesPortNew;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ColumnHeader chSalesPortStatus;
    }
}