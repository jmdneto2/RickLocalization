using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RickLocalization.Domain
{
    public class Promocao
    {
        [Key]
        public int PromocaoID { get; private set; }
        public Produto? Produto1 { get; private set; }
        public int? Produto1Id { get; private set; }
        [NotMapped]
        public string? Produto1Nome { get; private set; }
        public Produto? Produto2 { get; private set; }
        public int? Produto2Id { get; private set; }
        [NotMapped]
        public string? Produto2Nome { get; private set; }
        public Produto? Produto3 { get; private set; }

        public int? Produto3Id { get; private set; }
        [NotMapped]
        public string? Produto3Nome { get; private set; }
        public int? Produto1Qtd { get; private set; }
        public int? Produto2Qtd { get; private set; }
        public int? Produto3Qtd { get; private set; }

        public int? ValorDescP1 { get; private set; }
        public int? ValorDescP2 { get; private set; }
        public int? ValorDescP3 { get; private set; }

        public Promocao()
        {

        }
        public Promocao(
            int promocaoId, Produto produto1, Produto produto2, Produto? produto3,
            int? produto1Qtd, int? produto2Qtd, int? produto3Qtd,
            int? valorDescP1, int? valorDescP2, int? valorDescP3)
        {
            PromocaoID = promocaoId;
            Produto1 = produto1;
            Produto2 = produto2;
            Produto3 = produto3;
            Produto1Qtd = produto1Qtd;
            Produto2Qtd = produto2Qtd;
            Produto3Qtd = produto3Qtd;
            ValorDescP1 = valorDescP1;
            ValorDescP2 = valorDescP2;
            ValorDescP3 = valorDescP3;
            Produto1Id = produto1.ProdutoId;
            Produto2Id = produto2.ProdutoId;
            Produto2Id = produto2.ProdutoId;
            Produto1Nome = produto1.Nome;
            Produto2Nome = produto2.Nome;
            Produto3Nome = produto3?.Nome;
        }

    }

    public class PromocaoEncontrada
    {
        public int PromocaoID { get; private set; }
        public int Quantidade { get; private set; }

        public PromocaoEncontrada()
        {

        }
        public PromocaoEncontrada(int promocaoId, int quantidade)
        {
            PromocaoID = promocaoId;
            Quantidade = quantidade;

        }

    }
}
