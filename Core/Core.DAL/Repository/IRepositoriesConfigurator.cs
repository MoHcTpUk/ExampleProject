using Microsoft.Extensions.DependencyInjection;

namespace Core.DAL.Repository
{
    public interface IRepositoriesConfigurator
    {
        public void ConfigureRepositories(IServiceCollection serviceCollection);
    }
}
