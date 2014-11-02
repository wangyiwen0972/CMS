namespace CMS.Module.Printer.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Text;
    using System.Drawing.Printing;
    using System.Configuration;

    public abstract class BasePrinter:IDisposable
    {
        internal System.Windows.Forms.PrintDialog prnDialog = new PrintDialog();
        internal System.Windows.Forms.PrintPreviewDialog prnPreview = new PrintPreviewDialog();
        internal System.Drawing.Printing.PrintDocument prnDocument = new System.Drawing.Printing.PrintDocument();
        internal System.ComponentModel.Container components = null;
        internal System.Windows.Forms.PageSetupDialog prnSettingDialog = new PageSetupDialog();

        internal PageSettings prnPageSetting = null;
        internal PrinterSettings prnPrinterSettging = null;


        internal StringBuilder content = null;

        public abstract void Preview();

        public abstract void Clear();

        public abstract void Print();

        public abstract void AppendContent(string Content);

        public abstract void PageSetting();

        public abstract void PrinterSetting();

        public abstract void WriteSettingsToConfig(string Config);

        public abstract void ApplyTemplate(string Template);
        public abstract void ApplyTemplate(string content,string Template);

        public BasePrinter() 
        {
            
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
