using System.Collections.Generic;
using AutoMapper;
using AutoMapper.Mappers;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;
//using StructureMap.Web;


namespace MyCMS.Web.DependencyResolution.Registries
{
    public class AutoMapperRegistry : Registry
    {
        public AutoMapperRegistry()
        {
            Scan(scanner =>
            {
                scanner.TheCallingAssembly();
                scanner.AddAllTypesOf<Profile>();
            });

            For<MapperConfiguration>().Use("Build AutoMapper config", ctx =>
            {
                var profiles = ctx.GetAllInstances<Profile>();
                var config = new MapperConfiguration(cfg =>
                {
                    foreach (var profile in profiles)
                    {
                        cfg.AddProfile(profile);
                    }
                });
                return config;
            });
            For<IMapper>().Use(ctx => ctx.GetInstance<MapperConfiguration>().CreateMapper(ctx.GetInstance));

        }
        //public AutoMapperRegistry()
        //{
        //    For<ConfigurationStore>().Singleton().Use<ConfigurationStore>().Ctor<IEnumerable<IObjectMapper>>().Is(MapperRegistry.AllMappers());
        //    For<IConfigurationProvider>().Use(ctx => ctx.GetInstance<ConfigurationStore>());
        //    For<IConfiguration>().Use(ctx => ctx.GetInstance<ConfigurationStore>());
        //    For<ITypeMapFactory>().Use<TypeMapFactory>();
        //    For<IMappingEngine>().Singleton().Use<MappingEngine>();

        //    Scan(scanner =>
        //    {
        //        //first decide which assemblies you want to scan
        //        scanner.AssembliesFromApplicationBaseDirectory();
        //        scanner.With(new AutoMapperProfileConvention());//scan for automapper profile types
        //    });

        //    Scan(scanner =>
        //    {
        //        //first decide which assemblies you want to scan
        //        scanner.AssembliesFromApplicationBaseDirectory();
        //        scanner.ConnectImplementationsToTypesClosing(typeof(ITypeConverter<,>)).OnAddedPluginTypes(t => t.HybridHttpOrThreadLocalScoped());
        //        scanner.ConnectImplementationsToTypesClosing(typeof(ValueResolver<,>)).OnAddedPluginTypes(t => t.HybridHttpOrThreadLocalScoped());
        //    });
        //}
    }
}