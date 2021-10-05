using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospiEnCasa.App.Persistencia.Migrations
{
    public partial class tablaPersonaManual : Migration
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

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombres = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    apellidos = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    numeroTelefeno = table.Column<string>(type: "VARCHAR(12)", maxLength: 12, nullable: false),
                    genero_id = table.Column<int>(type: "int", nullable: false),
                    Medico_id = table.Column<int>(type: "int", nullable: false),
                    familiarDesignado_id = table.Column<int>(type: "int", nullable: false),
                    enfermera_id = table.Column<int>(type: "int", nullable: false),
                    historia_id = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tarjeta_profesional = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: true),
                    horas_laborales = table.Column<int>(type: "INTEGER", nullable: true),
                    parentesco = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: true),
                    correo = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: true),
                    Especialidad = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: true),
                    codigo = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: true),
                    registro_rethus = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: true),
                    direccion = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: true),
                    latitud = table.Column<double>(type: "FLOAT", nullable: true),
                    longitud = table.Column<double>(type: "FLOAT", nullable: true),
                    ciudad = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: true),
                    fechaNacimiento = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    medicoId = table.Column<int>(type: "int", nullable: true),
                    familiarDesignadoId = table.Column<int>(type: "int", nullable: true),
                    enfermeraId = table.Column<int>(type: "int", nullable: true),
                    historiaId = table.Column<int>(type: "int", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Personas_Historias_historiaId",
                        column: x => x.historiaId,
                        principalTable: "Historias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Personas_Personas_enfermeraId",
                        column: x => x.enfermeraId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Personas_Personas_familiarDesignadoId",
                        column: x => x.familiarDesignadoId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Personas_Personas_medicoId",
                        column: x => x.medicoId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Historias_SugerenciaCuidado_id",
                table: "Historias",
                column: "SugerenciaCuidado_id");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_enfermeraId",
                table: "Personas",
                column: "enfermeraId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_familiarDesignadoId",
                table: "Personas",
                column: "familiarDesignadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_genero_id",
                table: "Personas",
                column: "genero_id");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_historiaId",
                table: "Personas",
                column: "historiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_medicoId",
                table: "Personas",
                column: "medicoId");

            migrationBuilder.CreateIndex(
                name: "IX_SignoVitales_signoId",
                table: "SignoVitales",
                column: "signoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "SignoVitales");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropTable(
                name: "Historias");

            migrationBuilder.DropTable(
                name: "TipoSignos");

            migrationBuilder.DropTable(
                name: "SugerenciaCuidados");
        }
    }
}
