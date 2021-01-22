using AutoMapper;
using RickLocalization.Domain;
using RickLocalization.Shared;

namespace RickLocalization.WebApi.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
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
