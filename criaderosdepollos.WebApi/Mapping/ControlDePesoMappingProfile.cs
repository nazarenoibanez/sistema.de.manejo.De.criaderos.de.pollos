using AutoMapper;
using CriaderosDePollos.Application.Dtos.ControlDePeso;
using CriaderosDePollos.Entities;

namespace CriaderosDePollos.WebApi.Mapping
{
    public class ControlDePesoMappingProfile:Profile
    {
        public ControlDePesoMappingProfile()
        {
            CreateMap<ControlDePeso, ControlDePesoResponseDto>()
                .ForMember(dest => dest.controlID, opt => opt.MapFrom(src => src.ConteodepollosId))
                .ForMember(dest => dest.CantidadPollosEnConteo, opt => opt.MapFrom(src => src.Conteodepollos.CantidadPollos))
                .ForMember(dest => dest.NombreDelPollo, opt => opt.MapFrom(src => src.Conteodepollos.Pollos.Nombre))
                .ForMember(dest => dest.NombreDelGalpon, opt => opt.MapFrom(src => src.Conteodepollos.Galpones.Nombre));

            CreateMap<ControlDePesoRequestDto, ControlDePeso>();
        }
    }
}
