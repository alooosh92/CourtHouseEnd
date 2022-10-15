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

    public class FeesController : Controller
    {
        public IRepository<Fees> Fees { get; }
        public IRepository<PaymentMethod> PaymentMethod { get; }
        public IRepository<Person> Person { get; }
        public IRepository<RealtyContract> RealtyContract { get; }
        public IWebHostEnvironment Hosting { get; }
        public UserManager<User> UserManager { get; }
        public IRepository<RealtyContractNote> RealtyContractNote { get; }
        public IRepositoryUser UserFun { get; }

        public FeesController(IRepository<Fees> fees, IRepository<PaymentMethod> paymentMethod, IRepository<Person> person, IRepository<RealtyContract> realtyContract, IWebHostEnvironment hosting, UserManager<User> userManager, IRepository<RealtyContractNote> realtyContractNote, IRepositoryUser userFun)
        {
            Fees = fees;
            PaymentMethod = paymentMethod;
            Person = person;
            RealtyContract = realtyContract;
            Hosting = hosting;
            UserManager = userManager;
            RealtyContractNote = realtyContractNote;
            UserFun = userFun;
        }
        public ActionResult Details(string id)
        {
            try
            {
                var fee = Fees.Find(id);
                return PartialView("Details", fee);
            }
            catch
            {
                return View("Error");
            }
        }
        [Authorize(Roles = "Finance")]
        public ActionResult Create(string contractId, string personId)
        {
            try
            {
                var fee = new Fees
                {
                    person = Person.Find(personId),
                    realtyContract = RealtyContract.Find(contractId)
                };
                return PartialView("Create", fee);
            }
            catch
            {
                return View("Error");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fees collection)
        {
            try
            {
                var fee = new Fees
                {
                    id = Guid.NewGuid().ToString(),
                    financialNoticeNumber = collection.financialNoticeNumber,
                    isPayment = false,
                    person = Person.Find(collection.person.idNumber),
                    realtyContract = RealtyContract.Find(collection.realtyContract.id),
                    theFinancialValue = collection.theFinancialValue,
                    reasonOfPayment = collection.reasonOfPayment
                };
                Fees.Add(fee);
                var conNot = new RealtyContractNote
                {
                    id = Guid.NewGuid().ToString(),
                    noteDate = DateTime.Now,
                    noteType = "Add Fees",
                    realtyContract = fee.realtyContract,
                    user = UserManager.GetUserAsync(User).Result,
                    note = "Add Fees " + fee.id
                };
                RealtyContractNote.Add(conNot);
                Fees.Save();
                return RedirectToAction(nameof(Details), "Issues", new { id = fee.realtyContract.id });
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "Finance")]
        public ActionResult Edit(string id)
        {
            try
            {
                var fee = Fees.Find(id);
                if (fee.isPayment == false)
                {
                    var VMFee = new VMFees { financialNoticeNumber = fee.financialNoticeNumber, id = fee.id, person = fee.person, isPayment = fee.isPayment, paymentImage = fee.paymentImage, paymentMethod = fee.paymentMethod, realtyContract = fee.realtyContract, paymentMethods = PaymentMethod.All(), TheFinancialValue = fee.theFinancialValue, reasonOfPayment = fee.reasonOfPayment };
                    return PartialView("Edit", VMFee);
                }
                else { return RedirectToAction(nameof(Details), "Issues", new { id = fee.realtyContract.id }); }
            }
            catch
            {
                return View("Error");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VMFees collection, string check)
        {
            try
            {
                var Fee = Fees.Find(collection.id);
                if (check == "UnChecker")
                {
                    Fee.isPayment = false;
                    Fees.Update(Fee);
                    Fees.Save();
                    return RedirectToAction(nameof(Details), "Issues", new { id = Fee.realtyContract.id });
                }
                if (check == "Checker" && Fee.paymentImage != null)
                {
                    Fee.isPayment = true;
                    Fees.Update(Fee);
                    var conNot = new RealtyContractNote
                    {
                        id = Guid.NewGuid().ToString(),
                        noteDate = DateTime.Now,
                        noteType = "Checked Fees",
                        realtyContract = Fee.realtyContract,
                        user = UserManager.GetUserAsync(User).Result
                    };
                    RealtyContractNote.Add(conNot);
                    Fees.Save();
                    return RedirectToAction(nameof(Details), "Issues", new { id = Fee.realtyContract.id });
                }
                else
                {
                    Fee.financialNoticeNumber = collection.financialNoticeNumber;
                    Fee.isPayment = collection.isPayment;
                    Fee.paymentMethod = collection.paymentMethod;
                    Fee.theFinancialValue = collection.TheFinancialValue;
                    Fee.reasonOfPayment = collection.reasonOfPayment;
                    Fees.Update(Fee);
                    Fees.Save();
                    return RedirectToAction(nameof(Details), "Issues", new { id = Fee.realtyContract.id });
                }
            }
            catch
            {
                return PartialView("Edit");
            }
        }
        public ActionResult AddPayment(string id)
        {
            try
            {
                var fee = Fees.Find(id);
                var VMFee = new VMFees
                {
                    financialNoticeNumber = fee.financialNoticeNumber,
                    id = fee.id,
                    person = fee.person,
                    isPayment = fee.isPayment,
                    paymentImage = fee.paymentImage,
                    paymentMethod = fee.paymentMethod,
                    realtyContract = fee.realtyContract,
                    paymentMethods = PaymentMethod.All(),
                    TheFinancialValue = fee.theFinancialValue,
                    reasonOfPayment = fee.reasonOfPayment
                };
                return PartialView("AddPayment", VMFee);
            }
            catch
            {
                return View("Error");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPayment(VMFees collection)
        {
            try
            {
                var fee = Fees.Find(collection.id);
                if (collection.paymentImageUrl != null && collection.paymentImageUrl.Length < 204800)
                {
                    string paymentImage = string.Empty;
                    string uplode = Path.Combine(Hosting.WebRootPath, "FeesImages");
                    paymentImage = "PaymentImage" + collection.id + ".jpg";
                    string fullpath = Path.Combine(uplode, paymentImage);
                    collection.paymentImageUrl.CopyTo(new FileStream(fullpath, FileMode.Create));
                    fee.paymentImage = paymentImage;
                    fee.paymentMethod = collection.paymentMethod;
                    fee.financialNoticeNumber = collection.financialNoticeNumber;
                    Fees.Update(fee);
                    var conNot = new RealtyContractNote
                    {
                        id = Guid.NewGuid().ToString(),
                        noteDate = DateTime.Now,
                        noteType = "Add payment",
                        realtyContract = fee.realtyContract,
                        user = UserManager.GetUserAsync(User).Result,
                        note = "add payment " + fee.id
                    };
                    var feeses = Fees.Search(conNot.realtyContract.id);
                    var RC = RealtyContract.Find(fee.realtyContract.id);
                    var test = 0;
                    foreach (var f in feeses)
                    {
                        if (f.isPayment == false) break;
                        RC.isPayFinance = true;
                    }
                    foreach (var f in feeses)
                    {
                        if (f.financialNoticeNumber != null) test++;
                    }
                        if (test == feeses.Count) UserFun.sendMessage("PayFees",RC.finance.Email,"",RC.id);
                    RealtyContractNote.Add(conNot);
                    Fees.Save();
                }
                return RedirectToAction(nameof(Details), "Issues", new { id = collection.realtyContract.id });
            }
            catch
            {
                return PartialView("AddPayment", Fees.Find(collection.id));
            }
        }
        [Authorize(Roles = "Finance")]
        public ActionResult Delete(string id)
        {
            try
            {
                var fee = Fees.Find(id);
                if (fee.isPayment == false)
                {

                    return PartialView("Delete", fee);
                }
                else { return PartialView("Delete", new Fees { id = "Error" }); }

            }
            catch
            {
                return View("Error");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Fees collection, string mess)
        {
            try
            {
                var fee = Fees.Find(collection.id);
                Fees.Delete(fee);
                var conNot = new RealtyContractNote
                {
                    id = Guid.NewGuid().ToString(),
                    noteDate = DateTime.Now,
                    noteType = "delete fees",
                    realtyContract = fee.realtyContract,
                    user = UserManager.GetUserAsync(User).Result,
                    note = mess
                };
                RealtyContractNote.Add(conNot);
                Fees.Save();
                return RedirectToAction(nameof(Details), "Issues", new { id = fee.realtyContract.id });
            }
            catch
            {
                return View();
            }
        }
    }
}
