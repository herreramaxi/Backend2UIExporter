using System;
using EnumGenerator;
namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new EnumGenerator.EnumGenerator(new Type[] { typeof(Enum1) }).TransformText());
        }
    }
}
