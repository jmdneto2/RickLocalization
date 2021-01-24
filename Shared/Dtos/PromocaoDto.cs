using System.ComponentModel.DataAnnotations.Schema;

namespace RickLocalization.Shared.Dtos
{
    public class PromocaoDto
    {
        public int PromocaoID { get; set; }
        public ProdutoDto? Produto1 { get; set; }
        public int? Produto1Id { get; set; }
        [NotMapped]
        public string? Produto1Nome { get; set; }
        public ProdutoDto? Produto2 { get; set; }
        public int? Produto2Id { get; set; }
        [NotMapped]
        public string? Produto2Nome { get; set; }
        public ProdutoDto? Produto3 { get; set; }

        public int? Produto3Id { get; set; }
        [NotMapped]
        public string? Produto3Nome { get; set; }
        public int? Produto1Qtd { get; set; }
        public int? Produto2Qtd { get; set; }
        public int? Produto3Qtd { get; set; }

        public int? ValorDescP1 { get; set; }
        public int? ValorDescP2 { get; set; }
        public int? ValorDescP3 { get; set; }
    }
}
