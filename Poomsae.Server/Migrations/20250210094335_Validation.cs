using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Poomsae.Server.Migrations
{
    /// <inheritdoc />
    public partial class Validation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Completion",
                table: "steps",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Completion",
                table: "sports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Completion",
                table: "katas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Completion",
                table: "clubs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Completion",
                table: "steps");

            migrationBuilder.DropColumn(
                name: "Completion",
                table: "sports");

            migrationBuilder.DropColumn(
                name: "Completion",
                table: "katas");

            migrationBuilder.DropColumn(
                name: "Completion",
                table: "clubs");
        }
    }
}
