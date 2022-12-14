using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPP_AssBrowser.AssemblyComposition
{
    public class NameSpaceInfo
    {
        public string NameSpaceName { get; set; }
        public List<typeInfo> Types { get; set; }

        public NameSpaceInfo(string namespaceName, List<typeInfo> types)
        {
            NameSpaceName = namespaceName;
            Types = types;
        }

        public NameSpaceInfo()
        {
        }
    }
}
