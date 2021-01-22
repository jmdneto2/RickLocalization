using System;
using System.Collections.Generic;

namespace RickLocalization.Shared
{
    public class VendaDto
    {
        public int VendaID { get; set; }
        public IList<PedidoDto> Pedidos { get; set; }
        public Decimal ValorTotal { get; set; }
        public Decimal ValorTotalDescontos { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
