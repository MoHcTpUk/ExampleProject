using System;
using System.IO;
using System.Reflection;
using Core.DAL.EF;
using ExampleProject.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ExampleProject.Identity.EF
{
    public class IdentityContextFactory : AbstractContextFactory<IdentityDbContext>
    {
        private const string ConnectionStringName = "LocalConnection";

        public IdentityContextFactory()
        {
            OptionsBuilder = new DbContextOptionsBuilder<IdentityDbContext>();
            OptionsBuilder.UseNpgsql(GetDbConnectionString());
        }

        public sealed override string GetDbConnectionString()
        {
            var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty;
            var fullPath = Path.Combine(directory, Config.ConfigurationFile);

            try
            {
                if (File.Exists(fullPath))
                {
                    var builder = new ConfigurationBuilder();
                    builder.SetBasePath(directory);

                    var config = builder.AddJsonFile(Config.ConfigurationFile).Build();

                    string readedConnectionString = config.GetConnectionString(ConnectionStringName);
                    return string.IsNullOrWhiteSpace(readedConnectionString) ? "" : readedConnectionString;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(@$"Error while reading: {ex.Message}");
            }

            throw new Exception(@$"Error while reading: File {Config.ConfigurationFile} not found");
        }
    }
}