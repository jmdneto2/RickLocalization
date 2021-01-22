using RickLocalization.Domain;
using System.Threading.Tasks;

namespace RickLocalization.Repository
{
    public interface IVendaRepository
    {
        Task<bool> SaveChangesAsync();
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<Venda[]> GetAsync(bool includeItens);
        Task<Venda> GetByIdAsync(int vendaId, bool includeItens);
        Task<Produto[]> GetProdutosAsync();
        Task<Produto> GetProdutoByIdAsync(int produtoId);
    }
}
