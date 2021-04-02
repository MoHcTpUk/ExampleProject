using Core.BLL.DI;
using ExampleProject.BLL.DI;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ExampleProject.App
{
    public static class MediatorConfig
    {
        public static IMediator Mediator { get; } = Configurator.ServiceProvider.GetService<IMediator>();
    }
}