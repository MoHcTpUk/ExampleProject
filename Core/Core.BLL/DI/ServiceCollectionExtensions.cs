using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Core.BLL.Services;
using Core.DAL.EF;
using Core.DAL.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Core.BLL.DI
{
    public class TypeImplementation
    {
        public TypeInfo Definition { get; set; }
        public TypeInfo Implementation { get; set; }
    }

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMediatorHandlers(this IServiceCollection services, List<Assembly> assemblys)
        {
            //var interfaceType = typeof(IRequestHandler<,>);
            //var typeList = GetTypeList(assemblys, interfaceType);

            //foreach (var handlerType in typeList)
            //{
            //    services.AddTransient(handlerType.Definition,handlerType.Implementation);
            //}

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services, List<Assembly> assemblys)
        {
            var interfaceType = typeof(IServicesConfigurator);
            var typeList = GetAllInterfaceImplementations(assemblys, interfaceType);

            foreach (var handlerType in typeList)
            {
                var repositoriesConfigurator = (IServicesConfigurator)Activator.CreateInstance(handlerType.Implementation);
                repositoriesConfigurator?.ConfigureServices(services);

                //services.AddSingleton(handlerType.Implementation);
                //services.AddSingleton<ExampleRepositoryAbstract, ExampleRepository>();
            }

            return services;

            //var interfaceType = typeof(IService<,>);
            //var typeList = GetTypeList(assemblys, interfaceType);

            //foreach (var handlerType in typeList)
            //{
            //    //services.AddSingleton(handlerType.Definition, handlerType.Implementation);
            //    services.AddTransient(handlerType.Implementation);
            //    //services.AddSingleton<ExampleServiceAbstract, ExampleService>();
            //}

            //return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services, List<Assembly> assemblys)
        {
            //var interfaceType = typeof(IRepository<>);
            //var typeList = GetTypeList(assemblys, interfaceType);

            //foreach (var handlerType in typeList)
            //{
            //    services.AddSingleton(handlerType.Implementation);
            //    //services.AddSingleton<ExampleRepositoryAbstract, ExampleRepository>();
            //}

            var interfaceType = typeof(IRepositoriesConfigurator);
            var typeList = GetAllInterfaceImplementations(assemblys, interfaceType);

            foreach (var handlerType in typeList)
            {
                var repositoriesConfigurator = (IRepositoriesConfigurator) Activator.CreateInstance(handlerType.Implementation);
                repositoriesConfigurator?.ConfigureRepositories(services);

                //services.AddSingleton(handlerType.Implementation);
                //services.AddSingleton<ExampleRepositoryAbstract, ExampleRepository>();
            }

            return services;
        }

        public static IServiceCollection AddDbContextFactories(this IServiceCollection services, List<Assembly> assemblys)
        {
            var interfaceType = typeof(IContextFactoryConfigurator);
            var typeList = GetAllInterfaceImplementations(assemblys, interfaceType);

            foreach (var handlerType in typeList)
            {
                var repositoriesConfigurator = (IContextFactoryConfigurator)Activator.CreateInstance(handlerType.Implementation);
                repositoriesConfigurator?.ConfigureContextFactory(services);

                //services.AddSingleton(handlerType.Implementation);
                //services.AddSingleton<ExampleRepositoryAbstract, ExampleRepository>();
            }

            //var interfaceType = typeof(IDbContextFactory<>);
            //var typeList = GetTypeList(assemblys, interfaceType);

            //foreach (var handlerType in typeList)
            //{
            //    services.AddDbContextFactory<ApplicationDbContext, ExsampleContextFactory>(optionsAction);
            //}

            return services;
        }

        //private static List<TypeImplementation> GetTypeList(List<Assembly> assemblys, Type interfaceType)
        //{
        //    var typeList = new List<TypeImplementation>();

        //    foreach (var assembly in assemblys)
        //    {
        //        try
        //        {
        //            var classTypes = assembly.ExportedTypes.Select(t => t.GetTypeInfo())
        //                .Where(t => t.IsClass && !t.IsAbstract);

        //            foreach (var type in classTypes)
        //            {
        //                var interfaces = type.ImplementedInterfaces.Select(i => i.GetTypeInfo());

        //                foreach (var handlerType in interfaces.Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == interfaceType))
        //                {
        //                    typeList.Add(new TypeImplementation
        //                    {
        //                        Definition = handlerType,
        //                        Implementation = type
        //                    });
        //                }
        //            }
        //        }
        //        catch
        //        {
        //            // ignored
        //        }
        //    }

        //    return typeList;
        //}

        private static List<TypeImplementation> GetAllInterfaceImplementations(List<Assembly> assemblys, Type interfaceType)
        {
            var typeList = new List<TypeImplementation>();

            foreach (var assembly in assemblys)
            {
                try
                {
                    var classTypes = assembly.ExportedTypes.Select(t => t.GetTypeInfo())
                        .Where(t => t.IsClass && !t.IsAbstract);

                    foreach (var type in classTypes)
                    {
                        var interfaces = type.ImplementedInterfaces.Select(i => i.GetTypeInfo());

                        foreach (var handlerType in interfaces.Where(i => i.GetTypeInfo() == interfaceType))
                        {
                            typeList.Add(new TypeImplementation
                            {
                                Definition = handlerType,
                                Implementation = type
                            });
                        }
                    }
                }
                catch
                {
                    // ignored
                }
            }

            return typeList;
        }
    }
}