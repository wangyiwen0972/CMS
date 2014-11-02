using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CMS.WinForms.OSK
{
    public partial class OSK : Form
    {
        private Control activeControl = null;

        private const int WS_EX_TOOLWINDOW = 0x00000080;
        private const int WS_EX_NOACTIVATE = 0x08000000;


        [DllImport("user32.dll")]
        private extern static IntPtr SetActiveWindow(IntPtr handle);
        private const int WM_ACTIVATE = 0x006;
        private const int WM_ACTIVATEAPP = 0x01C;
        private const int WM_NCACTIVATE = 0x086;
        private const int WA_INACTIVE = 0;
        private const int WM_MOUSEACTIVATE = 0x21;
        private const int MA_NOACTIVATE = 3;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_MOUSEACTIVATE)
            {
                m.Result = new IntPtr(MA_NOACTIVATE);
                return;
            }
            else if (m.Msg == WM_NCACTIVATE)
            {
                if (((int)m.WParam & 0xFFFF) != WA_INACTIVE)
                {
                    if (m.LParam != IntPtr.Zero)
                    {
                        SetActiveWindow(m.LParam);
                    }
                    else
                    {
                        SetActiveWindow(IntPtr.Zero);
                    }
                }
            }
            base.WndProc(ref m);
        }

        public OSK()
        {
            InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= (WS_EX_NOACTIVATE | WS_EX_TOOLWINDOW);
                cp.Parent = IntPtr.Zero; // Keep this line only if you used UserControl
                
                return cp;
            }
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void BTq_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("q");
        }

        private void BT1_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("1");
        }

        private void BTw_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("w");
        }

        private void BTe_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("e");
        }

        private void BTr_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("r");
        }

        private void BTt_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("t");
        }

        private void BTy_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("y");
        }

        private void BTu_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("u");
        }

        private void BTi_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("i");
        }

        private void BTo_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("o");
        }

        private void BTp_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("p");
        }

        private void BTa_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("a");
        }

        private void BTs_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("s");
        }

        private void BTd_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("d");
        }

        private void BTf_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("f");
        }

        private void BTg_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("g");
        }

        private void BTh_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("h");
        }

        private void BTj_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("j");
        }

        private void BTk_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("k");
        }

        private void BTl_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("l");
        }

        private void BTz_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("z");
        }

        private void BTx_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("x");
        }

        private void BTc_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("c");
        }

        private void BTv_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("v");
        }

        private void BTb_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("b");
        }

        private void BTn_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("n");
        }

        private void BTm_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("m");
        }

        private void BTSpace_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("{space}");
        }

        private void BTBackspace_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("{BS}");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void BT2_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("2");
        }

        private void BT3_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("3");
        }

        private void BT4_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("4");
        }

        private void BT5_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("5");
        }

        private void BT6_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("6");
        }

        private void BT7_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("7");
        }

        private void BT8_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("8");
        }

        private void BT9_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("9");
        }

        private void BT0_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("0");
        }

        private void BTPoint_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("{kpdp}"); 
        }
    }
}
