namespace CMS.Common.Controller.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CMS.Common.ViewResult.Core;
    using CMS.Common.ViewResult.Base;

    public class CustomerController:Base.UserController
    {
        private Model.Customer customer = null;


        //评论服务
        public ActionResultBase CommentService(Model.Employee Employee, int Rank, string Message)
        {
            return null;
        }
        //投诉
        public ActionResultBase ComplainService(string Message)
        {
            return null;
        }
        //查询积分
        public ActionResultBase CheckPoints()
        {
            return null;
        }
        //获取账单对应积分
        public ActionResultBase GetRating(decimal money)
        {
            return null;
        }

        protected override string GetConnectionString()
        {
            return !string.IsNullOrEmpty(this.CMSContext.ConnectionString) ? this.CMSContext.ConnectionString : string.Empty;
        }

        #region
        public override ActionResultBase LogIn(Model.Base.UserBase User)
        {
            throw new NotImplementedException();
        }

        public override ActionResultBase ChangePassWord(string newPassword, string oldPassword)
        {
            throw new NotImplementedException();
        }

        public override ActionResultBase LogOut(Model.Base.UserBase User)
        {
            throw new NotImplementedException();
        }
        #endregion

        protected override string GetProvider()
        {
            return !string.IsNullOrEmpty(this.CMSContext.Provider) ? this.CMSContext.Provider : string.Empty;
        }
    }
}
