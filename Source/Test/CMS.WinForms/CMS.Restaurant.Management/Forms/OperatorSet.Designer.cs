namespace CMS.Restaurant.Management
{
    partial class OperatorSet
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
            this.pnOperatorSetBottom = new System.Windows.Forms.Panel();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.pnOperatorSetTop = new System.Windows.Forms.Panel();
            this.lvEmployeeList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnOperatorSetBottom.SuspendLayout();
            this.pnOperatorSetTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnOperatorSetBottom
            // 
            this.pnOperatorSetBottom.Controls.Add(this.btnEdit);
            this.pnOperatorSetBottom.Controls.Add(this.btnDelete);
            this.pnOperatorSetBottom.Controls.Add(this.btnCreate);
            this.pnOperatorSetBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnOperatorSetBottom.Location = new System.Drawing.Point(0, 401);
            this.pnOperatorSetBottom.Name = "pnOperatorSetBottom";
            this.pnOperatorSetBottom.Size = new System.Drawing.Size(489, 52);
            this.pnOperatorSetBottom.TabIndex = 0;
            // 
            // btnEdit
            // 
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEdit.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEdit.Location = new System.Drawing.Point(236, 13);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 27);
            this.btnEdit.TabIndex = 9;
            this.btnEdit.Text = "编辑";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelete.Location = new System.Drawing.Point(126, 13);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 27);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCreate.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCreate.Location = new System.Drawing.Point(16, 13);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 27);
            this.btnCreate.TabIndex = 7;
            this.btnCreate.Text = "新增";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // pnOperatorSetTop
            // 
            this.pnOperatorSetTop.Controls.Add(this.lvEmployeeList);
            this.pnOperatorSetTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnOperatorSetTop.Location = new System.Drawing.Point(0, 0);
            this.pnOperatorSetTop.Name = "pnOperatorSetTop";
            this.pnOperatorSetTop.Size = new System.Drawing.Size(489, 395);
            this.pnOperatorSetTop.TabIndex = 1;
            // 
            // lvEmployeeList
            // 
            this.lvEmployeeList.CheckBoxes = true;
            this.lvEmployeeList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvEmployeeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvEmployeeList.FullRowSelect = true;
            this.lvEmployeeList.Location = new System.Drawing.Point(0, 0);
            this.lvEmployeeList.Name = "lvEmployeeList";
            this.lvEmployeeList.Size = new System.Drawing.Size(489, 395);
            this.lvEmployeeList.TabIndex = 0;
            this.lvEmployeeList.UseCompatibleStateImageBehavior = false;
            this.lvEmployeeList.View = System.Windows.Forms.View.Details;
            this.lvEmployeeList.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvEmployeeList_ItemChecked);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Tag = "//Model[@name=\'Employee\']/Columns/Column[@name=\'Login\']";
            this.columnHeader1.Text = "工号（用户名）";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Tag = "//Model[@name=\'Employee\']/Columns/Column[@name=\'FullName\']";
            this.columnHeader2.Text = "姓名";
            this.columnHeader2.Width = 110;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Tag = "//Model[@name=\'Employee\']/Columns/Column[@name=\'Sex\']";
            this.columnHeader3.Text = "性别";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Tag = "//Column[@name=\'PositionID\']/Value/Model/Columns/Column[@name=\'EnumValue\']";
            this.columnHeader4.Text = "职位";
            this.columnHeader4.Width = 80;
            // 
            // OperatorSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 453);
            this.Controls.Add(this.pnOperatorSetTop);
            this.Controls.Add(this.pnOperatorSetBottom);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OperatorSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "员工管理";
            this.pnOperatorSetBottom.ResumeLayout(false);
            this.pnOperatorSetTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnOperatorSetBottom;
        private System.Windows.Forms.Panel pnOperatorSetTop;
        private System.Windows.Forms.ListView lvEmployeeList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCreate;
    }
}