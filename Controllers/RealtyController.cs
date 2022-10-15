using CourtHouse.Data.Repository;
using CourtHouse.Data.ViewModels;
using CourtHouse.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CourtHouse.Controllers
{
    [Authorize(Roles ="DataEntry")]
    public class RealtyController : Controller
    {
        public IRepository<Realty> Realty { get; }
        public IRepository<Region> Region { get; }
        public IRepository<User> Use { get; }
        public UserManager<User> UserManager { get; }
        public IRepository<RealtyNote> RealtyNote { get; }

        public RealtyController (IRepository<Realty> realty, IRepository<Region> region,IRepository<User> use,UserManager<User> userManager, IRepository<RealtyNote> realtyNote)
        {
            Realty = realty;
            Region = region;
            Use = use;
            UserManager = userManager;
            RealtyNote = realtyNote;
        }
        public ActionResult Index()
        {
            var u = Use.Find(UserManager.GetUserId(User));
            var r = Realty.Search(u.region.id.ToString());
            return View(r);
        }
        public ActionResult Details(string id)
        {
            var r = Realty.Find(id);
            return View(r);
        }
        public ActionResult Create(string con)
        {
            try
            {
                var real = Realty.Find(con);
                var VR = new VMRealty
                {
                    id = con,
                    regionList = Region.All().ToList()
                };
                if (real != null)
                {
                    VR.adress = real.adress;
                    VR.area = real.area;
                    VR.info = real.info;
                    VR.regionSelect = Region.Find(real.region.id.ToString()).id;
                    VR.isChecked = false;
                    VR.realtyType = real.realtyType;
                    VR.theFinancialValue = real.theFinancialValue;
                }                
                return View(VR);
            }
            catch
            {
                return View("Error");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VMRealty collection)
        {
            try
            {
                var u = UserManager.GetUserAsync(User).Result;
                var R = new Realty
                {
                    id = collection.id,
                    adress = collection.adress,
                    area = collection.area,
                    info = collection.info,
                    isChecked = false,
                    realtyType = collection.realtyType,
                    theFinancialValue = collection.theFinancialValue,
                    region = Region.Find(collection.regionSelect.ToString())                    
                };
                if (Realty.Find(R.id) == null)
                {
                    R.createBy = u;
                    Realty.Add(R);
                }
                else
                {
                    Realty.Update(R);
                    var NR = new RealtyNote
                    {
                        id = Guid.NewGuid().ToString(),
                        noteDate = DateTime.Now,
                        noteType = "Upate Realty",
                        realty = R,
                        user = u
                    };
                    RealtyNote.Add(NR);
                }               
                Realty.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Error");
            }
        }
        public ActionResult Edit(string id)
        {
            var r = Realty.Find(id);
            var vmr = new VMRealty
            {
                adress = r.adress,
                area = r.area,
                id = r.id,
                info = r.info,
                isChecked = r.isChecked,
                realtyType = r.realtyType,
                regionList = Region.All().ToList(),
                regionSelect = r.region.id,
                theFinancialValue = r.theFinancialValue
            };
            return View(vmr);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, VMRealty collection)
        {
            try
            {
                var r = Realty.Find(id);
                r.adress = collection.adress;
                r.area = collection.area;
                r.info = collection.info;
                r.isChecked = collection.isChecked;
                r.realtyType = collection.realtyType;
                r.region = Region.Find(collection.regionSelect.ToString());
                r.theFinancialValue = collection.theFinancialValue;
                Realty.Update(r);
                Realty.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Error");
            }
        }
        public ActionResult Delete(string id)
        {
            var r = Realty.Find(id);
            return View(r);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Realty collection)
        {
            try
            {
                Realty.Delete(collection);
                Realty.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Error");
            }
        }
        public ActionResult AddRealty()
        {
            return PartialView("AddRealty", new Realty { });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddRealty(Realty rea)
        {
            return RedirectToAction(nameof(Create), new { con = rea.id });
        }
    }
}
