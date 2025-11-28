using Gestor_de_Notas.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gestor_de_Notas.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Notes> Notes { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Notes>()
                        .HasOne(x => x.Category)
                        .WithMany(n => n.notes)
                        .HasForeignKey(c => c.CategoryId);
        }
    }
}
