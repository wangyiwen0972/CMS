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

namespace CMS.UnitTest.Utility
{
    public partial class XmlResolverTest : Form
    {
        CMS.Interface.Model.IModel imodel;

        public XmlResolverTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ICollection<CMS.Common.Model.Emun.Action> actions = new List<CMS.Common.Model.Emun.Action>();

            actions.Add(Common.Model.Emun.Action.AddDish);

            Employee employee = new Employee()
            {
                ID = new Guid(),
                FullName = "stephen",
                Department = new Department() { ID = Guid.NewGuid(), EnumCode = "Market", EnumValue = "市场部",Remark="负责市场营销及推广工作" },
                Age = 20,
                Address = "长宁",
                Actions = actions,
                Sex = 1
            };

            CookType[] cooktypes = new CookType[] {
                new CookType()
                {
                    ID = Guid.NewGuid(),
                    EnumValue = "红烧",
                    EnumCode = "HC",
                    CreatedDate = DateTime.Now,
                    ChangedDate = DateTime.Now,
                    CreatedBy = employee,
                    ChangedBy = employee
                },
            };

            UnitType unit = new UnitType()
            {
                ID = Guid.NewGuid(),
                EnumCode = "piece",
                EnumValue = "片",
                Remark = ""
            };

            imodel = new Dish()
            {
                ID = Guid.NewGuid(),
                Code = "HSR",
                CookingType = cooktypes,
                Discount = 100,
                ImageUrl = "C:\\PIC",
                Introduction = "红烧肉"
            };
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string content = CMS.Common.Utility.Core.Reflector.ModelReflector.GetFullyInfoByModel(imodel);

            using (CMS.Common.Utility.Core.Resolver.XmlResolver resolver = new Common.Utility.Core.Resolver.XmlResolver())
            {
                Dish dish = resolver.DeSerialize(content,typeof(Dish)) as Dish;
            }
            
        }
    }
}
