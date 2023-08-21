using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rent_A_Dog.Migrations
{
    /// <inheritdoc />
    public partial class teklif28 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Teklif",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Teklif");
        }
    }
}
