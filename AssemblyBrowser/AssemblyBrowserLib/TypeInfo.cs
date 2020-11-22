using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace AssemblyBrowserLib
{
    public class TypeInfo : BindableBase
    {
        public string Name { get; }
        private Type _type;
        private ObservableCollection<TypeMemberInfo> _members;
        public ObservableCollection<TypeMemberInfo> Members { get { return _members; } }

        public TypeInfo(Type type)
        {
            _type = type;
            Name = _type.Name;
            _members = GetInfo();
        }

        private ObservableCollection<TypeMemberInfo> GetInfo()
        {
            var result = from mem in _type.GetMembers()
                         where (mem.MemberType == MemberTypes.Method && mem.DeclaringType != typeof(Object)) || 
                               mem.MemberType == MemberTypes.Field ||
                               mem.MemberType == MemberTypes.Property
                         select new TypeMemberInfo(mem);
            return new ObservableCollection<TypeMemberInfo>(result);
        }
    }
}
