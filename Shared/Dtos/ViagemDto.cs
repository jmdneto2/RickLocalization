using System;
using System.Collections.Generic;
using System.Text;

namespace RickLocalization.Shared.Dtos
{
    public class ViagemDto
    {
        public int? ViagemId { get; set; }
        public PersonagemDto Personagem { get; set; }
        public DimensaoDto Origem { get; set; }
        public DimensaoDto Destino { get; set; }
        public DateTime Data { get; private set; }
    }
}
