using ExampleProject.BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ExampleProject.BLL.DI
{
    public static partial class Configurator
    {
        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddSingleton<ExampleServiceAbstract, ExampleService>()
                ;
        }
    }
}