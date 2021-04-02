using Core.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace ExampleProject.DAL.EF
{
    public class ExsampleContextFactory : AbstractContextFactory<ApplicationDbContext>
    {
        public ExsampleContextFactory(DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder) : base(optionsBuilder)
        { }
    }
}