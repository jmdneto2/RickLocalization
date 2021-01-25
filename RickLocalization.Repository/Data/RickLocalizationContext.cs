using RickLocalization.Domain;
using Microsoft.EntityFrameworkCore;

namespace RickLocalization.Repository.Data
{
    public class RickLocalizationContext : DbContext
    {        
        public RickLocalizationContext(DbContextOptions<RickLocalizationContext> options) : base(options) { }
        
        public DbSet<Personagem> Personagem { get; set; }
        public DbSet<Dimensao> Dimensao { get; set; }
        public DbSet<Viagem> Viagem { get; set; }        

    }

}
