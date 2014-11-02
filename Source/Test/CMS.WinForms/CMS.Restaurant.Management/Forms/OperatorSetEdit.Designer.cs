namespace CMS.Restaurant.Management
{
    partial class OperatorSetEdit
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.ddlStatus = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.ddlDepartment = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.RichTextBox();
            this.ddlPosition = new System.Windows.Forms.ComboBox();
            this.ddlSex = new System.Windows.Forms.ComboBox();
            this.txtTelphone = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtEmployeeCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btPhotopInsert = new System.Windows.Forms.Button();
            this.pbPicture = new System.Windows.Forms.PictureBox();
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 413);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(477, 60);
            this.panel1.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(236, 16);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 34);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(358, 16);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 34);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtConfirmPassword);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.ddlStatus);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.ddlDepartment);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtAddress);
            this.panel2.Controls.Add(this.ddlPosition);
            this.panel2.Controls.Add(this.ddlSex);
            this.panel2.Controls.Add(this.txtTelphone);
            this.panel2.Controls.Add(this.txtFullName);
            this.panel2.Controls.Add(this.txtPassword);
            this.panel2.Controls.Add(this.txtEmployeeCode);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btPhotopInsert);
            this.panel2.Controls.Add(this.pbPicture);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(477, 412);
            this.panel2.TabIndex = 1;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(291, 116);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(119, 21);
            this.txtConfirmPassword.TabIndex = 25;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(204, 116);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 19);
            this.label11.TabIndex = 24;
            this.label11.Text = "确认密码：";
            // 
            // ddlStatus
            // 
            this.ddlStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlStatus.FormattingEnabled = true;
            this.ddlStatus.Items.AddRange(new object[] {
            "男",
            "女"});
            this.ddlStatus.Location = new System.Drawing.Point(291, 155);
            this.ddlStatus.Name = "ddlStatus";
            this.ddlStatus.Size = new System.Drawing.Size(119, 20);
            this.ddlStatus.TabIndex = 23;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.button3.Location = new System.Drawing.Point(368, 26);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(49, 21);
            this.button3.TabIndex = 22;
            this.button3.Text = "生成";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnGenerateCode_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(232, 156);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 19);
            this.label10.TabIndex = 19;
            this.label10.Text = "状态：";
            // 
            // ddlDepartment
            // 
            this.ddlDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlDepartment.FormattingEnabled = true;
            this.ddlDepartment.Location = new System.Drawing.Point(69, 286);
            this.ddlDepartment.Name = "ddlDepartment";
            this.ddlDepartment.Size = new System.Drawing.Size(121, 20);
            this.ddlDepartment.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(12, 284);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 19);
            this.label9.TabIndex = 17;
            this.label9.Text = "部门：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(12, 134);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 19);
            this.label8.TabIndex = 16;
            this.label8.Text = "照片";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(237, 255);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(228, 107);
            this.txtAddress.TabIndex = 15;
            this.txtAddress.Text = "";
            // 
            // ddlPosition
            // 
            this.ddlPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPosition.FormattingEnabled = true;
            this.ddlPosition.Location = new System.Drawing.Point(67, 342);
            this.ddlPosition.Name = "ddlPosition";
            this.ddlPosition.Size = new System.Drawing.Size(121, 20);
            this.ddlPosition.TabIndex = 14;
            // 
            // ddlSex
            // 
            this.ddlSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSex.FormattingEnabled = true;
            this.ddlSex.Items.AddRange(new object[] {
            "男",
            "女"});
            this.ddlSex.Location = new System.Drawing.Point(291, 187);
            this.ddlSex.Name = "ddlSex";
            this.ddlSex.Size = new System.Drawing.Size(54, 20);
            this.ddlSex.TabIndex = 13;
            // 
            // txtTelphone
            // 
            this.txtTelphone.Location = new System.Drawing.Point(71, 234);
            this.txtTelphone.Name = "txtTelphone";
            this.txtTelphone.Size = new System.Drawing.Size(119, 21);
            this.txtTelphone.TabIndex = 12;
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(69, 186);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(119, 21);
            this.txtFullName.TabIndex = 11;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(291, 77);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(119, 21);
            this.txtPassword.TabIndex = 10;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtEmployeeCode
            // 
            this.txtEmployeeCode.Location = new System.Drawing.Point(291, 26);
            this.txtEmployeeCode.Name = "txtEmployeeCode";
            this.txtEmployeeCode.ReadOnly = true;
            this.txtEmployeeCode.Size = new System.Drawing.Size(71, 21);
            this.txtEmployeeCode.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(233, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 19);
            this.label7.TabIndex = 8;
            this.label7.Text = "密码：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(12, 236);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 19);
            this.label6.TabIndex = 7;
            this.label6.Text = "电话：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(233, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 19);
            this.label5.TabIndex = 6;
            this.label5.Text = "住址：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(12, 340);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "职位：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(233, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "性别：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "姓名：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(233, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "工号：";
            // 
            // btPhotopInsert
            // 
            this.btPhotopInsert.Location = new System.Drawing.Point(118, 132);
            this.btPhotopInsert.Name = "btPhotopInsert";
            this.btPhotopInsert.Size = new System.Drawing.Size(51, 21);
            this.btPhotopInsert.TabIndex = 1;
            this.btPhotopInsert.Text = "导入";
            this.btPhotopInsert.UseVisualStyleBackColor = true;
            this.btPhotopInsert.Click += new System.EventHandler(this.btPhotopInsert_Click);
            // 
            // pbPicture
            // 
            this.pbPicture.ErrorImage = null;
            this.pbPicture.Image = global::CMS.Restaurant.Management.Properties.Resources.headImage;
            this.pbPicture.InitialImage = null;
            this.pbPicture.Location = new System.Drawing.Point(44, 12);
            this.pbPicture.Name = "pbPicture";
            this.pbPicture.Size = new System.Drawing.Size(104, 104);
            this.pbPicture.TabIndex = 0;
            this.pbPicture.TabStop = false;
            // 
            // fileDialog
            // 
            this.fileDialog.Filter = "JPG 文件|*.jpg|GIF 文件|*.gif|PNG 文件|*.png|所有文件|*.*";
            // 
            // OperatorSetEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 473);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OperatorSetEdit";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "员工属性";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btPhotopInsert;
        private System.Windows.Forms.PictureBox pbPicture;
        private System.Windows.Forms.TextBox txtTelphone;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtEmployeeCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox txtAddress;
        private System.Windows.Forms.ComboBox ddlPosition;
        private System.Windows.Forms.ComboBox ddlSex;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox ddlDepartment;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox ddlStatus;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.OpenFileDialog fileDialog;
    }
}