﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;

namespace SocialNetworkSystem.Web.Infastructure
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration Configuration { get; private set; }

        public static void RegisterMappings()
        {
            Configuration = new MapperConfiguration(cfg => Execute(cfg));
        }

        private static void Execute(IMapperConfigurationExpression config)
        {
            var types = Assembly.GetExecutingAssembly().GetExportedTypes();

            LoadStandardMappings(config, types);

            LoadCustomMappings(config, types);
        }

        private static void LoadStandardMappings(IMapperConfigurationExpression config, IEnumerable<Type> types)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>) &&
                              !t.IsAbstract &&
                              !t.IsInterface
                        select new
                        {
                            Source = i.GetGenericArguments()[0],
                            Destination = t
                        }).ToArray();

            foreach (var map in maps)
            {
                config.CreateMap(map.Source, map.Destination);
                config.CreateMap(map.Destination, map.Source);
            }
        }

        private static void LoadCustomMappings(IMapperConfigurationExpression config, IEnumerable<Type> types)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where typeof(IHaveCustomMappings).IsAssignableFrom(t) &&
                              !t.IsAbstract &&
                              !t.IsInterface
                        select (IHaveCustomMappings)Activator.CreateInstance(t)).ToArray();

            foreach (var map in maps)
            {
                map.CreateMappings(config);
            }
        }
    }
}