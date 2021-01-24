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

            CreateMap<Produto, ProdutoDto>()
                 .ForMember(dest => dest.ProdutoId, opt =>
                 { opt.MapFrom(src => src.ProdutoId); })
                .ReverseMap();

            CreateMap<Promocao, PromocaoDto>().ReverseMap();

            CreateMap<Venda, VendaDto>()
                .ForMember(dest => dest.Pedidos, opt => { })
                .ReverseMap();

            CreateMap<Item, ItemDto>()
                //.ForMember(dest => dest.Produto, opt => { })
                .ForMember(dest => dest.Produto, opt =>
                {
                    opt.MapFrom(src => src.Produto);
                })
                .ForMember(dest => dest.ProdutoId, opt =>
                {
                    opt.MapFrom(src => src.ProdutoId);
                })
                .ReverseMap();

            CreateMap<Pedido, PedidoDto>()
                .ForMember(dest => dest.Itens, opt => { })
                //.ForMember(dest => dest.Itens, opt => {
                //opt.MapFrom(src => src.Itens.Select(x => x.Produto).ToList());
                //opt.MapFrom(src => src.Itens.Select(x => x.ItemId).ToList());
                //opt.MapFrom(src => src.Itens.Select(x => x.PedidoId).ToList());
                //opt.MapFrom(src => src.Itens.Select(x => x.ValorTotal).ToList());
                //opt.MapFrom(src => src.Itens.Select(x => x.DataCriacao).ToList());

                //})
                .ReverseMap();
        }
    }
}
