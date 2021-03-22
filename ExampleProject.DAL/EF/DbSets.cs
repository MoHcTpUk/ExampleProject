using ExampleProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExampleProject.DAL.EF
{
    public sealed partial class ApplicationDbContext
    {
        public DbSet<ExampleEntity> Bases { get; set; } = null;
    }
}
