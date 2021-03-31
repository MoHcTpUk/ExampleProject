using AutoMapper;
using Core.BLL.DTO;
using Core.DAL.Entities;

namespace Core.BLL
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