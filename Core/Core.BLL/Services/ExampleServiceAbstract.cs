using AutoMapper;
using Core.BLL.DTO;
using Core.DAL.Entities;
using Core.DAL.Repository;

namespace Core.BLL.Services
{
    public abstract class ExampleServiceAbstract : BaseService<ExampleEntity, ExampleEntityDto>
    {
        protected ExampleServiceAbstract(ExampleRepositoryAbstract repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}