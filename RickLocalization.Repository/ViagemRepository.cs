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

        #region Gerais
        public void Add<T>(T entity) where T : class
        {            
            _context.Add(entity);
            //_context.Entry(entity).Property("VendaId").IsModified = false;
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

        //public async Task<Venda[]> GetAsync(bool includeItens = false)
        //{
        //    IQueryable<Venda> venda = _context.Venda.AsNoTracking();

        //    if (includeItens)
        //    {
        //        venda = venda.Include(v => v.Pedidos)
        //             .ThenInclude(z => z.Itens);
        //    }

        //    return await venda.ToArrayAsync();

        //}

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

        public async Task<Produto[]> GetProdutosAsync()
        {

            IQueryable<Produto> produto = _context.Produto.AsNoTracking();

            return await produto.ToArrayAsync();

        }

        public async Task<Produto> GetProdutoByIdAsync(int produtoId)
        {
            IQueryable<Produto> produto = _context.Produto.Where(x => x.ProdutoId == produtoId).AsNoTracking();

            return await produto.FirstOrDefaultAsync();

        }

    }
}
