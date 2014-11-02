using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CMS.Common.Model;
using CMS.Common.Controller.Core;
using CMS.Common.ViewResult.Core;
using CMS.Module.Printer.Core;

namespace CMS.UnitTest.Controller
{
    public partial class AttributeEnumControllerTest : Form
    {
        public AttributeEnumControllerTest()
        {
            InitializeComponent();

            controller = new AttributeEnumController();
        }

        AttributeEnumController controller = null;

        private void button1_Click(object sender, EventArgs e)
        {
            //ICollection<CMS.Common.Model.Emun.Action> actions = new List<CMS.Common.Model.Emun.Action>();

            //actions.Add(Common.Model.Emun.Action.AddDish);

            //Employee employee = new Employee()
            //{
            //    ID = Guid.Parse("8f6946ca-d5e9-43c6-920d-ce6ceaad9d20"),
            //    FullName = "stephen",
            //    Department = new Department() { ID = Guid.NewGuid(), EnumCode = "Market", EnumValue = "市场部" },
            //    Age = 20,
            //    Address = "长宁",
            //    Actions = actions,
            //    Sex = 1
            //};

            DishStyle ds = new DishStyle() { 
                ID = Guid.NewGuid(),
                EnumValue = "川菜",
                EnumCode = CMS.Common.Utility.Core.Generater.MneCodeGenerater.GenerateShortID("川菜"),
                Remark = "其辣无比"
            };

            //CMS.Interface.Model.IModel model = employee as CMS.Interface.Model.IModel;
            controller.New<DishStyle>(ds);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ICollection<CMS.Common.Model.Emun.Action> actions = new List<CMS.Common.Model.Emun.Action>();

            actions.Add(Common.Model.Emun.Action.AddDish);

            Employee employee = new Employee()
            {
                ID = Guid.Parse("8f6946ca-d5e9-43c6-920d-ce6ceaad9d20"),
                FullName = "stephen",
                Department = new Department() { ID = Guid.NewGuid(), EnumCode = "Market", EnumValue = "市场部" },
                Age = 20,
                Address = "长宁",
                Actions = actions,
                Sex = 1
            };

            DishStyle ds = new DishStyle()
            {
                ID = new Guid("65fb5ae2-7a83-42e7-92ea-da8e4dfbf52f"),
                EnumCode = "CC",
                EnumValue = "川1菜",
                Remark = "其辣无比"
            };

            controller.Update<DishStyle>(ds);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ICollection<DishStyle> stylelist = controller.Sync<DishStyle>() as ICollection<DishStyle>;
            //if (controller.CMSContext.DatabaseCacheManager[typeof(DishStyle)] != null)
            //{
            //    Common.Database.Base.BaseCache<CMS.Interface.Model.IModel> collection = controller.CMSContext.DatabaseCacheManager[typeof(DishStyle)] ;
            //    foreach (CMS.Interface.Model.IModel model in collection)
            //    {
            //        DishStyle style = model as DishStyle;
            //        Employee ee = style.CreatedBy as Employee;
            //        richTextBox1.AppendText(string.Format("{0} {1} {3} {4}", style.ID, style.EnumCode, style.EnumValue, ee.FullName));
            //    }
            //}
            foreach (DishStyle style in stylelist)
            {
                richTextBox1.AppendText(string.Format("{0} {1} {2}", style.ID, style.EnumCode, style.EnumValue));
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee()
            {
                ID = Guid.Parse("8f6946ca-d5e9-43c6-920d-ce6ceaad9d20"),
                FullName = "stephen",
                Department = new Department() { ID = Guid.NewGuid(), EnumCode = "Market", EnumValue = "市场部" },
                Age = 20,
                Address = "长宁",
                Sex = 1
            };
        }

        private void postion_Click(object sender, EventArgs e)
        {
            //Postion tPosition = new Postion()
            //{
            //    ID = Guid.NewGuid(),
            //    EnumCode = "SolutionManager",
            //    EnumValue = "项目经理",
            //    Remark = "拥有较高的权限，可任意删除添加系统数据！"
            //};
            Postion tPosition = new Postion()
            {
                ID = Guid.Parse("5d89a4e9-cd75-4377-a8c1-6471f8f2e883"),
                EnumCode = "SolutionManager",
                EnumValue = "项目经理",
                Remark = "拥有较高的权限，可任意删除添加系统数据！"
            };
            try
            {
                //controller.New<Postion>(tPosition);
                controller.Update<Postion>(tPosition);
                richTextBox1.AppendText("新建职位成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnOperator_Click(object sender, EventArgs e)
        {
            Operator tOperator1 = new Operator()
            {
                ID = Guid.NewGuid(),
                EnumCode = "Select",
                EnumValue = "查看",
                Remark = "可执行查看数据的操作"
            };

            Operator tOperator2 = new Operator()
            {
                ID = Guid.NewGuid(),
                EnumCode = "Update",
                EnumValue = "更新数据",
                Remark = "可执行更新数据的操作"
            };

            Operator tOperator3 = new Operator()
            {
                ID = Guid.NewGuid(),
                EnumCode = "Insert",
                EnumValue = "新建数据",
                Remark = "可执行新建数据的操作"
            };

            Operator tOperator4 = new Operator()
            {
                ID = Guid.NewGuid(),
                EnumCode = "Delete",
                EnumValue = "删除数据",
                Remark = "可执行删除数据的操作"
            };
            try
            {
                controller.New<Operator>(tOperator1);
                controller.New<Operator>(tOperator2);
                controller.New<Operator>(tOperator3);
                controller.New<Operator>(tOperator4);
                richTextBox1.AppendText("新建操作成功！");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            CMS.Common.Model.Right pRight = new Right()
            {
                ID = Guid.NewGuid(),
                EnumCode = "AddDish",
                EnumValue = "添加菜品",
                Remark = "能够添加菜品的权限"
            };
            try
            {
                controller.New<CMS.Common.Model.Right>(pRight);
                richTextBox1.AppendText("新建权限成功！");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnEmployee_Click(object sender, EventArgs e)
        {
            ICollection<CMS.Interface.Model.IModel> posionCollection = controller.Sync<Postion>().GetModelResults();

            DepartmentController dController = new DepartmentController();

            //ICollection<CMS.Interface.Model.IModel> tOperator = controller.Sync<Operator>().GetModelResults();
            //ICollection<CMS.Interface.Model.IModel> tRight = controller.Sync<Right>().GetModelResults();

            ICollection<CMS.Interface.Model.IModel> tStatusCollection = controller.Sync<UserStatus>().GetModelResults();

            ICollection<CMS.Interface.Model.IModel> departmentCollection = dController.GetAllDepartment().GetModelResults();

            UserStatus status = null;

            foreach (UserStatus s in tStatusCollection)
            {
                status = s;
            }


            Department dd = departmentCollection.ElementAt(0) as Department;
            Postion pp = posionCollection.ElementAt(0) as Postion;
            //foreach (Department d in departmentCollection)
            //{
            //    department = d;
            //}

            //foreach (Postion p in posion)
            //{
            //    po = p;
            //}

            Employee employee = new Employee()
            {
                ID = Guid.NewGuid(),
                FullName = "管理员",
                Login = "admin",
                Age = 0,
                Password = CMS.Common.Utility.Core.Common.Helper.GetMd5Hash("admin"),
                Sex = 0,
                Status = status.ID,
                Telephone = "",
                Address = "",
                Department = dd,
                Position = pp
            };

            EmployeeController eConroller = new EmployeeController();

            try
            {
                eConroller.CreateEmployee(employee);
                //eConroller.CMSContext.Save<Employee>(employee);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            UserStatus status = new UserStatus()
            {
              ID = Guid.NewGuid(),
              EnumCode = "Active",
              EnumValue = "激活",
              Remark = "用户当前为激活状态"
            };
            try
            {
                controller.New<CMS.Common.Model.UserStatus>(status);
                richTextBox1.AppendText("新建状态成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDepartment_Click(object sender, EventArgs e)
        {
            Department department = new Department() { ID = Guid.NewGuid(), EnumCode = "IT", EnumValue = "IT部",Remark="负责IT相关工作" };

            DepartmentController dController = new DepartmentController();
            try
            {
                dController.New(department);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            ICollection<CMS.Interface.Model.IModel> posion = controller.Sync<Postion>().GetModelResults();
            ICollection<CMS.Interface.Model.IModel> tOperator = controller.Sync<Operator>().GetModelResults();
            ICollection<CMS.Interface.Model.IModel> tRight = controller.Sync<Right>().GetModelResults();

            ICollection<CMS.Interface.Model.IModel> tStatusCollection = controller.Sync<UserStatus>().GetModelResults();
            DepartmentController eController = new DepartmentController();
            ICollection<CMS.Interface.Model.IModel> departmentCollection = eController.GetAllDepartment().GetModelResults();

            UserStatus status = null;

            Department department = null;

            Postion po = null;

            foreach (UserStatus s in tStatusCollection)
            {
                status = s;
            }

            foreach (Department d in departmentCollection)
            {
                department = d;
            }

            foreach (Postion p in posion)
            {
                po = p;
            }

            Employee employee = new Employee()
            {
                ID = Guid.Parse("b90fd734-8891-4413-8d9e-9a7d217800b0"),
                FullName = "汪逸文",
                Login = "v-stwa",
                Age = 31,
                Password = "123456",
                Sex = 0,
                Status = status.ID,
                Telephone = "13764156070",
                Address = "沪青平公路249弄",
                Department = department,
                Position = po
            };
            EmployeeController eConroller = new EmployeeController();
            try
            {
                eConroller.DeleteEmployee(employee);
            }
            catch(Exception ex)
            {
            }
        }

        private void btnSyncEmployee_Click(object sender, EventArgs e)
        {
            EmployeeController eController = new EmployeeController();

            CMS.Common.ViewResult.Base.ActionResultCollectionBase<XMLResult> results = eController.GetAllEmployee();

            foreach (XMLResult result in results)
            {
                Employee ee = result.Model as Employee;
                richTextBox1.Text = ee.Department.EnumValue;
            }
        }

        private void btnCreateShopHour_Click(object sender, EventArgs e)
        {
            ShopHours hour = new ShopHours() { ID = Guid.NewGuid(),EnumCode="Breakfast",EnumValue="早市",Remark="早上6点到10点供应" };
            try
            {
                CMS.Common.ViewResult.Base.ActionResultBase result = controller.New<ShopHours>(hour);

                hour = result.Model as ShopHours;

                richTextBox1.Text = hour.EnumValue;
            }
            catch (Exception ex)
            {

            }

        }

        private void btnCreateDish_Click(object sender, EventArgs e)
        {
            ICollection<CMS.Interface.Model.IModel> tShopHourCollection = controller.Sync<ShopHours>().GetModelResults();

            ShopHours shophour = tShopHourCollection.ElementAt(0) as ShopHours;

            ICollection<CMS.Interface.Model.IModel> tDishStyleCollection = controller.Sync<DishStyle>().GetModelResults();

            DishStyle ds = tDishStyleCollection.ElementAt(0) as DishStyle;

            ICollection<CMS.Interface.Model.IModel> tDishTypeCollection = controller.Sync<DishType>().GetModelResults();

            DishType dt = tDishTypeCollection.ElementAt(0) as DishType;

            ICollection<CMS.Interface.Model.IModel> tUnitCollection = controller.Sync<UnitType>().GetModelResults();

            UnitType ut = tUnitCollection.ElementAt(0) as UnitType;

            ICollection<CMS.Interface.Model.IModel> tDishStatusCollection = controller.Sync<DishStatus>().GetModelResults();

            DishStatus status = tDishStatusCollection.ElementAt(0) as DishStatus;

            EmployeeController eController = new EmployeeController();

            CMS.Common.ViewResult.Base.ActionResultCollectionBase<XMLResult> results = eController.GetAllEmployee();

            Employee ee = results.ElementAt(0).Model as Employee;
            for (int i = 0; i < 16; i++)
            {
                Dish dish = new Dish()
                {
                    ID = Guid.NewGuid(),
                    Name = "外婆红烧肉" + i.ToString(),
                    Code = CMS.Common.Utility.Core.Generater.MneCodeGenerater.GenerateShortID("外婆红烧肉"),
                    Discount = 100,
                    ImageUrl = @"../image/wphsrjpg",
                    Introduction = "美味多汁的红烧肉",
                    ShopHours = shophour,
                    ShortID = CMS.Common.Utility.Core.Generater.MneCodeGenerater.GenerateShortID("外婆红烧肉"),
                    Style = ds,
                    Title = "外婆红烧肉" + i.ToString(),
                    Type = dt,
                    Status = status,
                    CreatedBy = ee,
                    ChangedBy = ee,
                    CreatedDate = DateTime.Now,
                    ChangedDate = DateTime.Now
                };
                DishController dishController = new DishController();
                CMS.Common.ViewResult.Base.ActionResultBase result = dishController.CreateDish(dish);
                richTextBox1.Text = result.Result;
            }
        }

        private void btnCreateDishType_Click(object sender, EventArgs e)
        {
            DishType ds = new DishType()
            {
                ID = Guid.NewGuid(),
                EnumValue = "热菜",
                EnumCode = CMS.Common.Utility.Core.Generater.MneCodeGenerater.GenerateShortID("热菜"),
                Remark = "一些大菜及现炒的菜品"
            };

            //CMS.Interface.Model.IModel model = employee as CMS.Interface.Model.IModel;
            controller.New<DishType>(ds);
        }

        private void btnCreateUnit_Click(object sender, EventArgs e)
        {
            UnitType unit = new UnitType()
            {
                ID = Guid.NewGuid(),
                EnumCode = "piece",
                EnumValue = "片",
                Remark = ""
            };

            //CMS.Interface.Model.IModel model = employee as CMS.Interface.Model.IModel;
            controller.New<UnitType>(unit);
        }

        private void btnCreateDishStatus_Click(object sender, EventArgs e)
        {
            DishStatus ds = new DishStatus()
            {
                ID = Guid.NewGuid(),
                EnumCode = "HotSale",
                EnumValue = "热卖",
                Remark = "该菜品正处于热卖中"
            };
            controller.New<DishStatus>(ds);
        }

        private void btnSyncDish_Click(object sender, EventArgs e)
        {
            EmployeeController eController = new EmployeeController();

            CMS.Common.ViewResult.Base.ActionResultCollectionBase<XMLResult> result= eController.GetAllEmployee();

            DishController dc = new DishController();
            CMS.Common.ViewResult.Base.ActionResultCollectionBase<XMLResult> results =  dc.GetAllDishes();
        }

        private void btnCreateEntrance_Click(object sender, EventArgs e)
        {
            EmployeeController eController = new EmployeeController();

            CMS.Common.ViewResult.Base.ActionResultCollectionBase<XMLResult> results = eController.GetAllEmployee();

            ICollection<CMS.Interface.Model.IModel> entranceStatusResults = controller.Sync<EntranceStatus>().GetModelResults();

            EntranceStatus eStatus = entranceStatusResults.ElementAt(0) as EntranceStatus;

            Employee ee = results.ElementAt(0).Model as Employee;

            EntranceController ec = new EntranceController();

            Entrance et = new Entrance()
            {
                ID = Guid.NewGuid (),
                EnterName = "挡口一",
                //MachineCollection = new string[]{"dev-build"},
                CreatedBy = ee,
                ChangedBy = ee,
                CreatedDate = DateTime.Now,
                ChangedDate = DateTime.Now
            };
            try
            {
                CMS.Common.ViewResult.Base.ActionResultBase result = ec.CreateEntrance(et);
                richTextBox1.Text = result.Result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCreateEntranceOrder_Click(object sender, EventArgs e)
        {
            EmployeeController eController = new EmployeeController();

            CMS.Common.ViewResult.Base.ActionResultCollectionBase<XMLResult> employeeResults = eController.GetAllEmployee();

            Employee ee = employeeResults.ElementAt(0).Model as Employee;

            EntranceController ec = new EntranceController();

            CMS.Common.ViewResult.Base.ActionResultCollectionBase<XMLResult> results = ec.GetAllEntrance();

            Entrance entrance = results.ElementAt(0).Model as Entrance;

            ICollection<CMS.Interface.Model.IModel> entranceStatusResults = controller.Sync<EntranceStatus>().GetModelResults();

            EntranceStatus eStatus = entranceStatusResults.ElementAt(0) as EntranceStatus;

            EntranceOrder order = new EntranceOrder()
            {
                ID = Guid.NewGuid(),
                Amount  = 120,
                CardID = Guid.Empty,
                Operator = ee,
                CreatedBy = ee,
                ChangedBy = ee,
                IsUseCard = false,
                Machine = Guid.NewGuid(),
                PayAmount = 100,
                PrintFlag = false,
                Status = eStatus,
                SalesID = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                ChangedDate = DateTime.Now
            };
            try
            {
                CMS.Common.ViewResult.Base.ActionResultBase result = ec.CreateEntranceOrder(entrance, order);
                richTextBox1.Text = result.Result;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCreateEntranceStatus_Click(object sender, EventArgs e)
        {
            EntranceStatus status = new EntranceStatus()
            {
                ID = Guid.NewGuid(),
                EnumCode = "Working",
                EnumValue = "工作中",
                Remark = "该挡口正处于工作中"
            };
            try
            {
                CMS.Common.ViewResult.Base.ActionResultBase result = controller.New<EntranceStatus>(status);

                richTextBox1.Text = result.Result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddDishesForOrder_Click(object sender, EventArgs e)
        {
            EntranceController ec = new EntranceController();

            CMS.Common.ViewResult.Base.ActionResultCollectionBase<XMLResult> results = ec.GetAllEntrance();

            Entrance entrance = results.ElementAt(0).Model as Entrance;

             CMS.Common.ViewResult.Base.ActionResultCollectionBase<XMLResult> orderResults = ec.GetOrderByEntrance(entrance);

             EntranceOrder order = orderResults.ElementAt(0).Model as EntranceOrder;

             DishController dc = new DishController();
             CMS.Common.ViewResult.Base.ActionResultCollectionBase<XMLResult> dishResults = dc.GetAllDishes();
             ICollection<Dish> dishCollection = new List<Dish>();
             foreach (XMLResult xr in dishResults)
             {
                 dishCollection.Add(xr.Model as Dish);
             }
             try
             {
                 CMS.Common.ViewResult.Base.ActionResultBase r = ec.AddDishesForOrder(order, null);
                 richTextBox1.Text = r.Result;
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            CMS.Module.Printer.Core.Printer printer = new Module.Printer.Core.Printer("LPT1");

            printer.WriteSettingsToConfig("dd");
            //printer.PrintDataSet();
            printer.Preview();
        }

        private void btnCreateCardType_Click(object sender, EventArgs e)
        {
            

            CardController cc = new CardController();

            CardTypes types = new CardTypes()
            {
                ID = Guid.NewGuid(),
                Cost = 20,
                Discount = 90,
                TypeCName = "会员卡",
                TypeEName = "vip",
                ValidDate = 365
            };
            cc.CreateCardType(types);
            types = new CardTypes()
            {
                ID = Guid.NewGuid(),
                Cost = 20,
                Discount = 100,
                TypeCName = "临时卡",
                TypeEName = "Temporary",
                ValidDate = 1
            };
            cc.CreateCardType(types);
        }

        private void btnActiveCard_Click(object sender, EventArgs e)
        {
            EmployeeController eController = new EmployeeController();

            CMS.Common.ViewResult.Base.ActionResultCollectionBase<XMLResult> employeeResults = eController.GetAllEmployee();

            Employee ee = employeeResults.ElementAt(0).Model as Employee;

            CardController cc = new CardController();

            CMS.Common.ViewResult.Base.ActionResultCollectionBase<XMLResult> results = cc.GetAllCardTypes();

            CardTypes vipType = null;

            foreach (XMLResult result in results)
            {
                CardTypes tyep = result.Model as CardTypes;

                if (tyep.TypeEName.ToLower() == "vip")
                {
                    vipType = tyep;
                    break;
                }
            }

            XMLCollectionResults xmlResutls = controller.Sync<CardStatus>();


            CardStatus cs = xmlResutls.ElementAt(0).Model as CardStatus;

            VIPCard card = new VIPCard()
            {
                Balance = 200,
                CardType = vipType,
                Cost = 20,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(360),
                ID = Guid.NewGuid(),
                Points = 0,
                SeriesNumber = "826190",
                Type = Common.Model.Emun.Card.CardType.VIPCard,
                ValidDate = 360,
                Status = cs,
                CreatedBy = ee
            };
            cc.CreateCard(card);
        }

        private void btnCreateCardStatus_Click(object sender, EventArgs e)
        {
            CardStatus cs = new CardStatus()
            {
                ID = Guid.NewGuid(),
                EnumCode = "Active",
                EnumValue = "激活中",
                Remark = "该卡片正处于激活状态"
            };
            controller.New<CardStatus>(cs);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            CardController cc = new CardController();

            CMS.Common.ViewResult.Base.ActionResultBase arb = cc.ActiveCard(null);

            MessageBox.Show(arb.Result);
        }

        private void btnUpdateCard_Click(object sender, EventArgs e)
        {
            CardController cc = new CardController();

            CMS.Common.ViewResult.Base.ActionResultBase arb = cc.ActiveCard(null);

            VIPCard card = arb.Model as VIPCard;

            card.Balance += 100;
            
            CMS.Common.ViewResult.Base.ActionResultBase ccarb = cc.Repiad(card);

            MessageBox.Show(ccarb.Result);
        }
    }
}
