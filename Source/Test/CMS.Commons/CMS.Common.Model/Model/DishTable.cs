using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Common.Model.Base;
namespace CMS.Common.Model
{
    public class DishTable:TableBase
    {
        //最后操作者信息
        public Employee Employee;

        //顾客信息
        public Customer Customer;
    }
}
