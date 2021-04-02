using Microsoft.Extensions.DependencyInjection;

namespace ExampleProject.BLL.DI
{
    public static partial class Configurator
    {

        public static ServiceProvider ServiceProvider { get; }
        private static ServiceCollection ServiceCollection { get; }

        static Configurator()
        {
            ServiceCollection = new ServiceCollection();

            ConfigureRepositories(ServiceCollection);
            ConfigureServices(ServiceCollection);
            ConfigureDepencies(ServiceCollection);

            ServiceProvider = ServiceCollection.BuildServiceProvider();

            //InitDb(ServiceProvider.GetService<ApplicationDbContext>());
        }
    }
}