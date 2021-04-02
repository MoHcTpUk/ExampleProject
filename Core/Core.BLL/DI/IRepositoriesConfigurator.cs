using Microsoft.Extensions.DependencyInjection;

namespace Core.BLL.DI
{
    public interface IRepositoriesConfigurator
    {
        public void ConfigureRepositories(IServiceCollection serviceCollection);
    }
}
