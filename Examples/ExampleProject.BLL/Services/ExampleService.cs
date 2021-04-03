using AutoMapper;
using Core.BLL.Services;
using ExampleProject.BLL.DTO;
using ExampleProject.DAL.Entities;
using ExampleProject.DAL.Repository;

namespace ExampleProject.BLL.Services
{
    public class ExampleService : AbstractService<ExampleEntity, ExampleEntityDto>
    {
        public ExampleService(ExampleRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}