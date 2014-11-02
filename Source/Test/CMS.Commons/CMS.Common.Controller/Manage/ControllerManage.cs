namespace CMS.Common.Controller.Manage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Reflection;
    using CMS.Common.Model;

    public class ControllerManage
    {
        private const string controllerAssembly = "CMS.Common.Controller";
        private const string controllerNameSpace = "CMS.Common.Controller.Core";

        private static Dictionary<string, string> _controllerDictionary = null;

        private Dictionary<string, Base.BaseController> _instanceDictionary = null;

        static ControllerManage()
        {
            _controllerDictionary = new Dictionary<string, string>();

            Assembly assembly = Assembly.Load(controllerAssembly);

            if (assembly == null) throw new Exception("Load assembly file failed!");

            Type[] types = assembly.GetTypes();

            _controllerDictionary = new Dictionary<string, string>(types.Length);

            foreach (Type type in types)
            {
                if (type.Namespace == null) continue;

                if (!type.Namespace.Equals(controllerNameSpace)) continue;

                if (!type.IsAbstract && type.IsClass)
                {
                    if (!_controllerDictionary.ContainsKey(type.Name))
                    {
                        _controllerDictionary[type.Name] = type.FullName;
                    }
                }
            }
        }

        public Base.BaseController this[string Name]
        {
            get
            {
                if (this._instanceDictionary == null) { return null; }

                return this._instanceDictionary[Name];

            }
        }

        public Base.BaseController this[int Index]
        {
            get
            {
                if (Index < 0 || Index > this._instanceDictionary.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return this._instanceDictionary.ElementAt(Index).Value;
            }
        }

        public Base.BaseController this[Type Type]
        {
            get
            {
                string shortName = Type.Name;
                return this._instanceDictionary[shortName];
            }
        }

        public ControllerManage()
        {
            if (ControllerManage._controllerDictionary != null && ControllerManage._controllerDictionary.Count > 0)
            {
                Assembly assembly = Assembly.Load(controllerAssembly);

                this._instanceDictionary = new Dictionary<string, Base.BaseController>(ControllerManage._controllerDictionary.Count);

                foreach (KeyValuePair<string, string> controller in ControllerManage._controllerDictionary)
                {
                    Type controllerType = assembly.GetType(controller.Value);

                    object obj = null;

                    try
                    {
                        obj = Activator.CreateInstance(controllerType);
                    }
                    catch(Exception ex)
                    {
                        throw ex;
                    }

                    if (obj == null) continue;

                    if (!this._instanceDictionary.ContainsKey(controller.Key))
                    {
                        this._instanceDictionary.Add(controller.Key, obj as Base.BaseController);
                    }
                }
            }
        }
    }
}
