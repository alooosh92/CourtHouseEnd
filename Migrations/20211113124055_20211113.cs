using Microsoft.EntityFrameworkCore.Migrations;

namespace CourtHouse.Migrations
{
    public partial class _20211113 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "checkerId",
                table: "RealtyContracts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "financeId",
                table: "RealtyContracts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "judgeId",
                table: "RealtyContracts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "regionid",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RealtyContracts_checkerId",
                table: "RealtyContracts",
                column: "checkerId");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyContracts_financeId",
                table: "RealtyContracts",
                column: "financeId");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyContracts_judgeId",
                table: "RealtyContracts",
                column: "judgeId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_regionid",
                table: "AspNetUsers",
                column: "regionid");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Regions_regionid",
                table: "AspNetUsers",
                column: "regionid",
                principalTable: "Regions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RealtyContracts_AspNetUsers_checkerId",
                table: "RealtyContracts",
                column: "checkerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RealtyContracts_AspNetUsers_financeId",
                table: "RealtyContracts",
                column: "financeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RealtyContracts_AspNetUsers_judgeId",
                table: "RealtyContracts",
                column: "judgeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Regions_regionid",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_RealtyContracts_AspNetUsers_checkerId",
                table: "RealtyContracts");

            migrationBuilder.DropForeignKey(
                name: "FK_RealtyContracts_AspNetUsers_financeId",
                table: "RealtyContracts");

            migrationBuilder.DropForeignKey(
                name: "FK_RealtyContracts_AspNetUsers_judgeId",
                table: "RealtyContracts");

            migrationBuilder.DropIndex(
                name: "IX_RealtyContracts_checkerId",
                table: "RealtyContracts");

            migrationBuilder.DropIndex(
                name: "IX_RealtyContracts_financeId",
                table: "RealtyContracts");

            migrationBuilder.DropIndex(
                name: "IX_RealtyContracts_judgeId",
                table: "RealtyContracts");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_regionid",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "checkerId",
                table: "RealtyContracts");

            migrationBuilder.DropColumn(
                name: "financeId",
                table: "RealtyContracts");

            migrationBuilder.DropColumn(
                name: "judgeId",
                table: "RealtyContracts");

            migrationBuilder.DropColumn(
                name: "regionid",
                table: "AspNetUsers");
        }
    }
}
