using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace RickLocalization.Domain
{
    public class Pedido
    {
        [Key]
        public int? PedidoId { get; private set; }
        public List<Item> Itens { get; private set; }
        public decimal ValorTotal { get; private set; }
        public DateTime DataCriacao { get; private set; }

        public Pedido()
        {
            DataCriacao = DateTime.Now;
            Itens = new List<Item>();
        }

        public Tuple<bool, List<string>> AdicionarItens(List<Item> itens)
        {
            bool result = false;
            var itensInvalidos = ValidaItensPedido(itens, Itens);
            List<string> mensagem = new List<string>();

            if (itensInvalidos.Count > 0)
            {
                foreach (var item in itensInvalidos)
                {
                    mensagem.Add(item.NomeProduto + " Qtd Max Por Cliente : " + item.QtdMaxPorCliente + " Qtd Comprada : " + item.QtdVenda);
                }

                return new Tuple<bool, List<string>>(result, mensagem);
            }
            else
            {
                itens.ForEach(item => { Itens.Add(item); });

                SomarValorTotalPedido();

                result = true;
                return new Tuple<bool, List<string>>(result, mensagem);
            }
        }

        public List<PedidoProdutoSumarizado> ValidaItensPedido(List<Item> itensParaAdicionar, List<Item> itensJaExistentes)
        {
            List<PedidoProdutoSumarizado> sumarizados = new List<PedidoProdutoSumarizado>();

            foreach (var item in itensParaAdicionar)
            {
                var lista = new PedidoProdutoSumarizado(item.ProdutoId, item.Produto.Nome, item.Produto.QtdMaxPorCliente, item.Quantidade);

                sumarizados.Add(lista);
            }

            foreach (var item in itensJaExistentes)
            {
                var lista = new PedidoProdutoSumarizado(item.ProdutoId, item.Produto.Nome, item.Produto.QtdMaxPorCliente, item.Quantidade);

                sumarizados.Add(lista);
            }

            var listaFinalSumario = sumarizados
                                        .GroupBy(x => x.NomeProduto)
                                        .Select(produtosAgrupados =>
                                        new PedidoProdutoSumarizado
                                        {
                                            NomeProduto = produtosAgrupados.Key,
                                            QtdMaxPorCliente = produtosAgrupados.First().QtdMaxPorCliente,
                                            QtdVenda = produtosAgrupados.Sum(p => p.QtdVenda)
                                        });

            List<PedidoProdutoSumarizado> listProdutosExcederamLimiteMaximo = listaFinalSumario.Where(x => x.QtdVenda > x.QtdMaxPorCliente).ToList<PedidoProdutoSumarizado>();


            return listProdutosExcederamLimiteMaximo;
        }

        private void SomarValorTotalPedido()
        {
            foreach (var item in Itens)
            {
                ValorTotal += item.ValorTotal;
            }
        }


    }
}
