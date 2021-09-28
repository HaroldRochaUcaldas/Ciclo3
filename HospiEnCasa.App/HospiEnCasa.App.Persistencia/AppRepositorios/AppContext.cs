using Microsoft.EntityFrameworkCore;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<TipoSigno> TipoSignos{ get; set; }
        public DbSet<SignoVital> SignoVitales { get; set; }
        public DbSet<SugerenciaCuidado> sugerenciaCuidados { get; set; }
        public DbSet<Historia> Historias { get; set; }
        //public DbSet<Medico> Medicos { get; set; }
        public DbContextOptionsBuilder OptionBuilder {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            if (!optionBuilder.IsConfigured)
            {
                optionBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = HospiEnCasaData");
            }
        
        
        }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          modelBuilder.Entity<Medico>().ToTable("Medicos");
          modelBuilder.Entity<Enfermera>().ToTable("Enfermeras");
          modelBuilder.Entity<FamiliarDesignado>().ToTable("FamiliaresDesignados");
          modelBuilder.Entity<Paciente>().ToTable("Pacientes");
      //    modelBuilder.Entity<Medico>().Property(e => e.Id).ValueGeneratedNever();
        }

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