using ExampleProject.App.Commands;
using ExampleProject.Identity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using MediatR;

namespace ExampleProject.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExampleController : AbstractController
    {
        private readonly ILogger<ExampleController> _logger;

        public ExampleController(ILogger<ExampleController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async void Get(RegisterRequest request)
        {
            var entity = await Cmd.Send(request);

            //return entity;
        }
    }
}