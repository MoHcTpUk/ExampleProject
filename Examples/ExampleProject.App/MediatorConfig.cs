using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Core.App
{
    public static class MediatorConfig
    {
        public static IMediator Mediator { get; } = BLL.DI.Configurator.ServiceProvider.GetService<IMediator>();
    }
}