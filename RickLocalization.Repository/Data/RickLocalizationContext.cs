using RickLocalization.Domain;
using Microsoft.EntityFrameworkCore;

namespace RickLocalization.Repository.Data
{
    public class RickLocalizationContext : DbContext
    {        
        public RickLocalizationContext(DbContextOptions<RickLocalizationContext> options) : base(options) { }

        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Promocao> Promocao { get; set; }
        public DbSet<Venda> Venda { get; set; }

        public DbSet<Personagem> Personagem { get; set; }
        public DbSet<Dimensao> Dimensao { get; set; }
        public DbSet<Viagem> Viagem { get; set; }



    }

}
