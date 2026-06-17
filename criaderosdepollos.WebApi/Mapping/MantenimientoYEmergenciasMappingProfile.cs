using AutoMapper;
using CriaderosDePollos.Application.Dtos.MantenimientoYEmergencias;
using CriaderosDePollos.Entities;

namespace CriaderosDePollos.WebApi.Mapping
{
    public class MantenimientoYEmergenciasMappingProfile : Profile
    {
        public MantenimientoYEmergenciasMappingProfile()
        {
            CreateMap<MantenimientoYEmergencias, MantenimientoYEmergenciasResponseDto>()
                .ForMember(dest => dest.NombreGalpon, opt => opt.MapFrom(src => src.Galpones.Nombre));

            CreateMap<MantenimientoYEmergenciasRequestDto, MantenimientoYEmergencias>();
        }
    }
}
