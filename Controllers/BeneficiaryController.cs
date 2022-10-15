using CourtHouse.Data.Repository;
using CourtHouse.Data.ViewModels;
using CourtHouse.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace CourtHouse.Controllers
{
    [Authorize]
    public class BeneficiaryController : Controller
    {
        public IRepository<Beneficiary> Beneficiary { get; }
        public IRepository<RealtyContract> RealtyContract { get; }
        public UserManager<User> UserManager { get; }
        public IRepository<RealtyContractNote> RealtyContractNote { get; }
        public IRepository<Person> Person { get; }
        public IRepository<Region> Region { get; }
        public IWebHostEnvironment Hosting { get; }
        public IRepository<User> Use { get; }
        public IRepository<WaysToCommunicate> WayToCommunicate { get; }
        public IRepositoryUser UserFun { get; }

        public BeneficiaryController(IRepository<Beneficiary> beneficiary, IRepository<RealtyContract> realtyContract, UserManager<User> userManager,
           IRepository<RealtyContractNote> realtyContractNote, IRepository<Person> person, IRepository<Region> region, IWebHostEnvironment hosting,
            IRepository<User> use, IRepository<WaysToCommunicate> wayToCommunicate, IRepositoryUser userFun)
        {
            Beneficiary = beneficiary;
            RealtyContract = realtyContract;
            UserManager = userManager;
            RealtyContractNote = realtyContractNote;
            Person = person;
            Region = region;
            Hosting = hosting;
            Use = use;
            WayToCommunicate = wayToCommunicate;
            UserFun = userFun;
        }
        public ActionResult Details(string id)
        {
            try
            {
                var ben = Beneficiary.Find(id);
                return View(ben);
            }
            catch
            {
                return View("Error");
            }
        }
        public ActionResult Create(string contract, string type, string personId)
        {
            try
            {
                var ben = new VMBeneficiary
                {
                    typePerson = type,
                    realtyContract = RealtyContract.Find(contract),
                    regionList = Region.All().ToList(),
                    ways = WayToCommunicate.All().ToList()
                };
                if (Person.Find(personId) != null)
                {
                    ben.person = Person.Find(personId);
                }
                else
                {
                    var per = new Person { idNumber = personId };
                    ben.person = per;
                }
                return View(ben);
            }
            catch
            {
                return View("Error");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VMBeneficiary collection)
        {
            try
            {
                string personImage = string.Empty;
                string identityImageFront = string.Empty;
                string identityImageBack = string.Empty;
                string uplode = Path.Combine(Hosting.WebRootPath, "PersonImages");
                var per = new Person { };
                if (Person.Find(collection.person.idNumber) == null)
                {
                    per.dateOfBirth = collection.person.dateOfBirth;
                    per.emailAddress = collection.person.emailAddress;
                    per.fatherName = collection.person.fatherName;
                    per.firstName = collection.person.firstName;
                    per.idNumber = collection.person.idNumber;
                    per.lastName = collection.person.lastName;
                    per.mobile = collection.person.mobile;
                    per.motherName = collection.person.motherName;
                    per.nationality = collection.person.nationality;
                    per.phone = collection.person.phone;
                    per.placeOFBirth = collection.person.placeOFBirth;
                    per.region = Region.Find(collection.person.region.id.ToString());
                    per.title = collection.person.title;
                    per.adress = collection.person.adress;                   
                    if (collection.personImage != null && collection.personImage.Length < 204800)
                    {
                        personImage = "personImage" + collection.person.idNumber + collection.personImage.FileName.Substring(collection.personImage.FileName.IndexOf('.'));
                        string fullpath = Path.Combine(uplode, personImage);
                        collection.personImage.CopyTo(new FileStream(fullpath, FileMode.Create));
                        per.personImage = personImage;
                    }
                    if (collection.identityImageFront != null && collection.identityImageFront.Length < 204800)
                    {
                        identityImageFront = "identityImageFront" + collection.person.idNumber + collection.identityImageFront.FileName.Substring(collection.identityImageFront.FileName.IndexOf('.'));
                        string fullpath = Path.Combine(uplode, identityImageFront);
                        collection.identityImageFront.CopyTo(new FileStream(fullpath, FileMode.Create));
                        per.identityImageFront = identityImageFront;
                    }
                    if (collection.identityImageBack != null && collection.identityImageBack.Length < 204800)
                    {
                        identityImageBack = "identityImageBack" + collection.person.idNumber + collection.identityImageBack.FileName.Substring(collection.identityImageBack.FileName.IndexOf('.')); ;
                        string fullpath = Path.Combine(uplode, identityImageBack);
                        collection.identityImageBack.CopyTo(new FileStream(fullpath, FileMode.Create));
                        per.identityImageBack = identityImageBack;
                    }
                    Person.Add(per);
                }
                else
                {
                    per = Person.Find(collection.person.idNumber);
                    if (collection.personImage != null && collection.personImage.Length < 204800)
                    {
                        personImage = "personImage" + collection.person.idNumber + collection.personImage.FileName.Substring(collection.personImage.FileName.IndexOf('.'));
                        string fullpath = Path.Combine(uplode, personImage);
                        collection.personImage.CopyTo(new FileStream(fullpath, FileMode.Create));
                        per.personImage = personImage;
                    }
                    if (collection.identityImageFront != null && collection.identityImageFront.Length < 204800)
                    {
                        identityImageFront = "identityImageFront" + collection.person.idNumber + collection.identityImageFront.FileName.Substring(collection.identityImageFront.FileName.IndexOf('.'));
                        string fullpath = Path.Combine(uplode, identityImageFront);
                        collection.identityImageFront.CopyTo(new FileStream(fullpath, FileMode.Create));
                        per.identityImageFront = identityImageFront;
                    }
                    if (collection.identityImageBack != null && collection.identityImageBack.Length < 204800)
                    {
                        identityImageBack = "identityImageBack" + collection.person.idNumber + collection.identityImageBack.FileName.Substring(collection.identityImageBack.FileName.IndexOf('.')); ;
                        string fullpath = Path.Combine(uplode, identityImageBack);
                        collection.identityImageBack.CopyTo(new FileStream(fullpath, FileMode.Create));
                        per.identityImageBack = identityImageBack;
                    }
                    Person.Update(per);
                }
                var con = RealtyContract.Find(collection.realtyContract.id);
                var ben = new Beneficiary
                {
                    id = Guid.NewGuid().ToString(),
                    period = collection.period,
                    isChecked = false,
                    realtyContract = con,
                    person = per,
                    typePerson = collection.typePerson,
                    waysToCommunicate = WayToCommunicate.Find(collection.wayToCommunicate.ToString())
                };
                if (UserFun.personCheck(ben.person.idNumber))
                {
                    ben.faceId = true;
                }
                Beneficiary.Add(ben);
                var conNot = new RealtyContractNote
                {
                    id = Guid.NewGuid().ToString(),
                    noteDate = DateTime.Now,
                    noteType = "Add person",
                    realtyContract = con,
                    user = UserManager.GetUserAsync(User).Result,
                    note = "add person " + per.idNumber
                };
                RealtyContractNote.Add(conNot);
                UserFun.sendMessage("AddBen"+ben.person.firstName + ben.person.lastName + ben.person.idNumber, ben.person.emailAddress, "", ben.realtyContract.id);                
                Beneficiary.Save();
                var path = Path.Combine(Hosting.WebRootPath, "FaceId");
                if (!Directory.Exists(path + @"/" + ben.person.idNumber))
                {
                    Directory.CreateDirectory(path + @"/" + ben.person.idNumber);
                }
                return RedirectToAction(nameof(Details), "Issues", new { id = collection.realtyContract.id });
            }
            catch
            {
                return View("Error");
            }

        }
        public ActionResult Edit(string id, string ckeck)
        {
            try
            {
                var ben = Beneficiary.Find(id);
                if (ben.isChecked == true)
                {
                    var VMBen = new VMBeneficiary
                    {
                        id = ben.id,
                        period = ben.period,
                        person = ben.person,
                        realtyContract = ben.realtyContract,
                        regionList = Region.All().ToList(),
                        typePerson = ben.typePerson
                    };
                    return View(VMBen);
                }
                else { return RedirectToAction(nameof(Details), "Issues", new { id = ben.realtyContract.id }); }
            }
            catch
            {
                return View("Error");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VMBeneficiary collection, string check, string notes)
        {
            try
            {
                if (check == "UnChecked")
                {
                    var ben = Beneficiary.Find(collection.id);
                    ben.isChecked = false;
                    var conNot = new RealtyContractNote
                    {
                        id = Guid.NewGuid().ToString(),
                        noteDate = DateTime.Now,
                        noteType = "Update person",
                        realtyContract = ben.realtyContract,
                        user = UserManager.GetUserAsync(User).Result,
                        note = "Update person " + ben.person.idNumber
                    };
                    RealtyContractNote.Add(conNot);
                    Beneficiary.Update(ben);
                    Beneficiary.Save();
                    return RedirectToAction(nameof(Details), "Issues", new { id = ben.realtyContract.id });
                }
                if (check == "Checked")
                {
                    var ben = Beneficiary.Find(collection.id);
                    ben.isChecked = true;
                    var conNot = new RealtyContractNote
                    {
                        id = Guid.NewGuid().ToString(),
                        noteDate = DateTime.Now,
                        noteType = "checked person",
                        realtyContract = ben.realtyContract,
                        user = UserManager.GetUserAsync(User).Result,
                        note = "checked person" + ben.person.idNumber
                    };
                    RealtyContractNote.Add(conNot);
                    Beneficiary.Update(ben);
                    Beneficiary.Save();
                    return RedirectToAction(nameof(Details), "Issues", new { id = ben.realtyContract.id });
                }
                else
                {
                    string personImage = string.Empty;
                    string identityImageFront = string.Empty;
                    string identityImageBack = string.Empty;
                    string uplode = Path.Combine(Hosting.WebRootPath, "PersonImages");
                    if (collection.personImage != null && collection.personImage.Length < 204800)
                    {
                        personImage = "personImage" + collection.person.idNumber + ".jpg";
                        string fullpath = Path.Combine(uplode, personImage);
                        collection.personImage.CopyTo(new FileStream(fullpath, FileMode.Create));
                    }
                    if (collection.identityImageFront != null && collection.identityImageFront.Length < 204800)
                    {
                        identityImageFront = "identityImageFront" + collection.person.idNumber + ".jpg";
                        string fullpath = Path.Combine(uplode, identityImageFront);
                        collection.identityImageFront.CopyTo(new FileStream(fullpath, FileMode.Create));
                    }
                    if (collection.identityImageBack != null && collection.identityImageBack.Length < 204800)
                    {
                        identityImageBack = "identityImageBack" + collection.person.idNumber + ".jpg";
                        string fullpath = Path.Combine(uplode, identityImageBack);
                        collection.identityImageBack.CopyTo(new FileStream(fullpath, FileMode.Create));
                    }
                    var per = new Person
                    {
                        dateOfBirth = collection.person.dateOfBirth,
                        emailAddress = collection.person.emailAddress,
                        fatherName = collection.person.fatherName,
                        firstName = collection.person.firstName,
                        idNumber = collection.person.idNumber,
                        lastName = collection.person.lastName,
                        mobile = collection.person.mobile,
                        motherName = collection.person.motherName,
                        nationality = collection.person.nationality,
                        phone = collection.person.phone,
                        placeOFBirth = collection.person.placeOFBirth,
                        region = Region.Find(collection.person.region.id.ToString()),
                        title = collection.person.title,
                        adress = collection.person.adress
                    };
                    if (personImage != null)
                    { per.personImage = personImage; }
                    if (identityImageFront != null)
                    { per.identityImageFront = identityImageFront; }
                    if (identityImageBack != null)
                    { per.identityImageBack = identityImageBack; }
                    Person.Update(per);
                    var con = RealtyContract.Find(collection.realtyContract.id);
                    var ben = new Beneficiary
                    {
                        id = collection.id,
                        period = collection.period,
                        isChecked = collection.isChecked,
                        realtyContract = con,
                        person = per,
                        typePerson = collection.typePerson
                    };
                    Beneficiary.Update(ben);
                    Beneficiary.Save();
                    return RedirectToAction(nameof(Details), "Issues", new { id = collection.realtyContract.id });
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
                var ben = Beneficiary.Find(id);
                if (ben.isChecked == false)
                {
                    return View(ben);
                }
                else { return RedirectToAction(nameof(Details), "Issues", new { id = ben.realtyContract.id }); }
            }
            catch
            {
                return View("Error");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Beneficiary collection, string mess)
        {
            try
            {
                var ben = Beneficiary.Find(collection.id);
                Beneficiary.Delete(ben);
                var conNot = new RealtyContractNote
                {
                    id = Guid.NewGuid().ToString(),
                    noteDate = DateTime.Now,
                    noteType = "delete person",
                    realtyContract = ben.realtyContract,
                    user = UserManager.GetUserAsync(User).Result,
                    note = mess
                };
                RealtyContractNote.Add(conNot);
                Beneficiary.Save();
                return RedirectToAction(nameof(Details), "Issues", new { id = ben.realtyContract.id });
            }
            catch
            {
                return View("Error");
            }
        }
        public ActionResult AddPerson(string contract, string type)
        {
            try
            {
                var con = RealtyContract.Find(contract);
                if (con.isChecked == false)
                {
                    var ben = new Beneficiary
                    {
                        realtyContract = con,
                        typePerson = type
                    };
                    return PartialView("AddPerson", ben);
                }
                else
                {
                    var ben = new Beneficiary
                    {
                        id = "Error"
                    };
                    return PartialView("AddPerson", ben);
                }
            }
            catch
            {
                return View("Error");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPerson(Beneficiary ben)
        {
            try
            {
                return RedirectToAction(nameof(Create), new { personId = ben.person.idNumber, contract = ben.realtyContract.id, type = ben.typePerson });
            }
            catch { return View("Error"); }
        }
        public ActionResult ScheduleASession(string beneficiaryId)
        {
            try
            {
                var ben = Beneficiary.Find(beneficiaryId);
                ben.SessionDate = DateTime.Now;
                return PartialView("ScheduleASession", ben);
            }
            catch
            { return View("Erorr"); }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ScheduleASession(Beneficiary collection)
        {
            try
            {
                var ben = Beneficiary.Find(collection.id);
                ben.SessionDate = collection.SessionDate;
                Beneficiary.Update(ben);
                UserFun.sendMessage("BenSchedule"+ ben.SessionDate,ben.person.emailAddress,"",ben.realtyContract.id);
                Beneficiary.Save();
                return RedirectToAction(nameof(Details), "Issues", new { id = ben.realtyContract.id });
            }
            catch
            { return View("Erorr"); }
        }
    }
}
