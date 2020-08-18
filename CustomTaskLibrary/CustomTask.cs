using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CustomTaskLibrary
{
    public class CustomTask : Task
    {
        [Required]
        public string AssemblyFile { get; set; } = null!;
        [Required]
        public string ProjectPath { get; set; } = null!;

        public override bool Execute()
        {
            Log.LogMessage(MessageImportance.High, "Testing CustomTask:");
            Log.LogMessage(MessageImportance.High, $"AssemblyFile: {AssemblyFile}");
            Log.LogMessage(MessageImportance.High, $"ProjectPath: {ProjectPath}");

            var assemblyPath = Path.Combine(this.ProjectPath, this.AssemblyFile);
            Log.LogMessage(MessageImportance.High, $"assemblyPath: {assemblyPath}");


            //using var stream = File.OpenRead(assemblyPath);
            // Log.LogMessage(MessageImportance.High, $"isNotNullStream?: {stream != null}");
            //var assembly = new IsolatedAssemblyLoadContext().LoadFromStream(stream);

            try
            {
                Log.LogMessage("Entering try-catch");
                var assembly = Assembly.LoadFile(assemblyPath);
                Log.LogMessage(MessageImportance.High, $"isNotNull assembly?: {assembly != null}");
                Log.LogMessage(MessageImportance.High, $"Loaded: {string.Join("#", assembly.GetTypes().Select(x => x.Name))}");
            }
            catch (ReflectionTypeLoadException refEx)
            {
                Log.LogMessage("ReflectionTypeLoadException found: ");
                Log.LogErrorFromException(refEx);

                if (refEx.LoaderExceptions != null)
                {
                    Log.LogMessage("refEx.LoaderExceptions != null");
                    foreach (var innerEx in refEx.LoaderExceptions)
                    {
                        Log.LogErrorFromException(innerEx);
                    }
                }
                else
                {
                    Log.LogMessage("refEx.LoaderExceptions == null");
                }
            }
            catch (Exception ex)
            {
                Log.LogMessage("Exception found: ");
                Log.LogErrorFromException(ex);

                if (ex.InnerException != null)
                {
                    Log.LogErrorFromException(ex.InnerException);
                    if (ex.InnerException.InnerException != null)
                    {
                        Log.LogErrorFromException(ex.InnerException.InnerException);
                    }
                }
            }

            return true;
        }
    }
}
