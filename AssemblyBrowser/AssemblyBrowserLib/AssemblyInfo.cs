using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Collections.ObjectModel;
using Prism.Mvvm;

namespace AssemblyBrowserLib
{
    public class AssemblyInfo //: BindableBase
    {
        public string Name { get; }
        private string _path;
        private Assembly _asm;
        public ObservableCollection<NamespaceInfo> Namespaces { get { return GetInfo(); } }

        public AssemblyInfo(string path)
        {
            _path = path;
            Name = AssemblyName.GetAssemblyName(path).ToString();
        }

        private ObservableCollection<NamespaceInfo> GetInfo()
        {
            _asm = Assembly.LoadFrom(_path);
            var namespaces = from type in _asm.GetTypes()
                             group type by type.Namespace;
            var result = from namespc in namespaces
                         select new NamespaceInfo(namespc.Key, new List<Type>(namespc.Where(type => type.Namespace == namespc.Key)));

            return new ObservableCollection<NamespaceInfo>(result);
        }
    }
}
