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
using CMS.Common.Utility;
using CMS.Common.Database;
using CMS.Common.Controller.Core;

namespace CMS.UnitTest.Controller
{
    public partial class DishControllerTest : Form
    {
        private DishController controller;

        public DishControllerTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            controller = new DishController();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Unit unit = new Unit()
            //{
            //    Code = "kg",
            //    ID = Guid.NewGuid(),
            //    Name = "千克",
            //    UnitType = UnitType.Weight
            //};
            //Dish dish = new Dish()
            //{
            //    ID = Guid.NewGuid(),
            //    Code = "HSR",
            //    Discount = 100,
            //    ImageUrl = "C:\\PIC",
            //    Introduction = "红烧肉",
            //    Unit = unit.Name,
            //    Price = 20,
            //    Name = "红烧肉",
            //    Title = "外婆红烧肉",
            //};
            //controller.CreateDish(dish.Name, dish.Title, dish.Price, dish.Introduction, "", dish.Unit, null, null);
        }
    }
}
