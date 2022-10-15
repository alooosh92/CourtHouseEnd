using CourtHouse.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CourtHouse.Data.Repository
{
    public class RepOfficialDocument : IRepository<OfficialDocument>
    {
        public RepOfficialDocument(ApplicationDbContext DB)
        {
            this.DB = DB;
        }

        public ApplicationDbContext DB { get; }
        public void Add(OfficialDocument entety)
        {
            DB.OfficialDocuments.Add(entety);
        }

        public IList<OfficialDocument> All()
        {
            return DB.OfficialDocuments.Include(r => r.realtyContract.realty.region).ToList();
        }

        public void Delete(OfficialDocument entety)
        {
            DB.OfficialDocuments.Remove(entety);
        }

        public OfficialDocument Find(string val)
        {
            return DB.OfficialDocuments.Include(r => r.realtyContract.realty.region)
                .Include(r => r.realtyContract.user)
                .SingleOrDefault(a => a.id == val);
        }

        public void Save()
        {
            DB.SaveChanges();
        }

        public IList<OfficialDocument> Search(string realtyContract)
        {
            return DB.OfficialDocuments.Include(r => r.realtyContract.realty.region)
                .Where(a => a.realtyContract.id == realtyContract).ToList();
        }

        public IList<OfficialDocument> Search(string val1, string val2)
        {
            throw new NotImplementedException();
        }

        public void Update(OfficialDocument entety)
        {
            DB.OfficialDocuments.Update(entety);
        }
    }
}
