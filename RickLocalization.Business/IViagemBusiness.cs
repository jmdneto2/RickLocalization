using Newtonsoft.Json.Linq;
using RickLocalization.Domain;
using RickLocalization.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RickLocalization.Business
{
    public interface IViagemBusiness
    {
        public Task<IEnumerable<ViagemDto>> GetByIdAsync(int idPerson, string personagemDimensao1, bool includeItens = true);
        public void AdicionarViagem(Viagem viagem);
        public Personagem GetDadosPersonagem(int personagemId);
        public Dimensao GetDadosOrigem(int origemId);
        public Dimensao GetDadosDestino(int destinoId);
    }
}
