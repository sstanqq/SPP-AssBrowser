using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPP_AssBrowser.AssemblyComposition
{
    public class propertyInfo
    {
        public string PropertyName { get; set; }
        public string PropertyType { get; set; }

        public propertyInfo(string propertyName, string propertyType)
        {
            PropertyName = propertyName;
            PropertyType = propertyType;
        }

        public propertyInfo()
        {
        }
    }
}
