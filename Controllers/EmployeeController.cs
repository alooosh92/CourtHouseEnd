using CourtHouse.Data.Repository;
using CourtHouse.Data.ViewModels;
using CourtHouse.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CourtHouse.Controllers
{
    public class EmployeeController : Controller
    {
        public UserManager<User> UserManager { get; }
        public IRepository<Region> Region { get; }
        public IRepository<User> Use { get; }
        public IRepositoryUser UserFun { get; }

        public EmployeeController(UserManager<User> userManager, IRepository<Region> region, IRepository<User> use,IRepositoryUser userFun)
        {
            UserManager = userManager;
            Region = region;
            Use = use;
            UserFun = userFun;
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            try
            {
                var u = UserManager.Users.Include(a=>a.region).ToList();
                var VMU = new List<VMUser>();
                var reg = Region.All().ToList();
                foreach (var user in u)
                {
                    var VM = new VMUser
                    {
                        id = user.Id,
                        userName = user.UserName,
                        email = user.Email,
                        phoneNumber = user.PhoneNumber                        
                    };
                    var r = UserManager.GetRolesAsync(user).Result;
                    if (r.Contains("Admin")) { VM.Admin = true; }
                    if (r.Contains("Checker")) { VM.Checker = true; }
                    if (r.Contains("Finance")) { VM.Finance = true; }
                    if (r.Contains("Human Resources")) { VM.HumanResources = true; }
                    if (r.Contains("Judge")) { VM.Judge = true; }
                    if (r.Contains("Recorder")) { VM.Recorder = true; }
                    if (r.Contains("DataEntry")) { VM.DataEntry = true; }
                    if (r.Contains("Employee")) { VM.Employee = true; }
                    VM.regionList = reg;
                    VM.regionSelect = -1;
                    if (user.region != null) { VM.regionSelect = user.region.id; } 
                    VMU.Add(VM);

                };
                return View(VMU);
            }
            catch
            {
                return View("Error");
            }
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Details(string id)
        {
            try
            {
                var user = UserManager.FindByIdAsync(id).Result;
                var VM = new VMUser
                {
                    id = user.Id,
                    userName = user.UserName,
                    email = user.Email,
                    phoneNumber = user.PhoneNumber
                };
                var r = UserManager.GetRolesAsync(user).Result;
                if (r.Contains("Admin")) { VM.Admin = true; }
                if (r.Contains("Checker")) { VM.Checker = true; }
                if (r.Contains("Finance")) { VM.Finance = true; }
                if (r.Contains("Human Resources")) { VM.HumanResources = true; }
                if (r.Contains("Judge")) { VM.Judge = true; }
                if (r.Contains("Recorder")) { VM.Recorder = true; }
                if (r.Contains("dataEntry")) { VM.DataEntry = true; }
                return View(VM);
            }
            catch
            {
                return View("Error");
            }
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            try
            {
                var r = Region.All().ToList();
                var u = new VMUser { regionList = r };
                return View(u);
            }
            catch
            {
                return View("Error");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(VMUser collection)
        {
            try
            {
                var u = new User
                {
                    Email = collection.email,
                    EmailConfirmed = true,
                    PhoneNumber = collection.phoneNumber,
                    UserName = collection.userName,
                    region = Region.Find(collection.regionSelect.ToString())
                };
                var check = UserManager.CreateAsync(u, collection.password).Result;
                if (check.Succeeded)
                {
                    var e = UserManager.AddToRoleAsync(u, "Employee").Result;
                    if (collection.Admin == true)
                    {
                        var r= UserManager.AddToRoleAsync(u, "Admin").Result;
                    }
                    if (collection.Checker == true)
                    {
                        var r = UserManager.AddToRoleAsync(u, "Checker").Result;
                    }
                    if (collection.Finance == true)
                    {
                        var r = UserManager.AddToRoleAsync(u, "Finance").Result;
                    }
                    if (collection.Judge == true)
                    {
                        var r = UserManager.AddToRoleAsync(u, "Judge").Result;
                    }
                    if (collection.Recorder == true)
                    {
                        var r = UserManager.AddToRoleAsync(u, "Recorder").Result;
                    }
                    if (collection.HumanResources == true)
                    {
                        var r = UserManager.AddToRoleAsync(u, "Human Resources").Result;
                    }
                    if (collection.DataEntry == true)
                    {
                        var r = UserManager.AddToRoleAsync(u, "DataEntry").Result;
                    }
                    if (collection.LocalAdmin == true)
                    {
                        var r = UserManager.AddToRoleAsync(u, "LocalAdmin").Result;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(string id)
        {
            try
            {
                var user = UserManager.FindByIdAsync(id).Result;
                var VM = new VMUser
                {
                    id = user.Id,
                    userName = user.UserName,
                    email = user.Email,
                    phoneNumber = user.PhoneNumber
                };
                var r = UserManager.GetRolesAsync(user).Result;
                if (r.Contains("Admin")) { VM.Admin = true; }
                if (r.Contains("Checker")) { VM.Checker = true; }
                if (r.Contains("Finance")) { VM.Finance = true; }
                if (r.Contains("Human Resources")) { VM.HumanResources = true; }
                if (r.Contains("Judge")) { VM.Judge = true; }
                if (r.Contains("Recorder")) { VM.Recorder = true; }
                if (r.Contains("dataEntry")) { VM.DataEntry = true; }
                return View(VM);
            }
            catch
            {
                return View("Error");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(VMUser collection)
        {
            try
            {
                var olduser = UserManager.FindByIdAsync(collection.id).Result;
                var u = new User
                {
                    Id = collection.id,
                    Email = collection.email,
                    EmailConfirmed = true,
                    PhoneNumber = collection.phoneNumber,
                    UserName = collection.userName,      
                    PasswordHash = olduser.PasswordHash
                };
                var del = UserManager.DeleteAsync(olduser).Result;
                var check = new IdentityResult { };
                if (collection.password == null)
                { check = UserManager.CreateAsync(u).Result; }
                else check = UserManager.CreateAsync(u, collection.password).Result;
                if (check.Succeeded)
                {
                    if (collection.Admin == true)
                    {
                        var r = UserManager.AddToRoleAsync(u, "Admin").Result;
                    }
                    else { var r = UserManager.RemoveFromRoleAsync(u, "Admin"); }
                    if (collection.Checker == true)
                    {
                        var r = UserManager.AddToRoleAsync(u, "Checker").Result;
                    }
                    else { var r = UserManager.RemoveFromRoleAsync(u, "Checker"); }
                    if (collection.Finance == true)
                    {
                        var r = UserManager.AddToRoleAsync(u, "Finance").Result;
                    }
                    else { var r = UserManager.RemoveFromRoleAsync(u, "Finance"); }
                    if (collection.Judge == true)
                    {
                        var r = UserManager.AddToRoleAsync(u, "Judge").Result;
                    }
                    else { var r = UserManager.RemoveFromRoleAsync(u, "Judge"); }
                    if (collection.Recorder == true)
                    {
                        var r = UserManager.AddToRoleAsync(u, "Recorder").Result;
                    }
                    else { var r = UserManager.RemoveFromRoleAsync(u, "Recorder"); }
                    if (collection.HumanResources == true)
                    {
                        var r = UserManager.AddToRoleAsync(u, "Human Resources").Result;
                    }
                    else { var r = UserManager.RemoveFromRoleAsync(u, "Human Resources"); }
                    if (collection.DataEntry == true)
                    {
                        var r = UserManager.AddToRoleAsync(u, "dataEntry").Result;
                    }
                    else { var r = UserManager.RemoveFromRoleAsync(u, "dataEntry"); }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(string id)
        {
            try
            {
                var user = UserManager.FindByIdAsync(id).Result;
                var VM = new VMUser
                {
                    id = user.Id,
                    userName = user.UserName,
                    email = user.Email,
                    phoneNumber = user.PhoneNumber
                };
                var r = UserManager.GetRolesAsync(user).Result;
                if (r.Contains("Admin")) { VM.Admin = true; }
                if (r.Contains("Checker")) { VM.Checker = true; }
                if (r.Contains("Finance")) { VM.Finance = true; }
                if (r.Contains("Human Resources")) { VM.HumanResources = true; }
                if (r.Contains("Judge")) { VM.Judge = true; }
                if (r.Contains("Recorder")) { VM.Recorder = true; }
                if (r.Contains("dataEntry")) { VM.DataEntry = true; }
                return View(VM);
            }
            catch 
            {
                return View("Error");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(VMUser collection)
        {
            try
            {
                var olduser = UserManager.FindByIdAsync(collection.id).Result;
                var del = UserManager.DeleteAsync(olduser).Result;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles ="Admin , LocalAdmin")]
        public ActionResult EmployeeInfo()
        {
            var emps = UserFun.employeeInfo(Use.Find(UserManager.GetUserId(User)).region).OrderByDescending(a => a.AvaregDelayInCase);
            ViewData["scrChart"] = "[";
            ViewData["valChart"] = "[";
            ViewData["valInMonthChart"] = "[";
            ViewData["valNumUnfinishedCases"] = "[";
            ViewData["valAvaregDelayInCase"] = "[";
            foreach (var i in emps)
            {
                ViewData["scrChart"] += "'" + i.user.UserName + "'";
                ViewData["valChart"] += i.NumAllCases.ToString();
                ViewData["valInMonthChart"] += i.NumEndCasesInThisMonth.ToString();
                ViewData["valNumUnfinishedCases"] += i.NumUnfinishedCases.ToString();
                ViewData["valAvaregDelayInCase"] += i.AvaregDelayInCase.ToString();
                if (i != emps.Last())
                {
                    ViewData["scrChart"] += ",";
                    ViewData["valChart"] += ",";
                    ViewData["valInMonthChart"] += ",";
                    ViewData["valNumUnfinishedCases"] += ",";
                    ViewData["valAvaregDelayInCase"] += ",";
                }
            }
            ViewData["scrChart"] += "]";
            ViewData["valChart"] += "]";
            ViewData["valInMonthChart"] += "]";
            ViewData["valNumUnfinishedCases"] += "]";
            ViewData["valAvaregDelayInCase"] += "]";
            return View(emps);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult RegionInfo()
        {
            var r = UserFun.regionInfo().OrderByDescending(a => a.AvaregDelayInCase);
            ViewData["scrChart"] = "[";
            ViewData["valChart"] = "[";
            ViewData["valInMonthChart"] = "[";
            ViewData["valNumUnfinishedCases"] = "[";
            ViewData["valAvaregDelayInCase"] = "[";
            foreach (var i in r)
            { 
                ViewData["scrChart"] += "'" + i.region.regionName + "'";
                ViewData["valChart"] += i.NumAllCases.ToString();
                ViewData["valInMonthChart"] += i.NumEndCasesInThisMonth.ToString();
                ViewData["valNumUnfinishedCases"] += i.NumUnfinishedCases.ToString();
                ViewData["valAvaregDelayInCase"] += i.AvaregDelayInCase.ToString();
                if (i != r.Last())
                {
                    ViewData["scrChart"] += ",";
                    ViewData["valChart"] += ",";
                    ViewData["valInMonthChart"] += ",";
                    ViewData["valNumUnfinishedCases"] += ",";
                    ViewData["valAvaregDelayInCase"] += ",";
                }
            }
            ViewData["scrChart"] += "]";
            ViewData["valChart"] += "]";
            ViewData["valInMonthChart"] += "]";
            ViewData["valNumUnfinishedCases"] += "]";
            ViewData["valAvaregDelayInCase"] += "]";
            return View(r);
        }        
    }
}
