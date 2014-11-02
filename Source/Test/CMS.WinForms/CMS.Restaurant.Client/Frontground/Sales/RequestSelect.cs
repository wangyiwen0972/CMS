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
    using System.Xml;
    using System.Windows.Forms;
    using CMS.Common.Model;
    using ControllerCore = CMS.Common.Controller.Core;
    using UtilityCore = CMS.Common.Utility.Core;
    using ResultCore = CMS.Common.ViewResult.Core;
    using CMS.Module.Printer.Core;
    using CMS.Module.Shell.Core;
    using CMS.Module.CardMachine;
    using CMS.Restaurant.Client.Cash;
    using CMS.WinForms;

    public partial class RequestSelect : CMSForm
    {
        public RequestSelect()
        {
            InitializeComponent();
        }
    }
}
