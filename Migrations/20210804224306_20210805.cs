using Microsoft.EntityFrameworkCore.Migrations;

namespace CourtHouse.Migrations
{
    public partial class _20210805 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiaries_RealtyContracts_realtyContractidRealtyContract",
                table: "Beneficiaries");

            migrationBuilder.DropForeignKey(
                name: "FK_Feeses_paymentMethods_paymentMethodidPaymentMethod",
                table: "Feeses");

            migrationBuilder.DropForeignKey(
                name: "FK_Feeses_RealtyContracts_realtyContractidRealtyContract",
                table: "Feeses");

            migrationBuilder.DropForeignKey(
                name: "FK_OfficialDocuments_RealtyContracts_realtyContractidRealtyContract",
                table: "OfficialDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Regions_regionidRegion",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_Realties_Regions_regionidRegion",
                table: "Realties");

            migrationBuilder.DropForeignKey(
                name: "FK_RealtyContractNotes_RealtyContracts_realtyContractidRealtyContract",
                table: "RealtyContractNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_RealtyContracts_Realties_realtyidRealty",
                table: "RealtyContracts");

            migrationBuilder.DropForeignKey(
                name: "FK_RealtyNotes_Realties_realtyidRealty",
                table: "RealtyNotes");

            migrationBuilder.RenameColumn(
                name: "idRegion",
                table: "Regions",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "realtyidRealty",
                table: "RealtyNotes",
                newName: "realtyid");

            migrationBuilder.RenameColumn(
                name: "idRealtyNote",
                table: "RealtyNotes",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_RealtyNotes_realtyidRealty",
                table: "RealtyNotes",
                newName: "IX_RealtyNotes_realtyid");

            migrationBuilder.RenameColumn(
                name: "realtyidRealty",
                table: "RealtyContracts",
                newName: "realtyid");

            migrationBuilder.RenameColumn(
                name: "idRealtyContract",
                table: "RealtyContracts",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_RealtyContracts_realtyidRealty",
                table: "RealtyContracts",
                newName: "IX_RealtyContracts_realtyid");

            migrationBuilder.RenameColumn(
                name: "realtyContractidRealtyContract",
                table: "RealtyContractNotes",
                newName: "realtyContractid");

            migrationBuilder.RenameColumn(
                name: "idRealtyContractNote",
                table: "RealtyContractNotes",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_RealtyContractNotes_realtyContractidRealtyContract",
                table: "RealtyContractNotes",
                newName: "IX_RealtyContractNotes_realtyContractid");

            migrationBuilder.RenameColumn(
                name: "regionidRegion",
                table: "Realties",
                newName: "regionid");

            migrationBuilder.RenameColumn(
                name: "idRealty",
                table: "Realties",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Realties_regionidRegion",
                table: "Realties",
                newName: "IX_Realties_regionid");

            migrationBuilder.RenameColumn(
                name: "regionidRegion",
                table: "People",
                newName: "regionid");

            migrationBuilder.RenameIndex(
                name: "IX_People_regionidRegion",
                table: "People",
                newName: "IX_People_regionid");

            migrationBuilder.RenameColumn(
                name: "idPaymentMethod",
                table: "paymentMethods",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "realtyContractidRealtyContract",
                table: "OfficialDocuments",
                newName: "realtyContractid");

            migrationBuilder.RenameColumn(
                name: "idOfficialDocument",
                table: "OfficialDocuments",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_OfficialDocuments_realtyContractidRealtyContract",
                table: "OfficialDocuments",
                newName: "IX_OfficialDocuments_realtyContractid");

            migrationBuilder.RenameColumn(
                name: "realtyContractidRealtyContract",
                table: "Feeses",
                newName: "realtyContractid");

            migrationBuilder.RenameColumn(
                name: "paymentMethodidPaymentMethod",
                table: "Feeses",
                newName: "paymentMethodid");

            migrationBuilder.RenameColumn(
                name: "idFees",
                table: "Feeses",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Feeses_realtyContractidRealtyContract",
                table: "Feeses",
                newName: "IX_Feeses_realtyContractid");

            migrationBuilder.RenameIndex(
                name: "IX_Feeses_paymentMethodidPaymentMethod",
                table: "Feeses",
                newName: "IX_Feeses_paymentMethodid");

            migrationBuilder.RenameColumn(
                name: "realtyContractidRealtyContract",
                table: "Beneficiaries",
                newName: "realtyContractid");

            migrationBuilder.RenameColumn(
                name: "idBeneficiary",
                table: "Beneficiaries",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Beneficiaries_realtyContractidRealtyContract",
                table: "Beneficiaries",
                newName: "IX_Beneficiaries_realtyContractid");

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficiaries_RealtyContracts_realtyContractid",
                table: "Beneficiaries",
                column: "realtyContractid",
                principalTable: "RealtyContracts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Feeses_paymentMethods_paymentMethodid",
                table: "Feeses",
                column: "paymentMethodid",
                principalTable: "paymentMethods",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Feeses_RealtyContracts_realtyContractid",
                table: "Feeses",
                column: "realtyContractid",
                principalTable: "RealtyContracts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OfficialDocuments_RealtyContracts_realtyContractid",
                table: "OfficialDocuments",
                column: "realtyContractid",
                principalTable: "RealtyContracts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Regions_regionid",
                table: "People",
                column: "regionid",
                principalTable: "Regions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Realties_Regions_regionid",
                table: "Realties",
                column: "regionid",
                principalTable: "Regions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RealtyContractNotes_RealtyContracts_realtyContractid",
                table: "RealtyContractNotes",
                column: "realtyContractid",
                principalTable: "RealtyContracts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Beneficiaries_RealtyContracts_realtyContractid",
                table: "Beneficiaries");

            migrationBuilder.DropForeignKey(
                name: "FK_Feeses_paymentMethods_paymentMethodid",
                table: "Feeses");

            migrationBuilder.DropForeignKey(
                name: "FK_Feeses_RealtyContracts_realtyContractid",
                table: "Feeses");

            migrationBuilder.DropForeignKey(
                name: "FK_OfficialDocuments_RealtyContracts_realtyContractid",
                table: "OfficialDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Regions_regionid",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_Realties_Regions_regionid",
                table: "Realties");

            migrationBuilder.DropForeignKey(
                name: "FK_RealtyContractNotes_RealtyContracts_realtyContractid",
                table: "RealtyContractNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_RealtyContracts_Realties_realtyid",
                table: "RealtyContracts");

            migrationBuilder.DropForeignKey(
                name: "FK_RealtyNotes_Realties_realtyid",
                table: "RealtyNotes");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Regions",
                newName: "idRegion");

            migrationBuilder.RenameColumn(
                name: "realtyid",
                table: "RealtyNotes",
                newName: "realtyidRealty");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "RealtyNotes",
                newName: "idRealtyNote");

            migrationBuilder.RenameIndex(
                name: "IX_RealtyNotes_realtyid",
                table: "RealtyNotes",
                newName: "IX_RealtyNotes_realtyidRealty");

            migrationBuilder.RenameColumn(
                name: "realtyid",
                table: "RealtyContracts",
                newName: "realtyidRealty");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "RealtyContracts",
                newName: "idRealtyContract");

            migrationBuilder.RenameIndex(
                name: "IX_RealtyContracts_realtyid",
                table: "RealtyContracts",
                newName: "IX_RealtyContracts_realtyidRealty");

            migrationBuilder.RenameColumn(
                name: "realtyContractid",
                table: "RealtyContractNotes",
                newName: "realtyContractidRealtyContract");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "RealtyContractNotes",
                newName: "idRealtyContractNote");

            migrationBuilder.RenameIndex(
                name: "IX_RealtyContractNotes_realtyContractid",
                table: "RealtyContractNotes",
                newName: "IX_RealtyContractNotes_realtyContractidRealtyContract");

            migrationBuilder.RenameColumn(
                name: "regionid",
                table: "Realties",
                newName: "regionidRegion");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Realties",
                newName: "idRealty");

            migrationBuilder.RenameIndex(
                name: "IX_Realties_regionid",
                table: "Realties",
                newName: "IX_Realties_regionidRegion");

            migrationBuilder.RenameColumn(
                name: "regionid",
                table: "People",
                newName: "regionidRegion");

            migrationBuilder.RenameIndex(
                name: "IX_People_regionid",
                table: "People",
                newName: "IX_People_regionidRegion");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "paymentMethods",
                newName: "idPaymentMethod");

            migrationBuilder.RenameColumn(
                name: "realtyContractid",
                table: "OfficialDocuments",
                newName: "realtyContractidRealtyContract");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "OfficialDocuments",
                newName: "idOfficialDocument");

            migrationBuilder.RenameIndex(
                name: "IX_OfficialDocuments_realtyContractid",
                table: "OfficialDocuments",
                newName: "IX_OfficialDocuments_realtyContractidRealtyContract");

            migrationBuilder.RenameColumn(
                name: "realtyContractid",
                table: "Feeses",
                newName: "realtyContractidRealtyContract");

            migrationBuilder.RenameColumn(
                name: "paymentMethodid",
                table: "Feeses",
                newName: "paymentMethodidPaymentMethod");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Feeses",
                newName: "idFees");

            migrationBuilder.RenameIndex(
                name: "IX_Feeses_realtyContractid",
                table: "Feeses",
                newName: "IX_Feeses_realtyContractidRealtyContract");

            migrationBuilder.RenameIndex(
                name: "IX_Feeses_paymentMethodid",
                table: "Feeses",
                newName: "IX_Feeses_paymentMethodidPaymentMethod");

            migrationBuilder.RenameColumn(
                name: "realtyContractid",
                table: "Beneficiaries",
                newName: "realtyContractidRealtyContract");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Beneficiaries",
                newName: "idBeneficiary");

            migrationBuilder.RenameIndex(
                name: "IX_Beneficiaries_realtyContractid",
                table: "Beneficiaries",
                newName: "IX_Beneficiaries_realtyContractidRealtyContract");

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficiaries_RealtyContracts_realtyContractidRealtyContract",
                table: "Beneficiaries",
                column: "realtyContractidRealtyContract",
                principalTable: "RealtyContracts",
                principalColumn: "idRealtyContract",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Feeses_paymentMethods_paymentMethodidPaymentMethod",
                table: "Feeses",
                column: "paymentMethodidPaymentMethod",
                principalTable: "paymentMethods",
                principalColumn: "idPaymentMethod",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Feeses_RealtyContracts_realtyContractidRealtyContract",
                table: "Feeses",
                column: "realtyContractidRealtyContract",
                principalTable: "RealtyContracts",
                principalColumn: "idRealtyContract",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OfficialDocuments_RealtyContracts_realtyContractidRealtyContract",
                table: "OfficialDocuments",
                column: "realtyContractidRealtyContract",
                principalTable: "RealtyContracts",
                principalColumn: "idRealtyContract",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Regions_regionidRegion",
                table: "People",
                column: "regionidRegion",
                principalTable: "Regions",
                principalColumn: "idRegion",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Realties_Regions_regionidRegion",
                table: "Realties",
                column: "regionidRegion",
                principalTable: "Regions",
                principalColumn: "idRegion",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RealtyContractNotes_RealtyContracts_realtyContractidRealtyContract",
                table: "RealtyContractNotes",
                column: "realtyContractidRealtyContract",
                principalTable: "RealtyContracts",
                principalColumn: "idRealtyContract",
                onDelete: ReferentialAction.Restrict);

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
