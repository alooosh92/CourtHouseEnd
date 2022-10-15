using CourtHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourtHouse.Data.Repository
{
    public class RepWaysToCommunicate : IRepository<WaysToCommunicate>
    {
        public RepWaysToCommunicate (ApplicationDbContext db)
        {
            Db = db;
        }

        public ApplicationDbContext Db { get; }

        public void Add(WaysToCommunicate entety)
        {
            Db.WaysToCommunicate.Add(entety);
        }

        public IList<WaysToCommunicate> All()
        {
            return Db.WaysToCommunicate.ToList();
        }

        public void Delete(WaysToCommunicate entety)
        {
            var WTC = Find(entety.id.ToString());
            Db.WaysToCommunicate.Remove(WTC);
        }

        public WaysToCommunicate Find(string val)
        {
            return Db.WaysToCommunicate.SingleOrDefault(a => a.id == int.Parse(val));
        }

        public void Save()
        {
            Db.SaveChanges();
        }

        public IList<WaysToCommunicate> Search(string val)
        {
            throw new NotImplementedException();
        }

        public IList<WaysToCommunicate> Search(string val1, string val2)
        {
            throw new NotImplementedException();
        }

        public void Update(WaysToCommunicate entety)
        {
            Db.Update(entety);
        }
    }
}
