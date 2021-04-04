using Core.DAL.Configuration;
using Core.DAL.EF;
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