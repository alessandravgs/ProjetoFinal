using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Models;

namespace ProjetoFinal.Data
{
    public class ApiDbContext: DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options): base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (optionsBuilder.IsConfigured)
        //    {
        //        return;
        //    }
        //    optionsBuilder
        //        .UseSqlServer(connectionString)
        //        .UseLazyLoadingProxies();
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curativo>()
                .HasMany(c => c.Coberturas)
                .WithMany(c => c.Curativos);

            modelBuilder.Entity<Paciente>()
                .HasMany(c => c.Alergias)
                .WithMany(c => c.Pacientes);

            modelBuilder.Entity<Paciente>()
                .HasMany(c => c.Comorbidades)
                .WithMany(c => c.Pacientes);
        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Alergia> Alergias { get; set; }
        public DbSet<Comorbidade> Comorbidades { get; set; }
        public DbSet<Lesao> Lesoes { get; set; }
        public DbSet<Curativo> Curativos { get; set; }
        public DbSet<Cobertura> Coberturas { get; set; }
        public DbSet<ImagemCurativo> ImagensCurativos { get; set; }
        public DbSet<Profissional> Profissionais { get; set; }
    }
}
