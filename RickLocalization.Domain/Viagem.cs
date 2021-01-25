using System;
using System.Collections.Generic;
using System.Text;

namespace RickLocalization.Domain
{
    public class Viagem
    {
        public int? ViagemId { get; private set; }
        public Personagem Personagem { get; private set; }
        public Dimensao Origem { get; private set; }
        public Dimensao Destino { get; private set; }
        public DateTime Data { get; private set; }

        public Viagem(int viagemId, Personagem personagem, Dimensao origem, Dimensao destino)
        {
            ViagemId = viagemId;
            Personagem = personagem;
            Origem = origem;
            Destino = destino;
            Data = DateTime.Now;

        }

        public Viagem( Personagem personagem, Dimensao origem, Dimensao destino)
        {            
            Personagem = personagem;
            Origem = origem;
            Destino = destino;
            Data = DateTime.Now;

        }

        public Viagem()
        {

        }
    }

    public class ViagemPostDto
    {
        public int id { get; set; }
        public int personagem { get; set; }
        public int origemId { get; set; }
        public int destinoId { get; set; }
    }

}
