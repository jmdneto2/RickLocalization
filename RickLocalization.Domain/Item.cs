using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RickLocalization.Domain
{
    public class Item
    {
        [Key]
        public int? ItemId { get; private set; }
        public int? PedidoId { get; private set; }
        [ForeignKey("ProdutoId")]
        public Produto Produto { get; set; }
        public int ProdutoId { get; private set; }
        [NotMapped]        
        public string NomeProduto { get; set; }
        public int Quantidade { get; private set; }
        public decimal ValorTotal { get; private set; }
        public DateTime DataCriacao { get; private set; }
        [NotMapped]
        public int QtdMaxPorCliente { get; set; }

        public Item()
        {

        }

        public Item(Produto item, int qtd)
        {
            Produto = item;
            ProdutoId = item.ProdutoId;
            NomeProduto = item.Nome;
            DataCriacao = DateTime.Now;
            Quantidade = qtd;
            QtdMaxPorCliente = item.QtdMaxPorCliente;            
            
            SomarTotalItens();
        }

        private void SomarTotalItens()
        {
            ValorTotal = Produto.Preco * Quantidade;
        }

    }


}
