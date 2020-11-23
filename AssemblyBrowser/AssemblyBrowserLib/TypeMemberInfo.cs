using System.Reflection;

namespace AssemblyBrowserLib
{
    public class TypeMemberInfo 
    {
        private MemberInfo _memberInfo { get; }

        public TypeMemberInfo(MemberInfo memberInfo)
        {
            _memberInfo = memberInfo;
            _info = GetInfo(memberInfo);
        }

        public string Info { get { return _info; } }
        private string _info;

        private string GetMemberInfo(MethodInfo info)
        {
            string result = $"Method {info.Name}(";
            foreach (var param in info.GetParameters())
            {
                result += $"{param.ParameterType} {param.Name}, ";
            }
            if(info.GetParameters().Length > 0)
                result = result.Remove(result.Length - 2);
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

        private string GetMemberInfo(ConstructorInfo info)
        {
            string result = $"Constructor {info.Name}(";
            foreach (var param in info.GetParameters())
            {
                result += $"{param.ParameterType} {param.Name}, ";
            }
            if (info.GetParameters().Length > 0)
                result = result.Remove(result.Length - 2);
            return result + ")";
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
            if (info.MemberType == MemberTypes.Constructor)
            {
                return GetMemberInfo(info as ConstructorInfo);
            }
            return null;
        }
    }
}
