using Microsoft.EntityFrameworkCore;

namespace Core.DAL.EF
{
    public abstract class AbstractApplicationDbContext : DbContext
    {
        protected AbstractApplicationDbContext(DbContextOptions<AbstractApplicationDbContext> options) : base(options)
        {
            //Database.EnsureDeleted();   // удаляем бд со старой схемой
            //Database.EnsureCreated();   // создаем бд с новой схемой
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}