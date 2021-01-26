using System;
using System.Collections.Generic;
using System.Text;

namespace RickLocalization.Shared.Dtos
{
    public class PersonagemDto
    {
        public int PersonagemId { get; set; }
        public string PersonagemNome { get; set; }
        public DimensaoDto PersonagemDimensao { get; set; }
        public string ImagemPersonagem { get; set; }

    }

    public class PersonagemConjuntoDto
    {
        public int Personagem1Id { get; private set; }
        public string Personagem1Nome { get; private set; }
        public DimensaoDto Personagem1Dimensao { get; private set; }
        public string ImagemPersonagem1 { get; private set; }
        public int Personagem2Id { get; private set; }
        public string Personagem2Nome { get; private set; }
        public DimensaoDto Personagem2Dimensao { get; private set; }
        public string ImagemPersonagem2 { get; private set; }

    }
}
