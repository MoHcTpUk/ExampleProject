using Core.BLL.Configuration;
using Core.BLL.Services;
using ExampleProject.BLL.DTO;
using ExampleProject.DAL.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace ExampleProject.BLL.Services
{
    public class ServicesConfigurator : IServicesConfigurator
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddSingleton<IService<ExampleEntity, ExampleEntityDto>, ExampleService>()
                ;
        }
    }
}