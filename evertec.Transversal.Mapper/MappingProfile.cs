using AutoMapper;
using evertec.Application.DTO;
using evertec.Domain.Entity;

namespace evertec.Transversal.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
        }
    }
}
