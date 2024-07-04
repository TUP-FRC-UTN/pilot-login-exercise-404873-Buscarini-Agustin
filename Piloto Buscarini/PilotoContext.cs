using Microsoft.EntityFrameworkCore;
using Piloto_Buscarini.Models;

namespace Piloto_Buscarini
{
    public class PilotoContext : DbContext
    {
        public PilotoContext(DbContextOptions<PilotoContext> options) : base(options)
        {

        }

        public DbSet<Piloto> pilotos { get; set; }
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Nacionalidad> Nacionalidad { get; set; }
        public DbSet<Sexo> Sexo { get; set; }   
    }
}
