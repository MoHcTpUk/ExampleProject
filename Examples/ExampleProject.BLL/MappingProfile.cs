using AutoMapper;
using ExampleProject.BLL.DTO;
using ExampleProject.DAL.Entities;

namespace ExampleProject.BLL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ExampleEntity, ExampleEntityDto>();
            CreateMap<ExampleEntityDto, ExampleEntity>();
        }
    }
}