namespace SPP_AssBrowser.AssemblyComposition
{
    public class fieldInfo
    {
        public string FieldName { get; set; }
        public string FieldType { get; set; }

        public fieldInfo(string fieldName, string fieldType)
        {
            FieldName = fieldName;
            FieldType = fieldType;
        }

        public fieldInfo()
        {
        }
    }
}
