//using System.IO;
//using System.Reflection;
//using System.Runtime.Loader;

//namespace CustomTaskLibrary
//{
//    public static class AssemblyLocation
//    {
//        static AssemblyLocation()
//        {
//            var assembly = typeof(AssemblyLocation).Assembly;

//            var path = assembly.Location
//                .Replace("file:///", "")
//                .Replace("file://", "")
//                .Replace(@"file:\\\", "")
//                .Replace(@"file:\\", "");

//            CurrentDirectory = Path.GetDirectoryName(path);
//        }

//        public static readonly string CurrentDirectory;
//    }

//    public class IsolatedAssemblyLoadContext : AssemblyLoadContext
//    {
//        protected override Assembly Load(AssemblyName assemblyName)
//        {
//            var assemblyFile = Path.Combine(AssemblyLocation.CurrentDirectory, assemblyName.Name + ".dll");
//            if (File.Exists(assemblyFile))
//            {
//                return LoadFromAssemblyPath(assemblyFile);
//            }

//            return null;
//        }
//    }
//}
