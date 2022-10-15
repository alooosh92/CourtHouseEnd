using CourtHouse.Data.Repository;
using CourtHouse.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

public static class Lib
{
    public static class AddDefultData
    {
        public static async Task CreateData(IServiceProvider serviceProvider, IConfiguration Configuration)
        {

            var scopeFactory = serviceProvider.GetRequiredService<IServiceScopeFactory>();
            var scope = scopeFactory.CreateScope();
            var region = scopeFactory.CreateScope();
            //adding customs roles
            var RoleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roleNames = { "Admin","Checker","Finance","Judge","Recorder","Human Resources","Employee","DataEntry","LocalAdmin" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                // creating the roles and seeding them to the database
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            User user = new User()
            {
                Email = "admin@test.com",
                EmailConfirmed = true,
                PhoneNumber = "0999999999",
                UserName = "Admin"
            };
            var check = await userManager.CreateAsync(user, "Qweasd12#");
            if (check.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Admin");
                await userManager.AddToRoleAsync(user, "Employee");
            }

            var Reg = region.ServiceProvider.GetRequiredService<IRepository<Region>>();
            if (Reg.All().Count == 0)
            {
                var reg0 = new Region { regionName = "دمشق" };
                var reg1 = new Region { regionName = "ريف دمشق" };
                var reg2 = new Region { regionName = "حلب" };
                var reg3 = new Region { regionName = "حمص" };
                var reg4 = new Region { regionName = "حماه" };
                var reg5 = new Region { regionName = "ادلب" };
                var reg6 = new Region { regionName = "اللاذقية" };
                var reg7 = new Region { regionName = "طرطوس" };
                var reg8 = new Region { regionName = "دير الزور" };
                var reg9 = new Region { regionName = "القامشلي" };
                var reg10 = new Region { regionName = "السويداء" };
                var reg11 = new Region { regionName = "الحسكة" };
                var reg12 = new Region { regionName = "درعا" };
                var reg13 = new Region { regionName = "القنيطرة" };
                var reg14 = new Region { regionName = "الرقة" };
                Reg.Add(reg0);
                Reg.Add(reg1);
                Reg.Add(reg2);
                Reg.Add(reg3);
                Reg.Add(reg4);
                Reg.Add(reg5);
                Reg.Add(reg6);
                Reg.Add(reg7);
                Reg.Add(reg8);
                Reg.Add(reg9);
                Reg.Add(reg10);
                Reg.Add(reg11);
                Reg.Add(reg12);
                Reg.Add(reg13);
                Reg.Add(reg14);
                Reg.Save();
            }
        }
    }
}