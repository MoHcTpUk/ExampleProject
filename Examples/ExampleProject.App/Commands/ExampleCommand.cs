using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ExampleProject.BLL.DTO;
using ExampleProject.BLL.Services;
using MediatR;

namespace ExampleProject.App.Commands
{
    public class ExsampleRequest : IRequest<ExampleEntityDto>
    {

    }

    public class ExsampleRequestHandler : IRequestHandler<ExsampleRequest, ExampleEntityDto>
    {
        private readonly ExampleService _exsampleService;

        public ExsampleRequestHandler(ExampleService exsampleService)
        {
            _exsampleService = exsampleService;
        }

        public async Task<ExampleEntityDto> Handle(ExsampleRequest request, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                var dto = _exsampleService.Select(_ => _.Id == 1).FirstOrDefault();

                return dto;
            }, cancellationToken);
        }
    }
}