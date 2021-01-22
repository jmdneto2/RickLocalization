//using AutoMapper;
//using Gov.Entity;
//using Gov2.Shared;
//using System;
//using System.Collections.Generic;

//namespace Gov2.Businness
//{
//    public class PedidoBusiness
//    {
//        private readonly IMapper _mapper;
//        private readonly VendasContext _context;

//        public PedidoBusiness(VendasContext context, IMapper mapper)
//        {
//            _mapper = mapper;
//            _context = context;
//        }

        


//        public void MontarPedidos(VendaDto dados)
//        {
//            var pedido = new Pedido();
//            var pedidos = new List<Pedido>();

//            foreach (var pedidoDto in dados.Pedidos)
//            {
//                //Converte DTO para classe do domínio
//                var itensParaValidar = _mapper.Map<Item[]>(dados.Pedidos.FirstOrDefault().Itens);

//                var itens = new List<Item>();

//                foreach (var item in itensParaValidar)
//                {
//                    itens.Add(new Item(item.Produto, item.Quantidade));
//                }

//                var resultadoInclusaoItens = pedido.AdicionarItens(itens);

//                if (resultadoInclusaoItens.Item1)
//                {
//                    pedidos.Add(pedido);
//                }
//            }

//        }

//    }
//}
