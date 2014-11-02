using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Common.Model.Emun
{
    /// <summary>
    /// 操作（查看Check，创建Create，删除Delete，编辑Edit，添加Add，导出Export）
    /// 可操作对象（菜品，餐台，区域，订单，菜系，烧法，菜品大类，发票，统计）
    /// </summary>
    [Flags]
    public enum Action
    {
        AddDish,
        CreateDish,
        CheckDishes,
        EditDish,
        DeleteDishes,
        CreateTable,
        CheckTables,
        EditTable,
        DeleteTable,
        CreateArea,
        CheckArea,
        EditArea,
        DeleteArea,
        CreateOrder,
        CheckOrder,
        EditOrder,
        DeleteOrder,
        CreateDishStyle,
        CheckDishStyles,
        EditDishStyle,
        DeleteDishStyles,
        CreateCookType,
        CheckCookTypes,
        EditCookType,
        DeleteCookType,
        CreateInvoce,
        CheckInvoces,
        EditInvoce,
        DeleteInvoces,
        //创建统计报表
        CreateChart,
        //导出统计报表
        ExportChart,
        //查看统计报表
        CheckChart
    }

    /// <summary>
    /// 职位
    /// </summary>
    public enum Position
    {
        //管理员
        Admistrator,
        //经理
        Manager,
        //服务员
        Waiter,
        //收银员
        Cashier
    }

    /// <summary>
    /// 权限等级
    /// </summary>
    public enum Level
    {
        SystemAdmin = 3,
        Manager = 2,
        Staff = 1
    }
    
}
