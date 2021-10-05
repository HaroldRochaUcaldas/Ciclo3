using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospiEnCasa.App.Persistencia.Migrations
{
    public partial class tablaPersona : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SugerenciaCuidados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaHora = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: false),
                    descripcion = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SugerenciaCuidados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoSignos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoSignos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enfermeras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tarjeta_profesional = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    horas_laborales = table.Column<int>(type: "INTEGER", nullable: false),
                    nombres = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    apellidos = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    numeroTelefeno = table.Column<string>(type: "VARCHAR(12)", maxLength: 12, nullable: false),
                    genero_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enfermeras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enfermeras_Generos_genero_id",
                        column: x => x.genero_id,
                        principalTable: "Generos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FamiliarDesignados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    parentesco = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    correo = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    nombres = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    apellidos = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    numeroTelefeno = table.Column<string>(type: "VARCHAR(12)", maxLength: 12, nullable: false),
                    genero_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamiliarDesignados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamiliarDesignados_Generos_genero_id",
                        column: x => x.genero_id,
                        principalTable: "Generos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Especialidad = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    codigo = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    registro_rethus = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: false),
                    nombres = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    apellidos = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    numeroTelefeno = table.Column<string>(type: "VARCHAR(12)", maxLength: 12, nullable: false),
                    genero_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicos_Generos_genero_id",
                        column: x => x.genero_id,
                        principalTable: "Generos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    historia_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    direccion = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    latitud = table.Column<double>(type: "FLOAT", nullable: false),
                    longitud = table.Column<double>(type: "FLOAT", nullable: false),
                    ciudad = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    fechaNacimiento = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    medico_id = table.Column<int>(type: "int", nullable: false),
                    familiarDesignado_id = table.Column<int>(type: "int", nullable: false),
                    enfermera_id = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    nombres = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    apellidos = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    numeroTelefeno = table.Column<string>(type: "VARCHAR(12)", maxLength: 12, nullable: false),
                    genero_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.historia_id);
                    table.ForeignKey(
                        name: "FK_Pacientes_Generos_genero_id",
                        column: x => x.genero_id,
                        principalTable: "Generos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Historias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    diagnostico = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: false),
                    entorno = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: false),
                    SugerenciaCuidado_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Historias_SugerenciaCuidados_SugerenciaCuidado_id",
                        column: x => x.SugerenciaCuidado_id,
                        principalTable: "SugerenciaCuidados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SignoVitales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false),
                    signoId = table.Column<int>(type: "int", nullable: true),
                    valor = table.Column<float>(type: "real", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignoVitales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SignoVitales_TipoSignos_signoId",
                        column: x => x.signoId,
                        principalTable: "TipoSignos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enfermeras_genero_id",
                table: "Enfermeras",
                column: "genero_id");

            migrationBuilder.CreateIndex(
                name: "IX_FamiliarDesignados_genero_id",
                table: "FamiliarDesignados",
                column: "genero_id");

            migrationBuilder.CreateIndex(
                name: "IX_Historias_SugerenciaCuidado_id",
                table: "Historias",
                column: "SugerenciaCuidado_id");

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_genero_id",
                table: "Medicos",
                column: "genero_id");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_genero_id",
                table: "Pacientes",
                column: "genero_id");

            migrationBuilder.CreateIndex(
                name: "IX_SignoVitales_signoId",
                table: "SignoVitales",
                column: "signoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enfermeras");

            migrationBuilder.DropTable(
                name: "FamiliarDesignados");

            migrationBuilder.DropTable(
                name: "Historias");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "SignoVitales");

            migrationBuilder.DropTable(
                name: "SugerenciaCuidados");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropTable(
                name: "TipoSignos");
        }
    }
}
