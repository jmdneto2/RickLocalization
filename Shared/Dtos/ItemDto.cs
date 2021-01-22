using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RickLocalization.Shared
{
    public class ItemDto
    {
        public int ItemId { get; set; }
        public int? PedidoId { get; set; }
        [ForeignKey("ProdutoId")]
        public ProdutoDto? Produto { get; set; }
        public int ProdutoId { get; set; }
        [NotMapped]
        public string? NomeProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime DataCriacao { get; set; }

        public int QtdMaxPorCliente { get; set; }
    }
}
