using Microsoft.EntityFrameworkCore.Migrations;

namespace HospiEnCasa.App.Persistencia.Migrations
{
    public partial class relacionesDemas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Medico_id",
                table: "Personas",
                newName: "historiaId");

            migrationBuilder.AddColumn<int>(
                name: "enfermeraId",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "familiarDesignadoId",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personas_enfermeraId",
                table: "Personas",
                column: "enfermeraId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_familiarDesignadoId",
                table: "Personas",
                column: "familiarDesignadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_historiaId",
                table: "Personas",
                column: "historiaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Historias_historiaId",
                table: "Personas",
                column: "historiaId",
                principalTable: "Historias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Personas_enfermeraId",
                table: "Personas",
                column: "enfermeraId",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Personas_familiarDesignadoId",
                table: "Personas",
                column: "familiarDesignadoId",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Historias_historiaId",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Personas_enfermeraId",
                table: "Personas");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Personas_familiarDesignadoId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_enfermeraId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_familiarDesignadoId",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_historiaId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "enfermeraId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "familiarDesignadoId",
                table: "Personas");

            migrationBuilder.RenameColumn(
                name: "historiaId",
                table: "Personas",
                newName: "Medico_id");
        }
    }
}
