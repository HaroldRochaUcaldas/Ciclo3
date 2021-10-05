using Microsoft.EntityFrameworkCore.Migrations;

namespace HospiEnCasa.App.Persistencia.Migrations
{
    public partial class relacionMedico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Historias_HistoriaId",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_SignoVitales_SignoVitalId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_HistoriaId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_SignoVitalId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "HistoriaId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "SignoVitalId",
                table: "Personas");

            migrationBuilder.RenameColumn(
                name: "signovital_id",
                table: "Personas",
                newName: "medicoId");

            migrationBuilder.RenameColumn(
                name: "nombre",
                table: "Personas",
                newName: "nombres");

            migrationBuilder.RenameColumn(
                name: "historias_id",
                table: "Personas",
                newName: "Medico_id");

            migrationBuilder.RenameColumn(
                name: "fecha",
                table: "Personas",
                newName: "fechaNacimiento");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_medicoId",
                table: "Personas",
                column: "medicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Personas_medicoId",
                table: "Personas",
                column: "medicoId",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Personas_medicoId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_medicoId",
                table: "Personas");

            migrationBuilder.RenameColumn(
                name: "nombres",
                table: "Personas",
                newName: "nombre");

            migrationBuilder.RenameColumn(
                name: "medicoId",
                table: "Personas",
                newName: "signovital_id");

            migrationBuilder.RenameColumn(
                name: "fechaNacimiento",
                table: "Personas",
                newName: "fecha");

            migrationBuilder.RenameColumn(
                name: "Medico_id",
                table: "Personas",
                newName: "historias_id");

            migrationBuilder.AddColumn<int>(
                name: "HistoriaId",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SignoVitalId",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personas_HistoriaId",
                table: "Personas",
                column: "HistoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_SignoVitalId",
                table: "Personas",
                column: "SignoVitalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Historias_HistoriaId",
                table: "Personas",
                column: "HistoriaId",
                principalTable: "Historias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_SignoVitales_SignoVitalId",
                table: "Personas",
                column: "SignoVitalId",
                principalTable: "SignoVitales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
