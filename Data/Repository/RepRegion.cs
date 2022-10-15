using CourtHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CourtHouse.Data.Repository
{
    public class RepRegion : IRepository<Region>
    {
        public RepRegion(ApplicationDbContext DB)
        {
            this.DB = DB;
        }

        public ApplicationDbContext DB { get; }
        public void Add(Region entety)
        {
            DB.Regions.Add(entety);
        }

        public IList<Region> All()
        {
            return DB.Regions.ToList();
        }

        public void Delete(Region entety)
        {
            DB.Regions.Remove(entety);
        }

        public Region Find(string id)
        {
            return DB.Regions.SingleOrDefault(a => a.id == int.Parse(id));
        }

        public void Save()
        {
            DB.SaveChanges();
        }

        public IList<Region> Search(string regionName)
        {
            return DB.Regions.Where(a => a.regionName == regionName).ToList();
        }

        public IList<Region> Search(string val1, string val2)
        {
            throw new NotImplementedException();
        }

        public void Update(Region entety)
        {
            DB.Regions.Update(entety);
        }
    }
}
