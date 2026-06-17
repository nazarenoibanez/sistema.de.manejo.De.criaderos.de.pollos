using AutoMapper;
using CriaderoDePollos.Entities;
using CriaderosDePollos.Application.Dtos.ConteoDePollos;

namespace CriaderosDePollos.WebApi.Mapping
{
    public class ConteodepollosMappingProfile:Profile
    {
        public ConteodepollosMappingProfile()
        {
            CreateMap<Conteodepollos, ConteodepollosResponseDto>()
                .ForMember(dest => dest.NombreGalpon, opt => opt.MapFrom(src => src.Galpones.Nombre))
                .ForMember(dest => dest.NombrePollo, opt => opt.MapFrom(src => src.Pollos.Nombre));

            CreateMap<ConteodepollosRequestDto, Conteodepollos>();
        }
    }
}
