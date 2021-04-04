using Microsoft.Extensions.DependencyInjection;

namespace Core.DAL.Configuration
{
    public interface IRepositoriesConfigurator
    {
        public void ConfigureRepositories(IServiceCollection serviceCollection);
    }
}
