// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IoC.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


using System.Web;
using Castle.DynamicProxy;
using MyCMS.Datalayer.Context;
using MyCMS.Servicelayer.EFServices;
using MyCMS.Servicelayer.Interfaces;
using MyCMS.Utilities.Caching;
using MyCMS.Web.Caching;
using MyCMS.Web.Email;
using MyCMS.Web.Infrastructure;
using MyCMS.Web.MyCMSMembership;
using StructureMap;

using AutoMapper;
using MyCMS.Web.DependencyResolution.Registries;
using StructureMap.Graph;
using System;
using System.Threading;
using StructureMap.Configuration.DSL;

namespace MyCMS.Web.DependencyResolution
{
    public static class IoC
    {
        private static readonly Lazy<Container> ContainerBuilder =
        new Lazy<Container>(Initialize, LazyThreadSafetyMode.ExecutionAndPublication);


        public static IContainer Container => ContainerBuilder.Value;

        private static Container Initialize()
        {
            var container = new Container(c =>
            {
                c.AddRegistry<DefaultRegistry>();
                c.AddRegistry<AutoMapperRegistry>();
                c.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    //scan.AssemblyContainingType<SomeType>(); // for other asms, if any.
                    scan.WithDefaultConventions();
                    scan.AddAllTypesOf<Profile>().NameBy(item => item.FullName);
                });

            });

            configureAutoMapper(container);

            return container;
        }

        private static void configureAutoMapper(IContainer container)
        {
            var configuration = container.TryGetInstance<IConfiguration>();
            if (configuration == null) return;
            //saying AutoMapper how to resolve services
            configuration.ConstructServicesUsing(container.GetInstance);
            foreach (var profile in container.GetAllInstances<Profile>())
            {
                configuration.AddProfile(profile);
            }
            container.GetInstance<IMappingEngine>().ConfigurationProvider.AssertConfigurationIsValid();
        }
        
    }

    public static class StructureMapObjectFactory
    {
        private static readonly Lazy<Container> _containerBuilder =
        new Lazy<Container>(() => new Container(), LazyThreadSafetyMode.ExecutionAndPublication);

        public static IContainer Container
        {
            get { return _containerBuilder.Value; }
        }

        public static void Initialize<T>() where T : Registry, new()
        {
            Container.Configure(x =>
            {
                x.AddRegistry<T>();
            });
        }
        public static void Initialize(Registry registry) 
        {
            Container.Configure(x =>
            {
                x.AddRegistry(registry);
            });
        }
    }

    public static class SmObjectFactory
    {
        private static readonly Lazy<Container> _containerBuilder =
            new Lazy<Container>(defaultContainer, LazyThreadSafetyMode.ExecutionAndPublication);

        public static IContainer Container
        {
            get { return _containerBuilder.Value; }
        }

        private static Container defaultContainer()
        {
            var container = new Container(cfg =>
            {
                cfg.AddRegistry<AutoMapperRegistry>();
                cfg.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                    scan.AddAllTypesOf<Profile>().NameBy(item => item.FullName);
                });
            });

            configureAutoMapper(container);

            return container;
        }

        private static void configureAutoMapper(IContainer container)
        {
            var configuration = container.TryGetInstance<IConfiguration>();
            if (configuration == null) return;
            //saying AutoMapper how to resolve services
            configuration.ConstructServicesUsing(container.GetInstance);
            foreach (var profile in container.GetAllInstances<Profile>())
            {
                configuration.AddProfile(profile);
            }
        }
    }
}