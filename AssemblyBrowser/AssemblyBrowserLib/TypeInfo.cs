using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace AssemblyBrowserLib
{
    public class TypeInfo : BindableBase
    {
        public TypeInfo(Type type)
        {
            _type = type;
            Name = _type.Name;
            _members = GetInfo();
        }

        public string Name { get; }
        private Type _type;
        private ObservableCollection<TypeMemberInfo> _members;
        public ObservableCollection<TypeMemberInfo> Members { get { return _members; } }

        private ObservableCollection<TypeMemberInfo> GetInfo()
        {
            var result = from mem in _type.GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance)
                         where (mem.MemberType == MemberTypes.Method && mem.DeclaringType.Equals(_type) && 
                                (((int)(mem as MethodInfo).Attributes & (int)MethodAttributes.SpecialName) == 0)) || 
                               mem.MemberType == MemberTypes.Field ||
                               mem.MemberType == MemberTypes.Property //||
                               //mem.MemberType == MemberTypes.Constructor
                         select new TypeMemberInfo(mem);
            return new ObservableCollection<TypeMemberInfo>(result); 
        }
    }
}
