using RickLocalization.Domain;
using RickLocalization.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace RickLocalization.Repository
{
    public class VendaRepository : IVendaRepository
    {
        private readonly VendasContext _context;

        public VendaRepository(VendasContext context)
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

        public async Task<Venda[]> GetAsync(bool includeItens = false)
        {
            IQueryable<Venda> venda = _context.Venda.AsNoTracking();

            if (includeItens)
            {
                venda = venda.Include(v => v.Pedidos)
                     .ThenInclude(z => z.Itens);
            }

            return await venda.ToArrayAsync();

        }

        public async Task<Venda> GetByIdAsync(int vendaId, bool includeItens)
        {
            IQueryable<Venda> venda = _context.Venda.Where(x => x.VendaID == vendaId).AsNoTracking();

            if (includeItens)
            {
                venda = venda.Include(v => v.Pedidos)
                     .ThenInclude(z => z.Itens);
            }

            return await venda.FirstOrDefaultAsync();
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
