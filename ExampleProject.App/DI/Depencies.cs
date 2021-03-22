using AutoMapper;
using ExampleProject.DAL;
using ExampleProject.DAL.EF;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ExampleProject.App.DI
{
    public static partial class Configurator
    {
        private static void ConfigureDepencies(IServiceCollection serviceCollection)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            var mapper = mapperConfig.CreateMapper();

            serviceCollection
                .AddMediatR(typeof(Configurator))
                .AddSingleton(mapper)
                //.AddDbContext<ApplicationDbContext>(options =>
                //    {
                //        //options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test");
                //        options.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=test");
                //        //options.UseInMemoryDatabase(@"ExsampleDataBase");
                //    }
                //)
                .AddDbContextFactory<ApplicationDbContext, ExsampleContextFactory>(opt =>
                {
                    opt.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=test");
                });
            ;
        }
    }
}