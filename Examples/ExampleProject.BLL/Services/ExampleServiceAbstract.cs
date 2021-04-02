using AutoMapper;
using Core.BLL.Services;
using ExampleProject.BLL.DTO;
using ExampleProject.DAL.Entities;
using ExampleProject.DAL.Repository;

namespace ExampleProject.BLL.Services
{
    public abstract class ExampleServiceAbstract : AbstractService<ExampleEntity, ExampleEntityDto>
    {
        protected ExampleServiceAbstract(ExampleRepositoryAbstract repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}