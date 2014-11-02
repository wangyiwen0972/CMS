using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Common.Utility.Core.Resolver
{
    public class JSONResolver : Base.BaseResolver
    {
        public override string Serialize(Interface.Model.IModel Model)
        {
            throw new NotImplementedException();
        }

        public override Interface.Model.IModel DeSerialize(string Content, Type ModelType)
        {
            throw new NotImplementedException();
        }

        public override T DeSerialize<T>(string Content, T ModelType)
        {
            throw new NotImplementedException();
        }

        public override T DeSerialize<T>(string Content)
        {
            throw new NotImplementedException();
        }

        public override ICollection<T> DeSerializeAll<T>(string Content)
        {
            throw new NotImplementedException();
        }

        public override string Serialize<T>(T Model)
        {
            throw new NotImplementedException();
        }

        public override string SerializeAll(ICollection<Interface.Model.IModel> ModelCollection)
        {
            throw new NotImplementedException();
        }
    }
}
