using Core.DAL.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExampleProject.DAL.EF
{
    public class ContextConfigurator : IContextFactoryConfigurator
    {
        public void ConfigureContextFactory(IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContextFactory<ExampleDbContext, ExsampleContextFactory>();
        }
    }
}