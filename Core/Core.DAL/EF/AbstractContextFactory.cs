using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace Core.DAL.EF
{
    public abstract class AbstractContextFactory<TContext> : IDesignTimeDbContextFactory<TContext>, IDbContextFactory<TContext> where TContext : DbContext
    {
        protected DbContextOptionsBuilder<TContext> OptionsBuilder { get; set; }

        public TContext CreateDbContext(string[] args)
        {
            return (TContext)Activator.CreateInstance(typeof(TContext), OptionsBuilder.Options);
        }

        public TContext CreateDbContext()
        {
            return (TContext)Activator.CreateInstance(typeof(TContext), OptionsBuilder.Options);
        }

        public abstract string GetDbConnectionString();
    }
}