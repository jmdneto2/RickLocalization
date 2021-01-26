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
    }
}
