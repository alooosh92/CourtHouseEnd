﻿// <auto-generated />
using System;
using CourtHouse.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CourtHouse.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210820122416_20210820")]
    partial class _20210820
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CourtHouse.Models.Beneficiary", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("isChecked")
                        .HasColumnType("bit");

                    b.Property<double>("period")
                        .HasColumnType("float");

                    b.Property<string>("personidNumber")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("realtyContractid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("typePerson")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("personidNumber");

                    b.HasIndex("realtyContractid");

                    b.ToTable("Beneficiaries");
                });

            modelBuilder.Entity("CourtHouse.Models.Fees", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("financialNoticeNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isPayment")
                        .HasColumnType("bit");

                    b.Property<string>("paymentImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("paymentMethodid")
                        .HasColumnType("int");

                    b.Property<string>("personidNumber")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("realtyContractid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("reasonOfPayment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("theFinancialValue")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.HasIndex("paymentMethodid");

                    b.HasIndex("personidNumber");

                    b.HasIndex("realtyContractid");

                    b.ToTable("Feeses");
                });

            modelBuilder.Entity("CourtHouse.Models.OfficialDocument", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imageType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("isChecked")
                        .HasColumnType("bit");

                    b.Property<string>("realtyContractid")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("id");

                    b.HasIndex("realtyContractid");

                    b.ToTable("OfficialDocuments");
                });

            modelBuilder.Entity("CourtHouse.Models.PaymentMethod", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("accountNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<double>("amount")
                        .HasColumnType("float");

                    b.Property<string>("paymentMethods")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.ToTable("paymentMethods");
                });

            modelBuilder.Entity("CourtHouse.Models.Person", b =>
                {
                    b.Property<string>("idNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("emailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fatherName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("identityImageBack")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("identityImageFront")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("mobile")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("motherName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("nationality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("personImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("placeOFBirth")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("regionid")
                        .HasColumnType("int");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idNumber");

                    b.HasIndex("regionid");

                    b.ToTable("People");
                });

            modelBuilder.Entity("CourtHouse.Models.Realty", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("adress")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("area")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("info")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("isChecked")
                        .HasColumnType("bit");

                    b.Property<string>("realtyType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("regionid")
                        .HasColumnType("int");

                    b.Property<double>("theFinancialValue")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.HasIndex("regionid");

                    b.ToTable("Realties");
                });

            modelBuilder.Entity("CourtHouse.Models.RealtyContract", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("contractType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("isChecked")
                        .HasColumnType("bit");

                    b.Property<bool>("isFinance")
                        .HasColumnType("bit");

                    b.Property<bool>("isJudge")
                        .HasColumnType("bit");

                    b.Property<bool>("isRecorder")
                        .HasColumnType("bit");

                    b.Property<string>("realtyid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("userId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("id");

                    b.HasIndex("realtyid");

                    b.HasIndex("userId");

                    b.ToTable("RealtyContracts");
                });

            modelBuilder.Entity("CourtHouse.Models.RealtyContractNote", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("noteDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("noteType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("realtyContractid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("userId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("id");

                    b.HasIndex("realtyContractid");

                    b.HasIndex("userId");

                    b.ToTable("RealtyContractNotes");
                });

            modelBuilder.Entity("CourtHouse.Models.RealtyNote", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("noteDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("noteType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("realtyid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("userId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("id");

                    b.HasIndex("realtyid");

                    b.HasIndex("userId");

                    b.ToTable("RealtyNotes");
                });

            modelBuilder.Entity("CourtHouse.Models.Region", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("regionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CourtHouse.Models.User", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.HasDiscriminator().HasValue("User");
                });

            modelBuilder.Entity("CourtHouse.Models.Beneficiary", b =>
                {
                    b.HasOne("CourtHouse.Models.Person", "person")
                        .WithMany()
                        .HasForeignKey("personidNumber");

                    b.HasOne("CourtHouse.Models.RealtyContract", "realtyContract")
                        .WithMany()
                        .HasForeignKey("realtyContractid");

                    b.Navigation("person");

                    b.Navigation("realtyContract");
                });

            modelBuilder.Entity("CourtHouse.Models.Fees", b =>
                {
                    b.HasOne("CourtHouse.Models.PaymentMethod", "paymentMethod")
                        .WithMany()
                        .HasForeignKey("paymentMethodid");

                    b.HasOne("CourtHouse.Models.Person", "person")
                        .WithMany()
                        .HasForeignKey("personidNumber");

                    b.HasOne("CourtHouse.Models.RealtyContract", "realtyContract")
                        .WithMany()
                        .HasForeignKey("realtyContractid");

                    b.Navigation("paymentMethod");

                    b.Navigation("person");

                    b.Navigation("realtyContract");
                });

            modelBuilder.Entity("CourtHouse.Models.OfficialDocument", b =>
                {
                    b.HasOne("CourtHouse.Models.RealtyContract", "realtyContract")
                        .WithMany()
                        .HasForeignKey("realtyContractid");

                    b.Navigation("realtyContract");
                });

            modelBuilder.Entity("CourtHouse.Models.Person", b =>
                {
                    b.HasOne("CourtHouse.Models.Region", "region")
                        .WithMany()
                        .HasForeignKey("regionid");

                    b.Navigation("region");
                });

            modelBuilder.Entity("CourtHouse.Models.Realty", b =>
                {
                    b.HasOne("CourtHouse.Models.Region", "region")
                        .WithMany()
                        .HasForeignKey("regionid");

                    b.Navigation("region");
                });

            modelBuilder.Entity("CourtHouse.Models.RealtyContract", b =>
                {
                    b.HasOne("CourtHouse.Models.Realty", "realty")
                        .WithMany()
                        .HasForeignKey("realtyid");

                    b.HasOne("CourtHouse.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("userId");

                    b.Navigation("realty");

                    b.Navigation("user");
                });

            modelBuilder.Entity("CourtHouse.Models.RealtyContractNote", b =>
                {
                    b.HasOne("CourtHouse.Models.RealtyContract", "realtyContract")
                        .WithMany()
                        .HasForeignKey("realtyContractid");

                    b.HasOne("CourtHouse.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("userId");

                    b.Navigation("realtyContract");

                    b.Navigation("user");
                });

            modelBuilder.Entity("CourtHouse.Models.RealtyNote", b =>
                {
                    b.HasOne("CourtHouse.Models.Realty", "realty")
                        .WithMany()
                        .HasForeignKey("realtyid");

                    b.HasOne("CourtHouse.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("userId");

                    b.Navigation("realty");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
