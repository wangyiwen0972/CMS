namespace CMS.Restaurant.Client.Sales
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;



    public partial class CardOpen : Form
    {
        public CardOpen()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtbRecharge.Focus();
            txtbRecharge.Text = "";
            SendKeys.SendWait("50");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtbRecharge.Focus();
            txtbRecharge.Text = "";
            SendKeys.SendWait("100");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtbRecharge.Focus();
            txtbRecharge.Text = "";
            SendKeys.SendWait("200");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtbRecharge.Focus();
            txtbRecharge.Text = "";
            SendKeys.SendWait("500");
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            txtbRecharge.Focus();
            txtbRecharge.Text = "";
            SendKeys.SendWait("50");

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            txtbRecharge.Focus();
            txtbRecharge.Text = "";
            SendKeys.SendWait("100");
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            txtbRecharge.Focus();
            txtbRecharge.Text = "";
            SendKeys.SendWait("200");
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            txtbRecharge.Focus();
            txtbRecharge.Text = "";
            SendKeys.SendWait("500");
        }
    }
}
