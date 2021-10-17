using Core.BLL.Services;
using ExampleProject.BLL.DTO;
using ExampleProject.DAL.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExampleProject.App.Commands
{
    public record ExsampleRequest : IRequest<ExampleEntityDto>;

    public class ExsampleRequestHandler : IRequestHandler<ExsampleRequest, ExampleEntityDto>
    {
        private readonly IService<ExampleEntity, ExampleEntityDto> _exsampleService;

        public ExsampleRequestHandler(IService<ExampleEntity, ExampleEntityDto> exsampleService)
        {
            _exsampleService = exsampleService;
        }

        public async Task<ExampleEntityDto> Handle(ExsampleRequest request, CancellationToken cancellationToken)
        {
            return (await _exsampleService.SelectAsync(_ => _.Id == 1)).FirstOrDefault();
        }
    }
}