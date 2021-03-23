using MediatR;
using Microsoft.AspNetCore.Mvc;
using Configurator = ExampleProject.BLL.DI.Configurator;

namespace ExampleProject.WebAPI.Controllers
{
    public abstract class AbstractController : ControllerBase
    {
        public IMediator Mediator { get; set; } = Configurator.Mediator;
    }
}
