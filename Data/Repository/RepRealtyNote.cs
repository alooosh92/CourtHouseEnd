using CourtHouse.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CourtHouse.Data.Repository
{
    public class RepRealtyNote : IRepository<RealtyNote>
    {
        public RepRealtyNote(ApplicationDbContext DB)
        {
            this.DB = DB;
        }

        public ApplicationDbContext DB { get; }
        public void Add(RealtyNote entety)
        {
            DB.RealtyNotes.Add(entety);
        }

        public IList<RealtyNote> All()
        {
            return DB.RealtyNotes.Include(r => r.realty.region).Include(u => u.user).ToList();
        }

        public void Delete(RealtyNote entety)
        {
            DB.RealtyNotes.Remove(entety);
        }

        public RealtyNote Find(string val)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            DB.SaveChanges();
        }

        public IList<RealtyNote> Search(string RealtyId)
        {
            return DB.RealtyNotes.Include(r => r.realty.region).Include(u=>u.user)
                .Where(a => a.realty.id == RealtyId).ToList();
        }

        public IList<RealtyNote> Search(string val1, string val2)
        {
            throw new NotImplementedException();
        }

        public void Update(RealtyNote entety)
        {
            DB.RealtyNotes.Update(entety);
        }
    }
}
