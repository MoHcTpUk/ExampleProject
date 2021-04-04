using Microsoft.Extensions.DependencyInjection;

namespace Core.DAL.Configuration
{
    public interface IContextFactoryConfigurator
    {
        public void ConfigureContextFactory(IServiceCollection serviceCollection);
    }
}
