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
        IEnumerable<ViagemDto> GetById(int idPerson, string personagemDimensao1, bool includeItens = true);
        public void AdicionarViagem(int personagemId, int origemId, int destinoId);        
    }
}
