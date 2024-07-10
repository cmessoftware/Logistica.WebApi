using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Logistica.WebApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Routes",
                newName: "ToDate");

            migrationBuilder.AddColumn<bool>(
                name: "Available",
                table: "Vehicules",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Available",
                table: "Vehicules");

            migrationBuilder.RenameColumn(
                name: "ToDate",
                table: "Routes",
                newName: "DateTime");
        }
    }
}
