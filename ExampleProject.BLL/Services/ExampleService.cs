using AutoMapper;
using ExampleProject.DAL.Repository;

namespace ExampleProject.BLL.Services
{
    public class ExampleService : ExampleServiceAbstract
    {
        public ExampleService(ExampleRepositoryAbstract repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}