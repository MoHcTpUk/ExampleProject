using ExampleProject.App.Commands;
using ExampleProject.Identity.Models;
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

        [HttpPost]
        public async Task<BaseResponse<AuthenticationResponse>> Get(AuthenticateRequest request)
        {
            var entity = await Cmd.Send(new AuthenticateRequest{Email = request.Email, Password = request.Password});

            return entity;
        }
    }
}