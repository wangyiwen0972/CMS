using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Common.Model.Emun.Table
{
    [Flags]
    public enum TableStatus
    {
        Cleaning,
        Available,
        Broken,
        Other
    }
}
