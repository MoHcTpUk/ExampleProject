using Core.DAL.EF;
using Core.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.DAL.Repository
{
    public abstract class ExampleRepositoryAbstract : BaseRepository<ExampleEntity>
    {
        protected ExampleRepositoryAbstract(IDbContextFactory<ApplicationDbContext> context) : base(context)
        {
        }
    }
}