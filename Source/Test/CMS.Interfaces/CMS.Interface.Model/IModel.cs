using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Interface.Model
{
    public interface IModel
    {
        /// <summary>
        /// 模型间比较
        /// </summary>
        /// <param name="Model">模型</param>
        /// <returns>返回大于等于或小于</returns>
        int Compare(IModel Model);

        /// <summary>
        /// 模型是否相等
        /// </summary>
        /// <param name="Model">模型</param>
        /// <returns>模型相等或不相等</returns>
        bool IsEqual(IModel Model);

        Guid PrimaryGuids();

        string PrimaryName();
    }
}
