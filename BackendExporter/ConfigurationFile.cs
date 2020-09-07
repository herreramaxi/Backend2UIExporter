using Newtonsoft.Json;
using System.ComponentModel;

namespace BackendExporter
{
    public class ConfigurationFile
    {
        [JsonRequired]
        public string UIProjectPath { get; set; } = "UIProjectPath";

        [DefaultValue(true)]
        public bool ExportEnums { get; set; }

        [DefaultValue(true)]
        public bool ExportDTOs { get; set; } = false;
    }
}
