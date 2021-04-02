using ExampleProject.App;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExampleProject.WebAPI.Controllers
{
    public abstract class AbstractController : ControllerBase
    {
        public IMediator Cmd { get; set; }

        protected AbstractController()
        {
            Cmd = MediatorConfig.Mediator;
        }
    }
}