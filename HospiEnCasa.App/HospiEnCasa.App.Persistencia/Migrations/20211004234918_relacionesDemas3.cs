using Microsoft.EntityFrameworkCore.Migrations;

namespace HospiEnCasa.App.Persistencia.Migrations
{
    public partial class relacionesDemas3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Medico_id",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "enfermera_id",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "familiarDesignado_id",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "historia_id",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "signoVital_id",
                table: "Personas",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Medico_id",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "enfermera_id",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "familiarDesignado_id",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "historia_id",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "signoVital_id",
                table: "Personas");
        }
    }
}
