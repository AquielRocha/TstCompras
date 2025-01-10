using Microsoft.EntityFrameworkCore;
using TstCompras.Models;

namespace TstCompras.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Materiais> Materiais { get; set; }
        public DbSet<Servicos> Servicos { get; set; }
        public DbSet<LsMateriais> ListaCatmat { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Mapeamento para as tabelas
            modelBuilder.Entity<Materiais>().ToTable("materiais_compras2");
            modelBuilder.Entity<Servicos>().ToTable("servicos_compras");
            modelBuilder.Entity<LsMateriais>().ToTable("lista_catmat");

            // Definindo a chave primária para 'Materiais'
            modelBuilder.Entity<Materiais>().HasKey(m => m.id);
            // Definindo a chave primária para 'Servicos'
            modelBuilder.Entity<Servicos>().HasKey(s => s.codigo);

            modelBuilder.Entity<LsMateriais>().HasKey(l => l.id);
        }
    }
}
