using CourtHouse.Data.Repository;
using CourtHouse.Data.ViewModels;
using CourtHouse.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace CourtHouse.Controllers
{
    [Authorize]
    public class OfficialDocumentController : Controller
    {
        public IRepository<OfficialDocument> OfficialDocument { get; }
        public IRepository<RealtyContract> RealtyContract { get; }
        public IWebHostEnvironment Hosting { get; }
        public IRepository<RealtyContractNote> RealtyContractNote { get; }
        public UserManager<User> UserManager { get; }
        public IRepository<Person> Person { get; }

        public OfficialDocumentController(IRepository<OfficialDocument> officialDocument, IRepository<RealtyContract> realtyContract, IWebHostEnvironment hosting
            ,IRepository<RealtyContractNote> realtyContractNote, UserManager<User> userManager,IRepository<Person> person)
        {
            OfficialDocument = officialDocument;
            RealtyContract = realtyContract;
            Hosting = hosting;
            RealtyContractNote = realtyContractNote;
            UserManager = userManager;
            Person = person;
        }
        public ActionResult Details(string id)
        {
            try
            {
                var off = OfficialDocument.Find(id);
                return PartialView("Details", off);
            }
            catch { return View("Error"); }
        }
        public ActionResult Create(string contractid, string personId)
        {
            try
            {
                var off = new VMOfficialDocument
                {
                    realtyContract = RealtyContract.Find(contractid)
                };
                if (User.IsInRole("Judge") && personId != null)
                { off.imageType = "Court session: " + personId; }
                return PartialView("Create", off);
            }
            catch
            {
                return View("Error");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VMOfficialDocument collection)
        {
            try
            {
                if (collection.imageUrl != null)
                {
                    var off = new OfficialDocument
                    {
                        id = Guid.NewGuid().ToString(),
                        imageType = collection.imageType,
                        realtyContract = RealtyContract.Find(collection.realtyContract.id),
                        isChecked = false
                    };
                    string Image = string.Empty;
                    string uplode = Path.Combine(Hosting.WebRootPath, "OfficialDocument");
                    Image = "OfficialDocument" + off.id + collection.imageUrl.FileName.Substring(collection.imageUrl.FileName.IndexOf('.'));
                    string fullpath = Path.Combine(uplode, Image);
                    var FS = new FileStream(fullpath, FileMode.Create);
                    collection.imageUrl.CopyTo(FS);
                    FS.Close();
                    off.image = Image;
                    OfficialDocument.Add(off);
                    OfficialDocument.Save();
                }
                return RedirectToAction(nameof(Details), "Issues", new { id = collection.realtyContract.id });
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(string id)
        {
            try
            {
                var off = OfficialDocument.Find(id);
                var VMOff = new VMOfficialDocument { id = off.id, realtyContract = off.realtyContract, image = off.image, imageType = off.imageType, isChecked = off.isChecked };
                return PartialView("Edit", VMOff);
            }
            catch { return View("Error"); }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VMOfficialDocument collection, string check)
        {
            try
            {
                var off = OfficialDocument.Find(collection.id);
                if (check == "UnChecked")
                {

                    off.isChecked = false;
                    OfficialDocument.Update(off);
                    OfficialDocument.Save();
                    return RedirectToAction(nameof(Details), "Issues", new { id = off.realtyContract.id });
                }
                if (check == "Checked")
                {
                    off.isChecked = true;
                    OfficialDocument.Update(off);
                    var conNot = new RealtyContractNote
                    {
                        id = Guid.NewGuid().ToString(),
                        noteDate = DateTime.Now,
                        noteType = "Check OfficialDocument",
                        realtyContract = off.realtyContract,
                        user = UserManager.GetUserAsync(User).Result,
                        note = "Check OfficialDocument " + off.id
                    };
                    RealtyContractNote.Add(conNot);
                    OfficialDocument.Save();
                    return RedirectToAction(nameof(Details), "Issues", new { id = off.realtyContract.id });
                }
                else
                {
                    if (collection.imageUrl != null && collection.imageUrl.Length < 204800)
                    {
                        string uplode = Path.Combine(Hosting.WebRootPath, "OfficialDocument");
                        string fullpath = Path.Combine(uplode, off.image);
                        System.IO.File.Delete(fullpath);
                        var FS = new FileStream(fullpath, FileMode.Create);
                        collection.imageUrl.CopyTo(FS);
                        FS.Close();
                    }
                    OfficialDocument.Update(off);
                    OfficialDocument.Save();
                    return RedirectToAction(nameof(Details), "Issues", new { id = off.realtyContract.id });
                }
            }
            catch
            {
                return View("Error");
            }
        }
        public ActionResult Delete(string id)
        {
            try
            {
                
                var off = OfficialDocument.Find(id);                
                if (off.isChecked == false)
                {
                    return PartialView("Delete", off);
                }
                else
                { return PartialView("Delete", new OfficialDocument { id = "Error" }); }
            }
            catch { return View("Error"); }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(OfficialDocument collection, string mess)
        {
            try
            {
                var off = OfficialDocument.Find(collection.id);
                string uplode = Path.Combine(Hosting.WebRootPath, "OfficialDocument");
                string fullpath = Path.Combine(uplode, off.image);
                OfficialDocument.Delete(off);
                System.IO.File.Delete(fullpath);
                var conNot = new RealtyContractNote
                {
                    id = Guid.NewGuid().ToString(),
                    noteDate = DateTime.Now,
                    noteType = "delete officialDocument",
                    realtyContract = off.realtyContract,
                    user = UserManager.GetUserAsync(User).Result,
                    note = mess
                };
                RealtyContractNote.Add(conNot);
                OfficialDocument.Save();
                return RedirectToAction(nameof(Details), "Issues", new { id = off.realtyContract.id });
            }
            catch
            {
                return View();
            }
        }        

    }
}
