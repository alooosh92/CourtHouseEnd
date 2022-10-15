using CourtHouse.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CourtHouse.Data.Repository
{
    public class RepBeneficiary : IRepository<Beneficiary>
    {
        public RepBeneficiary(ApplicationDbContext DB)
        {
            this.DB = DB;
        }
        public ApplicationDbContext DB { get; }
        public void Add(Beneficiary entety)
        {
            DB.Beneficiaries.Add(entety);            
        }

        public IList<Beneficiary> All()
        {
            return DB.Beneficiaries.Include(r => r.realtyContract.realty.region).Include(p => p.person.region).Include(w=>w.waysToCommunicate).ToList();
        }

        public void Delete(Beneficiary entety)
        {
            DB.Beneficiaries.Remove(entety);
        }

        public Beneficiary Find(string val)
        {
            return DB.Beneficiaries.Include(r => r.realtyContract.realty.region).Include(p => p.person.region).Include(w => w.waysToCommunicate).SingleOrDefault(a => a.id == val);
        }

        public void Save()
        {
            DB.SaveChanges();
        }

        public IList<Beneficiary> Search(string Contract)
        {
            return DB.Beneficiaries.Include(r => r.realtyContract.realty.region).Include(p => p.person.region).Include(w => w.waysToCommunicate)
                .Where(a => a.realtyContract.id == Contract).ToList();
        }

        public IList<Beneficiary> Search(string val1, string val2)
        {
            throw new NotImplementedException();
        }

        public void Update(Beneficiary entety)
        {
            DB.Beneficiaries.Update(entety);
        }
    }
}
