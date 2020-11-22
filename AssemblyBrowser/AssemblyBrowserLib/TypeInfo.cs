using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AssemblyBrowserLib
{
    class TypeInfo
    {
        public string Name { get; }
        private ObservableCollection<TypeMemberInfo> _members = new ObservableCollection<TypeMemberInfo>();
        public ReadOnlyObservableCollection<TypeMemberInfo> Members;

        public TypeInfo(Type type)
        {
            Members = new ReadOnlyObservableCollection<TypeMemberInfo>(_members);
        }
    }
}
