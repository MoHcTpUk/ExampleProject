using System;
using System.IO;
using System.Linq;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core.BLL.DI
{
    public static class Configurator
    {
        public static ServiceProvider ServiceProvider { get; }
        private static ServiceCollection ServiceCollection { get; }

        static Configurator()
        {
            ServiceCollection = new ServiceCollection();

            ConfigureDepencies(ServiceCollection);

            ServiceProvider = ServiceCollection.BuildServiceProvider();

            //InitDb(ServiceProvider.GetService<ApplicationDbContext>());
        }

        private static void ConfigureDepencies(IServiceCollection serviceCollection)
        {
            //var mapperConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });
            //var mapper = mapperConfig.CreateMapper();
            //var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(_ => _.FullName.Contains("ExampleProject")).ToList();

            var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(_ => !_.IsDynamic).ToList();

            serviceCollection
                .AddRepositories(assemblies)
                .AddServices(assemblies)
                //.AddMediatorHandlers(assemblies)
                .AddDbContextFactories(assemblies, opt =>
                {
                    opt.UseNpgsql(GetDbConnectionString());
                })
                //.AddDbContextFactory<ApplicationDbContext, ExsampleContextFactory>(opt =>
                //{
                //    opt.UseNpgsql(GetDbConnectionString());
                //    //        //options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test");
                //    //        options.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=test");
                //    //        //options.UseInMemoryDatabase(@"ExsampleDataBase");
                //})
                .AddMediatR(assemblies.ToArray())
                ;
            //.AddSingleton(mapper);

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