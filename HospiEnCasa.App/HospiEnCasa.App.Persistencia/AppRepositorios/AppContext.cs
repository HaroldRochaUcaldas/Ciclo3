using Microsoft.EntityFrameworkCore;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<SignoVital> SignoVitales { get; set; }
        public DbSet<TipoSigno> TipoSignos { get; set; }
        public DbSet<Historia> Historias { get; set; }
        public DbSet<SugerenciaCuidado> SugerenciaCuidados { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Enfermera> Enfermeras { get; set; }
        public DbSet<FamiliarDesignado> FamiliarDesignados { get; set; }
        public DbContextOptionsBuilder OptionBuilder { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            if (!optionBuilder.IsConfigured)
            {
                optionBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = HospiEnCasaData3");
            }
        
        
        }

     /*  protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          modelBuilder.Entity<Persona>().HasKey(k => new { k.enfermera_id});
          modelBuilder.Entity<Persona>().HasKey(k => new { k.Medico_id});
          modelBuilder.Entity<Persona>().HasKey(k => new { k.historia_id});
          modelBuilder.Entity<Persona>().HasKey(k => new { k.familiarDesignado_id});
          modelBuilder.Entity<Persona>().ToTable("Personas");
      //    modelBuilder.Entity<Medico>().Property(e => e.Id).ValueGeneratedNever();
        }*/

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>()
                .HasKey(b => b.id)
                .HasName("PersonaId");
            modelBuilder.Entity<Persona>()
           .Property(e => e.nombre).HasColumnType("VARCHAR").HasMaxLength(250);
            //  modelBuilder.Entity<Persona>()
            //      .HasIndex(b => b.nombre)
            //      .IsUnique();
            base.OnModelCreating(modelBuilder);
        }*/

    }
}