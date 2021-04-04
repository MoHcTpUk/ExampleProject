using ExampleProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExampleProject.DAL.EF
{
    public sealed class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<ExampleEntity> Bases { get; set; } = null;
    }
}