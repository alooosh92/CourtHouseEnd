using CourtHouse.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourtHouse.Data.Repository
{
    public class RepUser : IRepository<User>
    {
        public RepUser(ApplicationDbContext DB, UserManager<User> userManager)
        {
            this.DB = DB;
            UserManager = userManager;
        }

        public ApplicationDbContext DB { get; }
        public UserManager<User> UserManager { get; }

        public void Add(User entety)
        {
            throw new NotImplementedException();
        }

        public IList<User> All()
        {
            throw new NotImplementedException();
        }

        public void Delete(User entety)
        {            
            throw new NotImplementedException();
        }

        public User Find(string val)
        {
            var IU = UserManager.Users.Include(a => a.region).SingleOrDefault(a => a.Id == val);
            var MU = new User
            {
                AccessFailedCount = IU.AccessFailedCount,
                ConcurrencyStamp = IU.ConcurrencyStamp,
                Id = IU.Id,
                Email = IU.Email,
                EmailConfirmed = IU.EmailConfirmed,
                LockoutEnabled = IU.LockoutEnabled,
                LockoutEnd = IU.LockoutEnd,
                NormalizedEmail = IU.NormalizedEmail,
                NormalizedUserName = IU.NormalizedUserName,
                PasswordHash = IU.PasswordHash,
                PhoneNumber = IU.PhoneNumber,
                PhoneNumberConfirmed = IU.PhoneNumberConfirmed,
                SecurityStamp = IU.SecurityStamp,
                TwoFactorEnabled = IU.TwoFactorEnabled,
                UserName = IU.UserName,
                region = IU.region
            };
            return MU;        
        }

        public void Save()
        {

            throw new NotImplementedException();
        }

        public IList<User> Search(string region)
        {
            var use =  UserManager.Users.Where(a => a.region.id == int.Parse(region)).ToList();
            return use;
        }

        public IList<User> Search(string val1, string val2)
        {
            throw new NotImplementedException();
        }

        public void Update(User entety)
        {
            throw new NotImplementedException();
        }
    }
}
