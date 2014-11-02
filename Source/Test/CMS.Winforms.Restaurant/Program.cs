using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CMS.WinForms.Login;

namespace CMS.WinForms.Restaurant
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CMS.WinForms.Login.Login());
            //Application.Run(new CMS.WinForms.Cash.swipingcard());
        }
    }
}
