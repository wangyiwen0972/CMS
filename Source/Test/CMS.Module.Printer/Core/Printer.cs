namespace CMS.Module.Printer.Core
{
    using System;
    using System.Runtime.InteropServices;
    using System.Data;
    using System.IO;
    using System.Windows.Forms;
    using System.Drawing;
    using System.Text;
    using CMS.Module.Printer.Confuration;
    using System.Configuration;
    using System.Reflection;

    public class Printer:Base.BasePrinter
    {
        private IntPtr iHandle;
        private FileStream fs;
        private StreamWriter sw;

        private readonly string printPort;

        private const uint GENERIC_READ = 0x80000000;
        private const uint GENERIC_WRITE = 0x40000000;
        private const int OPEN_EXISTING = 3;

        [DllImport("kernel32.dll", EntryPoint = "CreateFile", CharSet = CharSet.Auto)]
        private static extern IntPtr CreateFile(string lpFileName, uint dwDesireAccess, int dwShareMode, int lpSecurityAttributes, int dwCreationDisposition, int FlagsAndAttributes, int hTemplateFile);

        private readonly string printerName;

        // for PrintDialog, PrintPreviewDialog and PrintDocument:
        public Printer()
            : this(null)
        {
        }

        public short Copies
        {
            get { return base.prnPrinterSettging.Copies; }
        }

        public Printer(string printer):base()
        {
            this.printerName = printer;

            this.content = new StringBuilder();

            base.prnDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(prnDocument_PrintPage);

            base.prnDocument.PrinterSettings.PrinterName = this.printerName;

            base.prnDocument.PrintController = new System.Drawing.Printing.StandardPrintController();
        }

        public void SetCopies(short count)
        {
            base.prnDocument.PrinterSettings.Copies = count;
        }

        private void prnDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float linesPerPage = 0;
            float yPosition = 0;
            int count = 0;
            float leftMargin = -10;
            float topMargin = -10;
            string line = null;
            Font printFont = new Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            SolidBrush myBrush = new SolidBrush(Color.Black);
            // Work out the number of lines per page, using the MarginBounds.
            linesPerPage = e.MarginBounds.Height / printFont.GetHeight(e.Graphics);
            // Iterate over the string using the StringReader, printing each line.

            StringReader myRead = new StringReader(this.content.ToString());

            while (count < linesPerPage && ((line = myRead.ReadLine()) != null))
            {
                // calculate the next line position based on the height of the font according to the printing device
                yPosition = topMargin + (count * printFont.GetHeight(e.Graphics));
                // draw the next line in the rich edit control
                e.Graphics.DrawString(line, printFont, myBrush, leftMargin, yPosition, new StringFormat());
                count++;
            }
        }

        public override void PageSetting()
        {
            DialogResult result = this.prnSettingDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.prnPageSetting = this.prnSettingDialog.PageSettings;
            }
        }

        public override void PrinterSetting()
        {
            DialogResult result = this.prnDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.prnPrinterSettging = this.prnDialog.PrinterSettings;
            }
        }

        public override void WriteSettingsToConfig(string Config)
        {
            System.Configuration.Configuration config =
        ConfigurationManager.OpenExeConfiguration(
              ConfigurationUserLevel.None);

            string appName =
        Environment.GetCommandLineArgs()[0];

            string configFile = string.Concat(appName,
              ".2.config");
            config.SaveAs(configFile, ConfigurationSaveMode.Full);

            ExeConfigurationFileMap configFileMap =
                      new ExeConfigurationFileMap();
            configFileMap.ExeConfigFilename = configFile;

            // Get the mapped configuration file
            config =
               ConfigurationManager.OpenMappedExeConfiguration(
                 configFileMap, ConfigurationUserLevel.None);

            string sectionName = "printerSection";

            PrinterSettingSection prtSection = new PrinterSettingSection();

            prtSection.SectionInformation.AllowExeDefinition = System.Configuration.ConfigurationAllowExeDefinition.MachineToLocalUser;

            prtSection.SectionInformation.AllowOverride = true;

            prtSection.CurrentPrinter.Name = "PrinterName";

            prtSection.CurrentPrinter.Value = "defaultPrinter";


            config.Sections.Add(sectionName, prtSection);

            config.Save(ConfigurationSaveMode.Modified);

            // Force a reload of the changed section. This 
            // makes the new values available for reading.
            ConfigurationManager.RefreshSection(sectionName);
        }

        public override void Preview()
        {
            prnPreview.Document = prnDocument;

            prnPreview.ShowDialog();
        }

        public override void Clear()
        {
            this.content = new StringBuilder();
        }

        public override void AppendContent(string Content)
        {
            this.content.AppendLine(Content);
        }

        public override void Print()
        {
            //prnDocument.PrinterSettings = new System.Drawing.Printing.PrinterSettings()
            //{
            //    Copies = 2
            //};
 
            prnDocument.Print();
        }

        /// <summary>
        /// 开始连接打印机
        /// </summary>
        private bool PrintOpen()
        {
            iHandle = CreateFile(printPort, GENERIC_READ | GENERIC_WRITE, 0, 0, OPEN_EXISTING, 0, 0);

            if (iHandle.ToInt32() == -1)
            {
                MessageBox.Show("没有连接打印机或者打印机端口不是LPT1！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                fs = new FileStream(iHandle, FileAccess.ReadWrite);
                sw = new StreamWriter(fs, System.Text.Encoding.Default);   //写数据
                return true;
            }
        }

        /// <summary>
        /// 打印字符串
        /// </summary>
        /// <param name="str">要打印的字符串</param>
        private void PrintLine(string str)
        {
            sw.WriteLine(str); ;
        }

        /// <summary>
        /// 关闭打印连接
        /// </summary>
        private void PrintEnd()
        {
            sw.Close();
            fs.Close();
        }

        /// <summary>
        /// 打印票据
        /// </summary>
        /// <param name="ds">tb_Temp 全部字段数据集合</param>
        /// <returns>true：打印成功 false：打印失败</returns>
        private bool PrintDataSet(DataSet dsPrint)
        {
            try
            {
                if (PrintOpen())
                {
                    PrintLine(" ");
                    PrintLine("[XXXXXXXXXXXXXXXXXX超市]");
                    PrintLine("NO :      " + dsPrint.Tables[0].Rows[0][1].ToString());
                    PrintLine("XXXXXX: " + dsPrint.Tables[0].Rows[0][2].ToString());
                    PrintLine("XXXXXX: " + dsPrint.Tables[0].Rows[0][3].ToString());
                    PrintLine("XXXXXX: " + dsPrint.Tables[0].Rows[0][4].ToString());
                    PrintLine("XXXXXX: " + dsPrint.Tables[0].Rows[0][5].ToString());
                    PrintLine("操 作 员: " + dsPrint.Tables[0].Rows[0][6].ToString() + " " + dsPrint.Tables[0].Rows[0][7].ToString());
                    PrintLine("-------------------------------------------");
                }
                PrintEnd();

                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool PrintDataSet()
        {
            try
            {
                if (PrintOpen())
                {
                    PrintLine(" ");
                    PrintLine("[XXXXXXXXXXXXXXXXXX超市]");
                    PrintLine("NO :      10086");
                    PrintLine("XXXXXX: ");
                    PrintLine("XXXXXX: ");
                    PrintLine("XXXXXX: " );
                    PrintLine("XXXXXX: ");
                    PrintLine("操 作 员: ");
                    PrintLine("-------------------------------------------");
                }
                PrintEnd();

                return true;
            }
            catch
            {
                return false;
            }
        }

        private void PrintESC(int iSelect)
        {
            string send;

            iHandle = CreateFile(printPort, GENERIC_READ | GENERIC_WRITE, 0, 0, OPEN_EXISTING, 0, 0);

            if (iHandle.ToInt32() == -1)
            {
                MessageBox.Show("没有连接打印机或者打印机端口不是LPT1！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                fs = new FileStream(iHandle, FileAccess.ReadWrite);
            }

            byte[] buf = new byte[80];

            switch (iSelect)
            {
                case 0:
                    send = "" + (char)(27) + (char)(64) + (char)(27) + 'j' + (char)(255);    //退纸1 255 为半张纸长
                    send = send + (char)(27) + 'j' + (char)(125);    //退纸2
                    break;
                case 1:
                    send = "" + (char)(27) + (char)(64) + (char)(27) + 'J' + (char)(255);    //进纸
                    break;
                case 2:
                    send = "" + (char)(27) + (char)(64) + (char)(12);   //换行
                    break;
                default:
                    send = "" + (char)(27) + (char)(64) + (char)(12);   //换行
                    break;
            }
            for (int i = 0; i < send.Length; i++)
            {
                buf[i] = (byte)send[i];
            }

            fs.Write(buf, 0, buf.Length);
            fs.Close();
        }


        public override void ApplyTemplate(string Template)
        {
            if (!System.IO.File.Exists(Template))
            {
                throw new Exception(string.Format("Can't find specific template file. Path: {0}", Template));
            }

            System.Xml.Xsl.XslCompiledTransform xslTransform = null;

            try
            {
                xslTransform = new System.Xml.Xsl.XslCompiledTransform();
            }
            catch
            {
            }
        }

        public override void ApplyTemplate(string content, string Template)
        {
            if (!System.IO.File.Exists(Template))
            {
                throw new Exception(string.Format("Can't find specific template file. Path: {0}", Template));
            }

            System.Xml.Xsl.XslCompiledTransform xslTransform = null;

            try
            {
                StringBuilder outputString = new StringBuilder();
                TextWriter outputWriter = new StringWriter(outputString);
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();

                doc.LoadXml(content);

                xslTransform = new System.Xml.Xsl.XslCompiledTransform(true);

                xslTransform.Load(Template);

                xslTransform.Transform(doc, null, outputWriter);

                this.content = outputString;
            }
            catch (System.Xml.Xsl.XsltCompileException exception)
            {
                throw exception;
            }
            catch (System.Xml.Xsl.XsltException xsltException)
            {
                throw xsltException;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ApplyTemplate(System.Xml.XmlDocument xmlDocument, string templatePath)
        {
            this.ApplyTemplate(xmlDocument.OuterXml, templatePath);
            //xmlDocument.Load(System.IO.Path.Combine(Environment.CurrentDirectory,@"Template\template.xml"));
            //this.ApplyTemplate(xmlDocument.OuterXml,templatePath);
        }
    }
}
