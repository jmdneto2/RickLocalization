using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RickLocalization.Domain;
using RickLocalization.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RickLocalization.Business
{
    public interface IPersonagemBusiness
    {
        Task<IEnumerable<PersonagemConjuntoDto>> GetAll();
    }
}
