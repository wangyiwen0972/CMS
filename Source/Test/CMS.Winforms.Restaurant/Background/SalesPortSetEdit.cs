namespace CMS.WinForms.Background
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Net;
    using System.Runtime.InteropServices;
    using System.Net.NetworkInformation;
    using System.Configuration;
    using CMS.Module.Shell.Core;
    using CMS.Common.Controller.Core;
    using CMS.Common.Model;
    using CMS.Common.ViewResult.Core;

    public partial class SalesPortSetEdit : CMSForm
    {
        private ICollection<DishType> dishTypeCollection = null;
        private Entrance entrance = null;

        private MachineController machineController = null;
        private DishController dishController = null;
        private EntranceController entranceController = null;

        private ICollection<DishType> secectedDishTypeCollection = null;

        public ICollection<DishType> SecectedDishTypeCollection
        {
            get { return secectedDishTypeCollection; }
        }

        public SalesPortSetEdit():this(null)
        {
            
        }

        public SalesPortSetEdit(Entrance entrance):base()
        {
            InitializeComponent();

            this.entrance = entrance;
            this.machineController = this.ControllerManager[typeof(MachineController)] as MachineController;
            this.dishController = this.ControllerManager[typeof(DishController)] as DishController;
            this.entranceController = this.ControllerManager[typeof(EntranceController)] as EntranceController;

            GetLatestDishType();

            FillDishTypesToGroupbox();

            FillMachinesToListview();

            Init();
        }

        private void Init()
        {
            if (this.entrance.LimitationCollection != null && this.entrance.LimitationCollection.Count > 0)
            {
                foreach (EntranceLimitationDetail limitation in this.entrance.LimitationCollection)
                {
                    foreach (CheckBox cb in this.gbDishTypes.Controls)
                    {
                        if (cb.Text.Equals(limitation.DishType.EnumValue, StringComparison.CurrentCultureIgnoreCase))
                        {
                            cb.Checked = true;
                        }
                    }
                }
            }
        }

        #region Fill data to controller
        private void FillDishTypesToGroupbox()
        {
            this.gbDishTypes.Controls.Clear();

            int boxWidth = this.gbDishTypes.Width;

            int width = 130, heiht = 50;

            int w = 30, h = 30;

            foreach (DishType dishType in this.dishTypeCollection)
            {
                if (w  >= boxWidth)
                {
                    w = 30;
                    h += heiht;
                }
                
                CheckBox check = new CheckBox()
                {
                    Location = new Point(w,h),
                    Text = dishType.EnumValue,
                    Tag = dishType
                };

                this.gbDishTypes.Controls.Add(check);

                w += width;
            }
        }

        private void FillMachinesToListview()
        {
            int index = 1;
            foreach (Machine machine in this.entrance.MachineCollection)
            {
                ListViewItem lvi = new ListViewItem()
                {
                    Text = index.ToString()
                };

                ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem()
                {
                    Text = machine.MachineName
                };
                lvi.SubItems.Add(subItem);

                this.listView1.Items.Add(lvi);
            }
        }
        #endregion

        #region Get data from database
        private void GetLatestDishType()
        {
            XMLCollectionResults results = this.dishController.GetAllDishTypes();

            dishTypeCollection = new List<DishType>();

            foreach (DishType dishType in results.GetModelResults())
            {
                if (dishType != null)
                {
                    dishTypeCollection.Add(dishType);
                }
            }
        }

        #endregion

        private void btnSalesPortSetEditSave_Click(object sender, EventArgs e)
        {
            List<EntranceLimitationDetail> limitationCollection = new List<EntranceLimitationDetail>();
            secectedDishTypeCollection = new List<DishType>();

            if (this.entrance.LimitationCollection != null && this.entrance.LimitationCollection.Count > 0)
            {
                try
                {
                    this.entranceController.DeleteLimitation(entrance);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            foreach (CheckBox check in this.gbDishTypes.Controls)
            {
                if (check.Checked)
                {
                    try
                    {
                        EntranceLimitationDetail limitation = new EntranceLimitationDetail()
                        {
                            DishType = check.Tag as DishType,
                            Entrance = this.entrance,
                            ID = Guid.NewGuid(),
                            CreatedBy = Login,
                            CreatedDate = DateTime.Now
                        };

                        BooleanResult result = this.entranceController.CreateNewLimitation(entrance, limitation) as BooleanResult;

                        if (Convert.ToBoolean(result.Result))
                        {
                            limitationCollection.Add(limitation);
                            secectedDishTypeCollection.Add(check.Tag as DishType);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else
                {

                }
            }
            if (limitationCollection.Count > 0)
            {
                entrance.LimitationCollection = limitationCollection;
            }
            
        }
    }
}
