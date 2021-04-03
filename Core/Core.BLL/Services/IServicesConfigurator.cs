using Microsoft.Extensions.DependencyInjection;

namespace Core.BLL.Services
{
    public interface IServicesConfigurator
    {
        public void ConfigureServices(IServiceCollection serviceCollection);
    }
}
