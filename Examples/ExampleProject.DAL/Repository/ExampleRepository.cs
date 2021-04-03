using System;
using Core.DAL.Repository;
using ExampleProject.DAL.EF;
using ExampleProject.DAL.Entities;
using ExampleProject.DAL.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace ExampleProject.DAL.Repository
{
    public class ExampleRepository : AbstractRepository<ExampleEntity>, IExampleRepository<ExampleEntity>, IDisposable
    {
        public ExampleRepository(IDbContextFactory<ApplicationDbContext> context) : base(context)
        {
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}