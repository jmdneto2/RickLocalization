namespace RickLocalization.Domain
{
    public class PedidoProdutoSumarizado
    {
        public int ProdutoId { get; set; }
        public string NomeProduto { get; set; }        
        public int QtdMaxPorCliente { get; set; }
        public int QtdVenda { get; set; }

        public PedidoProdutoSumarizado(int produtoID, string nomeProduto, int qtdMaxPorCliente, int qtdVenda)
        {
            ProdutoId = produtoID;
            NomeProduto = nomeProduto;
            QtdMaxPorCliente = qtdMaxPorCliente;
            QtdVenda = qtdVenda;
        }
        public PedidoProdutoSumarizado()
        {

        }

    }
}
