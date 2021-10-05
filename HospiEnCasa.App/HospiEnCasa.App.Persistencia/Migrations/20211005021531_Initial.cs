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
                name: "Historias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    diagnostico = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: false),
                    entorno = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: false),
                    sugerenciacuidado_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Historias_sugerenciaCuidados_sugerenciacuidado_id",
                        column: x => x.sugerenciacuidado_id,
                        principalTable: "sugerenciaCuidados",
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

            migrationBuilder.CreateTable(
                name: "Enfermeras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    tarjeta_profesional = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    horas_laborales = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enfermeras", x => x.Id);
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
                    correo = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamiliaresDesignados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamiliaresDesignados_Personas_Id",
                        column: x => x.Id,
                        principalTable: "Personas",
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
                    registro_rethus = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicos_Personas_Id",
                        column: x => x.Id,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    enfermera_id = table.Column<int>(type: "int", nullable: false),
                    familiarDesignado_id = table.Column<int>(type: "int", nullable: false),
                    historia_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacientes_Enfermeras_enfermera_id",
                        column: x => x.enfermera_id,
                        principalTable: "Enfermeras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pacientes_FamiliaresDesignados_familiarDesignado_id",
                        column: x => x.familiarDesignado_id,
                        principalTable: "FamiliaresDesignados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pacientes_Historias_historia_id",
                        column: x => x.historia_id,
                        principalTable: "Historias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pacientes_Medicos_medico_id",
                        column: x => x.medico_id,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pacientes_Personas_Id",
                        column: x => x.Id,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Historias_sugerenciacuidado_id",
                table: "Historias",
                column: "sugerenciacuidado_id");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_enfermera_id",
                table: "Pacientes",
                column: "enfermera_id");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_familiarDesignado_id",
                table: "Pacientes",
                column: "familiarDesignado_id");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_historia_id",
                table: "Pacientes",
                column: "historia_id");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_medico_id",
                table: "Pacientes",
                column: "medico_id");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_genero_id",
                table: "Personas",
                column: "genero_id");

            migrationBuilder.CreateIndex(
                name: "IX_SignoVitales_signoId",
                table: "SignoVitales",
                column: "signoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "SignoVitales");

            migrationBuilder.DropTable(
                name: "Enfermeras");

            migrationBuilder.DropTable(
                name: "FamiliaresDesignados");

            migrationBuilder.DropTable(
                name: "Historias");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "TipoSignos");

            migrationBuilder.DropTable(
                name: "sugerenciaCuidados");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Generos");
        }
    }
}
