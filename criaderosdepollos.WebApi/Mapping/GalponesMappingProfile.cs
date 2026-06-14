using AutoMapper;
using CriaderosDePollos.Application.Dtos.Galpones;
using CriaderosDePollos.Entities;

namespace CriaderosDePollos.WebApi.Mapping
{
    public class GalponesMappingProfile : Profile
    {
        public GalponesMappingProfile()
        {
            CreateMap<Galpones, GalponesResponseDto>();
            CreateMap<GalponesRequestDto, Galpones>();
        }
    }
}
