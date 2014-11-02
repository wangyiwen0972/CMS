namespace CMS.Module.Shell.Core
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using CMS.Common.Controller.Manage;
    using CMS.Interface.Model;
    using CMS.Common.Utility;
    using System.Text.RegularExpressions;
    using System.Xml;
    using System.Xml.XPath;
    using System.Resources;
    using CMS.Common.Model;
    using Sunisoft.IrisSkin;
    using CMS.WinForms.OSK;

    public class CMSForm:Form
    {
        protected Sunisoft.IrisSkin.SkinEngine _skin = null;

        private static ControllerManage controllerManager = null;
        private static Employee loginEmployee = null;
        private static Machine loginMachine = null;
        protected System.Resources.ResourceManager resourceManager = null;

        protected static OSK frmOSK = null;

        public event EventHandler LoadDataSourceCompleted;

        public ControllerManage ControllerManager
        {
            get
            {
                return CMSForm.controllerManager;
            }
        }

        public Employee Login
        {
            get { return CMSForm.loginEmployee; }
        }

        public Machine Machine
        {
            get { return CMSForm.loginMachine; }
        }

        static CMSForm()
        {
            try
            {
                controllerManager = new ControllerManage();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
                return;
            }
        }

        protected static void SetCurrentEmployee(Employee employee)
        {
            loginEmployee = employee;
        }

        protected static void SetCurrentMachine(Machine machine)
        {
            loginMachine = machine;
        }

        public CMSForm():base()
        {
            try
            {
                this.resourceManager = new System.Resources.ResourceManager(this.GetType());
                if (frmOSK == null) frmOSK = new OSK();
            }
            catch
            {
            }

            //_skin = new Sunisoft.IrisSkin.SkinEngine();
            //_skin.SkinFile = @"skin\EmeraldColor1.ssk";
        }

        protected virtual void LoadDataSource<T>(ICollection<T> Datasource, Control Container) where T : IModel
        {
            if (Container is ListView)
            {
                ListView lvContainter = Container as ListView;

                foreach(var dataRow in Datasource)
                {
                    int index = 0;
                    ListViewItem lvi = null;

                    string content = string.Empty;
                    XmlDocument mDoc = new XmlDocument();

                    try
                    {
                        content = CMS.Common.Utility.Core.Reflector.ModelReflector.GetFullyInfoByModel(dataRow);

                        mDoc.LoadXml(content);
                    }
                    catch { }

                    foreach (ColumnHeader columnHeader in lvContainter.Columns)
                    {
                       
                        ListViewItem.ListViewSubItem subLvi = new ListViewItem.ListViewSubItem();

                        string columnQuery = (String)columnHeader.Tag;

                        string rValue = string.Empty;

                        XPathExpression Expr = null;

                        if (string.IsNullOrEmpty(columnQuery)) continue;

                        try
                        {
                            Expr = XPathExpression.Compile(columnQuery);

                            XPathNavigator oXPathNav = mDoc.CreateNavigator();

                            XPathNodeIterator iterator = oXPathNav.Select(Expr);

                            while (iterator.MoveNext())
                            {
                                rValue = iterator.Current.Value;
                            }

                            if (index == 0)
                            {
                                lvi = new ListViewItem(rValue);
                                continue;
                            }
                            else
                            {
                                subLvi.Text = rValue;

                                lvi.SubItems.Add(subLvi);
                            }

                        }
                        catch
                        {
                            throw;
                        }
                        finally
                        {
                            index += 1;
                        }
                    }
                    lvContainter.Items.Add(lvi);
                }
                OnDataSourceLoad(lvContainter, new EventArgs());
            }
            else if (Container is ComboBox)
            {
            }
            else if (Container is DataGrid)
            {
            }
        }

        protected virtual void OnDataSourceLoad(object sender, EventArgs e)
        {
            if (LoadDataSourceCompleted != null)
                LoadDataSourceCompleted(sender, e);
        }

        internal void Refresh()
        {
        }
    }
}
