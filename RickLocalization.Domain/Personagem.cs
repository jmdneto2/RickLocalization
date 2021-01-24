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
}
