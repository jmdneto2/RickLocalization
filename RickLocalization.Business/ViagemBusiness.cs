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
        //private readonly RickLocalizationContext _context;


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
            //_repo.Context.Entry(viagem.Personagem).State = EntityState.Detached;
            //_repo.Context.Entry(viagem.Origem).State = EntityState.Detached;
            //_repo.Context.Entry(viagem.Destino).State = EntityState.Detached;

            //var personagem = _repo.Context.Personagem.FirstOrDefaultAsync(x => x.PersonagemId == viagem.Personagem.PersonagemId);
            //var origem = _repo.Context.

            //_repo.Add(viagem);       
            
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

        //public void MontarPedidos(VendaDto dados)
        //{
        //    var pedido = new Pedido();
        //    var pedidos = new List<Pedido>();

        //    foreach (var pedidoDto in dados.Pedidos)
        //    {
        //        //Converte DTO para classe do domínio
        //        var itensParaValidar = _mapper.Map<Item[]>(dados.Pedidos.FirstOrDefault().Itens);

        //        var itens = new List<Item>();

        //        foreach (var item in itensParaValidar)
        //        {
        //            itens.Add(new Item(item.Produto, item.Quantidade));
        //        }

        //        var resultadoInclusaoItens = pedido.AdicionarItens(itens);

        //        if (resultadoInclusaoItens.Item1)
        //        {
        //            pedidos.Add(pedido);
        //        }
        //    }

        //}

    }
}
