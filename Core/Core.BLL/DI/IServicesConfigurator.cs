using Microsoft.Extensions.DependencyInjection;

namespace Core.BLL.DI
{
    public interface IServicesConfigurator
    {
        public void ConfigureServices(IServiceCollection serviceCollection);
    }
}
