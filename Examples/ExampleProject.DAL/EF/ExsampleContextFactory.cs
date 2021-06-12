using Core.DAL.EF;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace ExampleProject.DAL.EF
{
    public class ExsampleContextFactory : AbstractContextFactory<ApplicationDbContext>
    {
        private const string AppSettingsFile = "config.json";
        private const string ConnectionStringName = "LocalConnection";

        public ExsampleContextFactory()
        {
            OptionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            OptionsBuilder.UseNpgsql(GetDbConnectionString());
        }

        public sealed override string GetDbConnectionString()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), AppSettingsFile);

            try
            {
                if (File.Exists(path))
                {
                    var builder = new ConfigurationBuilder();
                    builder.SetBasePath(Directory.GetCurrentDirectory());

                    var config = builder.AddJsonFile(AppSettingsFile).Build();

                    string readedConnectionString = config.GetConnectionString(ConnectionStringName);
                    return string.IsNullOrWhiteSpace(readedConnectionString) ? "" : readedConnectionString;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(@$"Error while reading appsettings.json: {ex.Message}");
            }

            throw new Exception(@$"Error while reading appsettings.json: File {path} not found");
        }
    }
}