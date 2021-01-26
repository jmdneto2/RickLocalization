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

        public async Task<IEnumerable<ViagemDto>> GetByIdAsync(int idPerson, string personagemDimensao1, bool includeItens = true)
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

        public void AdicionarViagem(Viagem viagem)
        {
            var personagem = _repo.Context.Personagem.FirstOrDefaultAsync(x => x.PersonagemId == viagem.Personagem.PersonagemId).Result;
            var origem = _repo.Context.Dimensao.FirstOrDefaultAsync(x => x.DimensaoId == viagem.Origem.DimensaoId).Result;
            var destino = _repo.Context.Dimensao.FirstOrDefaultAsync(x => x.DimensaoId == viagem.Destino.DimensaoId).Result;

            var viagem2 = new Viagem(personagem, origem, destino);

            _repo.Add(viagem2);

            _repo.SaveChangesAsync().Wait();
            
        }

        public Personagem GetDadosPersonagem(int personagemId)
        {
            Personagem personagem = _repo.GetDadosPersonagem(personagemId).Result;
            return personagem;
        }
        public Dimensao GetDadosOrigem(int origemId)
        {
            Dimensao dimensao = _repo.GetDadosDimensao(origemId).Result;
            return dimensao;
        }
        public Dimensao GetDadosDestino(int destinoId)
        {
            Dimensao dimensao = _repo.GetDadosDimensao(destinoId).Result;
            return dimensao;
        }
    }
}
