using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CriaderosDePollos.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class FixRetirro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RetiroDePollos_ControlDePeso_controlID",
                table: "RetiroDePollos");

            migrationBuilder.RenameColumn(
                name: "controlID",
                table: "RetiroDePollos",
                newName: "ControlDePesoId");

            migrationBuilder.RenameIndex(
                name: "IX_RetiroDePollos_controlID",
                table: "RetiroDePollos",
                newName: "IX_RetiroDePollos_ControlDePesoId");

            migrationBuilder.AddForeignKey(
                name: "FK_RetiroDePollos_ControlDePeso_ControlDePesoId",
                table: "RetiroDePollos",
                column: "ControlDePesoId",
                principalTable: "ControlDePeso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RetiroDePollos_ControlDePeso_ControlDePesoId",
                table: "RetiroDePollos");

            migrationBuilder.RenameColumn(
                name: "ControlDePesoId",
                table: "RetiroDePollos",
                newName: "controlID");

            migrationBuilder.RenameIndex(
                name: "IX_RetiroDePollos_ControlDePesoId",
                table: "RetiroDePollos",
                newName: "IX_RetiroDePollos_controlID");

            migrationBuilder.AddForeignKey(
                name: "FK_RetiroDePollos_ControlDePeso_controlID",
                table: "RetiroDePollos",
                column: "controlID",
                principalTable: "ControlDePeso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
