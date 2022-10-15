using Microsoft.EntityFrameworkCore.Migrations;

namespace CourtHouse.Migrations
{
    public partial class _20220214 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "faceId",
                table: "Beneficiaries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "RegionInfo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    regionid = table.Column<int>(type: "int", nullable: true),
                    NumAllCases = table.Column<int>(type: "int", nullable: false),
                    NumEndCasesInThisMonth = table.Column<int>(type: "int", nullable: false),
                    NumUnfinishedCases = table.Column<int>(type: "int", nullable: false),
                    AvaregDelayInCase = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionInfo", x => x.id);
                    table.ForeignKey(
                        name: "FK_RegionInfo_Regions_regionid",
                        column: x => x.regionid,
                        principalTable: "Regions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegionInfo_regionid",
                table: "RegionInfo",
                column: "regionid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegionInfo");

            migrationBuilder.DropColumn(
                name: "faceId",
                table: "Beneficiaries");
        }
    }
}
