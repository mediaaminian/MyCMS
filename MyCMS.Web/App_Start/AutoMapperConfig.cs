﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using AutoMapper;
using AutoMapperContracts;
using MyCMS.Web.DependencyResolution;
using MyCMS.Abstraction;

namespace MyCMS.Web
{
    public class AutoMapperConfig
    {

        public static void Config()
        {
            var types =
              Assembly
   .GetExecutingAssembly()
   .GetReferencedAssemblies()
   .Select(Assembly.Load)
   .SelectMany(x => x.GetExportedTypes()).ToList();


            LoadStandardMappings(types);

            LoadCustomMappings(types);

        }

        private static void LoadStandardMappings(IEnumerable<Type> types)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>) && !t.IsAbstract && !t.IsInterface
                        select new
                        {
                            Source = i.GetGenericArguments()[0],
                            Destination = t
                        }).ToArray();

            foreach (var map in maps)
            {
                Mapper.CreateMap(map.Source, map.Destination);
                //IoC.Container.GetInstance<IMappingEngine>().CreateMapExpression(map.Source, map.Destination);
            }
        }

        private static void LoadCustomMappings(IEnumerable<Type> types)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where typeof(IHaveCustomMappings).IsAssignableFrom(t) && !t.IsAbstract && !t.IsInterface
                        select (IHaveCustomMappings)Activator.CreateInstance(t)).ToArray();

            foreach (IHaveCustomMappings map in maps)
            {
                map.CreateMappings();

            }
        }
    }


}