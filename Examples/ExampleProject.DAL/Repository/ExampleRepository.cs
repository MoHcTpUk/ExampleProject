using Core.DAL.Repository;
using ExampleProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using ApplicationDbContext = ExampleProject.DAL.EF.ApplicationDbContext;

namespace ExampleProject.DAL.Repository
{
    public class ExampleRepository : AbstractRepository<ExampleEntity>
    {
        public ExampleRepository(IDbContextFactory<ApplicationDbContext> context) : base(context)
        {
        }
    }
}