using CourtHouse.Data;
using CourtHouse.Data.Repository;
using CourtHouse.Data.ViewModels;
using CourtHouse.Models;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;

namespace CourtHouse.Controllers
{
    [Authorize]
    public class IssuesController : Controller
    {
        public IRepository<RealtyContract> RealtyContract { get; }
        public UserManager<User> UserManager { get; }
        public IRepository<Region> Region { get; }
        public IRepository<Realty> Realty { get; }
        public IRepository<Beneficiary> Beneficiary { get; }
        public IRepository<Fees> Fees { get; }
        public IRepository<OfficialDocument> OfficialDocument { get; }
        public IWebHostEnvironment Hosting { get; }
        public IRepository<RealtyContractNote> RealtyContractNots { get; }
        public IRepositoryUser UserFun { get; }
        public FaceId FaceId { get; }

        public IssuesController(IRepository<RealtyContract> realtyContract, UserManager<User> userManager,
            IRepository<Region> region, IRepository<Realty> realty, IRepository<Beneficiary> beneficiary,
            IRepository<Fees> fees, IRepository<OfficialDocument> officialDocument, IWebHostEnvironment hosting,
            IRepository<RealtyContractNote> realtyContractNots, IRepositoryUser userFun, FaceId faceId)
        {
            RealtyContract = realtyContract;
            UserManager = userManager;
            Region = region;
            Realty = realty;
            Beneficiary = beneficiary;
            Fees = fees;
            OfficialDocument = officialDocument;
            Hosting = hosting;
            RealtyContractNots = realtyContractNots;
            UserFun = userFun;
            FaceId = faceId;
        }
        public ActionResult Index()
        {
            try
            {
                var username = UserManager.GetUserId(User);
                var VMReCoWILs = new VMRealtyContractWithList
                {
                    CheckContract = new List<RealtyContract>(),
                    EndContract = new List<RealtyContract>(),
                    NewContract = new List<RealtyContract>(),
                    ScheduleContract = new List<RealtyContract>(),
                    WaitPayContract = new List<RealtyContract>(),
                    WaitScheduleContract = new List<RealtyContract>(),
                    ScheduleContractToday = new List<RealtyContract>()
                };
                if (User.IsInRole("Admin"))
                {
                    var con = RealtyContract.All().OrderByDescending(a => a.startDate);
                    foreach (var item in con)
                    {
                        if (item.isChecked == false) VMReCoWILs.NewContract.Add(item);
                        if (item.isChecked == true && item.isAddFinance == false) VMReCoWILs.CheckContract.Add(item);
                        if (item.isAddFinance == true && item.isFinance == false) VMReCoWILs.WaitPayContract.Add(item);
                        if (item.isFinance == true && item.isJudge == false)
                        {
                            var c = Beneficiary.Search(item.id);
                            var b = false;
                            foreach (var ben in c)
                            {
                                if (ben.SessionDate.ToString() == "1/1/0001 12:00:00 AM")
                                {
                                    b = true;
                                    break;
                                }
                            }
                            if (b)
                            {
                                VMReCoWILs.WaitScheduleContract.Add(item);
                            }
                        }
                        if (item.isFinance == true && item.isJudge == false)
                        {
                            var c = Beneficiary.Search(item.id);
                            var b = true;
                            foreach (var ben in c)
                            {
                                if (ben.SessionDate.ToString() == "1/1/0001 12:00:00 AM")
                                {
                                    b = false;
                                    break;
                                }
                            }
                            foreach (var ben in c)
                            {
                                if (ben.SessionDate.Date == DateTime.Now.Date)
                                {
                                    VMReCoWILs.ScheduleContractToday.Add(ben.realtyContract);
                                }
                            }
                            if (b)
                            {
                                VMReCoWILs.ScheduleContract.Add(item);
                            }
                        }
                        if (item.isJudge == true) VMReCoWILs.EndContract.Add(item);                        
                    }
                    VMReCoWILs.NewContract.OrderBy(a => a.startDate);
                    VMReCoWILs.EndContract.OrderByDescending(a => a.startDate);
                    VMReCoWILs.CheckContract.OrderBy(a => a.startDate);
                    VMReCoWILs.ScheduleContract.OrderBy(a => a.startDate);
                    VMReCoWILs.ScheduleContractToday.OrderBy(a => a.startDate);
                    VMReCoWILs.WaitPayContract.OrderBy(a => a.startDate);
                    VMReCoWILs.WaitScheduleContract.OrderBy(a => a.startDate);                   
                    return View(VMReCoWILs);
                }
                if (User.IsInRole("LocalAdmin"))
                {
                    var con = RealtyContract.Search(UserManager.GetUserId(User),"LocalAdmin").OrderByDescending(a => a.startDate);
                    foreach (var item in con)
                    {
                        if (item.isChecked == false) VMReCoWILs.NewContract.Add(item);
                        if (item.isChecked == true && item.isAddFinance == false) VMReCoWILs.CheckContract.Add(item);
                        if (item.isAddFinance == true && item.isFinance == false) VMReCoWILs.WaitPayContract.Add(item);
                        if (item.isFinance == true && item.isJudge == false)
                        {
                            var c = Beneficiary.Search(item.id);
                            var b = false;
                            foreach (var ben in c)
                            {
                                if (ben.SessionDate.ToString() == "1/1/0001 12:00:00 AM")
                                {
                                    b = true;
                                    break;
                                }
                            }
                            if (b)
                            {
                                VMReCoWILs.WaitScheduleContract.Add(item);
                            }
                        }
                        if (item.isFinance == true && item.isJudge == false)
                        {
                            var c = Beneficiary.Search(item.id);
                            var b = true;
                            foreach (var ben in c)
                            {
                                if (ben.SessionDate.ToString() == "1/1/0001 12:00:00 AM")
                                {
                                    b = false;
                                    break;
                                }
                            }
                            foreach (var ben in c)
                            {
                                if (ben.SessionDate.Date == DateTime.Now.Date)
                                {
                                    VMReCoWILs.ScheduleContractToday.Add(ben.realtyContract);
                                }
                            }
                            if (b)
                            {
                                VMReCoWILs.ScheduleContract.Add(item);
                            }
                        }
                        if (item.isJudge == true) VMReCoWILs.EndContract.Add(item);
                    }
                    VMReCoWILs.NewContract.OrderBy(a => a.startDate);
                    VMReCoWILs.EndContract.OrderByDescending(a => a.startDate);
                    VMReCoWILs.CheckContract.OrderBy(a => a.startDate);
                    VMReCoWILs.ScheduleContract.OrderBy(a => a.startDate);
                    VMReCoWILs.ScheduleContractToday.OrderBy(a => a.startDate);
                    VMReCoWILs.WaitPayContract.OrderBy(a => a.startDate);
                    VMReCoWILs.WaitScheduleContract.OrderBy(a => a.startDate);
                    return View(VMReCoWILs);
                }
                if (User.IsInRole("Checker"))
                {
                    var con = RealtyContract.Search(username, "Checker").OrderBy(b => b.isChecked).ThenBy(a => a.startDate);
                    VMReCoWILs.NewContract = con.ToList();
                    return View(VMReCoWILs);
                }
                if (User.IsInRole("Finance"))
                {
                    var con = RealtyContract.Search(username, "Finance").OrderBy(b => b.isFinance).ThenBy(a => a.startDate);
                    foreach (var item in con)
                    {
                        if (item.isChecked == true && item.isAddFinance == false) VMReCoWILs.NewContract.Add(item);
                        if (item.isAddFinance == true && item.isFinance == false) VMReCoWILs.WaitPayContract.Add(item);
                    }
                    VMReCoWILs.NewContract.OrderBy(a => a.startDate);
                    VMReCoWILs.WaitPayContract.OrderBy(a => a.startDate);
                    return View(VMReCoWILs);
                }
                if (User.IsInRole("Judge"))
                {
                    var con = RealtyContract.Search(username, "Judge").OrderBy(b => b.isJudge).ThenBy(a => a.startDate);
                    foreach (var item in con)
                    {
                        if (item.isFinance == true && item.isJudge == false)
                        {
                            var c = Beneficiary.Search(item.id);
                            var b = false;
                            foreach (var ben in c)
                            {
                                if (ben.SessionDate.ToString() == "1/1/0001 12:00:00 AM")
                                {
                                    b = true;
                                    break;
                                }
                            }
                            foreach (var ben in c)
                            {
                                if (ben.SessionDate.Date == DateTime.Now.Date)
                                {
                                    VMReCoWILs.ScheduleContractToday.Add(ben.realtyContract);
                                }
                            }
                            if (b)
                            {
                                VMReCoWILs.NewContract.Add(item);
                            }
                        }
                        if (item.isFinance == true && item.isJudge == false)
                        {
                            var c = Beneficiary.Search(item.id);
                            var b = true;
                            foreach (var ben in c)
                            {
                                if (ben.SessionDate.ToString() == "1/1/0001 12:00:00 AM")
                                {
                                    b = false;
                                    break;
                                }
                            }
                            if (b)
                            {
                                VMReCoWILs.ScheduleContract.Add(item);
                            }
                        }
                    }
                    VMReCoWILs.NewContract.OrderBy(a => a.startDate);
                    VMReCoWILs.ScheduleContract.OrderBy(a => a.startDate);
                    VMReCoWILs.ScheduleContractToday.OrderBy(a => a.startDate);
                    return View(VMReCoWILs);
                }
                if (User.IsInRole("Recorder"))
                {
                    var con = RealtyContract.Search(username, "Recorder").OrderBy(b => b.isRecorder).ThenBy(a => a.startDate);
                    VMReCoWILs.NewContract = con.ToList();
                    return View(VMReCoWILs);
                }
                var conn = RealtyContract.Search(username).OrderByDescending(a => a.startDate);
                foreach (var item in conn)
                {
                    if (item.isChecked == false) VMReCoWILs.NewContract.Add(item);
                    if (item.isChecked == true && item.isAddFinance == false) VMReCoWILs.CheckContract.Add(item);
                    if (item.isAddFinance == true && item.isFinance == false) VMReCoWILs.WaitPayContract.Add(item);
                    if (item.isFinance == true && item.isJudge == false)
                    {
                        var c = Beneficiary.Search(item.id);
                        var b = false;
                        foreach (var ben in c)
                        {
                            if (ben.SessionDate.ToString() == "1/1/0001 12:00:00 AM")
                            {
                                b = true;
                                break;
                            }
                        }
                        foreach (var ben in c)
                        {
                            if (ben.SessionDate.Date == DateTime.Now.Date)
                            {
                                VMReCoWILs.ScheduleContractToday.Add(ben.realtyContract);
                            }
                        }
                        if (b)
                        {
                            VMReCoWILs.WaitScheduleContract.Add(item);
                        }
                    }
                    if (item.isFinance == true && item.isJudge == false)
                    {
                        var c = Beneficiary.Search(item.id);
                        var b = true;
                        foreach (var ben in c)
                        {
                            if (ben.SessionDate.ToString() == "1/1/0001 12:00:00 AM")
                            {
                                b = false;
                                break;
                            }
                        }
                        if (b)
                        {
                            VMReCoWILs.ScheduleContract.Add(item);
                        }
                    }
                    if (item.isJudge == true) VMReCoWILs.EndContract.Add(item);
                }
                VMReCoWILs.NewContract.OrderBy(a => a.startDate);
                VMReCoWILs.EndContract.OrderByDescending(a => a.startDate);
                VMReCoWILs.CheckContract.OrderBy(a => a.startDate);
                VMReCoWILs.ScheduleContract.OrderBy(a => a.startDate);
                VMReCoWILs.ScheduleContractToday.OrderBy(a => a.startDate);
                VMReCoWILs.WaitPayContract.OrderBy(a => a.startDate);
                VMReCoWILs.WaitScheduleContract.OrderBy(a => a.startDate);
                return View(VMReCoWILs);
            }
            catch
            {
                return View("Error");
            }
        }
        public ActionResult Details(string id)
        {
            try
            {
                var reacon = RealtyContract.Find(id);
                var testUser = UserManager.GetUserId(User);
                if (User.IsInRole("Admin") || reacon.user.Id == testUser || reacon.checker.Id == testUser || reacon.finance.Id == testUser || reacon.judge.Id == testUser)
                {
                    var benList = Beneficiary.Search(id);
                    var feeslist = Fees.Search(id);
                    var offecList = OfficialDocument.Search(id);
                    if (reacon.isJudge == true)
                    {
                        ViewData["info"] = "ملاحظات القضية:" + reacon.judgment;
                        ViewData["ContractState"] = "<h2><span style='color:lightgreen'> <i class='bi bi-check-circle-fill'></i></span>معلومات العقد</h2>";
                        if (User.IsInRole("Admin"))
                        {
                            ViewData["AdminBtnCheck"] = "UnJudge";
                            ViewData["AdminBtnText"] = "إلغاء الحكم";
                        }
                    }
                    else if (reacon.isFinance == true)
                    {
                        ViewData["info"] = "ملاحظات القضية: تمت تدقيق الدفعات المالية وبإنتظار الحكم";
                        ViewData["ContractState"] = "<h2><span style='color:deepskyblue'> <i class='bi bi-exclamation-circle-fill'></i></span>معلومات العقد</h2>";
                        if (User.IsInRole("Admin"))
                        {
                            ViewData["AdminBtnCheck"] = "UnFinance";
                            ViewData["AdminBtnText"] = "غير مدفوع";
                        }
                        if (User.IsInRole("Judge"))
                        {
                            ViewData["BtnCheck"] = "";
                        }
                    }
                    else if (reacon.isAddFinance == true)
                    {
                        ViewData["info"] = "ملاحظات القضية: تمت اضافة الدفعات الرجاء دفع الذمم المالية";
                        ViewData["ContractState"] = "<h2><span style='color: dodgerblue'> <i class='bi bi-exclamation-circle-fill'></i></span>معلومات العقد</h2>";
                        if (User.IsInRole("Admin"))
                        {
                            ViewData["AdminBtnCheck"] = "UnAddFinance";
                            ViewData["AdminBtnText"] = "لم يتم اضافة الرسوم";
                        }
                        if (User.IsInRole("Finance"))
                        {
                            ViewData["BtnCheck"] = "Finance";
                            ViewData["BtnText"] = "تم الدفع";
                        }
                    }
                    else if (reacon.isChecked == true)
                    {
                        ViewData["info"] = "ملاحظات القضية:  تمت تدقيق بيانات القضية وتحويلها لقسم المالية ";
                        ViewData["ContractState"] = "<h2><span style='color: dodgerblue'> <i class='bi bi-exclamation-circle-fill'></i></span>معلومات العقد</h2>";
                        if (User.IsInRole("Admin"))
                        {
                            ViewData["AdminBtnCheck"] = "UnChecker";
                            ViewData["AdminBtnText"] = "غير مدقق";
                        }
                        if (User.IsInRole("Finance"))
                        {
                            ViewData["BtnCheck"] = "AddFinance";
                            ViewData["BtnText"] = "تم اضافة الرسوم";
                        }
                    }
                    else
                    {
                        ViewData["info"] = "ملاحظات القضية: بانتظار تدقيق القضية من قسم التدقيق(يمكنك التعديل على القضية قبل تدقيقها فقط)";
                        ViewData["ContractState"] = "<h2><span style='color: coral'> <i class='bi bi-exclamation-circle-fill'></i></span>معلومات العقد</h2>";
                        if (User.IsInRole("Checker"))
                        {
                            ViewData["BtnCheck"] = "Checker";
                            ViewData["BtnText"] = "مدقق";
                        }
                    }
                    var Issues = new VMIssues
                    {
                        beneficiary = benList,
                        fees = feeslist,
                        officialDocument = offecList,
                        realtyContract = reacon
                    };
                    return View(Issues);
                }else return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Error", "Home", new { info = "انت لا تملك الصلاحية لعرض هذه القضية" });
            }
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
                var VRCR = new VMRealtyContractRealty
                {
                    realty = VR
                };
                return View(VRCR);
            }
            catch
            {
                return View("Error");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VMRealtyContractRealty collection)
        {
            try
            {
                var R = Realty.Find(collection.realty.id);
                R.isChecked = true;
                Realty.Update(R);
                var RC = new RealtyContract
                {
                    contractType = collection.realtyContract.contractType,
                    id = Guid.NewGuid().ToString(),
                    isChecked = false,
                    isFinance = false,
                    isJudge = false,
                    isRecorder = false,
                    startDate = DateTime.Now,
                    realty = R,
                    user = UserManager.FindByIdAsync(collection.realtyContract.user).Result,
                    checker = UserFun.chooseUser(R.region, "Checker")
                };
                RealtyContract.Add(RC);
                var conNot = new RealtyContractNote
                {
                    id = Guid.NewGuid().ToString(),
                    noteDate = DateTime.Now,
                    noteType = "Add Issues",
                    realtyContract = RC,
                    user = UserManager.GetUserAsync(User).Result
                };
                RealtyContractNots.Add(conNot);
                var email = UserManager.GetUserAsync(User).Result.Email;
                UserFun.sendMessage("Create", UserManager.GetUserAsync(User).Result.Email, RC.checker.Email, RC.id);
                RealtyContract.Save();
                return RedirectToAction(nameof(Details), new { id = RC.id});
            }
            catch { return View("Error"); }
        }
        public ActionResult Edit(string id, string check)
        {
            try
            {
                var reac = RealtyContract.Find(id);
                switch (check)
                {
                    case "Recorder": { return View(); }
                    case "UnRecorder":
                        {
                            reac.isRecorder = false;
                            RealtyContract.Update(reac);
                            RealtyContract.Save();
                            return RedirectToAction(nameof(Details), new { id = reac.id });
                        }
                    case "Judge":
                        {
                            return PartialView("AddJudgment", id);
                        }
                    case "UnJudge":
                        {
                            reac.isJudge = false;
                            RealtyContract.Update(reac);
                            RealtyContract.Save();
                            return RedirectToAction(nameof(Details), new { id = reac.id });
                        }
                    case "Finance":
                        {
                            var Fee = Fees.Search(reac.id);
                            for (int i = 0; i < Fees.Search(reac.id).Count; i++)
                            {
                                if (Fee[i].isPayment == false)
                                    return RedirectToAction(nameof(Details), new { id = reac.id });
                            };
                            reac.isFinance = true;
                            reac.judge = UserFun.chooseUser(reac.realty.region, "Judge");
                            RealtyContract.Update(reac);
                            var conNot = new RealtyContractNote
                            {
                                id = Guid.NewGuid().ToString(),
                                noteDate = DateTime.Now,
                                noteType = "Add Finance",
                                realtyContract = reac,
                                user = UserManager.GetUserAsync(User).Result
                            };
                            RealtyContractNots.Add(conNot);
                            UserFun.sendMessage("CkeckFees", reac.user.Email, reac.judge.Email, reac.id);
                            RealtyContract.Save();
                            return RedirectToAction(nameof(Details), new { id = reac.id });
                        }
                    case "UnFinance":
                        {
                            reac.isFinance = false;
                            RealtyContract.Update(reac);
                            RealtyContract.Save();
                            return RedirectToAction(nameof(Details), new { id = reac.id });
                        }
                    case "AddFinance":
                        {
                            if (Fees.Search(reac.id).Count != 0)
                            {
                                reac.isAddFinance = true;
                                RealtyContract.Update(reac);
                                var conNot = new RealtyContractNote
                                {
                                    id = Guid.NewGuid().ToString(),
                                    noteDate = DateTime.Now,
                                    noteType = "Add Finance complete",
                                    realtyContract = reac,
                                    user = UserManager.GetUserAsync(User).Result
                                };
                                RealtyContractNots.Add(conNot);
                                RealtyContract.Save();
                                UserFun.sendMessage("AddFees", reac.user.Email, "", reac.id);
                                return RedirectToAction(nameof(Details), new { id = reac.id });
                            }
                            else { return RedirectToAction(nameof(Details), new { id = reac.id }); }
                        }
                    case "UnAddFinance":
                        {
                            reac.isAddFinance = false;
                            RealtyContract.Update(reac);
                            RealtyContract.Save();
                            return RedirectToAction(nameof(Details), new { id = reac.id });
                        }
                    case "Checker":
                        {
                            var con = RealtyContract.Find(id);
                            var benList = Beneficiary.Search(id);
                            var feeslist = Fees.Search(id);
                            var offecList = OfficialDocument.Search(id);
                            if (benList.Count == 0 || offecList.Count == 0)
                            {
                                return RedirectToAction(nameof(Details), new { id = con.id });
                            }
                            foreach (var item in benList)
                            {
                                if (item.isChecked == false)
                                {
                                    return RedirectToAction(nameof(Details), new { id = con.id });
                                }
                            }
                            foreach (var item in feeslist)
                            {
                                if (item.isPayment == false)
                                {
                                    return RedirectToAction(nameof(Details), new { id = con.id });
                                }
                            }
                            foreach (var item in offecList)
                            {
                                if (item.isChecked == false)
                                {
                                    return RedirectToAction(nameof(Details), new { id = con.id });
                                }
                            }
                            con.isChecked = true;
                            con.finance = UserFun.chooseUser(con.realty.region, "Finance");
                            RealtyContract.Update(con);
                            var conNot = new RealtyContractNote
                            {
                                id = Guid.NewGuid().ToString(),
                                noteDate = DateTime.Now,
                                noteType = "Checked",
                                realtyContract = reac,
                                user = UserManager.GetUserAsync(User).Result
                            };
                            RealtyContractNots.Add(conNot);
                            UserFun.sendMessage("Ckeck", con.user.Email, con.finance.Email, con.id);
                            RealtyContract.Save();
                            return RedirectToAction(nameof(Details), new { id = con.id });
                        }
                    case "UnChecker":
                        {
                            reac.isChecked = false;
                            RealtyContract.Update(reac);
                            RealtyContract.Save();
                            return RedirectToAction(nameof(Details), new { id = reac.id });
                        }
                }
                if (reac.isChecked == false)
                {
                    var VMC = new VMRealtyContract
                    {
                        contractType = reac.contractType,
                        id = reac.id,
                        isChecked = reac.isChecked,
                        isFinance = reac.isFinance,
                        isJudge = reac.isJudge,
                        isRecorder = reac.isRecorder,
                        startDate = reac.startDate,
                        user = UserManager.GetUserId(User)
                    };
                    var VMR = new VMRealty
                    {
                        adress = reac.realty.adress,
                        area = reac.realty.area,
                        id = reac.realty.id,
                        info = reac.realty.info,
                        isChecked = reac.realty.isChecked,
                        realtyType = reac.realty.realtyType,
                        regionList = Region.All().ToList(),
                        regionSelect = reac.realty.region.id,
                        theFinancialValue = reac.realty.theFinancialValue
                    };
                    var VMRCR = new VMRealtyContractRealty
                    {
                        realty = VMR,
                        realtyContract = VMC
                    };
                    return View(VMRCR);
                }
                else { return RedirectToAction(nameof(Index)); }
            }
            catch
            {
                return View("Error");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VMRealtyContractRealty collection)
        {
            try
            {
                var rea = Realty.Find(collection.realty.id);
                rea.adress = collection.realty.adress;
                rea.area = collection.realty.area;
                rea.info = collection.realty.info;
                rea.realtyType = collection.realty.realtyType;
                rea.region = Region.Find(collection.realty.regionSelect.ToString());
                rea.theFinancialValue = collection.realty.theFinancialValue;
                var reaCon = RealtyContract.Find(collection.realtyContract.id);
                reaCon.contractType = collection.realtyContract.contractType;
                reaCon.realty = rea;
                RealtyContract.Update(reaCon);
                var conNot = new RealtyContractNote
                {
                    id = Guid.NewGuid().ToString(),
                    noteDate = DateTime.Now,
                    noteType = "Update Issuse",
                    realtyContract = reaCon,
                    user = UserManager.GetUserAsync(User).Result
                };
                RealtyContractNots.Add(conNot);
                RealtyContract.Save();
                return RedirectToAction(nameof(Details), new { id = reaCon.id });
            }
            catch
            {
                return View("Error");
            }

        }
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(string id)
        {
            try
            {
                var reacon = RealtyContract.Find(id);
                if (reacon.isChecked == false)
                {return PartialView("Delete", reacon);}
                else { return PartialView("Delete", new RealtyContract { id = "Error" }); }
            }
            catch
            {
                return View("Error");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(RealtyContract collection)
        {
            try
            {
                var reacon = RealtyContract.Find(collection.id);
                var benList = Beneficiary.Search(collection.id);
                var feeslist = Fees.Search(collection.id);
                var offecList = OfficialDocument.Search(collection.id);
                var reaconnot = RealtyContractNots.Search(collection.id);
                foreach (var item in offecList)
                {
                    string uplode = Path.Combine(Hosting.WebRootPath, "OfficialDocument");
                    string fullpath = Path.Combine(uplode, item.image);
                    OfficialDocument.Delete(item);
                    System.IO.File.Delete(fullpath);
                }
                foreach (var item in feeslist)
                {
                    Fees.Delete(item);
                }
                foreach (var item in benList)
                {
                    Beneficiary.Delete(item);
                }
                foreach (var item in reaconnot)
                {
                    RealtyContractNots.Delete(item);
                }
                RealtyContract.Delete(reacon);
                UserFun.sendMessage("DeleteCon", reacon.user.Email, "", reacon.id);
                reacon.realty.isChecked = false;
                Realty.Update(reacon.realty);
                RealtyContract.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Error");
            }
        }
        public ActionResult print(RealtyContract con)
        {
            try
            {
                var co = RealtyContract.Find(con.id);
                return View(co);
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
            if (Realty.Find(rea.id).isChecked == false)
            {
                return RedirectToAction(nameof(Create), new { con = rea.id });
            }
            else
            {
                return RedirectToAction("Error","Home", new { info = "هذا العقار ضمن قضية غير منتهية بعد\nلا يمكن انشاء قضية بهذا العقار حتى يتم الانتهاء من القضية الحالية"});
            }
        }
        public ActionResult AddJudgment(string id)
        {
            var rea = RealtyContract.Find(id);
            return PartialView("AddJudgment", rea);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddJudgment(RealtyContract collection)
        {
            var rea = RealtyContract.Find(collection.id);
            rea.judgment = collection.judgment;
            rea.isJudge = true;
            RealtyContract.Update(rea);
            var conNot = new RealtyContractNote
            {
                id = Guid.NewGuid().ToString(),
                noteDate = DateTime.Now,
                noteType = "Add Judgment",
                realtyContract = rea,
                user = UserManager.GetUserAsync(User).Result
            };
            RealtyContractNots.Add(conNot);
            UserFun.sendMessage("Sentencing" + rea.judgment, rea.user.Email, "", rea.id);
            rea.realty.isChecked = false;
            Realty.Update(rea.realty);
            RealtyContract.Save();
            return RedirectToAction(nameof(Details), new { id = rea.id });
        }
        public ActionResult ShowRealtyContractNote(string id)
        {
            var d = RealtyContractNots.Search(id).ToList();
            return PartialView("ShowRealtyContractNote", d);
        }
        public ActionResult SentMessege(string con)
        {
            var co = RealtyContract.Find(con);
            return PartialView("SentMessege", co);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SentMessege(RealtyContract con, string subject, string messegeBody)
        {
            var r = RealtyContract.Find(con.id);
            UserFun.sendMessage("Erorr", subject, messegeBody, r.user.Email);
            return RedirectToAction(nameof(Details), new { id = r.id });
        }
        [HttpPost]
        public ActionResult saveImage(string id)

        {
            try
            {
                var files = HttpContext.Request.Form.Files;
                var rea = new RealtyContract();
                if (files != null)
                {
                    foreach (var file in files)
                    {
                        if (file.Length > 0)
                        {
                            var fileName = file.FileName;
                            string fileNameToStore;
                            Beneficiary ben = Beneficiary.Find(fileName.Split("_")[0]);
                            rea = RealtyContract.Find(ben.realtyContract.id);
                            if (fileName.Contains("checkPerson"))
                            {
                                fileNameToStore = ben.person.idNumber + "_" + ben.id + "_checkPerson_" + string.Concat(Convert.ToString(Guid.NewGuid()), Path.GetExtension(fileName));
                            }
                            else
                            {
                                fileNameToStore = ben.person.idNumber + "_" + ben.id + "_RealImage_" + string.Concat(Convert.ToString(Guid.NewGuid()), Path.GetExtension(fileName));
                            }                           
                            var filepath = Path.Combine(Hosting.WebRootPath, "FaceId") + $@"\{fileNameToStore}";
                            if (!string.IsNullOrEmpty(filepath))
                            {
                                using (FileStream fileStream = System.IO.File.Create(filepath))
                                {
                                    file.CopyTo(fileStream);
                                    fileStream.Flush();
                                }
                                if (files[0].FileName.Contains("checkPerson"))
                                {
                                    List<Image<Gray, Byte>> LGImage = new List<Image<Gray, byte>>();
                                    var personImages = Directory.GetFiles(Path.Combine(Hosting.WebRootPath, "FaceId"), ben.person.idNumber + "*" + "_RealImage*", SearchOption.TopDirectoryOnly);
                                    foreach (var image in personImages)
                                    {
                                        Image<Bgr, Byte> imgBgr = new Image<Bgr, byte>(image);
                                        Image<Gray, Byte> imgGray = FaceId.faceDetectionImage(imgBgr);
                                        if (imgGray != null)
                                        {LGImage.Add(imgGray);}
                                    }

                                    Image<Bgr, Byte> img = new Image<Bgr, byte>(filepath);
                                    Image<Gray, Byte> grayImage = FaceId.faceDetectionImage(img);
                                    grayImage.Resize(200, 200, Inter.Cubic);
                                    Mat mat = new Mat();
                                    CvInvoke.EqualizeHist(grayImage, grayImage);
                                    FisherFaceRecognizer fisherFace = FaceId.recogntionFaceImageFisher(LGImage, ben.person.idNumber);
                                    var test = fisherFace.Predict(grayImage);
                                    if (test.Label == 1)
                                    {
                                        ben.faceIdChecked = true;
                                        Beneficiary.Update(ben);
                                        Beneficiary.Save();
                                        return RedirectToAction(nameof(Details), new { id = ben.realtyContract});
                                    }
                                    else
                                    {
                                        System.IO.File.Delete(filepath);
                                        return RedirectToAction(nameof(Details), new { id = ben.realtyContract});
                                    }
                                }
                                else
                                {
                                    ben.faceId = true;
                                    Beneficiary.Update(ben);
                                    Beneficiary.Save();
                                    return RedirectToAction(nameof(Details), new { id = ben.realtyContract});
                                }
                            }

                        }
                    }
                    return Json(true);
                }
                else
                {
                    return Json(false);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ActionResult CaptionImage(string id)
        {
            Beneficiary per = Beneficiary.Find(id);
            return PartialView("CaptionImage", per);
        }
        public ActionResult checkPerson(string id)
        {
            Beneficiary ben = Beneficiary.Find(id);
            return PartialView("checkPerson", ben);
        }
        public ActionResult deleteFaceID(string id)
        {
            var ben = Beneficiary.Find(id);
            return PartialView("deleteFaceID", ben);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult deleteFaceID(Beneficiary beneficiary)
        {
            var ben = Beneficiary.Find(beneficiary.id);
            var path = Path.Combine(Hosting.WebRootPath, "FaceId");
            var images = Directory.GetFiles(path, ben.person.idNumber.ToString() + "_" + ben.id.ToString() + "*", SearchOption.TopDirectoryOnly);
            foreach (var img in images)
            {
                System.IO.File.Delete(img);
            }
            ben.faceId = false;
            Beneficiary.Update(ben);
            Beneficiary.Save();
            return RedirectToAction(nameof(Details), new { id = ben.realtyContract.id });
        }
    }
}
