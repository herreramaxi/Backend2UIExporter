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
            //TODO: it is pending to handle parameters
            var projectPath = args[0];
            var assemblyFile = args[1];
            Console.WriteLine($"projectPath: {projectPath}");
            Console.WriteLine($"assemblyFile: {assemblyFile}");

            var assemblyPath = Path.Combine(projectPath, assemblyFile);
            Console.WriteLine($"assemblyPath: {assemblyPath}");

            var configFile = ConfigurationFileFinder.Find(projectPath);
            
            if (configFile.IsDefault) return;

            var assembly = Assembly.LoadFile(assemblyPath);
            var enumTypes = assembly.GetTypes()
                                     .Where(t => t.GetCustomAttribute<EnumTBEAttribute>() != null)
                                     .ToArray();
            var script = new EnumGenerator.EnumGenerator(enumTypes).TransformText();
            Console.WriteLine("script:");
            Console.WriteLine(script);
                        
            var ouputPath = Path.Combine(configFile.UIProjectPath, configFile.EnumFileName);
            Console.WriteLine($"ouputPath: {ouputPath}");

            if (!Directory.Exists(configFile.UIProjectPath))
            {
                Directory.CreateDirectory(configFile.UIProjectPath);
            }

            File.WriteAllText(ouputPath, script);
        }
    }
}
