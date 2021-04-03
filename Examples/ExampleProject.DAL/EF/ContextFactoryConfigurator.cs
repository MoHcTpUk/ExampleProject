using Core.DAL.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace ExampleProject.DAL.EF
{
    public class ContextFactoryConfigurator : IContextFactoryConfigurator
    {
        public void ConfigureContextFactory(IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContextFactory<ApplicationDbContext, ExsampleContextFactory>(opt =>
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