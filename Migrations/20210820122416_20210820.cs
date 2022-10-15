using Microsoft.EntityFrameworkCore.Migrations;

namespace CourtHouse.Migrations
{
    public partial class _20210820 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealtyContracts_Realties_realtyidRealty",
                table: "RealtyContracts");

            migrationBuilder.DropForeignKey(
                name: "FK_RealtyNotes_Realties_realtyidRealty",
                table: "RealtyNotes");

            migrationBuilder.RenameColumn(
                name: "realtyidRealty",
                table: "RealtyNotes",
                newName: "realtyid");

            migrationBuilder.RenameIndex(
                name: "IX_RealtyNotes_realtyidRealty",
                table: "RealtyNotes",
                newName: "IX_RealtyNotes_realtyid");

            migrationBuilder.RenameColumn(
                name: "realtyidRealty",
                table: "RealtyContracts",
                newName: "realtyid");

            migrationBuilder.RenameIndex(
                name: "IX_RealtyContracts_realtyidRealty",
                table: "RealtyContracts",
                newName: "IX_RealtyContracts_realtyid");

            migrationBuilder.RenameColumn(
                name: "idRealty",
                table: "Realties",
                newName: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_RealtyContracts_Realties_realtyid",
                table: "RealtyContracts",
                column: "realtyid",
                principalTable: "Realties",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RealtyNotes_Realties_realtyid",
                table: "RealtyNotes",
                column: "realtyid",
                principalTable: "Realties",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealtyContracts_Realties_realtyid",
                table: "RealtyContracts");

            migrationBuilder.DropForeignKey(
                name: "FK_RealtyNotes_Realties_realtyid",
                table: "RealtyNotes");

            migrationBuilder.RenameColumn(
                name: "realtyid",
                table: "RealtyNotes",
                newName: "realtyidRealty");

            migrationBuilder.RenameIndex(
                name: "IX_RealtyNotes_realtyid",
                table: "RealtyNotes",
                newName: "IX_RealtyNotes_realtyidRealty");

            migrationBuilder.RenameColumn(
                name: "realtyid",
                table: "RealtyContracts",
                newName: "realtyidRealty");

            migrationBuilder.RenameIndex(
                name: "IX_RealtyContracts_realtyid",
                table: "RealtyContracts",
                newName: "IX_RealtyContracts_realtyidRealty");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Realties",
                newName: "idRealty");

            migrationBuilder.AddForeignKey(
                name: "FK_RealtyContracts_Realties_realtyidRealty",
                table: "RealtyContracts",
                column: "realtyidRealty",
                principalTable: "Realties",
                principalColumn: "idRealty",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RealtyNotes_Realties_realtyidRealty",
                table: "RealtyNotes",
                column: "realtyidRealty",
                principalTable: "Realties",
                principalColumn: "idRealty",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
