using RickLocalization.Domain;
using RickLocalization.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace RickLocalization.Repository
{
    public class ViagemRepository : IViagemRepository
    {
        private readonly RickLocalizationContext _context;

        public ViagemRepository(RickLocalizationContext context)
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

        public async Task<Viagem[]> GetByIdAsync(int personagemId, string dimensao, bool includeItens)
        {
            IQueryable<Viagem> viagemContext = _context.Viagem;                                                          

            if (includeItens)
            {
                viagemContext = viagemContext.Include(v => v.Personagem)
                     .ThenInclude(z => z.PersonagemDimensao);

                viagemContext = viagemContext.Include(v => v.Origem);
                viagemContext = viagemContext.Include(v => v.Destino);
            }

            IQueryable<Viagem> viagem = viagemContext
                                        .Where(x => x.Personagem.PersonagemId == personagemId && x.Origem.DimensaoNome.Equals(dimensao)).AsNoTracking();

            return await viagem.ToArrayAsync();
        }

        public async Task<Personagem> GetDadosPersonagem(int personagemId)
        {
            IQueryable <Personagem> personagemContext = _context.Personagem
                                                        .Include(v => v.PersonagemDimensao)
                                                        .Where(x => x.PersonagemId == personagemId)
                                                        .AsNoTracking();                                                       


            return await personagemContext.FirstOrDefaultAsync();
        }

        public async Task<Dimensao> GetDadosDimensao(int dimensaoId)
        {
            IQueryable<Dimensao> dimensaoContext = _context.Dimensao
                                                    .Where(x => x.DimensaoId == dimensaoId).AsNoTracking();

            return await dimensaoContext.FirstOrDefaultAsync();
        }
    }
}
