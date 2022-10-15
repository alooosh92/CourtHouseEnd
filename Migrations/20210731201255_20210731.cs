using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CourtHouse.Migrations
{
    public partial class _20210731 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "paymentMethods",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    paymentMethods = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    accountNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paymentMethods", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    regionName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    idNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    fatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    motherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    regionid = table.Column<int>(type: "int", nullable: true),
                    placeOFBirth = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    dateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    mobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    emailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    personImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    identityImageFront = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    identityImageBack = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.idNumber);
                    table.ForeignKey(
                        name: "FK_People_Regions_regionid",
                        column: x => x.regionid,
                        principalTable: "Regions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Realties",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    area = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    regionid = table.Column<int>(type: "int", nullable: true),
                    info = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    realtyType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    adress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    theFinancialValue = table.Column<double>(type: "float", nullable: false),
                    isChecked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Realties", x => x.id);
                    table.ForeignKey(
                        name: "FK_Realties_Regions_regionid",
                        column: x => x.regionid,
                        principalTable: "Regions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RealtyContracts",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    startDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    contractType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    realtyid = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    isChecked = table.Column<bool>(type: "bit", nullable: false),
                    isFinance = table.Column<bool>(type: "bit", nullable: false),
                    isJudge = table.Column<bool>(type: "bit", nullable: false),
                    isRecorder = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealtyContracts", x => x.id);
                    table.ForeignKey(
                        name: "FK_RealtyContracts_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RealtyContracts_Realties_realtyid",
                        column: x => x.realtyid,
                        principalTable: "Realties",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RealtyNotes",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    realtyid = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    noteType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    noteDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealtyNotes", x => x.id);
                    table.ForeignKey(
                        name: "FK_RealtyNotes_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RealtyNotes_Realties_realtyid",
                        column: x => x.realtyid,
                        principalTable: "Realties",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Beneficiaries",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    personidNumber = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    typePerson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    period = table.Column<double>(type: "float", nullable: false),
                    realtyContractid = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    isChecked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beneficiaries", x => x.id);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_People_personidNumber",
                        column: x => x.personidNumber,
                        principalTable: "People",
                        principalColumn: "idNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_RealtyContracts_realtyContractid",
                        column: x => x.realtyContractid,
                        principalTable: "RealtyContracts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Feeses",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    personidNumber = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    realtyContractid = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TheFinancialValue = table.Column<double>(type: "float", nullable: false),
                    paymentMethodid = table.Column<int>(type: "int", nullable: true),
                    financialNoticeNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isPayment = table.Column<bool>(type: "bit", nullable: false),
                    paymentImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feeses", x => x.id);
                    table.ForeignKey(
                        name: "FK_Feeses_paymentMethods_paymentMethodid",
                        column: x => x.paymentMethodid,
                        principalTable: "paymentMethods",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Feeses_People_personidNumber",
                        column: x => x.personidNumber,
                        principalTable: "People",
                        principalColumn: "idNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Feeses_RealtyContracts_realtyContractid",
                        column: x => x.realtyContractid,
                        principalTable: "RealtyContracts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OfficialDocuments",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    imageType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    realtyContractid = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    isChecked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficialDocuments", x => x.id);
                    table.ForeignKey(
                        name: "FK_OfficialDocuments_RealtyContracts_realtyContractid",
                        column: x => x.realtyContractid,
                        principalTable: "RealtyContracts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RealtyContractNotes",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    realtyContractid = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    noteType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    noteDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealtyContractNotes", x => x.id);
                    table.ForeignKey(
                        name: "FK_RealtyContractNotes_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RealtyContractNotes_RealtyContracts_realtyContractid",
                        column: x => x.realtyContractid,
                        principalTable: "RealtyContracts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_personidNumber",
                table: "Beneficiaries",
                column: "personidNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_realtyContractid",
                table: "Beneficiaries",
                column: "realtyContractid");

            migrationBuilder.CreateIndex(
                name: "IX_Feeses_paymentMethodid",
                table: "Feeses",
                column: "paymentMethodid");

            migrationBuilder.CreateIndex(
                name: "IX_Feeses_personidNumber",
                table: "Feeses",
                column: "personidNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Feeses_realtyContractid",
                table: "Feeses",
                column: "realtyContractid");

            migrationBuilder.CreateIndex(
                name: "IX_OfficialDocuments_realtyContractid",
                table: "OfficialDocuments",
                column: "realtyContractid");

            migrationBuilder.CreateIndex(
                name: "IX_People_regionid",
                table: "People",
                column: "regionid");

            migrationBuilder.CreateIndex(
                name: "IX_Realties_regionid",
                table: "Realties",
                column: "regionid");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyContractNotes_realtyContractid",
                table: "RealtyContractNotes",
                column: "realtyContractid");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyContractNotes_userId",
                table: "RealtyContractNotes",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyContracts_realtyid",
                table: "RealtyContracts",
                column: "realtyid");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyContracts_userId",
                table: "RealtyContracts",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyNotes_realtyid",
                table: "RealtyNotes",
                column: "realtyid");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyNotes_userId",
                table: "RealtyNotes",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Beneficiaries");

            migrationBuilder.DropTable(
                name: "Feeses");

            migrationBuilder.DropTable(
                name: "OfficialDocuments");

            migrationBuilder.DropTable(
                name: "RealtyContractNotes");

            migrationBuilder.DropTable(
                name: "RealtyNotes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "paymentMethods");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "RealtyContracts");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Realties");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
