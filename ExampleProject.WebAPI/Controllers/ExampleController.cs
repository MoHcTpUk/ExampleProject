using ExampleProject.App.Commands;
using ExampleProject.BLL.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

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

        [HttpGet]
        public async Task<ExampleEntityDto> Get()
        {
            var entity = await Mediator.Send(new ExsampleRequest());

            return entity;
        }
    }
}