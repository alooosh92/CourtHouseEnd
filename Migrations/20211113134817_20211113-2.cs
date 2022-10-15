using Microsoft.EntityFrameworkCore.Migrations;

namespace CourtHouse.Migrations
{
    public partial class _202111132 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "createById",
                table: "Realties",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Realties_createById",
                table: "Realties",
                column: "createById");

            migrationBuilder.AddForeignKey(
                name: "FK_Realties_AspNetUsers_createById",
                table: "Realties",
                column: "createById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Realties_AspNetUsers_createById",
                table: "Realties");

            migrationBuilder.DropIndex(
                name: "IX_Realties_createById",
                table: "Realties");

            migrationBuilder.DropColumn(
                name: "createById",
                table: "Realties");
        }
    }
}
