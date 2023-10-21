using SeeSharpCore.Interfaces;
using System.Reflection;
using System.Runtime.Loader;

namespace Program
{
    public class Program
    {
        public static Dictionary<string, IPlugIn> Plugins = new Dictionary<string, IPlugIn>();
        private static string PlugInPath = "C:\\Users\\user\\source\\repos\\SeeSharpCore\\PlugIns";

        static void Main()
        {
            Console.WriteLine("Started Application \n");

            LoadPlugIn();
            foreach (var key in Plugins.Keys)
            {
                Plugins[key].DoProcess();
            }

            Console.WriteLine("\nFinished Application");
        }

        static void LoadPlugIn()
        {
            foreach (var dll in Directory.GetFiles(PlugInPath, "*.dll"))
            {
                try
                {
                    AssemblyLoadContext assemblyLoadContext = new AssemblyLoadContext(Path.GetFileNameWithoutExtension(dll));
                    Assembly assembly = assemblyLoadContext.LoadFromAssemblyPath(dll);

                    var pluginTypes = assembly.GetTypes().Where(type => typeof(IPlugIn).IsAssignableFrom(type));
                    foreach (var pluginType in pluginTypes)
                    {
                        IPlugIn plugin = Activator.CreateInstance(pluginType) as IPlugIn;
                        Plugins.Add(Path.GetFileNameWithoutExtension(dll), plugin);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading plugin from {dll}: {ex.Message}");
                }
            }
        }
    }
}
