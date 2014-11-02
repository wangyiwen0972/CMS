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
    using System.Threading;
    using System.Runtime.InteropServices;
    using System.Net.NetworkInformation;
    using System.Configuration;
    using CMS.Module.Shell.Core;
    using CMS.Common.Controller.Core;
    using CMS.Common.Model;
    using CMS.Common.ViewResult.Core;
    using System.Diagnostics;

    

    public partial class SalesPortSet : CMSForm
    {
        [DllImport("ws2_32.dll")]
        private static extern int inet_addr(string cp);

        [DllImport("IPHLPAPI.dll")]
        private static extern int SendARP(Int32 DestIP, Int32 SrcIP, ref Int64 pMacAddr, ref Int32 PhyAddrLen);

        private readonly string ipScope;

        private EntranceController entranceController = null;
        private MachineController machineController = null;

        private ICollection<Machine> machineCollection = null;

        private AutoResetEvent autoEvent = new AutoResetEvent(false);
        private BackgroundWorker worker = null;

        public SalesPortSet()
        {
            InitializeComponent();

            this.ipScope = ConfigurationManager.AppSettings["ipScope"];

            this.entranceController = this.ControllerManager[typeof(EntranceController)] as EntranceController;

            this.machineController = this.ControllerManager[typeof(MachineController)] as MachineController;

            //worker = new BackgroundWorker();
            //worker.DoWork += worker_DoWork;
            //worker.RunWorkerCompleted += worker_RunWorkerCompleted;

            //this.worker.RunWorkerAsync();
        }

        /// <summary>
        /// Scan the computers by IP address
        /// </summary>
        private string EnumComputers(IPAddress IpAddress)
        {
            List<string> computerList = new List<string>();

            IPHostEntry myScanHost = null;

            try
            {
                myScanHost = Dns.GetHostByAddress(IpAddress);

                Dictionary<string, string> ipAndHostName = new Dictionary<string, string>();
                Process p = new Process();//开启cmd获取局域网中的所有计算机名称
                p.StartInfo.FileName = "net";
                p.StartInfo.Arguments = "view";
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.Start();
                while (!p.StandardOutput.EndOfStream)
                {
                    string s = p.StandardOutput.ReadLine();
                    if (s.StartsWith(@"\\"))
                    {
                        try
                        {
                            string hostName = s.Substring(2, s.IndexOf(' ') - 1); //计算机名称
                            if (!string.IsNullOrEmpty(hostName))
                            {
                                return hostName;
                            }
                        }
                        catch
                        {
                        }

                    }
                }
            }
            catch
            {

            }

            if (myScanHost != null)
            {
                return myScanHost.HostName;
            }
            else
            {
                return null;
            }

        }

        private void EnumComputers()
        {
            try
            {
                this.lvComputerInfo.Items.Clear();

                if (this.ipScope.IndexOf('*') == -1)
                {
                    Ping myPing = new Ping();
                    myPing.PingCompleted += new PingCompletedEventHandler(myPing_PingCompleted);

                    string pingIP = this.ipScope;

                    myPing.SendAsync(pingIP, 1000, null);
                }
                else
                {
                    string scanIP = this.ipScope.Split('*')[0];

                    for (int i = 1; i <= 255; i++)
                    {

                        Ping myPing = new Ping();
                        myPing.PingCompleted += new PingCompletedEventHandler(myPing_PingCompleted);

                        string pingIP = scanIP + i.ToString();

                        myPing.SendAsync(pingIP, 1000, null);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void myPing_PingCompleted(object sender, PingCompletedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            if (e.Reply.Status == IPStatus.Success)
            {
                string ipAddress = e.Reply.Address.ToString();
                
                string mac = GetMacAddress(e.Reply.Address.ToString());

                string host = this.EnumComputers(e.Reply.Address);
                
                ListViewItem.ListViewSubItem lviIpSubItem = new ListViewItem.ListViewSubItem()
                {
                    Text = ipAddress
                };
                ListViewItem.ListViewSubItem lviMacSubItem = new ListViewItem.ListViewSubItem()
                {
                    Text = mac
                };

                Machine machine = this.machineController.GetMachine(host).Model as Machine;

                ListViewItem.ListViewSubItem lviIsRelated = new ListViewItem.ListViewSubItem()
                {
                    Text = machine == null || !machine.IsRelated ? "未关联" : "已关联"
                };
                

                ListViewItem lvi = new ListViewItem()
                {
                    Text = host
                };

                lvi.SubItems.AddRange(new ListViewItem.ListViewSubItem[] { lviIpSubItem, lviMacSubItem, lviIsRelated });

                lvComputerInfo.Items.Add(lvi);
            }
        }

        private string GetMacAddress(string hostip)//获取远程IP（不能跨网段）的MAC地址
        {
            string Mac = "";

            try
            {
                Int32 ldest = inet_addr(hostip); //将IP地址从 点数格式转换成无符号长整型
                Int64 macinfo = new Int64();
                Int32 len = 6;

                SendARP(ldest, 0, ref macinfo, ref len);

                string TmpMac = Convert.ToString(macinfo, 16).PadLeft(12, '0');//转换成16进制　　注意有些没有十二位

                Mac = TmpMac.Substring(0, 2).ToUpper();//

                for (int i = 2; i < TmpMac.Length; i = i + 2)
                {
                    Mac = TmpMac.Substring(i, 2).ToUpper() + "-" + Mac;
                }
            }
            catch (Exception Mye)
            {
                Mac = "获取远程主机的MAC错误：" + Mye.Message;
            }

            return Mac;
        }

        private void btnSalesPortNew_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbSalesPortName.Text.Trim()))
            {
                MessageBox.Show("You need to set Port name first!");
                return;
            }

            Entrance entrance = null;

            List<Machine> machines = new List<Machine>();

            entrance = this.CreateEntrance(this.tbSalesPortName.Text, machines);

            foreach (ListViewItem lvi in this.lvComputerInfo.Items)
            {
                if (lvi.Selected)
                {
                    Machine machine = new Machine()
                    {
                        ID = Guid.NewGuid(),
                        EntranceID = entrance.ID,
                        MachineMAC = lvi.SubItems[2].Text,
                        MachineName = lvi.Text,
                        MachineIP = lvi.SubItems[1].Text,
                        IsRelated = true
                    };
                    Machine tmpMachine = this.machineController.GetMachineByMac(lvi.SubItems[2].Text).Model as Machine;
                    if (tmpMachine == null)
                    {
                        this.machineController.CreateMachine(machine);
                    }
                    else
                    {
                        this.machineController.UpdateMachine(machine);
                    }
                    machines.Add(machine);
                }
            }

            if (machines.Count == 0) 
            {
                MessageBox.Show("Please choose computer first");
                return;
            }
            try
            {
                Common.ViewResult.Core.BooleanResult result = this.entranceController.CreateEntrance(entrance) as Common.ViewResult.Core.BooleanResult;

                if (!Convert.ToBoolean(result.Result))
                {
                    MessageBox.Show("Create new entrance failed! Please check log");
                    return;
                }

                int count = this.listView1.Items.Count;

                ListViewItem item = new ListViewItem()
                {
                    Text = (count + 1).ToString()
                };

                ListViewItem.ListViewSubItem lvsEntrance = new ListViewItem.ListViewSubItem()
                {
                    Text = entrance.EnterName
                };
                string[] machineList = new string[entrance.MachineCollection.Count];

                for (int i = 0; i < entrance.MachineCollection.Count; i++)
                {
                    machineList[i] = entrance.MachineCollection.ElementAt(i).MachineName;
                }

                ListViewItem.ListViewSubItem lvsMachine = new ListViewItem.ListViewSubItem()
                {
                    Text = string.Join(",", machineList)
                };

                ListViewItem.ListViewSubItem lvsDishType = new ListViewItem.ListViewSubItem(item, "");

                ListViewItem.ListViewSubItem lvsChoose = new ListViewItem.ListViewSubItem(item, "...");

                ListViewItem.ListViewSubItem lvsStatus = new ListViewItem.ListViewSubItem()
                {
                    Text = "新增"
                };
                item.SubItems.AddRange(new ListViewItem.ListViewSubItem[] { lvsEntrance, lvsMachine, lvsDishType, lvsChoose, lvsStatus });

                item.Tag = entrance;

                this.listView1.Items.Add(item);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private Entrance CreateEntrance(string entranceName, ICollection<Machine> machines)
        {
            Entrance entrance = new Entrance()
            {
                ID = Guid.NewGuid(),
                EnterName = entranceName,
                CreatedBy = this.Login,
                CreatedDate = DateTime.Now,
                ChangedBy = this.Login,
                ChangedDate = DateTime.Now,
                MachineCollection = machines
            };

            return entrance;
        }

        private EntranceLimitationDetail CreateNewLimitation(Entrance entrance, DishType dishType)
        {
            EntranceLimitationDetail limitation = new EntranceLimitationDetail()
            {
                ID = Guid.NewGuid(),
                Entrance = entrance,
                DishType = dishType,
            };

            return limitation;
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (ListViewItem item in this.listView1.Items)
            {
                Rectangle rec = item.GetBounds(ItemBoundsPortion.Entire);

                if (rec.Contains(e.Location))
                {
                    ListViewItem.ListViewSubItem subItem = item.SubItems[4];
                    if (subItem.Bounds.Contains(e.Location))
                    {
                        Entrance entrance = item.Tag as Entrance;

                        SalesPortSetEdit frmPortEdit = new SalesPortSetEdit(entrance);
                        DialogResult result = frmPortEdit.ShowDialog();
                        if (result == System.Windows.Forms.DialogResult.OK)
                        {
                            string[] selectDishTypes = new string[frmPortEdit.SecectedDishTypeCollection.Count];
                            for (int i = 0; i < frmPortEdit.SecectedDishTypeCollection.Count; i++)
                            {
                                DishType dishType = frmPortEdit.SecectedDishTypeCollection.ElementAt(i);
                                selectDishTypes[i] = dishType.EnumValue;
                            }
                            item.SubItems[3].Text = string.Join(",", selectDishTypes);

                            this.EnumComputers();

                            return;
                        }
                        return;
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                List<ListViewItem> newItems = new List<ListViewItem>();

                if (this.listView1.Items.Count > 0)
                {
                    foreach (ListViewItem lvi in this.listView1.Items)
                    {
                        if (lvi.SubItems["status"].Text == "新增")
                        {
                            newItems.Add(lvi);
                        }
                    }
                }

                this.listView1.Items.Clear();
                this.listView1.BeginUpdate();

                int index = 0;
                ICollection<CMS.Interface.Model.IModel> entranceModel = (this.entranceController.GetAllEntrance() as XMLCollectionResults).GetModelResults();

                foreach (Entrance entrance in entranceModel)
                {
                    index += 1;
                    ListViewItem item = new ListViewItem()
                    {
                        Text = index.ToString()
                    };

                    this.entranceController.GetMachineCollectionByEntrance(entrance);

                    ListViewItem.ListViewSubItem lvsEntrance = new ListViewItem.ListViewSubItem()
                    {
                        Text = entrance.EnterName
                    };
                    string[] machineList = new string[entrance.MachineCollection.Count];

                    for (int i = 0; i < entrance.MachineCollection.Count; i++)
                    {
                        machineList[i] = entrance.MachineCollection.ElementAt(i).MachineName;
                    }
                    ListViewItem.ListViewSubItem lvsMachine = new ListViewItem.ListViewSubItem()
                    {
                        Text = string.Join(",", machineList)
                    };

                    this.entranceController.GetLimitationCollection(entrance);

                    ListViewItem.ListViewSubItem lvsDishType = new ListViewItem.ListViewSubItem(item,"");
                    if (entrance.LimitationCollection == null)
                    {

                    }
                    else
                    {
                        string[] limitationList = new string[entrance.LimitationCollection.Count];

                        for (int i = 0; i < entrance.LimitationCollection.Count; i++)
                        {
                            EntranceLimitationDetail limitation = entrance.LimitationCollection.ElementAt(i);
                            this.entranceController.GetDishTypeByLimitation(limitation);

                            limitationList[i] = limitation.DishType.EnumValue;
                        }

                        lvsDishType = new ListViewItem.ListViewSubItem()
                        {
                            Text = string.Join(",", limitationList)
                        };
                    }

                    ListViewItem.ListViewSubItem lvsChoose = new ListViewItem.ListViewSubItem(item, "...");

                    ListViewItem.ListViewSubItem lvsStatus = new ListViewItem.ListViewSubItem()
                    {
                        Text = "正常"
                    };
                    item.SubItems.AddRange(new ListViewItem.ListViewSubItem[] { lvsEntrance, lvsMachine, lvsDishType,lvsChoose, lvsStatus });

                    item.Tag = entrance;

                    this.listView1.Items.Add(item);
                }

                if (newItems.Count > 0)
                {
                    foreach (ListViewItem lvi in newItems)
                    {
                        index += 1;
                        lvi.Text = index.ToString();
                        this.listView1.Items.Add(lvi);
                    }
                }
                this.listView1.EndUpdate();

            }
            catch (Exception ex) 
            {
                throw ex;
            }
                    
        }

        private void btGetComputer_Click(object sender, EventArgs e)
        {
            this.lvComputerInfo.Items.Clear();
            //this.worker.RunWorkerAsync();
            EnumComputers();
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            EnumComputers();
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            autoEvent.Set();
        }

    }
}
