using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using RickLocalization.Business;
using RickLocalization.Domain;
using RickLocalization.Repository;
using RickLocalization.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RickLocalization.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ViagemController : ControllerBase
    {
        private readonly IViagemRepository _repo;
        private readonly ILogger<ViagemController> _logger;
        private readonly IMapper _mapper;
        private readonly IViagemBusiness _viagemBusiness;

        public ViagemController(IViagemBusiness viagemBusiness, IMapper mapper = null, IViagemRepository repo = null)
        {
            _viagemBusiness = viagemBusiness;
            _mapper = mapper;
            _repo = repo;
        }        

        //[HttpGet("{idPerson}/{personagemDimensao1}/{includeItens}")]
        public async Task<IActionResult> GetById([FromQuery] int idPerson, [FromQuery] string personagemDimensao1, bool includeItens = true)
        {
            try
            {
                var viagens = _viagemBusiness.GetByIdAsync(idPerson, personagemDimensao1, includeItens).Result;                

                return Ok(viagens);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<ActionResult<ViagemDto>> Post([FromBody] ViagemPostDto data)
        {
            var personagemId = data.personagem; 
            var origemId = data.origemId;
            var destinoId = data.destinoId;

            var personagem = _viagemBusiness.GetDadosPersonagem(personagemId);
            var origem = _viagemBusiness.GetDadosOrigem(origemId);            
            var destino = _viagemBusiness.GetDadosDestino(destinoId);
            
            try
            {
                
                var viagem = new Viagem(personagem, origem, destino);

                _viagemBusiness.AdicionarViagem(viagem);
                return Ok();

                
                //if (await _repo.SaveChangesAsync())
                //{
                //    return Created($"/venda/{venda.VendaID}", venda);
                //}
                //else
                //{
                //    return BadRequest("Erro ao criar venda");
                //}

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
