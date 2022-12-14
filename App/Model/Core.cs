using SPP_AssBrowser;
using SPP_AssBrowser.AssemblyComposition;


namespace WPFApp.Model
{
    public class Core
    {
        public static AssemblyInfo GetTree(string filename)
        {
            AssBrowser assemblyBrowser = new AssBrowser(filename);
            return assemblyBrowser.GetAssemblyInfo();
        }
    }
}
