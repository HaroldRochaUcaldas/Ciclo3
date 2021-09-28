using Microsoft.EntityFrameworkCore.Migrations;

namespace HospiEnCasa.App.Persistencia.Migrations
{
    public partial class allentidades4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HistoriaId",
                table: "Pacientes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SignoVitalId",
                table: "Pacientes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "historias_id",
                table: "Pacientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "signovital_id",
                table: "Pacientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_HistoriaId",
                table: "Pacientes",
                column: "HistoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_SignoVitalId",
                table: "Pacientes",
                column: "SignoVitalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_Historias_HistoriaId",
                table: "Pacientes",
                column: "HistoriaId",
                principalTable: "Historias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_SignoVitales_SignoVitalId",
                table: "Pacientes",
                column: "SignoVitalId",
                principalTable: "SignoVitales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_Historias_HistoriaId",
                table: "Pacientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_SignoVitales_SignoVitalId",
                table: "Pacientes");

            migrationBuilder.DropIndex(
                name: "IX_Pacientes_HistoriaId",
                table: "Pacientes");

            migrationBuilder.DropIndex(
                name: "IX_Pacientes_SignoVitalId",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "HistoriaId",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "SignoVitalId",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "historias_id",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "signovital_id",
                table: "Pacientes");
        }
    }
}
