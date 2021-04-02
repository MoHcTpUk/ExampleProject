using Core.BLL.DI;
using ExampleProject.DAL.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace ExampleProject.BLL.DI
{
    public class RepositoriesConfigurator : IRepositoriesConfigurator
    {
        public void ConfigureRepositories(IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddSingleton<ExampleRepositoryAbstract, ExampleRepository>()
                ;
        }
    }
}