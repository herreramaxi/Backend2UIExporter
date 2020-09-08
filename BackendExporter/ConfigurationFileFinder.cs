using F23.StringSimilarity;
using Newtonsoft.Json;
using System;
using System.IO;

namespace BackendExporter
{
    public static class ConfigurationFileFinder
    {
        public const string FileName = "BackendToUIExported.json";

        public static ConfigurationFile Find(string projectPath)
        {
            if (string.IsNullOrEmpty(projectPath))
            {
                Console.WriteLine("projectPath is null or empty");
            }

            var path = Path.Combine(projectPath, FileName);

            var configFile = default(ConfigurationFile);

            if (!File.Exists(path))
            {
                //create default

                Console.WriteLine($"config file not found on path: {path}");

                configFile = new ConfigurationFile();
                var configText = JsonConvert.SerializeObject(configFile, Formatting.Indented, new JsonSerializerSettings
                {
                    DefaultValueHandling = DefaultValueHandling.Ignore
                });

                Console.WriteLine($"Creating default: {configText}");

                File.WriteAllText(path, configText);
            }
            else
            {
                var configFileText = File.ReadAllText(path);
                configFile = JsonConvert.DeserializeObject<ConfigurationFile>(configFileText);
                configFile.IsDefault = false;

                Console.WriteLine($"Config file: {configFileText}");
            }

            var l = new Levenshtein();
            Console.WriteLine($"Levenshtein Distance: {l.Distance("My string", "My $tring").ToString()}");

            return configFile;
        }
    }
}
