using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPP_AssBrowser.AssemblyComposition
{
    public class methodInfo
    {
        public string MethodName { get; set; }
        public string ReturnType { get; set; }
        public List<fieldInfo> Parameters { get; set; }

        public methodInfo(string methodName, string returnType, List<fieldInfo> parameters)
        {
            MethodName = methodName;
            ReturnType = returnType;
            Parameters = parameters;
        }

        public methodInfo()
        {
        }
    }
}
