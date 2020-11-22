using System.Reflection;

namespace AssemblyBrowserLib
{
    class TypeMemberInfo
    {
        private MemberInfo _memberInfo { get; }

        public TypeMemberInfo(MemberInfo memberInfo)
        {
            _memberInfo = memberInfo;
        }

        public string Info { get { return GetInfo(_memberInfo); } }

        private string GetMemberInfo(MethodInfo info)
        {
            string result = $"Method {info.Name} (";
            foreach (var param in info.GetParameters())
            {
                result += $"{param.ParameterType} {param.Name}, ";
            }
            result.Remove(result.Length - 2);
            return result + ")";
        }

        private string GetMemberInfo(FieldInfo info)
        {
            return $"Field {info.FieldType} {info.Name}";
        }

        private string GetMemberInfo(PropertyInfo info)
        {
            return $"Property {info.PropertyType} {info.Name}";
        }


        private string GetInfo(MemberInfo info)
        {
            if (info.MemberType == MemberTypes.Method)
            {
                return GetMemberInfo(info as MethodInfo);
            }
            if (info.MemberType == MemberTypes.Property)
            {
                return GetMemberInfo(info as PropertyInfo);
            }
            if (info.MemberType == MemberTypes.Field)
            {
                return GetMemberInfo(info as FieldInfo);
            }
            return null;
        }
    }
}
