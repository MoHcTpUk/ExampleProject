using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;
using Core.DAL.EF;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Core.BLL.DI
{
    public static class MediatorExtensions
    {
        public static IServiceCollection AddMediatorHandlers(this IServiceCollection services, List<Assembly> assemblys)
        {
            foreach (var assembly in assemblys)
            {
                try
                {
                    var classTypes = assembly.ExportedTypes.Select(t => t.GetTypeInfo())
                        .Where(t => t.IsClass && !t.IsAbstract);

                    foreach (var type in classTypes)
                    {
                        var interfaces = type.ImplementedInterfaces.Select(i => i.GetTypeInfo());

                        foreach (var handlerType in interfaces.Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>)))
                        {
                            services.AddTransient(handlerType.AsType(), type.AsType());
                        }
                    }
                }
                catch
                {
                    // ignored
                }
            }

            return services;
        }
    }

    public static partial class Configurator
    {
        private static void ConfigureDepencies(IServiceCollection serviceCollection)
        {
            var mapperConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });
            var mapper = mapperConfig.CreateMapper();

            serviceCollection
                .AddMediatR(typeof(Configurator))
                .AddMediatorHandlers(AppDomain.CurrentDomain.GetAssemblies().ToList())
                .AddSingleton(mapper)
                .AddDbContextFactory<ApplicationDbContext, ExsampleContextFactory>(opt =>
                {
                    opt.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=test");
                    //        //options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test");
                    //        options.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=test");
                    //        //options.UseInMemoryDatabase(@"ExsampleDataBase");
                });
        }
    }
}