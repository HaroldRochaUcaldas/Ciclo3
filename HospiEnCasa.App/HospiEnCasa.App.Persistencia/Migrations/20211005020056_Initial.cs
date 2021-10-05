using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospiEnCasa.App.Persistencia.Migrations
{
    public partial class Initial : Migration
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
                name: "sugerenciaCuidados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaHora = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: false),
                    descripcion = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sugerenciaCuidados", x => x.Id);
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
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombres = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    apellidos = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    numeroTelefeno = table.Column<string>(type: "VARCHAR(12)", maxLength: 12, nullable: false),
                    genero_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personas_Generos_genero_id",
                        column: x => x.genero_id,
                        principalTable: "Generos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    direccion = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    latitud = table.Column<double>(type: "FLOAT", nullable: false),
                    longitud = table.Column<double>(type: "FLOAT", nullable: false),
                    ciudad = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    fechaNacimiento = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    medico_id = table.Column<int>(type: "int", nullable: false),
                    Enfermera = table.Column<int>(type: "int", nullable: true),
                    paciente_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacientes_Pacientes_paciente_id",
                        column: x => x.paciente_id,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pacientes_Personas_Id",
                        column: x => x.Id,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enfermeras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    tarjeta_profesional = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    horas_laborales = table.Column<int>(type: "INTEGER", nullable: false),
                    paciente_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enfermeras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enfermeras_Pacientes_paciente_id",
                        column: x => x.paciente_id,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enfermeras_Personas_Id",
                        column: x => x.Id,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FamiliaresDesignados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    parentesco = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    correo = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    paciente_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamiliaresDesignados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamiliaresDesignados_Pacientes_paciente_id",
                        column: x => x.paciente_id,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FamiliaresDesignados_Personas_Id",
                        column: x => x.Id,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Historias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    diagnostico = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: false),
                    entorno = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: false),
                    sugerenciacuidado_id = table.Column<int>(type: "int", nullable: true),
                    paciente_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Historias_Pacientes_paciente_id",
                        column: x => x.paciente_id,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Historias_sugerenciaCuidados_sugerenciacuidado_id",
                        column: x => x.sugerenciacuidado_id,
                        principalTable: "sugerenciaCuidados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Especialidad = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    codigo = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    registro_rethus = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: false),
                    paciente_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicos_Pacientes_paciente_id",
                        column: x => x.paciente_id,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Medicos_Personas_Id",
                        column: x => x.Id,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SignoVitales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false),
                    signoId = table.Column<int>(type: "int", nullable: true),
                    valor = table.Column<float>(type: "real", maxLength: 100, nullable: false),
                    paciente_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignoVitales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SignoVitales_Pacientes_paciente_id",
                        column: x => x.paciente_id,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SignoVitales_TipoSignos_signoId",
                        column: x => x.signoId,
                        principalTable: "TipoSignos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enfermeras_paciente_id",
                table: "Enfermeras",
                column: "paciente_id");

            migrationBuilder.CreateIndex(
                name: "IX_FamiliaresDesignados_paciente_id",
                table: "FamiliaresDesignados",
                column: "paciente_id");

            migrationBuilder.CreateIndex(
                name: "IX_Historias_paciente_id",
                table: "Historias",
                column: "paciente_id");

            migrationBuilder.CreateIndex(
                name: "IX_Historias_sugerenciacuidado_id",
                table: "Historias",
                column: "sugerenciacuidado_id");

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_paciente_id",
                table: "Medicos",
                column: "paciente_id",
                unique: true,
                filter: "[paciente_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_Enfermera",
                table: "Pacientes",
                column: "Enfermera");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_medico_id",
                table: "Pacientes",
                column: "medico_id");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_paciente_id",
                table: "Pacientes",
                column: "paciente_id");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_genero_id",
                table: "Personas",
                column: "genero_id");

            migrationBuilder.CreateIndex(
                name: "IX_SignoVitales_paciente_id",
                table: "SignoVitales",
                column: "paciente_id");

            migrationBuilder.CreateIndex(
                name: "IX_SignoVitales_signoId",
                table: "SignoVitales",
                column: "signoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_Enfermeras_Enfermera",
                table: "Pacientes",
                column: "Enfermera",
                principalTable: "Enfermeras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_Medicos_medico_id",
                table: "Pacientes",
                column: "medico_id",
                principalTable: "Medicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enfermeras_Pacientes_paciente_id",
                table: "Enfermeras");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicos_Pacientes_paciente_id",
                table: "Medicos");

            migrationBuilder.DropTable(
                name: "FamiliaresDesignados");

            migrationBuilder.DropTable(
                name: "Historias");

            migrationBuilder.DropTable(
                name: "SignoVitales");

            migrationBuilder.DropTable(
                name: "sugerenciaCuidados");

            migrationBuilder.DropTable(
                name: "TipoSignos");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Enfermeras");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Generos");
        }
    }
}
