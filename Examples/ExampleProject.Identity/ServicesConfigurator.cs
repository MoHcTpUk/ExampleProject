using Core.BLL.Configuration;
using ExampleProject.Identity.Services.Concrete;
using ExampleProject.Identity.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ExampleProject.Identity
{
    public class ServicesConfigurator : IServicesConfigurator
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddSingleton<IAccountService, AccountService>()
                ;
        }
    }
}