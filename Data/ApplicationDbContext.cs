using CourtHouse.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CourtHouse.Data.ViewModels;

namespace CourtHouse.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Beneficiary> Beneficiaries { get; set; }
        public DbSet<Fees> Feeses { get; set; }
        public DbSet<OfficialDocument> OfficialDocuments { get; set; }
        public DbSet<PaymentMethod> paymentMethods { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Realty> Realties { get; set; }
        public DbSet<RealtyContract> RealtyContracts { get; set; }
        public DbSet<RealtyContractNote> RealtyContractNotes { get; set; }
        public DbSet<RealtyNote> RealtyNotes { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<WaysToCommunicate> WaysToCommunicate { get; set; }
        public DbSet<CourtHouse.Models.RegionInfo> RegionInfo { get; set; }
    }
}
