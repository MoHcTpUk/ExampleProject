using Core.DAL.EF;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace ExampleProject.DAL.EF
{
    public class ExsampleContextFactory : AbstractContextFactory<ApplicationDbContext>
    {
        public ExsampleContextFactory()
        {
            OptionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            OptionsBuilder.UseNpgsql(GetDbConnectionString());
        }

        public sealed override string GetDbConnectionString()
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