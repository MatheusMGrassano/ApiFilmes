using ApiFilmes.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiFilmes.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Filme> Filmes { get; set; }
    }
}
