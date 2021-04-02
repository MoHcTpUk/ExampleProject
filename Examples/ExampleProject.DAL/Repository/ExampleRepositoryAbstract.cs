using Core.DAL.EF;
using Core.DAL.Repository;
using ExampleProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using ApplicationDbContext = ExampleProject.DAL.EF.ApplicationDbContext;

namespace ExampleProject.DAL.Repository
{
    public abstract class ExampleRepositoryAbstract : AbstractRepository<ExampleEntity>
    {
        protected ExampleRepositoryAbstract(IDbContextFactory<ApplicationDbContext> context) : base(context)
        {
        }
    }
}