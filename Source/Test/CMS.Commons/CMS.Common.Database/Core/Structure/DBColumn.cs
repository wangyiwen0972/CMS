using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Common.Database.Core.Structure
{
    internal class DBColumn
    {
    }

    internal class DBColumnCollection:IEnumerable<DBColumn>
    {
        public IEnumerator<DBColumn> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
