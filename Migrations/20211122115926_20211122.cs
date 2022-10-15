using Microsoft.EntityFrameworkCore.Migrations;

namespace CourtHouse.Migrations
{
    public partial class _20211122 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "waysToCommunicateid",
                table: "Beneficiaries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_waysToCommunicateid",
                table: "Beneficiaries",
                column: "waysToCommunicateid");

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficiaries_WaysToCommunicate_waysToCommunicateid",
                table: "Beneficiaries",
                column: "waysToCommunicateid",
                principalTable: "WaysToCommunicate",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiaries_WaysToCommunicate_waysToCommunicateid",
                table: "Beneficiaries");

            migrationBuilder.DropIndex(
                name: "IX_Beneficiaries_waysToCommunicateid",
                table: "Beneficiaries");

            migrationBuilder.DropColumn(
                name: "waysToCommunicateid",
                table: "Beneficiaries");
        }
    }
}
