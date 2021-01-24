using System;
using System.Collections.Generic;

namespace RickLocalization.Shared.Dtos
{
    public class PedidoDto
    {
        public int PedidoId { get; set; }
        public List<ItemDto> Itens { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
