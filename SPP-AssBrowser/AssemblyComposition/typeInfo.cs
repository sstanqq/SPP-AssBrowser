using System.Collections.Generic;

namespace SPP_AssBrowser.AssemblyComposition
{
    public class typeInfo
    {
        public string TypeName { get; set; }
        public string Type { get; set; }
        public List<fieldInfo> Fields { get; set; }
        public List<propertyInfo> Properties { get; set; }
        public List<methodInfo> Methods { get; set; }

        // Конструктор
        public typeInfo(string typeName, string type, List<fieldInfo> fields, List<propertyInfo> properties, List<methodInfo> methods)
        {
            TypeName = typeName;
            Type = type;
            Fields = fields;
            Properties = properties;
            Methods = methods;
        }

        // Перегрузка
        public typeInfo()
        {
        }
    }
}
