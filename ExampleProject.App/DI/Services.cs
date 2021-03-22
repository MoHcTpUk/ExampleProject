using ExampleProject.BLL.DTO;
using ExampleProject.BLL.Services;
using ExampleProject.DAL.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace ExampleProject.App.DI
{
    public static partial class Configurator
    {
        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddSingleton<BaseService<ExampleEntity, ExampleEntityDto>, ExampleService>()
                ;
        }
    }
}