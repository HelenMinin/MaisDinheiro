using MaisDinheiro.Models;
using Microsoft.EntityFrameworkCore;

namespace MaisDinheiro.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Despesa> Despesas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("DataSource=MaisDinheiro.db;Cache=Shared");
    }
}