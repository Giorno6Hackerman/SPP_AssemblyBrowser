﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Reflection;

namespace AssemblyBrowserLib
{
    class TypeInfo
    {
        public string Name { get; }
        private Type _type;
        private List<TypeMemberInfo> _members;
        public IReadOnlyList<TypeMemberInfo> Info { get { return GetInfo(); } }

        public TypeInfo(Type type)
        {
            _type = type;
            _members = new List<TypeMemberInfo>();
        }

        private IReadOnlyList<TypeMemberInfo> GetInfo()
        {
            
            var result = from mem in _type.GetMembers()
                         where mem.MemberType == MemberTypes.Method || 
                               mem.MemberType == MemberTypes.Field ||
                               mem.MemberType == MemberTypes.Property
                         select new TypeMemberInfo(mem);
            return new List<TypeMemberInfo>(result);
        }
    }
}
