using System;
using System.Collections.Generic;
using System.Text;

namespace RickLocalization.Domain
{
    public class Personagem
    {
        public int PersonagemId { get; private set; }
        public string PersonagemNome { get; private set; }
        public Dimensao PersonagemDimensao { get; private set; }

        public string ImagemPersonagem { get; private set; }
       

        public Personagem()
        {

        }

        public Personagem(int personagemId, string personagemNome, Dimensao personagemDimensao, string imagemPersonagem)
        {
            PersonagemId = personagemId;
            PersonagemNome = personagemNome;
            PersonagemDimensao = personagemDimensao;
            ImagemPersonagem = imagemPersonagem;

        }        

    }

    public class PersonagemConjunto
    {
        public int Personagem1Id { get; private set; }
        public string Personagem1Nome { get; private set; }
        public Dimensao Personagem1Dimensao { get; private set; }
        public string ImagemPersonagem1 { get; private set; }
        public int Personagem2Id { get; private set; }
        public string Personagem2Nome { get; private set; }
        public Dimensao Personagem2Dimensao { get; private set; }
        public string ImagemPersonagem2 { get; private set; }

        public PersonagemConjunto(int personagemId, string personagemNome, Dimensao personagemDimensao, string imagemPersonagem,
            int personagemId2, string personagemNome2, Dimensao personagemDimensao2, string imagemPersonagem2)
        {
            Personagem1Id = personagemId;
            Personagem1Nome = personagemNome;
            Personagem1Dimensao = personagemDimensao;
            ImagemPersonagem1 = imagemPersonagem;

            Personagem2Id = personagemId2;
            Personagem2Nome = personagemNome2;
            Personagem2Dimensao = personagemDimensao2;
            ImagemPersonagem2 = imagemPersonagem2;

        }
    }
    
}
