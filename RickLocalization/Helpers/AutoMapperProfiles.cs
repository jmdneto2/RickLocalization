using AutoMapper;
using RickLocalization.Domain;
using RickLocalization.Shared;
using RickLocalization.Shared.Dtos;

namespace RickLocalization.WebApi.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Viagem, ViagemDto>()
                .ForMember(dest => dest. Personagem, opt => { opt.MapFrom(src => src.Personagem); })
                .ForMember(dest => dest.Origem, opt => { opt.MapFrom(src => src.Origem); })
                .ForMember(dest => dest.Destino, opt => { opt.MapFrom(src => src.Destino); })
                .ReverseMap();

            CreateMap<Personagem, PersonagemDto>()
                .ForMember(dest => dest.PersonagemDimensao, opt => { })
                .ReverseMap();

            CreateMap<Dimensao, DimensaoDto>()                
                .ReverseMap();
        }
    }
}
