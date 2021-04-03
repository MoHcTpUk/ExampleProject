using Core.DAL.EF;
using ExampleProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExampleProject.DAL.EF
{
    public sealed class ApplicationDbContext: AbstractApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<AbstractApplicationDbContext> options) : base(options)
        { }

        public DbSet<ExampleEntity> Bases { get; set; } = null;
    }
}