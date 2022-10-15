using CourtHouse.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CourtHouse.Data.Repository
{
    public class RepPerson : IRepository<Person>
    {
        public RepPerson(ApplicationDbContext DB)
        {
            this.DB = DB;
        }

        public ApplicationDbContext DB { get; }
        public void Add(Person entety)
        {
            DB.People.Add(entety);
        }

        public IList<Person> All()
        {
            return DB.People.Include(r => r.region).ToList();
        }

        public void Delete(Person entety)
        {
            DB.People.Remove(entety);
        }

        public Person Find(string Id)
        {
            return DB.People.Include(r => r.region).SingleOrDefault(a => a.idNumber == Id);
        }

        public void Save()
        {
            DB.SaveChanges();
        }

        public IList<Person> Search(string val)
        {
            throw new NotImplementedException();
        }

        public IList<Person> Search(string val1, string val2)
        {
            throw new NotImplementedException();
        }

        public void Update(Person entety)
        {
            DB.People.Update(entety);
        }
    }
}
