using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rent_A_Dog.Migrations
{
    /// <inheritdoc />
    public partial class poss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeriNo",
                table: "KopekIlan");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "KopekIlan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "KopekIlan");

            migrationBuilder.AddColumn<int>(
                name: "SeriNo",
                table: "KopekIlan",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
