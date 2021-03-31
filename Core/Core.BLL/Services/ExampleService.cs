using AutoMapper;
using Core.DAL.Repository;

namespace Core.BLL.Services
{
    public class ExampleService : ExampleServiceAbstract
    {
        public ExampleService(ExampleRepositoryAbstract repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}