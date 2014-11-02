namespace CMS.Common.Controller.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Model = CMS.Common.Model;
    using CMS.Common.ViewResult.Base;
    using CMS.Interface.Model;

    public abstract class UserController:BaseController
    {
        protected readonly string prefix;

        public UserController()
        {
            this.prefix = "T";
        }

        public abstract ActionResultBase  LogIn(Model.Base.UserBase User);

        public abstract ActionResultBase ChangePassWord(string newPassword, string oldPassword);

        public abstract ActionResultBase LogOut(Model.Base.UserBase User);


        protected override string GetConnectionString()
        {
            throw new NotImplementedException();
        }
    }
}
