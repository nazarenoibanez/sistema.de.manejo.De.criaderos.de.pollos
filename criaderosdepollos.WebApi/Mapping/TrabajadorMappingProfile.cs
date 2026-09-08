using AutoMapper;
using CriaderosDePollos.Application.Dtos.Trabajador;
using CriaderosDePollos.Entities;

namespace CriaderosDePollos.WebApi.Mapping
{
    public class TrabajadorMappingProfile: Profile
    {
        public TrabajadorMappingProfile() 
        {
            CreateMap<trabajador, TrabajadorResponseDto>()
                .ForMember(dest => dest.Rol, opt=>opt.MapFrom(src=>src.Rol.ToString()));
            CreateMap<TrabajadorRequestDto, trabajador>();
        }
    }
}
