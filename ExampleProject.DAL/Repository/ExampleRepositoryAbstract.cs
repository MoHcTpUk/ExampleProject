using ExampleProject.DAL.EF;
using ExampleProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExampleProject.DAL.Repository
{
    public abstract class ExampleRepositoryAbstract : BaseRepository<ExampleEntity>
    {
        protected ExampleRepositoryAbstract(IDbContextFactory<ApplicationDbContext> context) : base(context)
        {
        }
    }
}