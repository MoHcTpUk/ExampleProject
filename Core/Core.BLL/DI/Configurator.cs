using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

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
                .AddDbContextFactories(assemblies)
                //.AddMediatorHandlers(assemblies)
                //.AddDbContextFactories(assemblies, opt =>
                //{
                //    opt.UseNpgsql(GetDbConnectionString());
                //})
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
    }
}