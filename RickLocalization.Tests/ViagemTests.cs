using RickLocalization.Domain;
using System;
using System.Collections.Generic;
using Xunit;

namespace RickLocalization.Tests
{
    public class ViagemTests
    {
        private Personagem _personagem;
        private Dimensao _personagemDimensao;
        private Dimensao _origem;
        private Dimensao _destino;
        private Viagem _viagem;        

        public ViagemTests()
        {
            
        }

        [Fact]
        public void CriarViagem_DadosCompletos_DeveRetornarOk()
        {
            //Criando personagem:
            _personagemDimensao = new Dimensao(1, "C-130");
            _personagem = new Personagem(1, "Ricky", _personagemDimensao, "http://labcon.fafich.ufmg.br/wp-content/uploads/2018/06/5164749-940x429.jpg");

            //Criando viagem:
            _origem = new Dimensao(1, "C-130");
            _destino = new Dimensao(2, "C-131");
            _viagem = new Viagem(1, _personagem, _origem, _destino);

            Assert.NotNull(_viagem);

        }

        //[Fact]
        //public void CriarVenda_PedidoItensDentroLimite_DeveRetornarOk()
        //{
        //    bool resultado = false;
        //    var statusCriacaoPedido = MontarPedidoComItensDentroLimite_DeveRetornarOk();

        //    if (statusCriacaoPedido.Item1)
        //    {
        //        IList<Pedido> listPedidos = new List<Pedido>();
        //        listPedidos.Add(_pedido1);

        //        Venda venda = new Venda(listPedidos);
        //        resultado = true;
        //    }

        //    Assert.True(resultado);

        //}
        //[Fact]
        //public void CriarVenda_PedidoItensForaLimite_DeveRetornarNOk()
        //{
        //    bool resultado = false;
        //    var statusCriacaoPedido = MontarPedidoComItensForaLimite_DeveRetornarNOk();

        //    if (statusCriacaoPedido.Item1)
        //    {
        //        IList<Pedido> listPedidos = new List<Pedido>();
        //        listPedidos.Add(_pedido2);

        //        Venda venda = new Venda(listPedidos);
        //        resultado = true;
        //    }

        //    Assert.False(resultado);


        //}

        //#region Métodos Auxiliares

        //private Tuple<bool, List<string>> MontarPedidoComItensDentroLimite_DeveRetornarOk()
        //{


        //    //Criando instância dos pedido 1
        //    _pedido1 = new Pedido();

        //    //Criando instância de itens do pedido 1
        //    _pedidoItem1 = new Item(_produto1, 1);
        //    _pedidoItem2 = new Item(_produto2, 10);
        //    _pedidoItem3 = new Item(_produto3, 10);
        //    _pedidoItem4 = new Item(_produto4, 6);
        //    _pedidoItem5 = new Item(_produto5, 20);
        //    _pedidoItem6 = new Item(_produto1, 4);

        //    //Agrupando todos os itens de pedido
        //    var listItensPedido1 = new List<Item>();
        //    listItensPedido1.Add(_pedidoItem1);
        //    listItensPedido1.Add(_pedidoItem2);
        //    listItensPedido1.Add(_pedidoItem3);
        //    listItensPedido1.Add(_pedidoItem4);
        //    listItensPedido1.Add(_pedidoItem5);
        //    listItensPedido1.Add(_pedidoItem6);

        //    //Adicionando itens do Pedido 1
        //    var resultado = _pedido1.AdicionarItens(listItensPedido1);

        //    return resultado;

        //}
        //private Tuple<bool, List<string>> MontarPedidoComItensForaLimite_DeveRetornarNOk()
        //{

        //    //Criando instância dos pedido 2
        //    _pedido2 = new Pedido();

        //    //Criando instância de itens do pedido 2
        //    _pedidoItem1 = new Item(_produto5, 3);
        //    _pedidoItem2 = new Item(_produto4, 6);
        //    _pedidoItem3 = new Item(_produto3, 4);
        //    _pedidoItem4 = new Item(_produto2, 2);
        //    _pedidoItem5 = new Item(_produto2, 50);

        //    //Agrupando todos os itens de pedido
        //    var listItensPedido2 = new List<Item>();
        //    listItensPedido2.Add(_pedidoItem1);
        //    listItensPedido2.Add(_pedidoItem2);
        //    listItensPedido2.Add(_pedidoItem3);
        //    listItensPedido2.Add(_pedidoItem4);
        //    listItensPedido2.Add(_pedidoItem5);

        //    //Adicionando itens do Pedido 2
        //    var resultado = _pedido2.AdicionarItens(listItensPedido2);

        //    return resultado;

        //}
        //private Tuple<bool, List<string>> MontarPedidoComItensForaLimite_DeveRetornarNOk2()
        //{

        //    //Criando instância dos pedido 3
        //    _pedido3 = new Pedido();

        //    //Criando instância de itens do pedido 3
        //    _pedidoItem1 = new Item(_produto5, 10);
        //    _pedidoItem2 = new Item(_produto4, 20);
        //    _pedidoItem3 = new Item(_produto3, 30);
        //    _pedidoItem4 = new Item(_produto2, 40);
        //    _pedidoItem5 = new Item(_produto1, 50);

        //    //Agrupando todos os itens de pedido
        //    var listItensPedido3 = new List<Item>();
        //    listItensPedido3.Add(_pedidoItem1);
        //    listItensPedido3.Add(_pedidoItem2);
        //    listItensPedido3.Add(_pedidoItem3);
        //    listItensPedido3.Add(_pedidoItem4);
        //    listItensPedido3.Add(_pedidoItem5);

        //    //Adicionando itens do Pedido 3
        //    var resultado = _pedido3.AdicionarItens(listItensPedido3);


        //    return resultado;

        //}
        //private List<Promocao> CarregarPromocoes_DeveRetornarListaDePromocoes()
        //{
        //    //Promo 1: Arroz e Feijao, o arroz(1o item tem desconto de 3 reais)
        //    var promo1 = new Promocao(1, _produto1, _produto2, null, 1, 1, null, 3, null, null);

        //    //Promo 2: Arroz e Macarrão, o arroz(1o item tem desconto de 3 reais)
        //    var promo2 = new Promocao(2, _produto1, _produto3, _produto5, 2, 3, null, null, null, 2);

        //    promocoes = new List<Promocao>() { promo1, promo2 };

        //    return (List<Promocao>)promocoes;
        //}
        //#endregion

    }
}
