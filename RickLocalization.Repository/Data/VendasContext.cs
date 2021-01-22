using RickLocalization.Domain;
using Microsoft.EntityFrameworkCore;

namespace RickLocalization.Repository.Data
{
    public class VendasContext : DbContext
    {        
        public VendasContext(DbContextOptions<VendasContext> options) : base(options) { }

        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Promocao> Promocao { get; set; }
        public DbSet<Venda> Venda { get; set; }



    }

}
