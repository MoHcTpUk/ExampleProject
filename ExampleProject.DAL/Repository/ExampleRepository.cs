using ExampleProject.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace ExampleProject.DAL.Repository
{
    public class ExampleRepository: ExampleRepositoryAbstract
    {
        public ExampleRepository(IDbContextFactory<ApplicationDbContext> context) : base(context)
        {
        }
    }
}