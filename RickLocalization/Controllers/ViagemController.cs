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
        private readonly IMapper _mapper;
        private readonly IViagemBusiness _viagemBusiness;

        public ViagemController(IViagemBusiness viagemBusiness, IMapper mapper = null)
        {
            _viagemBusiness = viagemBusiness;
            _mapper = mapper;            
        }        
        
        public IActionResult GetById([FromQuery] int idPerson, [FromQuery] string personagemDimensao1, bool includeItens = true)
        {
            try
            {
                var viagens = _viagemBusiness.GetById(idPerson, personagemDimensao1, includeItens);                

                return Ok(viagens);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult<ViagemDto> Post([FromBody] ViagemPostDto data)
        {
            var personagemId = data.personagem; 
            var origemId = data.origemId;
            var destinoId = data.destinoId;
            
            try
            {
                _viagemBusiness.AdicionarViagem(personagemId, origemId, destinoId);
                return Ok();                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
