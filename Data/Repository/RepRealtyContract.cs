using CourtHouse.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CourtHouse.Data.Repository
{
    public class RepRealtyContract : IRepository<RealtyContract>
    {
        public RepRealtyContract(ApplicationDbContext DB, UserManager<User> userManager , IRepository<User> use)
        {
            this.DB = DB;
            UserManager = userManager;
            Use = use;
        }

        public ApplicationDbContext DB { get; }
        public UserManager<User> UserManager { get; }
        public IRepository<User> Use { get; }

        public void Add(RealtyContract entety)
        {
            DB.RealtyContracts.Add(entety);
        }

        public IList<RealtyContract> All()
        {
            return DB.RealtyContracts.Include(r => r.realty.region).Include(u => u.user).ToList();
        }

        public void Delete(RealtyContract entety)
        {
            DB.RealtyContracts.Remove(entety);
        }

        public RealtyContract Find(string val)
        {
            return DB.RealtyContracts.Include(r => r.realty.region).Include(u => u.user).Include(c=>c.checker).Include(f=>f.finance).
                Include(j=>j.judge).SingleOrDefault(a => a.id == val);
        }

        public void Save()
        {
            DB.SaveChanges();
        }

        public IList<RealtyContract> Search(string userId)
        {
            return DB.RealtyContracts.Include(r => r.realty.region).Include(u => u.user).Where(a => a.user.Id == userId).ToList();
        }

        public IList<RealtyContract> Search(string username, string roleUser)
        {
            switch (roleUser)
            {
                case "Admin":
                    return All();
                case "Checker":
                    return DB.RealtyContracts.Include(r => r.realty.region).Include(u => u.user).Where(a => a.isChecked == false && a.checker == UserManager.FindByIdAsync(username).Result).ToList();
                case "LocalAdmin":
                    return DB.RealtyContracts.Include(r => r.realty.region).Include(u => u.user).Where(a=>a.realty.region == Use.Find(username).region).ToList();
                case "Finance":
                    return DB.RealtyContracts.Include(r => r.realty.region).Include(u => u.user).Where(a => a.isChecked == true && a.isFinance == false && a.finance == UserManager.FindByIdAsync(username).Result).ToList();
                case "Judge":
                    return DB.RealtyContracts.Include(r => r.realty.region).Include(u => u.user).Where(a => a.isFinance == true && a.isJudge == false && a.judge == UserManager.FindByIdAsync(username).Result).ToList();
                case "Recorder":
                    return DB.RealtyContracts.Include(r => r.realty.region).Include(u => u.user).Where(a => a.isJudge == true).ToList();
            }
            return new List<RealtyContract>();
        }

        public void Update(RealtyContract entety)
        {
            DB.RealtyContracts.Update(entety);
        }
    }
}
