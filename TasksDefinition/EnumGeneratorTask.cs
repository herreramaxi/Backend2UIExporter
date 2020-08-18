using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace TasksDefinition
{
    public class EnumGeneratorTask : Task
    {
        public override bool Execute()
        {
            Log.LogMessage(MessageImportance.High, "hello world");

            return false;
        }
    }
}
