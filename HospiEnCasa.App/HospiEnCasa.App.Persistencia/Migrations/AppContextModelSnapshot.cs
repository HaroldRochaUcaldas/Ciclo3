﻿// <auto-generated />
using System;
using HospiEnCasa.App.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HospiEnCasa.App.Persistencia.Migrations
{
    [DbContext(typeof(AppContext))]
    partial class AppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("HospiEnCasa.App.Dominio.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("HospiEnCasa.App.Dominio.Historia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("SugerenciaCuidado_id")
                        .HasColumnType("int");

                    b.Property<string>("diagnostico")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("VARCHAR(500)");

                    b.Property<string>("entorno")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("VARCHAR(500)");

                    b.HasKey("Id");

                    b.HasIndex("SugerenciaCuidado_id");

                    b.ToTable("Historias");
                });

            modelBuilder.Entity("HospiEnCasa.App.Dominio.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Medico_id")
                        .HasColumnType("int");

                    b.Property<string>("apellidos")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("VARCHAR(250)");

                    b.Property<int>("enfermera_id")
                        .HasColumnType("int");

                    b.Property<int>("familiarDesignado_id")
                        .HasColumnType("int");

                    b.Property<int>("genero_id")
                        .HasColumnType("int");

                    b.Property<int>("historia_id")
                        .HasColumnType("int");

                    b.Property<string>("nombres")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("VARCHAR(250)");

                    b.Property<string>("numeroTelefeno")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("VARCHAR(12)");

                    b.HasKey("Id");

                    b.HasIndex("genero_id");

                    b.ToTable("Personas");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Persona");
                });

            modelBuilder.Entity("HospiEnCasa.App.Dominio.SignoVital", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("fecha")
                        .HasMaxLength(100)
                        .HasColumnType("datetime2");

                    b.Property<int?>("signoId")
                        .HasColumnType("int");

                    b.Property<float>("valor")
                        .HasMaxLength(100)
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("signoId");

                    b.ToTable("SignoVitales");
                });

            modelBuilder.Entity("HospiEnCasa.App.Dominio.SugerenciaCuidado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("VARCHAR(500)");

                    b.Property<string>("fechaHora")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("VARCHAR(500)");

                    b.HasKey("Id");

                    b.ToTable("SugerenciaCuidados");
                });

            modelBuilder.Entity("HospiEnCasa.App.Dominio.TipoSigno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TipoSignos");
                });

            modelBuilder.Entity("HospiEnCasa.App.Dominio.Enfermera", b =>
                {
                    b.HasBaseType("HospiEnCasa.App.Dominio.Persona");

                    b.Property<int>("horas_laborales")
                        .HasColumnType("INTEGER");

                    b.Property<string>("tarjeta_profesional")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)");

                    b.HasDiscriminator().HasValue("Enfermera");
                });

            modelBuilder.Entity("HospiEnCasa.App.Dominio.FamiliarDesignado", b =>
                {
                    b.HasBaseType("HospiEnCasa.App.Dominio.Persona");

                    b.Property<string>("correo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("parentesco")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)");

                    b.HasDiscriminator().HasValue("FamiliarDesignado");
                });

            modelBuilder.Entity("HospiEnCasa.App.Dominio.Medico", b =>
                {
                    b.HasBaseType("HospiEnCasa.App.Dominio.Persona");

                    b.Property<string>("Especialidad")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("VARCHAR(250)");

                    b.Property<string>("codigo")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("VARCHAR(250)");

                    b.Property<string>("registro_rethus")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("VARCHAR(500)");

                    b.HasDiscriminator().HasValue("Medico");
                });

            modelBuilder.Entity("HospiEnCasa.App.Dominio.Paciente", b =>
                {
                    b.HasBaseType("HospiEnCasa.App.Dominio.Persona");

                    b.Property<string>("ciudad")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("direccion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)");

                    b.Property<int?>("enfermeraId")
                        .HasColumnType("int");

                    b.Property<int?>("familiarDesignadoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("fechaNacimiento")
                        .HasColumnType("DATETIME");

                    b.Property<int?>("historiaId")
                        .HasColumnType("int");

                    b.Property<double>("latitud")
                        .HasColumnType("FLOAT");

                    b.Property<double>("longitud")
                        .HasColumnType("FLOAT");

                    b.Property<int?>("medicoId")
                        .HasColumnType("int");

                    b.HasIndex("enfermeraId");

                    b.HasIndex("familiarDesignadoId");

                    b.HasIndex("historiaId");

                    b.HasIndex("medicoId");

                    b.HasDiscriminator().HasValue("Paciente");
                });

            modelBuilder.Entity("HospiEnCasa.App.Dominio.Historia", b =>
                {
                    b.HasOne("HospiEnCasa.App.Dominio.SugerenciaCuidado", "SugerenciaCuidados")
                        .WithMany()
                        .HasForeignKey("SugerenciaCuidado_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SugerenciaCuidados");
                });

            modelBuilder.Entity("HospiEnCasa.App.Dominio.Persona", b =>
                {
                    b.HasOne("HospiEnCasa.App.Dominio.Genero", "genero")
                        .WithMany()
                        .HasForeignKey("genero_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("genero");
                });

            modelBuilder.Entity("HospiEnCasa.App.Dominio.SignoVital", b =>
                {
                    b.HasOne("HospiEnCasa.App.Dominio.TipoSigno", "signo")
                        .WithMany()
                        .HasForeignKey("signoId");

                    b.Navigation("signo");
                });

            modelBuilder.Entity("HospiEnCasa.App.Dominio.Paciente", b =>
                {
                    b.HasOne("HospiEnCasa.App.Dominio.Enfermera", "enfermera")
                        .WithMany()
                        .HasForeignKey("enfermeraId");

                    b.HasOne("HospiEnCasa.App.Dominio.FamiliarDesignado", "familiarDesignado")
                        .WithMany()
                        .HasForeignKey("familiarDesignadoId");

                    b.HasOne("HospiEnCasa.App.Dominio.Historia", "historia")
                        .WithMany()
                        .HasForeignKey("historiaId");

                    b.HasOne("HospiEnCasa.App.Dominio.Medico", "medico")
                        .WithMany()
                        .HasForeignKey("medicoId");

                    b.Navigation("enfermera");

                    b.Navigation("familiarDesignado");

                    b.Navigation("historia");

                    b.Navigation("medico");
                });
#pragma warning restore 612, 618
        }
    }
}
