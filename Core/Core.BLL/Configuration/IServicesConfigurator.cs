using Microsoft.Extensions.DependencyInjection;

namespace Core.BLL.Configuration
{
    public interface IServicesConfigurator
    {
        public void ConfigureServices(IServiceCollection serviceCollection);
    }
}
