using AutoMapper;
using ExampleProject.BLL.DTO;
using ExampleProject.DAL.Entities;
using ExampleProject.DAL.Repository;

namespace ExampleProject.BLL.Services
{
    public class ExampleService : BaseService<ExampleEntity, ExampleEntityDto>
    {
        public ExampleService(IRepository<ExampleEntity> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}