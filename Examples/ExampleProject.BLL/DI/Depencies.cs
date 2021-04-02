using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using AutoMapper;
using ExampleProject.DAL.EF;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExampleProject.BLL.DI
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
                .AddMediatorHandlers(AppDomain.CurrentDomain.GetAssemblies().Where(_=>_.FullName.Contains("ExampleProject")).ToList())
                .AddSingleton(mapper)
                .AddDbContextFactory<ApplicationDbContext, ExsampleContextFactory>(opt =>
                {
                    opt.UseNpgsql(GetDbConnectionString());
                    //        //options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test");
                    //        options.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=test");
                    //        //options.UseInMemoryDatabase(@"ExsampleDataBase");
                });
        }

        public static string GetDbConnectionString()
        {
            string path = Directory.GetCurrentDirectory() + @"\appsettings.json";

            try
            {
                if (File.Exists(path))
                {
                    var builder = new ConfigurationBuilder();
                    builder.SetBasePath(Directory.GetCurrentDirectory());

                    var config = builder.AddJsonFile("appsettings.json").Build();

                    string readedConnectionString = config.GetConnectionString("LocalConnection");
                    return string.IsNullOrWhiteSpace(readedConnectionString) ? "" : readedConnectionString;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while reading appsettings.json:" + ex.Message);
            }

            return "";
        }
    }
}