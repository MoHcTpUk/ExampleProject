using ExampleProject.Identity.DTO.Account;
using ExampleProject.Identity.Models;
using ExampleProject.Identity.Services.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ExampleProject.App.Commands
{
    public class AuthenticateRequest : IRequest<BaseResponse<AuthenticationResponse>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class AuthenticateRequestHandler : IRequestHandler<AuthenticateRequest, BaseResponse<AuthenticationResponse>>
    {
        private readonly IAccountService _accountService;

        public AuthenticateRequestHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<BaseResponse<AuthenticationResponse>> Handle(AuthenticateRequest request, CancellationToken cancellationToken)
        {
            return await _accountService.AuthenticateAsync(new AuthenticationRequest { Email = request.Email, Password = request.Password });
        }
    }
}
