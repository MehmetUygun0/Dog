using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rent_A_Dog.Migrations
{
    /// <inheritdoc />
    public partial class qerr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "TeklifGelmismi",
                table: "KopekIlan",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Views",
                table: "KopekIlan",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeklifGelmismi",
                table: "KopekIlan");

            migrationBuilder.DropColumn(
                name: "Views",
                table: "KopekIlan");
        }
    }
}
