using Core.BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Core.BLL.DI
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