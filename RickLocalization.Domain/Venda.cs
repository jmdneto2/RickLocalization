using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace RickLocalization.Domain
{
    public class Venda
    {
        [Key]
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]        
        public int? VendaID { get; private set; }
        [NotMapped]
        public int? VendaIDTemp { get; private set; }        
        public IList<Pedido> Pedidos { get; private set; }
        public Decimal ValorTotal { get; private set; }
        public Decimal ValorTotalDescontos { get; private set; }
        public DateTime DataCriacao { get; private set; }

        public Venda()
        {

        }
        public Venda(IList<Pedido> pedidos)
        {
            VendaIDTemp = new Random().Next(100000,100000); //TODO: VER FORMA DE RESOLVER O ID DA CLASSE VENDA, O QUAL É AUTO INCREMENTAL NA BASE DE DADOS.
            Pedidos = pedidos;
            DataCriacao = DateTime.Now;

            var promo = CarregarPromocoes();
            SomarValorTotalVenda();
            SomarValorTotalDescontos(promo);

        }

        private void SomarValorTotalDescontos(IList<Promocao> promo)
        {            
            var listaItens = new List<Item>();
            
            foreach (var pedido in Pedidos)
            {
                for (int i = 0; i < pedido.Itens.Count; i++)
                {
                    listaItens.Add(pedido.Itens[i]);
                }
            }

            var produtosPromo = promo.Select(x => new { Produto1Id = x.Produto1Id, Produto1Nome = x.Produto1Nome, Produto2Id = x.Produto2Id, Produto2Nome = x.Produto2Nome });
            

            var listaSumarioItens = listaItens.Select(listaOriginal => new PedidoProdutoSumarizado { ProdutoId = listaOriginal.ProdutoId, NomeProduto = listaOriginal.Produto.Nome, QtdVenda = listaOriginal.Quantidade })
                                              .GroupBy(x => new { x.ProdutoId, x.NomeProduto })
                                              .Select(listaAgrupada => new { listaAgrupada.Key, TotalVendido = listaAgrupada.Sum(y => y.QtdVenda) });

            var listaSumarioApenasItensComDesconto = listaSumarioItens.Where(listaSumario => produtosPromo.Any(listaProdutosPromo => listaSumario.Key.ProdutoId == listaProdutosPromo.Produto1Id 
                                                                                                                                  || listaSumario.Key.ProdutoId == listaProdutosPromo.Produto2Id)).ToList();

            List<PromocaoEncontrada> promocoesEncontradas = new List<PromocaoEncontrada>();
            PromocaoEncontrada promocaoEncontrada;

            foreach (var promocao in promo)
            {
                promocaoEncontrada = new PromocaoEncontrada(1, 10);                               
                promocoesEncontradas.Add(promocaoEncontrada);
            }



        }

        private List<Promocao> CarregarPromocoes()
        {
            var _produto1 = new Produto(1, "Arroz", 25, 5);
            var _produto2 = new Produto(2, "Feijão", 9, 10);
            var _produto3 = new Produto(3, "Macarrão", 5, 20);
            var _produto4 = new Produto(4, "Farinha", 3, 20);
            var _produto5 = new Produto(5, "Sabão", 2, 100);

            //Promo 1: Arroz e Feijao, o arroz(1o item tem desconto de 3 reais)
            var promo1 = new Promocao(1, _produto1, _produto2, null, 1, 1, null, 3, null, null);

            //Promo 2: Arroz e Macarrão, o arroz(1o item tem desconto de 3 reais)
            var promo2 = new Promocao(2, _produto1, _produto3, _produto5, 2, 3, null, null, null, 2);

            var promocoes = new List<Promocao>() { promo1, promo2 };

            return promocoes;
        }

        private void SomarValorTotalVenda()
        {
            foreach (var pedido in Pedidos)
            {
                ValorTotal += pedido.ValorTotal;
            }
        }
    }
}
