using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Common.Model
{
    /// <summary>
    /// 配方、食材
    /// </summary>
    public class Recipe
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name;

        /// <summary>
        /// 单位
        /// </summary>
        public UnitType Unit;

        /// <summary>
        /// 数量
        /// </summary>
        public double Amount;

        /// <summary>
        /// 食材介绍
        /// </summary>
        public string Introduction;

        /// <summary>
        /// 图片
        /// </summary>
        public string ImageUrl;
    }
}
