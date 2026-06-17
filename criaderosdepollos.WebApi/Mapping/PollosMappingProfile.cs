using AutoMapper;
using CriaderosDePollos.Application.Dtos.Pollos;
using CriaderosDePollos.Entities;

namespace CriaderosDePollos.WebApi.Mapping
{
    public class PollosMappingProfile:Profile
    {
        public PollosMappingProfile()
        {
            CreateMap<Pollos, PollosResponseDto>()
                .ForMember(dest => dest.TipoPollo, opt => opt.MapFrom(src => src.TipoPollo.ToString()))
                .ForMember(dest => dest.TipoAlimento, opt => opt.MapFrom(src => src.TipoAlimento.ToString()));

            CreateMap<PollosRequestDto, Pollos>();
        }
    }
}
