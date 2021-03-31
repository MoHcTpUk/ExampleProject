using Core.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace Core.DAL.Repository
{
    public class ExampleRepository: ExampleRepositoryAbstract
    {
        public ExampleRepository(IDbContextFactory<ApplicationDbContext> context) : base(context)
        {
        }
    }
}