﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace EnumGenerator
{
    //TODO: To be renamed becuase I will generate not only enum scripts but also DTO objects
    public partial class EnumGenerator //: ITextTemplate
    {
        private Type[] _types;
        //private List<Assembly> _assemblies;

        public EnumGenerator(Type[] types)
        {
            _types = types;
            //_assemblies = new List<Assembly>();

            //foreach (var type in types)
            //{
              
            //       var assembly = Assembly.GetAssembly(type);

            //    if (assembly == null) continue;

            //    _assemblies.Add(assembly);
            //}
        }
    }
}