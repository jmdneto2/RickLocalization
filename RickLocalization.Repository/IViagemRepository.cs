using RickLocalization.Domain;
using System.Threading.Tasks;

namespace RickLocalization.Repository
{
    public interface IViagemRepository
    {
        Task<bool> SaveChangesAsync();
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        //Task<Venda[]> GetAsync(bool includeItens);
        Task<Viagem[]> GetByIdAsync(int personagemId, string dimensao, bool includeItens);
        Task<Produto[]> GetProdutosAsync();
        Task<Produto> GetProdutoByIdAsync(int produtoId);
    }
}
