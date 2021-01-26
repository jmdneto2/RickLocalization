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
    public class PersonagemController : ControllerBase
    {        
        private readonly IMapper _mapper;
        private readonly IPersonagemBusiness _personagemBusiness;

        public PersonagemController(IPersonagemBusiness personagemBusiness, IMapper mapper = null)
        {
            _personagemBusiness = personagemBusiness;
            _mapper = mapper;            
        }        
        
        public IActionResult GetAll()
        {
            try
            {
                var personagens = _personagemBusiness.GetAll();                

                return Ok(personagens);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        
    }
}
