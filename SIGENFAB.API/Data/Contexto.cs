using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SIGENFAB.Shared.Entities;
using System.Security.Principal;

namespace SIGENFAB.API.Data
{
    public class Contexto : IdentityDbContext<Usuario>
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
            
        }

        public DbSet<Deficiencia> Deficiencias { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Bairro> Bairros { get; set; }
        public DbSet<Logradouro> Logradouros { get; set; }

        public DbSet<AgenteSaude> AgentesSaude { get; set; }
        public DbSet<Antropometria> Antropometrias { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<AtribuicaoDeDeficiencia> AtribuicaoDeficiencia { get; set; }
        public DbSet<AtribuicaoDeGrupo> AtribuicaoGrupo { get; set; }
        public DbSet<Domicilio> Domicilios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Enfermeiro> Enfermeiros { get; set; }
        public DbSet<Estabelecimento> Estabeleciomentos { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Micro> Micros { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Residencia> Residencias { get; set; }
        public DbSet<TecEnfermagem> TecnicosEnfermagem { get; set; }
        public DbSet<Unidade> Unidades { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Deficiencia>().HasIndex(x => x.Nome).IsUnique();
            modelBuilder.Entity<Estado>().HasIndex(x => x.Descricao).IsUnique();
            modelBuilder.Entity<Cidade>().HasIndex("Descricao", "EstadoId").IsUnique();
            modelBuilder.Entity<Bairro>().HasIndex("Descricao", "CidadeId").IsUnique();
            modelBuilder.Entity<Logradouro>().HasIndex("Descricao", "BairroId").IsUnique();
            modelBuilder.Entity<Usuario>().HasIndex(x => x.CPF).IsUnique();
            modelBuilder.Entity<Area>().HasIndex("Nome", "UnidadeId").IsUnique();
            modelBuilder.Entity<Micro>().HasIndex("Descricao", "AreaId").IsUnique();
            modelBuilder.Entity<Domicilio>().HasIndex(x => x.Familia).IsUnique();
            modelBuilder.Entity<Enfermeiro>().HasIndex(x => x.COREN_UF).IsUnique();
            modelBuilder.Entity<TecEnfermagem>().HasIndex(x => x.COREN_UF).IsUnique();
            modelBuilder.Entity<Grupo>().HasIndex(x => x.Nome).IsUnique();
            modelBuilder.Entity<Logradouro>().HasIndex(x => x.CEP).IsUnique();
            modelBuilder.Entity<Paciente>().HasIndex("Nome", "Sobrenome", "Mae", "Nascimento").IsUnique();
            modelBuilder.Entity<Unidade>().HasIndex(x => x.Nome).IsUnique();

            modelBuilder.Entity<AtribuicaoDeDeficiencia>()
                .HasKey(c => new { c.DeficienciaId, c.PacienteId });

            modelBuilder.Entity<AtribuicaoDeGrupo>()
                .HasKey(c => new { c.GrupoId, c.PacienteId });
        }
    }
}
