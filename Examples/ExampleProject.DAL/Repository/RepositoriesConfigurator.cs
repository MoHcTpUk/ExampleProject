using Core.DAL.Repository;
using ExampleProject.DAL.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace ExampleProject.DAL.Repository
{
    public class RepositoriesConfigurator : IRepositoriesConfigurator
    {
        public void ConfigureRepositories(IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddSingleton<IRepository<ExampleEntity>, ExampleRepository>()
                ;
        }
    }
}