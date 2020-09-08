using Newtonsoft.Json;
using System.ComponentModel;

namespace BackendExporter
{
    //TODO: Check the jsonRequired attribute
    public class ConfigurationFile
    {
        [JsonIgnore]
        public bool IsDefault { get; set; } = true;

        //[JsonRequired]
        [DefaultValue("UIProjectPath")]
        public string UIProjectPath { get; set; } = "UIProjectPath";

        [DefaultValue(true)]
        public bool ExportEnums { get; set; } = true;

        [DefaultValue(false)]
        public bool ExportDTOs { get; set; } = false;

        //[JsonRequired]
        [DefaultValue("OutputFileName.ts")]
        public string EnumFileName { get; set; } = "OutputFileName.ts";
    }
}
