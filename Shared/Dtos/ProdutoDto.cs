namespace RickLocalization.Shared.Dtos
{
    public class ProdutoDto
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int QtdMaxPorCliente { get; set; }
    }
}
