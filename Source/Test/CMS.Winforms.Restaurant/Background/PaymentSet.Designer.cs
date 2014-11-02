namespace CMS.WinForms.Restaurant.Background
{
    partial class PaymentSet
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
            this.btnPaymentEdit = new System.Windows.Forms.Button();
            this.btnPaymentHide = new System.Windows.Forms.Button();
            this.btnPaymentAdd = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.chPaymentCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPaymentName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPoint = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTicket = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPaymentEdit);
            this.panel1.Controls.Add(this.btnPaymentHide);
            this.panel1.Controls.Add(this.btnPaymentAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 366);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(425, 75);
            this.panel1.TabIndex = 0;
            // 
            // btnPaymentEdit
            // 
            this.btnPaymentEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPaymentEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPaymentEdit.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPaymentEdit.ForeColor = System.Drawing.Color.DarkMagenta;
            this.btnPaymentEdit.Location = new System.Drawing.Point(338, 27);
            this.btnPaymentEdit.Name = "btnPaymentEdit";
            this.btnPaymentEdit.Size = new System.Drawing.Size(75, 27);
            this.btnPaymentEdit.TabIndex = 5;
            this.btnPaymentEdit.Text = "编辑";
            this.btnPaymentEdit.UseVisualStyleBackColor = true;
            // 
            // btnPaymentHide
            // 
            this.btnPaymentHide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPaymentHide.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPaymentHide.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPaymentHide.ForeColor = System.Drawing.Color.DarkMagenta;
            this.btnPaymentHide.Location = new System.Drawing.Point(12, 27);
            this.btnPaymentHide.Name = "btnPaymentHide";
            this.btnPaymentHide.Size = new System.Drawing.Size(75, 27);
            this.btnPaymentHide.TabIndex = 4;
            this.btnPaymentHide.Text = "隐藏";
            this.btnPaymentHide.UseVisualStyleBackColor = true;
            // 
            // btnPaymentAdd
            // 
            this.btnPaymentAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPaymentAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPaymentAdd.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPaymentAdd.ForeColor = System.Drawing.Color.DarkMagenta;
            this.btnPaymentAdd.Location = new System.Drawing.Point(241, 27);
            this.btnPaymentAdd.Name = "btnPaymentAdd";
            this.btnPaymentAdd.Size = new System.Drawing.Size(75, 27);
            this.btnPaymentAdd.TabIndex = 3;
            this.btnPaymentAdd.Text = "新增";
            this.btnPaymentAdd.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.listView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(425, 366);
            this.panel2.TabIndex = 1;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chPaymentCode,
            this.chPaymentName,
            this.chPoint,
            this.chTicket});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(425, 366);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // chPaymentCode
            // 
            this.chPaymentCode.Text = " 编号";
            this.chPaymentCode.Width = 50;
            // 
            // chPaymentName
            // 
            this.chPaymentName.Text = "名称";
            this.chPaymentName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chPaymentName.Width = 120;
            // 
            // chPoint
            // 
            this.chPoint.Text = " 积分 ";
            this.chPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chPoint.Width = 50;
            // 
            // chTicket
            // 
            this.chTicket.Text = " 抵用券 ";
            this.chTicket.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PaymentSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 441);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PaymentSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "收款方式设置";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnPaymentEdit;
        private System.Windows.Forms.Button btnPaymentHide;
        private System.Windows.Forms.Button btnPaymentAdd;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader chPaymentCode;
        private System.Windows.Forms.ColumnHeader chPaymentName;
        private System.Windows.Forms.ColumnHeader chPoint;
        private System.Windows.Forms.ColumnHeader chTicket;
    }
}