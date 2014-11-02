namespace CMS.Common.ViewResult.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CMS.Interface.Model;



    /// <summary>
    /// 抽象结果类
    /// </summary>
    public abstract class ActionResultBase
    {
        /// <summary>
        /// 获取模型对象
        /// </summary>
        public virtual IModel Model
        {
            get;
            internal set;
        }

        public virtual string Result
        {
            get;
            internal set;
        }


        public ActionResultBase(IModel Model)
        {
            this.Model = Model;
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        public virtual void GetResult()
        {
            if (this.Model == null)
            {
                return;
            }
        }
    }
}
