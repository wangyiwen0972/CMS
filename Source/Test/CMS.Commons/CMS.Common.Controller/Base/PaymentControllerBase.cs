using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Common.Controller.Base
{
    public abstract class PaymentControllerBase : BaseController
    {
        protected override string GetConnectionString()
        {
            throw new NotImplementedException();
        }

        protected override string GetProvider()
        {
            throw new NotImplementedException();
        }
    }
}
