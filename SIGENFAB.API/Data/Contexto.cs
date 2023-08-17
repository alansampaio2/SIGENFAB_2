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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Deficiencia>().HasIndex(x => x.Nome).IsUnique();
        }
    }
}
