using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace AssemblyBrowserLib
{
    class AssemblyInfo
    {
        public string Name { get; }
        private string _path;
        private Assembly _asm;
        public IReadOnlyList<NamespaceInfo> Namespaces { get { return GetInfo(); } }

        public AssemblyInfo(string path)
        {
            _path = path;
            Name = AssemblyName.GetAssemblyName(path).ToString();
        }

        private IReadOnlyList<NamespaceInfo> GetInfo()
        {
            _asm = Assembly.LoadFrom(_path);
            var namespaces = from type in _asm.GetTypes()
                             group type by type.Namespace;
            var result = from namespc in namespaces
                         select new NamespaceInfo(namespc.Key, new List<Type>(namespc.Where(type => type.Namespace == namespc.Key)));
            return new List<NamespaceInfo>(result);
        }
    }
}
