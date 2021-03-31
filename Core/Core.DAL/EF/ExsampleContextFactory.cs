using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Core.DAL.EF
{
    public class ExsampleContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>, IDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseNpgsql(GetDbConnectionString());

            return new ApplicationDbContext(optionsBuilder.Options);
        }

        public ApplicationDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseNpgsql(GetDbConnectionString());

            return new ApplicationDbContext(optionsBuilder.Options);
        }

        string GetDbConnectionString()
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