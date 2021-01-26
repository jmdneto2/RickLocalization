using RickLocalization.Domain;
using RickLocalization.Repository.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RickLocalization.Repository
{
    public interface IPersonagemRepository
    {
        Task<bool> SaveChangesAsync();
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<PersonagemConjunto[]> GetAll();

        Task<List<Personagem>> GetAllRick();
        Task<List<Personagem>> GetAllMorty();



    }
}
