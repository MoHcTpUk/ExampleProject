using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;
using Core.BLL.Configuration;
using Core.DAL.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.BLL.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAutoMapperConfigs(this IServiceCollection services, List<Assembly> assemblys)
        {
            var baseClassType = typeof(Profile);
            var typeList = GetAllClassInheritance(assemblys, baseClassType);

            var mapperConfig = new MapperConfiguration(mc =>
            {
                foreach (var handlerType in typeList)
                {
                    mc.AddProfile((Profile)Activator.CreateInstance(handlerType.Implementation));
                }
            });


            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

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
            }

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services, List<Assembly> assemblys)
        {
            var interfaceType = typeof(IRepositoriesConfigurator);
            var typeList = GetAllInterfaceImplementations(assemblys, interfaceType);

            foreach (var handlerType in typeList)
            {
                var repositoriesConfigurator = (IRepositoriesConfigurator) Activator.CreateInstance(handlerType.Implementation);
                repositoriesConfigurator?.ConfigureRepositories(services);
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
            }

            return services;
        }

        /// <summary>
        /// Получить все классы реализующие интерфейс
        /// </summary>
        /// <param name="assemblys">Сборки для поиска</param>
        /// <param name="interfaceType">Интерфейс</param>
        /// <returns></returns>
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

        /// <summary>
        /// Получить всех наследников класса
        /// </summary>
        /// <param name="assemblys">Сборки для поиска</param>
        /// <param name="classType">Тип класса</param>
        /// <returns></returns>
        private static List<TypeImplementation> GetAllClassInheritance(List<Assembly> assemblys, Type classType)
        {
            var typeList = new List<TypeImplementation>();

            foreach (var assembly in assemblys)
            {
                try
                {
                    var classTypes = assembly.ExportedTypes.Select(t => t.GetTypeInfo())
                        .Where(t => t.IsClass && !t.IsAbstract && t.BaseType == classType);

                    foreach (var type in classTypes)
                    {
                        typeList.Add(new TypeImplementation
                            {
                                Definition = classType.GetTypeInfo(),
                                Implementation = type
                            });
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