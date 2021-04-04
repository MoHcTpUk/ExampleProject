using Core.BLL.Configuration;
using ExampleProject.DAL;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ExampleProject.App
{
    public static class MediatorConfig
    {
        public static IMediator Mediator { get; }

        static MediatorConfig()
        {
            Initializator.Init();
            Mediator = Configurator.ServiceProvider.GetService<IMediator>();
        }
    }
}