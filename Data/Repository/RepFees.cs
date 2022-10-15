using CourtHouse.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CourtHouse.Data.Repository
{
    public class RepFees : IRepository<Fees>
    {
        public RepFees(ApplicationDbContext DB)
        {
            this.DB = DB;
        }

        public ApplicationDbContext DB { get; }
        public void Add(Fees entety)
        {
            DB.Feeses.Add(entety);
        }

        public IList<Fees> All()
        {
            return DB.Feeses.Include(p => p.paymentMethod).Include(p => p.person.region)
                .Include(r => r.realtyContract.realty.region).ToList();
        }

        public void Delete(Fees entety)
        {
            DB.Feeses.Remove(entety);
        }

        public Fees Find(string id)
        {
            return DB.Feeses.Include(p => p.paymentMethod).Include(p => p.person.region)
                .Include(r => r.realtyContract.realty.region).
                SingleOrDefault(a => a.id == id);
        }

        public void Save()
        {
            DB.SaveChanges();
        }

        public IList<Fees> Search(string realtyContract)
        {
            return DB.Feeses.Include(p => p.paymentMethod).Include(p => p.person.region)
                .Include(r => r.realtyContract.realty.region).Where(a =>a.realtyContract.id == realtyContract).ToList();
        }

        public IList<Fees> Search(string val1, string val2)
        {
            throw new NotImplementedException();
        }

        public void Update(Fees entety)
        {
            DB.Feeses.Update(entety);
        }
    }
}
