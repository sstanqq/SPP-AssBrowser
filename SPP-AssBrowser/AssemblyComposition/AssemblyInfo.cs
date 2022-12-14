using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPP_AssBrowser.AssemblyComposition
{
    public class AssemblyInfo
    {
        public string AssemblyName { get; set; }
        public List<NameSpaceInfo> NameSpaces { get; set; }

        public AssemblyInfo(string assemblyName, List<NameSpaceInfo> namespaces)
        {
            AssemblyName = assemblyName;
            NameSpaces = namespaces;
        }

        public AssemblyInfo()
        {
        }
    }
}
