using RickLocalization.Domain;
using System;
using System.Collections.Generic;
using Xunit;

namespace RickLocalization.Tests
{
    public class VendaTests
    {
        private readonly Produto _produto1;
        private readonly Produto _produto2;
        private readonly Produto _produto3;
        private readonly Produto _produto4;
        private readonly Produto _produto5;
        private Item _pedidoItem1;
        private Item _pedidoItem2;
        private Item _pedidoItem3;
        private Item _pedidoItem4;
        private Item _pedidoItem5;
        private Item _pedidoItem6;
        private Item _pedidoItem7;
        private Item _pedidoItem8;
        private Item _pedidoItem9;
        private Item _pedidoItem10;
        private Pedido _pedido1;
        private Pedido _pedido2;
        private Pedido _pedido3;
        private IList<Promocao> promocoes;


        public VendaTests()
        {

            //Lista de Produtos:
            _produto1 = new Produto(1, "Arroz", 25, 5);
            _produto2 = new Produto(2, "Feijão", 9, 10);
            _produto3 = new Produto(3, "Macarrão", 5, 20);
            _produto4 = new Produto(4, "Farinha", 3, 20);
            _produto5 = new Produto(5, "Sabão", 2, 100);

            //Carregando as promoções vigentes:
            promocoes = CarregarPromocoes_DeveRetornarListaDePromocoes();

        }

        [Fact]
        public void CriarVenda_PedidoItensDentroLimite_DeveRetornarOk()
        {
            bool resultado = false;
            var statusCriacaoPedido = MontarPedidoComItensDentroLimite_DeveRetornarOk();

            if (statusCriacaoPedido.Item1)
            {
                IList<Pedido> listPedidos = new List<Pedido>();
                listPedidos.Add(_pedido1);

                Venda venda = new Venda(listPedidos);
                resultado = true;
            }

            Assert.True(resultado);

        }
        [Fact]
        public void CriarVenda_PedidoItensForaLimite_DeveRetornarNOk()
        {
            bool resultado = false;
            var statusCriacaoPedido = MontarPedidoComItensForaLimite_DeveRetornarNOk();

            if (statusCriacaoPedido.Item1)
            {
                IList<Pedido> listPedidos = new List<Pedido>();
                listPedidos.Add(_pedido2);

                Venda venda = new Venda(listPedidos);
                resultado = true;
            }

            Assert.False(resultado);


        }

        #region Métodos Auxiliares

        private Tuple<bool, List<string>> MontarPedidoComItensDentroLimite_DeveRetornarOk()
        {


            //Criando instância dos pedido 1
            _pedido1 = new Pedido();

            //Criando instância de itens do pedido 1
            _pedidoItem1 = new Item(_produto1, 1);
            _pedidoItem2 = new Item(_produto2, 10);
            _pedidoItem3 = new Item(_produto3, 10);
            _pedidoItem4 = new Item(_produto4, 6);
            _pedidoItem5 = new Item(_produto5, 20);
            _pedidoItem6 = new Item(_produto1, 4);

            //Agrupando todos os itens de pedido
            var listItensPedido1 = new List<Item>();
            listItensPedido1.Add(_pedidoItem1);
            listItensPedido1.Add(_pedidoItem2);
            listItensPedido1.Add(_pedidoItem3);
            listItensPedido1.Add(_pedidoItem4);
            listItensPedido1.Add(_pedidoItem5);
            listItensPedido1.Add(_pedidoItem6);

            //Adicionando itens do Pedido 1
            var resultado = _pedido1.AdicionarItens(listItensPedido1);

            return resultado;

        }
        private Tuple<bool, List<string>> MontarPedidoComItensForaLimite_DeveRetornarNOk()
        {

            //Criando instância dos pedido 2
            _pedido2 = new Pedido();

            //Criando instância de itens do pedido 2
            _pedidoItem1 = new Item(_produto5, 3);
            _pedidoItem2 = new Item(_produto4, 6);
            _pedidoItem3 = new Item(_produto3, 4);
            _pedidoItem4 = new Item(_produto2, 2);
            _pedidoItem5 = new Item(_produto2, 50);

            //Agrupando todos os itens de pedido
            var listItensPedido2 = new List<Item>();
            listItensPedido2.Add(_pedidoItem1);
            listItensPedido2.Add(_pedidoItem2);
            listItensPedido2.Add(_pedidoItem3);
            listItensPedido2.Add(_pedidoItem4);
            listItensPedido2.Add(_pedidoItem5);

            //Adicionando itens do Pedido 2
            var resultado = _pedido2.AdicionarItens(listItensPedido2);

            return resultado;

        }
        private Tuple<bool, List<string>> MontarPedidoComItensForaLimite_DeveRetornarNOk2()
        {

            //Criando instância dos pedido 3
            _pedido3 = new Pedido();

            //Criando instância de itens do pedido 3
            _pedidoItem1 = new Item(_produto5, 10);
            _pedidoItem2 = new Item(_produto4, 20);
            _pedidoItem3 = new Item(_produto3, 30);
            _pedidoItem4 = new Item(_produto2, 40);
            _pedidoItem5 = new Item(_produto1, 50);

            //Agrupando todos os itens de pedido
            var listItensPedido3 = new List<Item>();
            listItensPedido3.Add(_pedidoItem1);
            listItensPedido3.Add(_pedidoItem2);
            listItensPedido3.Add(_pedidoItem3);
            listItensPedido3.Add(_pedidoItem4);
            listItensPedido3.Add(_pedidoItem5);

            //Adicionando itens do Pedido 3
            var resultado = _pedido3.AdicionarItens(listItensPedido3);


            return resultado;

        }
        private List<Promocao> CarregarPromocoes_DeveRetornarListaDePromocoes()
        {
            //Promo 1: Arroz e Feijao, o arroz(1o item tem desconto de 3 reais)
            var promo1 = new Promocao(1, _produto1, _produto2, null, 1, 1, null, 3, null, null);

            //Promo 2: Arroz e Macarrão, o arroz(1o item tem desconto de 3 reais)
            var promo2 = new Promocao(2, _produto1, _produto3, _produto5, 2, 3, null, null, null, 2);

            promocoes = new List<Promocao>() { promo1, promo2 };

            return (List<Promocao>)promocoes;
        }
        #endregion

    }
}
