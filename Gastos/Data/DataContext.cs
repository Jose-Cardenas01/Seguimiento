using Gastos.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gastos.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Perdidas> Gastos { get; set; }
        public DbSet<Categoria> categoria { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Relacion 1:N entre Gastos y Categoria
            modelBuilder.Entity<Perdidas>()
                .HasOne(g => g.category)
                .WithMany(g => g.gastos)
                .HasForeignKey(g => g.CategoriaID);
        }
    }
}
