using System.Reflection;
using SPP_AssBrowser.AssemblyComposition;

namespace SPP_AssBrowser
{
    public class AssBrowser
    {
        private readonly Assembly? _assembly;

        public AssBrowser(string filename)
        {
            try
            {
                _assembly = Assembly.LoadFrom(filename);
            }
            catch
            {
                _assembly = null;
            }

        }

        public AssemblyInfo? GetAssemblyInfo()
        {
            if (_assembly != null)
            {
                return new AssemblyInfo(_assembly.GetName().Name, GetNamespaceInfo());
            }
            else
            {
                return null;
            }
        }

        private List<NameSpaceInfo> GetNamespaceInfo()
        {
            IEnumerable<string?> namespaces = _assembly.GetTypes().Select(type => type.Namespace).Distinct();
            List<NameSpaceInfo> namespaceInfos = new List<NameSpaceInfo>();

            foreach (string namespaceName in namespaces)
            {
                NameSpaceInfo namespaceInfo = new NameSpaceInfo();
                namespaceInfo.NameSpaceName = namespaceName;
                namespaceInfo.Types = GetTypeInfo(namespaceName);
                namespaceInfos.Add(namespaceInfo);
            }

            return namespaceInfos;
        }

        private List<typeInfo> GetTypeInfo(string namespaceName)
        {
            IEnumerable<Type> types = _assembly.GetTypes().Where(type => type.Namespace == namespaceName);
            List<typeInfo> typeInfos = new List<typeInfo>();

            foreach (Type type in types)
            {
                typeInfo typeInfo = new typeInfo();
                typeInfo.TypeName = type.Name;
                if (type.IsClass)
                    typeInfo.Type = "Class";
                else if (type.IsInterface)
                    typeInfo.Type = "Interface";
                else if (type.IsEnum)
                    typeInfo.Type = "Enam";
                else
                    typeInfo.Type = "Type";
                typeInfo.Fields = GetFieldInfo(type);
                typeInfo.Properties = GetPropertyInfo(type);
                typeInfo.Methods = GetMethodInfo(type);
                typeInfos.Add(typeInfo);
            }

            return typeInfos;
        }

        private List<fieldInfo> GetFieldInfo(Type classType)
        {
            var fields = classType.GetFields();
            List<fieldInfo> fieldInfos = new List<fieldInfo>();

            foreach (var field in fields)
            {
                fieldInfo fieldInfo = new fieldInfo();
                fieldInfo.FieldName = field.Name;
                fieldInfo.FieldType = field.FieldType.Name;
                fieldInfos.Add(fieldInfo);
            }

            return fieldInfos;
        }

        private List<propertyInfo> GetPropertyInfo(Type classType)
        {
            var properties = classType.GetProperties();
            List<propertyInfo> propertyInfos = new List<propertyInfo>();

            foreach (var property in properties)
            {
                propertyInfo propertyInfo = new propertyInfo();
                propertyInfo.PropertyName = property.Name;
                propertyInfo.PropertyType = property.PropertyType.Name;
                propertyInfos.Add(propertyInfo);
            }

            return propertyInfos;
        }

        private List<methodInfo> GetMethodInfo(Type classType)
        {
            var methods = classType.GetMethods();
            List<methodInfo> methodInfos = new List<methodInfo>();

            foreach (var method in methods)
            {
                methodInfo methodInfo = new methodInfo();
                methodInfo.MethodName = method.Name;
                methodInfo.ReturnType = method.ReturnType.Name;
                methodInfo.Parameters = GetParametersInfo(method);
                methodInfos.Add(methodInfo);
            }

            return methodInfos;
        }

        private List<fieldInfo> GetParametersInfo(System.Reflection.MethodInfo method)
        {
            List<fieldInfo> parameterInfos = new List<fieldInfo>();
            var parametrs = method.GetParameters();

            foreach (var param in parametrs)
            {
                fieldInfo parametrInfo = new fieldInfo();
                parametrInfo.FieldName = param.Name;
                parametrInfo.FieldType = param.ParameterType.Name;
                parameterInfos.Add(parametrInfo);
            }

            return parameterInfos;
        }
    }
}