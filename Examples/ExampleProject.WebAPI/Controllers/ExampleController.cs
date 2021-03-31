using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Core.App.Commands;
using Core.BLL.DTO;

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
            var entity = await Cmd.Send(new ExsampleRequest());

            return entity;
        }
    }
}