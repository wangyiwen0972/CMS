namespace CMS.Common.Utility.Core.Reflector
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data;
    using System.Reflection;
    using CMS.Common.Model;
    using CMS.Interface.Model;

    public class DatasetReflector
    {
        /// <summary>
        /// 数据集转换成模型
        /// </summary>
        /// <param name="dataset"></param>
        /// <returns></returns>
        public static string ConvertToContent(DataSet dataset)
        {
            //第一个为主表
            DataTable mainTable = dataset.Tables[0];

            return string.Empty;
        }
    }
}
