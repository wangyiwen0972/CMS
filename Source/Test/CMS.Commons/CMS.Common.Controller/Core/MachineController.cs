namespace CMS.Common.Controller.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using CMS.Common.ViewResult.Core;
    using CMS.Common.ViewResult.Base;
    using CMS.Common.Database.Core;
    using CMS.Common.Model;
    using CMS.Common.Utility.Core;
    using CMS.Interface.Model;


    public class MachineController : Base.BaseController
    {

        #region
        protected override string GetConnectionString()
        {
            return !string.IsNullOrEmpty(this.CMSContext.ConnectionString) ? this.CMSContext.ConnectionString : string.Empty;
        }

        protected override string GetProvider()
        {
            return !string.IsNullOrEmpty(this.CMSContext.Provider) ? this.CMSContext.Provider : string.Empty;
        }
        #endregion

        public ActionResultBase CreateMachine(Machine Machine)
        {
            try
            {
                using (this.CMSContext)
                {
                    this.CMSContext.New<Machine>(Machine);

                    return Boolean(true);
                }
            }
            catch (Exception ex)
            {
                return Boolean(false);
            }
        }

        public ActionResultBase UpdateMachine(Machine Machine)
        {
            try
            {
                using (this.CMSContext)
                {
                    this.CMSContext.Save<Machine>(Machine);

                    return Boolean(true);
                }
            }
            catch (Exception ex)
            {
                return Boolean(false);
            }
        }

        public ActionResultBase DeleteMachine(Machine Machine)
        {
            try
            {
                using (this.CMSContext)
                {
                    this.CMSContext.Delete<Machine>(Machine);

                    return Boolean(true);
                }
            }
            catch (Exception ex)
            {
                return Boolean(false);
            }
        }

        public ActionResultBase GetMachine(string MachineName)
        {
            try
            {
                using (this.CMSContext)
                {
                    if (this.CacheManage[typeof(Machine)] != null && this.CacheManage[typeof(Machine)].Count() > 0)
                    {
                        var machineCollection = from m in this.CacheManage[typeof(Machine)] where (m as Machine).MachineName == MachineName select m;

                        Machine machine = machineCollection != null && machineCollection.Count() > 0 ? machineCollection.ElementAt(0) as Machine : null;

                        if (machine == null)
                        {
                            this.CMSContext.Sync<Machine>(typeof(Machine));

                            machineCollection = from m in this.CacheManage[typeof(Machine)] where (m as Machine).MachineName == MachineName select m;

                            machine = machineCollection != null && machineCollection.Count() > 0 ? machineCollection.ElementAt(0) as Machine : null;
                        }
                        return this.Xml<Machine>(machine);
                    }
                    else
                    {
                        ICollection<Machine> machineCollection = this.CMSContext.Sync<Machine>(typeof(Machine));

                        foreach (Machine machine in machineCollection)
                        {
                            if (machine.PrimaryName().Trim().Equals(MachineName.Trim(), StringComparison.CurrentCultureIgnoreCase))
                            {
                                return this.Xml<Machine>(machine);
                            }
                        }
                        return this.Xml<Machine>(null);
                    }
                }
            }
            catch (Exception ex)
            {
                return Boolean(false);
            }
        }

        public ActionResultBase GetMachineByMac(string Mac)
        {
            try
            {
                using (this.CMSContext)
                {
                    if (this.CacheManage[typeof(Machine)] != null && this.CacheManage[typeof(Machine)].Count() > 0)
                    {
                        var machineCollection = from m in this.CacheManage[typeof(Machine)] where (m as Machine).MachineMAC.Equals(Mac, StringComparison.CurrentCultureIgnoreCase) select m;

                        Machine machine = machineCollection != null && machineCollection.Count() > 0 ? machineCollection.ElementAt(0) as Machine : null;

                        if (machine == null)
                        {
                            this.CMSContext.Sync<Machine>(typeof(Machine));

                            machineCollection = from m in this.CacheManage[typeof(Machine)] where (m as Machine).MachineMAC.Equals(Mac, StringComparison.CurrentCultureIgnoreCase) select m;

                            machine = machineCollection != null && machineCollection.Count() > 0 ? machineCollection.ElementAt(0) as Machine : null;
                        }
                        return this.Xml<Machine>(machine);
                    }
                    else
                    {
                        this.CMSContext.Sync<Machine>(typeof(Machine));

                        foreach (Machine machine in this.CacheManage[typeof(Machine).Name])
                        {
                            if (machine.MachineMAC.Equals(Mac.Trim(), StringComparison.CurrentCultureIgnoreCase))
                            {
                                return this.Xml<Machine>(machine);
                            }
                        }
                        return this.Xml<Machine>(null);
                    }
                }
            }
            catch (Exception ex)
            {
                return Boolean(false);
            }
        }

    }
}
