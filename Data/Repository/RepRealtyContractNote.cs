using CourtHouse.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CourtHouse.Data.Repository
{
    public class RepRealtyContractNote : IRepository<RealtyContractNote>
    {
        public RepRealtyContractNote(ApplicationDbContext DB)
        {
            this.DB = DB;
        }

        public ApplicationDbContext DB { get; }
        public void Add(RealtyContractNote entety)
        {
            DB.RealtyContractNotes.Add(entety);
        }

        public IList<RealtyContractNote> All()
        {
            return DB.RealtyContractNotes.Include(r => r.realtyContract.realty.region).Include(u => u.user).ToList();
        }

        public void Delete(RealtyContractNote entety)
        {
            DB.RealtyContractNotes.Remove(entety);
        }

        public RealtyContractNote Find(string val)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            DB.SaveChanges();
        }

        public IList<RealtyContractNote> Search(string realtyContracct)
        {
            return DB.RealtyContractNotes.Include(r => r.realtyContract.realty.region).Include(u => u.user)
                .Where(a => a.realtyContract.id == realtyContracct).ToList();
        }

        public IList<RealtyContractNote> Search(string val1, string val2)
        {
            throw new NotImplementedException();
        }

        public void Update(RealtyContractNote entety)
        {
            DB.RealtyContractNotes.Update(entety);
        }
    }
}
