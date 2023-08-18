using Microsoft.EntityFrameworkCore;
using SIGENFAB.Shared.Entities;

namespace SIGENFAB.API.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
            
        }

        public DbSet<Deficiencia> Deficiencias { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Bairro> Bairros { get; set; }
        public DbSet<Logradouro> Logradouros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Deficiencia>().HasIndex(x => x.Nome).IsUnique();
            modelBuilder.Entity<Estado>().HasIndex(x => x.Descricao).IsUnique();
            modelBuilder.Entity<Cidade>().HasIndex("Descricao", "EstadoId").IsUnique();
            modelBuilder.Entity<Bairro>().HasIndex("Descricao", "CidadeId").IsUnique();
            modelBuilder.Entity<Logradouro>().HasIndex("Descricao", "BairroId").IsUnique();
        }
    }
}
