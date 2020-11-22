﻿using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AssemblyBrowserLib
{
    public class NamespaceInfo //: BindableBase
    {
        public string Name { get; }
        private List<Type> _types;
        public ObservableCollection<TypeInfo> Types { get { return _typesInfo; } }
        private ObservableCollection<TypeInfo> _typesInfo;

        public NamespaceInfo(string name, List<Type> types)
        {
            Name = name;
            _types = new List<Type>(types);
            _typesInfo = GetInfo();
        }

        private ObservableCollection<TypeInfo> GetInfo()
        {
            var result = from type in _types
                         select new TypeInfo(type);
            return new ObservableCollection<TypeInfo>(result);
        }
    }
}
