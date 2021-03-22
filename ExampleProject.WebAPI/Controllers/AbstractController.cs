using ExampleProject.App.DI;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExampleProject.WebAPI.Controllers
{
    public abstract class AbstractController : ControllerBase
    {
        public IMediator Mediator { get; set; } = Configurator.Mediator;
    }
}
