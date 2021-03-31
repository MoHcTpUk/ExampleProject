using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Configurator = ExampleProject.BLL.DI.Configurator;

namespace ExampleProject.WebAPI.Controllers
{
    public abstract class AbstractController : ControllerBase
    {
        public IMediator Cmd { get; set; }

        protected AbstractController()
        {
            Cmd = App.MediatorConfig.Configure(Configurator.ServiceProvider.GetService<IMediator>());
        }
    }
}