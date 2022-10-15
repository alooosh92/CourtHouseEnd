using CourtHouse.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
namespace CourtHouse.Data.Repository
{
    public class RepRealty : IRepository<Realty>
    {
        public RepRealty(ApplicationDbContext DB)
        {
            this.DB = DB;
        }

        public ApplicationDbContext DB { get; }
        public void Add(Realty entety)
        {
            DB.Realties.Add(entety);
        }

        public IList<Realty> All()
        {
            return DB.Realties.Include(a=>a.region).ToList();
        }

        public void Delete(Realty entety)
        {
            DB.Realties.Remove(entety);            
        }

        public Realty Find(string id)
        {
            return DB.Realties.AsNoTracking().Include(a => a.region).SingleOrDefault(a => a.id == id);
        }

        public void Save()
        {
            DB.SaveChanges();
        }

        public IList<Realty> Search(string val)
        {
            return DB.Realties.Include(a => a.region).Where(a=>a.region.id == int.Parse(val)).ToList();
        }

        public IList<Realty> Search(string val1, string val2)
        {
            throw new NotImplementedException();
        }

        public void Update(Realty entety)
        {
            DB.Realties.Update(entety);            
        }
    }
}
