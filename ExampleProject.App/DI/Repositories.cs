using ExampleProject.DAL.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace ExampleProject.App.DI
{
    public static partial class Configurator
    {
        private static void ConfigureRepositories(IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddSingleton<ExampleRepositoryAbstract, ExampleRepository>()
                ;
        }
    }
}