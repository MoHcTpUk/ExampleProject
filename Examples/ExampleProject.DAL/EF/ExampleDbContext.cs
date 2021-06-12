using ExampleProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExampleProject.DAL.EF
{
    public sealed class ExampleDbContext : DbContext
    {
        public ExampleDbContext(DbContextOptions<ExampleDbContext> options) : base(options)
        { }

        public DbSet<ExampleEntity> Bases { get; set; } = null;
    }
}