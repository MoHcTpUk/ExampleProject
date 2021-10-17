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

    public class RegisterRequest : IRequest
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class RegisterRequestHandler : IRequestHandler<RegisterRequest>
    {
        private readonly IAccountService _accountService;

        public RegisterRequestHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<Unit> Handle(RegisterRequest request, CancellationToken cancellationToken)
        {
            await _accountService.RegisterAsync(new Identity.DTO.Account.RegisterRequest()
            {
                ConfirmPassword = request.ConfirmPassword,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Password = request.Password,
                UserName = request.UserName
            }, "localhost");

            return Unit.Value;
        }
    }
}
