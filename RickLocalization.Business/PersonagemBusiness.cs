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
    public class PersonagemBusiness : IPersonagemBusiness
    {
        private readonly IPersonagemRepository _repo;
        private readonly IMapper _mapper;        


        public PersonagemBusiness(IPersonagemRepository repo = null, IMapper mapper = null)
        {
            _repo = repo;
            _mapper = mapper;
        }        

        public IEnumerable<PersonagemConjuntoDto> GetAll()
        {
            try
            {
                var personagens = _repo.GetAll();
                var results = _mapper.Map<IEnumerable<PersonagemConjuntoDto>>(personagens);

                return results;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
