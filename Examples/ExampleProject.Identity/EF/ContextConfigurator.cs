using Core.DAL.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExampleProject.Identity.EF
{
    public class ContextConfigurator : IContextFactoryConfigurator
    {
        public void ConfigureContextFactory(IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContextFactory<IdentityDbContext, IdentityContextFactory>();
            serviceCollection.AddDbContext<IdentityDbContext>();
        }
    }
}