using AutoMapper;
using CriaderosDePollos.Application.Dtos.RetiroDePollos;
using CriaderosDePollos.Entities;

namespace CriaderosDePollos.WebApi.Mapping
{
    public class RetiroDePollosMappingProfile: Profile
    {

        public RetiroDePollosMappingProfile()
        {
            CreateMap<RetiroDePollos, RetiroDePollosResponseDto>()
                .ForMember(dest => dest.controlID, opt => opt.MapFrom(src => src.ControlDePesoId))
                .ForMember(dest => dest.UltimoPesoPromedioRegistradoGr, opt => opt.MapFrom(src => src.control.PesoPromedioGr))
                .ForMember(dest => dest.EdadDiasEnRetiro, opt => opt.MapFrom(src => src.control.EdadDias));

            CreateMap<RetiroDePollosRequestDto, RetiroDePollos>();
        }

    }
}
