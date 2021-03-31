using Core.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.DAL.EF
{
    public sealed partial class ApplicationDbContext
    {
        public DbSet<ExampleEntity> Bases { get; set; } = null;
    }
}
