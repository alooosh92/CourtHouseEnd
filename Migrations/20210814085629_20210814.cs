using Microsoft.EntityFrameworkCore.Migrations;

namespace CourtHouse.Migrations
{
    public partial class _20210814 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TheFinancialValue",
                table: "Feeses",
                newName: "theFinancialValue");

            migrationBuilder.AddColumn<string>(
                name: "reasonOfPayment",
                table: "Feeses",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "reasonOfPayment",
                table: "Feeses");

            migrationBuilder.RenameColumn(
                name: "theFinancialValue",
                table: "Feeses",
                newName: "TheFinancialValue");
        }
    }
}
