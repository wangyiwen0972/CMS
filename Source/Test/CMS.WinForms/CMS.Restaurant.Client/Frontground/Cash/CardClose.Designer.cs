﻿namespace CMS.Restaurant.Client.Cash
{
    partial class CardClose
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
            this.lblConsumeTotal = new System.Windows.Forms.Label();
            this.lblCardBalance = new System.Windows.Forms.Label();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbMoney = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbCash = new System.Windows.Forms.Label();
            this.lbAmount = new System.Windows.Forms.Label();
            this.lbNumber = new System.Windows.Forms.Label();
            this.lbCardType = new System.Windows.Forms.Label();
            this.lblCardType = new System.Windows.Forms.Label();
            this.btCheckDetail = new System.Windows.Forms.Button();
            this.lblSalesNo = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblConsumeTotal
            // 
            this.lblConsumeTotal.AutoSize = true;
            this.lblConsumeTotal.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblConsumeTotal.Location = new System.Drawing.Point(42, 167);
            this.lblConsumeTotal.Name = "lblConsumeTotal";
            this.lblConsumeTotal.Size = new System.Drawing.Size(90, 22);
            this.lblConsumeTotal.TabIndex = 0;
            this.lblConsumeTotal.Text = "本次消费：";
            // 
            // lblCardBalance
            // 
            this.lblCardBalance.AutoSize = true;
            this.lblCardBalance.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCardBalance.Location = new System.Drawing.Point(42, 227);
            this.lblCardBalance.Name = "lblCardBalance";
            this.lblCardBalance.Size = new System.Drawing.Size(90, 22);
            this.lblCardBalance.TabIndex = 1;
            this.lblCardBalance.Text = "卡内余额：";
            // 
            // btnCheckout
            // 
            this.btnCheckout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheckout.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCheckout.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCheckout.Location = new System.Drawing.Point(259, 16);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(85, 30);
            this.btnCheckout.TabIndex = 2;
            this.btnCheckout.Text = "确认结账";
            this.btnCheckout.UseVisualStyleBackColor = true;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCheckout);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 311);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(607, 61);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbMoney);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lbCash);
            this.panel2.Controls.Add(this.lbAmount);
            this.panel2.Controls.Add(this.lbNumber);
            this.panel2.Controls.Add(this.lbCardType);
            this.panel2.Controls.Add(this.lblCardType);
            this.panel2.Controls.Add(this.btCheckDetail);
            this.panel2.Controls.Add(this.lblSalesNo);
            this.panel2.Controls.Add(this.lblCardBalance);
            this.panel2.Controls.Add(this.lblConsumeTotal);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(607, 311);
            this.panel2.TabIndex = 4;
            // 
            // lbMoney
            // 
            this.lbMoney.AutoSize = true;
            this.lbMoney.Location = new System.Drawing.Point(423, 264);
            this.lbMoney.Name = "lbMoney";
            this.lbMoney.Size = new System.Drawing.Size(47, 12);
            this.lbMoney.TabIndex = 10;
            this.lbMoney.Text = "lbMoney";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(354, 259);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 22);
            this.label1.TabIndex = 9;
            this.label1.Text = "找零 ：";
            // 
            // lbCash
            // 
            this.lbCash.AutoSize = true;
            this.lbCash.Location = new System.Drawing.Point(137, 234);
            this.lbCash.Name = "lbCash";
            this.lbCash.Size = new System.Drawing.Size(41, 12);
            this.lbCash.TabIndex = 8;
            this.lbCash.Text = "label4";
            // 
            // lbAmount
            // 
            this.lbAmount.AutoSize = true;
            this.lbAmount.Location = new System.Drawing.Point(138, 174);
            this.lbAmount.Name = "lbAmount";
            this.lbAmount.Size = new System.Drawing.Size(41, 12);
            this.lbAmount.TabIndex = 7;
            this.lbAmount.Text = "label3";
            // 
            // lbNumber
            // 
            this.lbNumber.AutoSize = true;
            this.lbNumber.Location = new System.Drawing.Point(137, 114);
            this.lbNumber.Name = "lbNumber";
            this.lbNumber.Size = new System.Drawing.Size(41, 12);
            this.lbNumber.TabIndex = 6;
            this.lbNumber.Text = "label2";
            // 
            // lbCardType
            // 
            this.lbCardType.AutoSize = true;
            this.lbCardType.Location = new System.Drawing.Point(137, 54);
            this.lbCardType.Name = "lbCardType";
            this.lbCardType.Size = new System.Drawing.Size(65, 12);
            this.lbCardType.TabIndex = 5;
            this.lbCardType.Text = "lbCardType";
            // 
            // lblCardType
            // 
            this.lblCardType.AutoSize = true;
            this.lblCardType.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCardType.Location = new System.Drawing.Point(42, 47);
            this.lblCardType.Name = "lblCardType";
            this.lblCardType.Size = new System.Drawing.Size(89, 22);
            this.lblCardType.TabIndex = 4;
            this.lblCardType.Text = "卡 类 型 ：";
            // 
            // btCheckDetail
            // 
            this.btCheckDetail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCheckDetail.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btCheckDetail.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btCheckDetail.Location = new System.Drawing.Point(453, 133);
            this.btCheckDetail.Name = "btCheckDetail";
            this.btCheckDetail.Size = new System.Drawing.Size(60, 56);
            this.btCheckDetail.TabIndex = 3;
            this.btCheckDetail.Text = "查看明细";
            this.btCheckDetail.UseVisualStyleBackColor = true;
            // 
            // lblSalesNo
            // 
            this.lblSalesNo.AutoSize = true;
            this.lblSalesNo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSalesNo.Location = new System.Drawing.Point(42, 107);
            this.lblSalesNo.Name = "lblSalesNo";
            this.lblSalesNo.Size = new System.Drawing.Size(89, 22);
            this.lblSalesNo.TabIndex = 2;
            this.lblSalesNo.Text = "流 水 号 ：";
            // 
            // CardClose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 372);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CardClose";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "结账";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblConsumeTotal;
        private System.Windows.Forms.Label lblCardBalance;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btCheckDetail;
        private System.Windows.Forms.Label lblSalesNo;
        private System.Windows.Forms.Label lblCardType;
        private System.Windows.Forms.Label lbCash;
        private System.Windows.Forms.Label lbAmount;
        private System.Windows.Forms.Label lbNumber;
        private System.Windows.Forms.Label lbCardType;
        private System.Windows.Forms.Label lbMoney;
        private System.Windows.Forms.Label label1;
    }
}