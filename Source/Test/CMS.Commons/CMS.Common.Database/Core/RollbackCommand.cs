namespace CMS.Common.Database.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class RollbackCommand
    {
        public RollbackCommand()
        {
        }

        public override void AppendColumns(ICollection<KeyValuePair<string, object>> Columns)
        {
            throw new NotImplementedException();
        }

        public override void AppendColumns(System.Xml.XmlDocument Columns)
        {
            throw new NotImplementedException();
        }

        public override void AppendWhereCommand(KeyValuePair<string, object> Column)
        {
            throw new NotImplementedException();
        }

        public override void AppendOrCommand()
        {
            throw new NotImplementedException();
        }

        public override void AppendAndCommand()
        {
            throw new NotImplementedException();
        }

        public override void AppendOrderByCommand(bool isAsc)
        {
            throw new NotImplementedException();
        }

        public override bool Check()
        {
            throw new NotImplementedException();
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
