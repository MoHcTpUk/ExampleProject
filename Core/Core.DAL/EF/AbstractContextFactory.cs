using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace Core.DAL.EF
{
    public abstract class AbstractContextFactory<TContext> : IDesignTimeDbContextFactory<TContext>, IDbContextFactory<TContext> where TContext : DbContext
    {
        private DbContextOptionsBuilder<TContext> OptionsBuilder { get; }

        protected AbstractContextFactory(DbContextOptionsBuilder<TContext> optionsBuilder)
        {
            OptionsBuilder = optionsBuilder;
        }

        public TContext CreateDbContext(string[] args)
        {
            return (TContext)Activator.CreateInstance(typeof(TContext), OptionsBuilder.Options);
        }

        public TContext CreateDbContext()
        {
            return (TContext)Activator.CreateInstance(typeof(TContext), OptionsBuilder.Options);
        }
    }
}