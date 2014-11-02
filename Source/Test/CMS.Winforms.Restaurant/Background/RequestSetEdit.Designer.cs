namespace CMS.WinForms.Restaurant.Background
{
    partial class RequestSetEdit
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BTSave = new System.Windows.Forms.Button();
            this.TBRequestName = new System.Windows.Forms.TextBox();
            this.TBRequestPrice = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "价格";
            // 
            // BTSave
            // 
            this.BTSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BTSave.Location = new System.Drawing.Point(101, 154);
            this.BTSave.Name = "BTSave";
            this.BTSave.Size = new System.Drawing.Size(75, 36);
            this.BTSave.TabIndex = 2;
            this.BTSave.Text = "保存";
            this.BTSave.UseVisualStyleBackColor = true;
            // 
            // TBRequestName
            // 
            this.TBRequestName.Location = new System.Drawing.Point(123, 24);
            this.TBRequestName.Name = "TBRequestName";
            this.TBRequestName.Size = new System.Drawing.Size(112, 26);
            this.TBRequestName.TabIndex = 3;
            // 
            // TBRequestPrice
            // 
            this.TBRequestPrice.Location = new System.Drawing.Point(123, 90);
            this.TBRequestPrice.Name = "TBRequestPrice";
            this.TBRequestPrice.Size = new System.Drawing.Size(112, 26);
            this.TBRequestPrice.TabIndex = 4;
            // 
            // RequestSetEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 202);
            this.Controls.Add(this.TBRequestPrice);
            this.Controls.Add(this.TBRequestName);
            this.Controls.Add(this.BTSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RequestSetEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "做法与要求编辑";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BTSave;
        private System.Windows.Forms.TextBox TBRequestName;
        private System.Windows.Forms.TextBox TBRequestPrice;
    }
}