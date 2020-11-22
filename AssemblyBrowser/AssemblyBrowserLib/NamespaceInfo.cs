using System;
using System.Collections.Generic;
using System.Linq;

namespace AssemblyBrowserLib
{
    public class NamespaceInfo
    {
        public string Name { get; }
        private List<Type> _types;
        public IReadOnlyList<TypeInfo> Types { get { return GetInfo(); } }

        public NamespaceInfo(string name, List<Type> types)
        {
            Name = name;
            _types = new List<Type>(types);
        }

        private IReadOnlyList<TypeInfo> GetInfo()
        {
            var result = from type in _types
                         select new TypeInfo(type);
            return new List<TypeInfo>(result);
        }
    }
}
