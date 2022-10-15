using Microsoft.EntityFrameworkCore.Migrations;

namespace CourtHouse.Migrations
{
    public partial class _20211121 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isPayFinance",
                table: "RealtyContracts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "wayToCommunicateid",
                table: "People",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WaysToCommunicate",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    wayName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaysToCommunicate", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_People_wayToCommunicateid",
                table: "People",
                column: "wayToCommunicateid");

            migrationBuilder.AddForeignKey(
                name: "FK_People_WaysToCommunicate_wayToCommunicateid",
                table: "People",
                column: "wayToCommunicateid",
                principalTable: "WaysToCommunicate",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_WaysToCommunicate_wayToCommunicateid",
                table: "People");

            migrationBuilder.DropTable(
                name: "WaysToCommunicate");

            migrationBuilder.DropIndex(
                name: "IX_People_wayToCommunicateid",
                table: "People");

            migrationBuilder.DropColumn(
                name: "isPayFinance",
                table: "RealtyContracts");

            migrationBuilder.DropColumn(
                name: "wayToCommunicateid",
                table: "People");
        }
    }
}
