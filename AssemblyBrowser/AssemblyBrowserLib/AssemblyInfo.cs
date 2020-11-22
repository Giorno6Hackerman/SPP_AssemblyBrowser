using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Collections.ObjectModel;
using Prism.Mvvm;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AssemblyBrowserLib
{
    public class AssemblyInfo : /*BindableBase*/INotifyPropertyChanged
    {
        private string _name;
        public string Name 
        {
            get
            {
                return _name;
            }

            set 
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        private string _path;
        private Assembly _asm;
        public ObservableCollection<NamespaceInfo> Namespaces { get { return _namespaces; } }
        private ObservableCollection<NamespaceInfo> _namespaces;

        public AssemblyInfo(string path)
        {
            _path = path;
            Name = AssemblyName.GetAssemblyName(_path).ToString();
            _namespaces = GetInfo();
        }

        private ObservableCollection<NamespaceInfo> GetInfo()
        {
            _asm = Assembly.LoadFrom(_path);
            var namespaces = from type in _asm.GetTypes()
                             group type by type.Namespace;
            var result = from namespc in namespaces
                         select new NamespaceInfo(namespc.Key, new List<Type>(namespc.Where(type => type.Namespace == namespc.Key && type.Namespace != null)));

            return new ObservableCollection<NamespaceInfo>(result);
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
