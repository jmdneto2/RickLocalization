using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using RickLocalization.Business;
using RickLocalization.Domain;
using RickLocalization.Repository;
using RickLocalization.Repository.Data;
using RickLocalization.Shared;
using RickLocalization.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RickLocalization.Businness
{
    public class ViagemBusiness : IViagemBusiness
    {
        private readonly IViagemRepository _repo;
        private readonly IMapper _mapper;        


        public ViagemBusiness(IViagemRepository repo = null, IMapper mapper = null)
        {
            _repo = repo;
            _mapper = mapper;
        }        

        public IEnumerable<ViagemDto> GetById(int idPerson, string personagemDimensao1, bool includeItens = true)
        {
            try
            {
                var viagens = _repo.GetByIdAsync(idPerson, personagemDimensao1, includeItens).Result;
                var results = _mapper.Map<IEnumerable<ViagemDto>>(viagens);

                return results;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AdicionarViagem(int personagemId, int origemId, int destinoId)
        {
            var personagem = _repo.Context.Personagem.FirstOrDefaultAsync(x => x.PersonagemId == personagemId).Result;
            var origem = _repo.Context.Dimensao.FirstOrDefaultAsync(x => x.DimensaoId == origemId).Result;
            var destino = _repo.Context.Dimensao.FirstOrDefaultAsync(x => x.DimensaoId == destinoId).Result;

            var viagem = new Viagem(personagem, origem, destino);

            _repo.Add(viagem);

            _repo.SaveChangesAsync().Wait();
            
        }
    }
}
