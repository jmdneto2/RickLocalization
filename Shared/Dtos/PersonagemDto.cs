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
}
