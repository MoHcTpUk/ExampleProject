using AutoMapper;
using Core.BLL.Services;
using Core.DAL.Repository;
using ExampleProject.BLL.DTO;
using ExampleProject.DAL.Entities;

namespace ExampleProject.BLL.Services
{
    public class ExampleService : AbstractService<ExampleEntity, ExampleEntityDto>
    {
        public ExampleService(IRepository<ExampleEntity> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}