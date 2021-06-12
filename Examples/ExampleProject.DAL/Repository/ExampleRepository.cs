using Core.DAL.Repository;
using ExampleProject.DAL.EF;
using ExampleProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExampleProject.DAL.Repository
{
    public class ExampleRepository : AbstractRepository<ExampleEntity>
    {
        public ExampleRepository(IDbContextFactory<ExampleDbContext> context) : base(context)
        { }
    }
}