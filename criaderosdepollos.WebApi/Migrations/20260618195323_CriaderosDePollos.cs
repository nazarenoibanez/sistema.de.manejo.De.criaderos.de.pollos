using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CriaderosDePollos.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class CriaderosDePollos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "controlID",
                table: "ControlDePeso");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "controlID",
                table: "ControlDePeso",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
