using System.ComponentModel.DataAnnotations;

namespace RickLocalization.Domain
{
    public class Produto
    {
        [Key]                
        public int ProdutoId { get; private set; }
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }
        public int QtdMaxPorCliente { get; private set; }

        public Produto(int produtoId, string nomeProduto, decimal precoProduto, int qtdMaxPorCliente)
        {
            ProdutoId = produtoId;
            Nome = nomeProduto;
            Preco = precoProduto;
            QtdMaxPorCliente = qtdMaxPorCliente;
        }

        public Produto()
        {

        }

    }
}
