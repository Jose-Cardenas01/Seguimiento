using Microsoft.EntityFrameworkCore;
using Tareas.Data.Entities;

namespace Tareas.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Tarea> Tareas{ get; set; }
    }
}
