namespace Microsoft.STB.WSDUA.DxEditor.UpdateFramework
{
    partial class UpdatesAvailableDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdatesAvailableDialog));
            this.Header = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CancelUpdateButton = new System.Windows.Forms.Button();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.OKButton = new Microsoft.STB.WSDUA.DxEditor.UpdateFramework.ShieldButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Header
            // 
            this.Header.AutoSize = true;
            this.Header.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Header.Location = new System.Drawing.Point(12, 16);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(117, 22);
            this.Header.TabIndex = 0;
            this.Header.Text = "[Header text]";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.OKButton);
            this.groupBox1.Controls.Add(this.CancelUpdateButton);
            this.groupBox1.Controls.Add(this.MessageLabel);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(4, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(592, 95);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // CancelUpdateButton
            // 
            this.CancelUpdateButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelUpdateButton.Location = new System.Drawing.Point(511, 62);
            this.CancelUpdateButton.Name = "CancelUpdateButton";
            this.CancelUpdateButton.Size = new System.Drawing.Size(75, 23);
            this.CancelUpdateButton.TabIndex = 2;
            this.CancelUpdateButton.Text = "[Cancel text]";
            this.CancelUpdateButton.UseVisualStyleBackColor = true;
            this.CancelUpdateButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // MessageLabel
            // 
            this.MessageLabel.Location = new System.Drawing.Point(6, 16);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(580, 43);
            this.MessageLabel.TabIndex = 0;
            this.MessageLabel.Text = "[Message text]";
            // 
            // OKButton
            // 
            this.OKButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.OKButton.Location = new System.Drawing.Point(430, 62);
            this.OKButton.Name = "OKButton";
            this.OKButton.ShowShield = true;
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 3;
            this.OKButton.Text = "[OK text]";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // UpdatesAvailableDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelUpdateButton;
            this.ClientSize = new System.Drawing.Size(600, 151);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Header);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdatesAvailableDialog";
            this.Text = "[Dialog Title text]";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Header;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button CancelUpdateButton;
        private System.Windows.Forms.Label MessageLabel;
        private ShieldButton OKButton;
    }
}