using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ExampleProject.App
{
    public static class MediatorConfig
    {
        public static IMediator Mediator { get; } = BLL.DI.Configurator.ServiceProvider.GetService<IMediator>();
    }
}