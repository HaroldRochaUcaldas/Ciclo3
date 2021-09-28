using Microsoft.EntityFrameworkCore.Migrations;

namespace HospiEnCasa.App.Persistencia.Migrations
{
    public partial class allentidades3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SugerenciaCuidado_id",
                table: "Historias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Historias_SugerenciaCuidado_id",
                table: "Historias",
                column: "SugerenciaCuidado_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Historias_sugerenciaCuidados_SugerenciaCuidado_id",
                table: "Historias",
                column: "SugerenciaCuidado_id",
                principalTable: "sugerenciaCuidados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Historias_sugerenciaCuidados_SugerenciaCuidado_id",
                table: "Historias");

            migrationBuilder.DropIndex(
                name: "IX_Historias_SugerenciaCuidado_id",
                table: "Historias");

            migrationBuilder.DropColumn(
                name: "SugerenciaCuidado_id",
                table: "Historias");
        }
    }
}
