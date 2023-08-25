using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rent_A_Dog.Migrations
{
    /// <inheritdoc />
    public partial class IlanId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IlanId",
                table: "Teklif",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IlanId",
                table: "Teklif");
        }
    }
}
