using Microsoft.EntityFrameworkCore.Migrations;

namespace CourtHouse.Migrations
{
    public partial class _20210828 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isAddFinance",
                table: "RealtyContracts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "judgment",
                table: "RealtyContracts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isAddFinance",
                table: "RealtyContracts");

            migrationBuilder.DropColumn(
                name: "judgment",
                table: "RealtyContracts");
        }
    }
}
