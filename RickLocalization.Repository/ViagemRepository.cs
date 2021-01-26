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
            _context.Add(entity);
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

    }
}
