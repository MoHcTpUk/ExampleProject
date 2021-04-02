using Core.BLL.DI;
using ExampleProject.BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ExampleProject.BLL.DI
{
    public class ServicesConfigurator : IServicesConfigurator
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddSingleton<ExampleServiceAbstract, ExampleService>()
                ;
        }
    }
}