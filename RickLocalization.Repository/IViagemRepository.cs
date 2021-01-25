using RickLocalization.Domain;
using RickLocalization.Repository.Data;
using System.Threading.Tasks;

namespace RickLocalization.Repository
{
    public interface IViagemRepository
    {
        Task<bool> SaveChangesAsync();
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;        
        Task<Viagem[]> GetByIdAsync(int personagemId, string dimensao, bool includeItens);
        Task<Personagem> GetDadosPersonagem(int personagemId);

        Task<Dimensao> GetDadosDimensao(int dimensaoId);

        RickLocalizationContext Context { get; }
    }
}
