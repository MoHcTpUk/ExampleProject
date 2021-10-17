using System;
using System.IO;
using System.Reflection;
using ExampleProject.Configuration;
using ExampleProject.Identity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ExampleProject.Identity.EF
{
    public class IdentityDbContext : IdentityDbContext<
        ApplicationUser,
        ApplicationRole,
        int,
        ApplicationUserClaim,
        ApplicationUserRole,
        ApplicationUserLogin,
        ApplicationRoleClaim,
        ApplicationUserToken>
    {
        private const string ConnectionStringName = "LocalConnection";

        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(GetDbConnectionString());
            }
        }

        public string GetDbConnectionString()
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