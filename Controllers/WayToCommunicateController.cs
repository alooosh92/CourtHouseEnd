using CourtHouse.Data.Repository;
using CourtHouse.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourtHouse.Controllers
{
    [Authorize(Roles ="Admin")]
    public class WayToCommunicateController : Controller
    {
        public IRepository<WaysToCommunicate> WaysToCommunicate { get; }
        public WayToCommunicateController (IRepository<WaysToCommunicate> waysToCommunicate)
        {
            WaysToCommunicate = waysToCommunicate;
        }
        public ActionResult Index()
        {
            var WTC = WaysToCommunicate.All();
            return View(WTC);
        }
        public ActionResult Details(int id)
        {
            var WTC = WaysToCommunicate.Find(id.ToString());
            return View(WTC);
        }
        public ActionResult Create()
        {
            var WTC = new WaysToCommunicate { };
            return View(WTC);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WaysToCommunicate collection)
        {
            try
            {
                WaysToCommunicate.Add(collection);
                WaysToCommunicate.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            var WTC = WaysToCommunicate.Find(id.ToString());
            return View(WTC);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, WaysToCommunicate collection)
        {
            try
            {
                WaysToCommunicate.Update(collection);
                WaysToCommunicate.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            var WTC = WaysToCommunicate.Find(id.ToString());
            return View(WTC);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, WaysToCommunicate collection)
        {
            try
            {
                WaysToCommunicate.Delete(collection);
                WaysToCommunicate.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
