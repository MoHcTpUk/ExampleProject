using Microsoft.Extensions.DependencyInjection;

namespace Core.DAL.EF
{
    public interface IContextFactoryConfigurator
    {
        public void ConfigureContextFactory(IServiceCollection serviceCollection);
    }
}
