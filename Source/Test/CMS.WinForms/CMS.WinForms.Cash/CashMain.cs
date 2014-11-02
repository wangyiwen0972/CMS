namespace CMS.WinForms.Cash
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using CMS.WinForms.Cash;
    using CMS.WinForms.Sales;
    using CMS.Module.Shell.Core;
    using CMS.Common.Controller.Core;
    using CMS.Common.Model;
    using CMS.Common.ViewResult.Core;



    public partial class CashMain : CMSForm
    {
        private EntranceController entranceController = null;

        private Entrance[] entrance;

        public CashMain()
        {
            InitializeComponent();
            this.entranceController = this.ControllerManager[typeof(EntranceController)] as EntranceController;

            InitEntrance();

        }

        private void InitEntrance()
        {
            XMLCollectionResults results = this.entranceController.GetAllEntrance() as XMLCollectionResults;

            entrance = new Entrance[results.Count];

            for (int i = 0; i < results.Count; i++)
            {
                entrance[i] = (Entrance)results.ElementAt(i).Model;
            }

            for (int i = 1; i <= 3; i++)
            {
                for (int j = 1; j <= 3; j++)
                {
                    int index = i * j;

                    string strEntrance = string.Empty;
                    string strAmount = "0.00";
                    string strCount = "0";
                    string strOperator = "未知";

                    bool isEnable = false;

                    if (index <= entrance.Length)
                    {
                        Entrance tmpEntrance = entrance[index - 1];

                        strEntrance = tmpEntrance.EnterName;

                        ContentResult amountResult = entranceController.GetSalesRevenueByEntrance(tmpEntrance) as ContentResult;

                        strAmount = amountResult.Result;

                        ContentResult countResult = entranceController.GetOrderCountByEntrance(tmpEntrance) as ContentResult;

                        strCount = countResult.Result;

                        isEnable = true;
                    }

                    GroupBox groupBox = CreateGroupBoxForEntrance(strEntrance, strOperator, strAmount, strCount);

                    groupBox.Enabled = isEnable;

                    this.TLPanelStatus.Controls.Add(groupBox, i - 1, j - 1);
                }
            }

            
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.LblTime.Text = DateTime.Now.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.LblTime.Text = DateTime.Now.ToString();
        }

        private void buttonBilling_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private GroupBox CreateGroupBoxForEntrance(string entrance,string operatorName,string amount,string count)
        {
            GroupBox groupBox = new GroupBox();

            Button btnCheckDetail = new Button();
            Label lbOperator = new Label();
            Label lbAmout = new Label();
            Label lbCount = new Label();
            Label lbEntrance = new Label();

            Label lbOperatorName = new Label();
            Label lbOrderCount = new Label();
            Label lbOrderAmount = new Label();

            lbOperator.AutoSize = true;
            lbOperator.ForeColor = System.Drawing.Color.Chocolate;
            lbOperator.Location = new System.Drawing.Point(16, 74);
            lbOperator.Name = "lbOperator";
            lbOperator.Size = new System.Drawing.Size(74, 22);
            lbOperator.Text = "操作员：";
            lbOperatorName.Location = new Point(86, 74);
            lbOperatorName.Text = "管理员";

            lbCount.AutoSize = true;
            lbCount.ForeColor = System.Drawing.Color.Chocolate;
            lbCount.Location = new System.Drawing.Point(16, 160);
            lbCount.Name = "label4";
            lbCount.Size = new System.Drawing.Size(74, 22);
            lbCount.Text = "开单数：";
            lbOrderCount.Location = new Point(86, 160);
            lbOrderCount.Text = count;
            lbOrderCount.AutoSize = true;
            // 
            // label3
            // 
            lbAmout.AutoSize = true;
            lbAmout.ForeColor = System.Drawing.Color.Chocolate;
            lbAmout.Location = new System.Drawing.Point(16, 118);
            lbAmout.Name = "label3";
            lbAmout.Size = new System.Drawing.Size(74, 22);
            lbAmout.TabIndex = 2;
            lbAmout.Text = "营业额：";
            lbOrderAmount.Location = new Point(86, 118);
            lbOrderAmount.Text = "2000.20";
            lbOrderAmount.AutoSize = true;

            lbEntrance.AutoSize = true;
            lbEntrance.ForeColor = System.Drawing.Color.DarkBlue;
            lbEntrance.Location = new System.Drawing.Point(107, 25);
            lbEntrance.Name = "label1";
            lbEntrance.Size = new System.Drawing.Size(90, 22);
            lbEntrance.TabIndex = 0;
            lbEntrance.Text = entrance;
            lbEntrance.AutoSize = true;

            btnCheckDetail.BackColor = System.Drawing.SystemColors.Menu;
            btnCheckDetail.Cursor = System.Windows.Forms.Cursors.Hand;
            btnCheckDetail.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            btnCheckDetail.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            btnCheckDetail.Location = new System.Drawing.Point(232, 99);
            btnCheckDetail.Name = "button1";
            btnCheckDetail.Size = new System.Drawing.Size(60, 60);
            btnCheckDetail.TabIndex = 4;
            btnCheckDetail.Text = "查看明细";
            btnCheckDetail.UseVisualStyleBackColor = false;

            groupBox.Controls.Add(btnCheckDetail);
            groupBox.Controls.Add(lbCount);
            groupBox.Controls.Add(lbAmout);
            groupBox.Controls.Add(lbOperator);
            groupBox.Controls.Add(lbEntrance);

            groupBox.Controls.Add(lbOperatorName);
            groupBox.Controls.Add(lbOrderCount);
            groupBox.Controls.Add(lbOrderAmount);
            

            groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            groupBox.ForeColor = System.Drawing.Color.Chocolate;
            groupBox.Location = new System.Drawing.Point(3, 3);
            groupBox.Name = "GroupBox1";
            groupBox.Size = new System.Drawing.Size(303, 209);
            groupBox.TabIndex = 0;
            groupBox.TabStop = false;
            groupBox.Text = "档口1";
            groupBox.Paint += new System.Windows.Forms.PaintEventHandler(this.GroupBox_Paint);

            return groupBox;

        }

        private void GroupBox_Paint(object sender, PaintEventArgs e)
        {
            GroupBox groupBox = sender as GroupBox;

            e.Graphics.Clear(groupBox.BackColor);
            Rectangle Rtg_LT = new Rectangle();
            Rectangle Rtg_RT = new Rectangle();
            Rectangle Rtg_LB = new Rectangle();
            Rectangle Rtg_RB = new Rectangle();
            Rtg_LT.X = 0; Rtg_LT.Y = 7; Rtg_LT.Width = 10; Rtg_LT.Height = 10;
            Rtg_RT.X = e.ClipRectangle.Width - 11; Rtg_RT.Y = 7; Rtg_RT.Width = 10; Rtg_RT.Height = 10;
            Rtg_LB.X = 0; Rtg_LB.Y = e.ClipRectangle.Height - 11; Rtg_LB.Width = 10; Rtg_LB.Height = 10;
            Rtg_RB.X = e.ClipRectangle.Width - 11; Rtg_RB.Y = e.ClipRectangle.Height - 11; Rtg_RB.Width = 10; Rtg_RB.Height = 10;

            Color color = Color.FromArgb(0, 0, 0);
            Pen Pen_AL = new Pen(color, 1);
            Pen_AL.Color = color;
            Brush brush = new HatchBrush(HatchStyle.Divot, color);

            e.Graphics.DrawString(groupBox.Text, groupBox.Font, brush, 6, 0);
            e.Graphics.DrawArc(Pen_AL, Rtg_LT, 180, 90);
            e.Graphics.DrawArc(Pen_AL, Rtg_RT, 270, 90);
            e.Graphics.DrawArc(Pen_AL, Rtg_LB, 90, 90);
            e.Graphics.DrawArc(Pen_AL, Rtg_RB, 0, 90);
            e.Graphics.DrawLine(Pen_AL, 5, 7, 6, 7);
            e.Graphics.DrawLine(Pen_AL, e.Graphics.MeasureString(groupBox.Text, groupBox.Font).Width + 3, 7, e.ClipRectangle.Width - 7, 7);
            e.Graphics.DrawLine(Pen_AL, 0, 13, 0, e.ClipRectangle.Height - 7);
            e.Graphics.DrawLine(Pen_AL, 6, e.ClipRectangle.Height - 1, e.ClipRectangle.Width - 7, e.ClipRectangle.Height - 1);
            e.Graphics.DrawLine(Pen_AL, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 7, e.ClipRectangle.Width - 1, 13);
        }
      
        private void PanelMainLeft_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonBilling_Click(object sender, EventArgs e)
        {
            CMS.WinForms.Cash.swipingcard sc = new swipingcard();
            sc.Show();
        }
    }
}
