using Core.DAL.EF;
using Microsoft.EntityFrameworkCore;
using ApplicationDbContext = ExampleProject.DAL.EF.ApplicationDbContext;

namespace ExampleProject.DAL.Repository
{
    public class ExampleRepository: ExampleRepositoryAbstract
    {
        public ExampleRepository(IDbContextFactory<ApplicationDbContext> context) : base(context)
        {
        }
    }
}