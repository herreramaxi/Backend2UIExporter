using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace BackendExporter
{
    public class Program
    {
        static void Main(string[] args)
        {
            //TODO: it is pending to handle parameters and load assembly
            var projectPath = args[0];
            var assemblyFile = args[1];
            Console.WriteLine($"projectPath: {projectPath}");
            Console.WriteLine($"assemblyFile: {assemblyFile}");

            var assemblyPath = Path.Combine(projectPath, assemblyFile);
            Console.WriteLine($"assemblyPath: {assemblyPath}");

            //var configFile = ConfigurationFileFinder.Find(projectPath);
            var assembly = Assembly.LoadFile(assemblyPath);
            var enumTypes = assembly.GetTypes()
                                     .Where(t => t.GetCustomAttribute<EnumTBEAttribute>() != null)
                                     .ToArray();
            var script = new EnumGenerator.EnumGenerator(enumTypes).TransformText();
            Console.WriteLine("script:");
            Console.WriteLine(script);
        }
    }
}
