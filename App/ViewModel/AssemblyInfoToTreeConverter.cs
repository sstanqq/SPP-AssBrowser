using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPP_AssBrowser.AssemblyComposition;

namespace WPFApp.ViewModel
{
    public static class AssemblyInfoToTreeConverter
    {
        public static List<Node> Convert(AssemblyInfo assemblyInfo)
        {
            List<Node> tree = new List<Node>();
            foreach (var namespaceInfo in assemblyInfo.NameSpaces)
            {
                Node node = new Node();
                node.Header = "Namespace: " + namespaceInfo.NameSpaceName;
                node.Nodes = GetTypeNodes(namespaceInfo);
                tree.Add(node);
            }

            return tree;
        }

        private static List<Node> GetTypeNodes(NameSpaceInfo namespaceInfo)
        {
            List<Node> nodes = new List<Node>();
            foreach (var _typeInfo in namespaceInfo.Types)
            {
                Node node = new Node();
                node.Header = "Type: " + _typeInfo.Type + " " + _typeInfo.TypeName;
                node.Nodes = GetMethodNodes(_typeInfo);
                nodes.Add(node);
            }

            return nodes;
        }

        private static List<Node> GetMethodNodes(typeInfo classInfo)
        {
            List<Node> nodes = new List<Node>();

            foreach (var field in classInfo.Fields)
            {
                Node node = new Node();
                node.Header = "Field: " + field.FieldType + " " + field.FieldName;
                nodes.Add(node);
            }

            foreach (var property in classInfo.Properties)
            {
                Node node = new Node();
                node.Header = "Property: " + property.PropertyType + " " + property.PropertyName;
                nodes.Add(node);
            }

            foreach (var method in classInfo.Methods)
            {
                Node node = new Node();
                node.Header = "Method: " + method.ReturnType + " " + method.MethodName;
                node.Nodes = GetParamsNodes(method);
                nodes.Add(node);
            }

            return nodes;
        }

        private static List<Node> GetParamsNodes(methodInfo _methodInfo)
        {
            List<Node> nodes = new List<Node>();
            foreach (var param in _methodInfo.Parameters)
            {
                Node node = new Node();
                node.Header = "Parameter: " + param.FieldType + " " + param.FieldName;
                nodes.Add(node);
            }

            return nodes;
        }
    }
}
