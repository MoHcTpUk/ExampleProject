using Core.DAL.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExampleProject.DAL.EF
{
    public class ContextFactoryConfigurator : IContextFactoryConfigurator
    {
        public void ConfigureContextFactory(IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContextFactory<ApplicationDbContext, ExsampleContextFactory>();
        }
    }
}