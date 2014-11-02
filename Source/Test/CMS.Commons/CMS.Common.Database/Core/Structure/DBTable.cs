namespace CMS.Common.Database.Core.Structure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;



    internal class DBTable
    {
        internal string TableName
        {
            set;
            get;
        }

        internal DBColumnCollection Columns
        {
            get;
            set;
        }

        internal bool HasSubTable { get; set; }
    }

    internal class TableCollection : IEnumerable<DBTable>
    {
        public IEnumerator<DBTable> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
