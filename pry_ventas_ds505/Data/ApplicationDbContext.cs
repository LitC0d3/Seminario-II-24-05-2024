using Microsoft.EntityFrameworkCore;
using pry_ventas_ds505.Models;

namespace pry_ventas_ds505.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Personal> Personal { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
    }
}
