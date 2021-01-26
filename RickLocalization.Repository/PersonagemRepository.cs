﻿using RickLocalization.Domain;
using RickLocalization.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace RickLocalization.Repository
{
    public class PersonagemRepository : IPersonagemRepository
    {
        private readonly RickLocalizationContext _context;

        public PersonagemRepository(RickLocalizationContext context)
        {
            _context = context;
        }

        public RickLocalizationContext Context => _context;

        #region Gerais
        public void Add<T>(T entity) where T : class
        {
            //_context.Entry(entity).Property("DimensaoId").IsModified = false;
            //_context.Entry(entity).State = EntityState.Detached;
            
            _context.Add(entity);
            // _context.Entry(((Viagem) entity).Origem ).State = EntityState.Unchanged;


        }
       

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        #endregion
        public async Task<bool> SaveChangesAsync()
        {
            //_context.Entry(dimensao).State = EntityState.Detached;
            return (await _context.SaveChangesAsync()) > 0;
        }        

        //public async Task<Viagem[]> GetByIdAsync(int personagemId, string dimensao, bool includeItens)
        //{
        //    IQueryable<Viagem> viagemContext = _context.Viagem;                                                          

        //    if (includeItens)
        //    {
        //        viagemContext = viagemContext.Include(v => v.Personagem)
        //             .ThenInclude(z => z.PersonagemDimensao);

        //        viagemContext = viagemContext.Include(v => v.Origem);
        //        viagemContext = viagemContext.Include(v => v.Destino);
        //    }

        //    IQueryable<Viagem> viagem = viagemContext
        //                                .Where(x => x.Personagem.PersonagemId == personagemId && x.Origem.DimensaoNome.Equals(dimensao)).AsNoTracking();

        //    return await viagem.ToArrayAsync();
        //}


        public async Task<PersonagemConjunto[]> GetAll()
        {
            List <Personagem> listaRick = GetAllRick().Result;
            List <Personagem> listaMorty = GetAllMorty().Result;

            IEnumerable<PersonagemConjunto> lista = from rick in listaRick
                    join morth in listaMorty on rick. PersonagemDimensao.DimensaoId equals morth.PersonagemDimensao.DimensaoId                    
                    select new PersonagemConjunto
                    (
                        rick.PersonagemId, rick.PersonagemNome, rick.PersonagemDimensao, rick.ImagemPersonagem,
                        morth.PersonagemId, morth.PersonagemNome, morth.PersonagemDimensao, morth.ImagemPersonagem
                    );
                    
                    
            

            //int personagemId, string personagemNome, Dimensao personagemDimensao, string imagemPersonagem,
            //int personagemId2, string personagemNome2, Dimensao personagemDimensao2, string imagemPersonagem2

            return lista.ToArray();
        }
        

        public async Task<List<Personagem>> GetAllRick()
        {
            IQueryable <Personagem> personagemRickContext = _context.Personagem
                                                        .Include(v => v.PersonagemDimensao)
                                                        .Where(x => x.PersonagemNome.Equals("Rick"))
                                                        .AsNoTracking();            


            return await personagemRickContext.ToListAsync();
        }

        public async Task<List<Personagem>> GetAllMorty()
        {            

            IQueryable<Personagem> personagemMorthContext = _context.Personagem
                                                        .Include(v => v.PersonagemDimensao)
                                                        .Where(x => x.PersonagemNome.Equals("Morty"))
                                                        .AsNoTracking();


            return await personagemMorthContext.ToListAsync();
        }
    }
}
