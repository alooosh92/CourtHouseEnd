using CourtHouse.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using static CourtHouse.Data.Repository.RepUserFun;

namespace CourtHouse.Data.Repository
{
    public class RepUserFun : IRepositoryUser
    {
        public class MailForm
        {
            public string subject { get; set; }
            public string mailBody { get; set; }
        }
        public RepUserFun(ApplicationDbContext db,UserManager<User> userManager, IWebHostEnvironment hosting,IRepository<RealtyContract> realtycontract, IHttpContextAccessor httpContext,IRepository<Region> region, IRepository<User> Ruser)
        {
            DB = db;
            UserManager = userManager;
            Hosting = hosting;
            Realtycontract = realtycontract;
            HttpContext = httpContext;
            Region = region;
            RUser = Ruser;
        }
        public ApplicationDbContext DB { get; }
        public UserManager<User> UserManager { get; }
        public IWebHostEnvironment Hosting { get; }
        public IRepository<RealtyContract> Realtycontract { get; }
        public IHttpContextAccessor HttpContext { get; }
        public IRepository<Region> Region { get; }
        public IRepository<User> RUser { get; }
        public User chooseUser(Region region, string role)
        {
            var users = UserManager.GetUsersInRoleAsync(role).Result.Where(a => a.region == region).ToList();
            User user = null;
            int num = -1;
            switch (role)
            {
                case "Checker":
                    {
                        foreach (var u in users)
                        {
                            var realty = DB.RealtyContracts.Where(a => a.isChecked == false && a.checker == u);
                            if (user == null)
                            { user = u; num = realty.Count(); }
                            else if (num > realty.Count()) { user = u; num = realty.Count(); }
                        }
                        return user;
                    }
                case "Finance":
                    {
                        foreach (var u in users)
                        {
                            var realty = DB.RealtyContracts.Where(a => a.isFinance == false && a.finance == u);
                            if (user == null)
                            { user = u; num = realty.Count(); }
                            else if (num > realty.Count()) { user = u; num = realty.Count(); }
                        }
                        return user;
                    }
                case "Judge":
                    {
                        foreach (var u in users)
                        {
                            var realty = DB.RealtyContracts.Where(a => a.isJudge == false && a.judge == u);
                            if (user == null)
                            { user = u; num = realty.Count(); }
                            else if (num > realty.Count()) { user = u; num = realty.Count(); }
                        }
                        return user;
                    }
            }
            return user;
        }        
        public IList<EmployeeInfo> employeeInfo(Region Reg)
        {
            var users = new List<User>();
            try
            {
                var r = Region.Find(Reg.id.ToString());
                if (r != null)
                {
                    users = UserManager.Users.Include(a => a.region).Where(a => a.region == Reg).ToList();
                }else users = UserManager.Users.Include(a => a.region).ToList();
            }
            catch 
            {
                users = UserManager.Users.Include(a => a.region).ToList();
            }
            List<EmployeeInfo> emps = new List<EmployeeInfo>();
            int i = 0;
            foreach (var u in users)
            {
                if (UserManager.IsInRoleAsync(u, "Employee").Result)
                {
                    double n = 0;
                    var cases = DB.RealtyContractNotes.Include(a => a.realtyContract).Include(a => a.user).Where(a =>
                        (a.noteType == "Checked" && a.user == u) ||
                        (a.noteType == "Add Finance" && a.user == u) ||
                        (a.noteType == "Add Judgment" && a.user == u));
                    foreach (var c in cases)
                    {
                        if (c.noteType == "Checked") { n = n + (c.noteDate - c.realtyContract.startDate).TotalDays; }
                        else if (c.noteType == "Add Finance")
                        {
                            var cn = DB.RealtyContractNotes.Include(a => a.realtyContract).Include(a => a.user).Where(a =>
                            a.noteType == "Checked" && a.realtyContract == c.realtyContract).FirstOrDefault();
                            if (cn != null) n = n + (c.noteDate - cn.noteDate).TotalDays;
                        }
                        else if (c.noteType == "Add Judgment")
                        {
                            var cn = DB.RealtyContractNotes.Include(a => a.realtyContract).Include(a => a.user).Where(a =>
                            a.noteType == "Add Finance" && a.realtyContract == c.realtyContract).FirstOrDefault();
                            if (cn != null) n = n + (c.noteDate - cn.noteDate).TotalDays;
                        }

                    }
                    var e = new EmployeeInfo
                    {
                        id = i + 1,

                        AvaregDelayInCase = Math.Ceiling(n / cases.Count()),

                        NumAllCases = DB.RealtyContracts.Include(a => a.user).Include(a => a.checker).
                        Include(a => a.judge).Include(a => a.finance).Include(a => a.realty).Where(a =>
                       (a.checker == u && a.isChecked == true) ||
                       (a.finance == u && a.isFinance == true) ||
                       (a.judge == u && a.isJudge == true)).Count(),

                        NumEndCasesInThisMonth = DB.RealtyContractNotes.Include(a => a.realtyContract).Include(a => a.user).Where(a =>
                        (a.noteType == "Checked" && a.user == u && a.noteDate > DateTime.Now.AddMonths(-1)) ||
                        (a.noteType == "Add Finance" && a.user == u && a.noteDate > DateTime.Now.AddMonths(-1)) ||
                        (a.noteType == "Add Judgment" && a.user == u && a.noteDate > DateTime.Now.AddMonths(-1))).Count(),

                        NumUnfinishedCases = DB.RealtyContracts.Include(a => a.user).Include(a => a.checker).
                        Include(a => a.judge).Include(a => a.realty).Include(a => a.finance).Where(a =>
                       (a.checker == u && a.isChecked == false) ||
                       (a.finance == u && a.isFinance == false) ||
                       (a.judge == u && a.isJudge == false)).Count(),

                        user = u
                    };
                    emps.Add(e);
                    i++;
                };
            }
            return emps;
        }
        public IList<RegionInfo> regionInfo()
        {
            var Reg = Region.All();
            var empinf = employeeInfo(new Region { });
            var reginles = new List<RegionInfo>();
            foreach (var item in Reg)
            {
                var emp = empinf.Where(a => a.user.region == item);
                var reginf = new RegionInfo { AvaregDelayInCase = 0};
                reginf.region = item;
                foreach(var em in emp)
                {
                    reginf.NumAllCases += em.NumAllCases;
                    reginf.NumEndCasesInThisMonth += em.NumEndCasesInThisMonth;
                    reginf.NumUnfinishedCases += em.NumUnfinishedCases;
                    if ( em.AvaregDelayInCase > 0)
                    reginf.AvaregDelayInCase += em.AvaregDelayInCase;
                }
                reginf.AvaregDelayInCase = Math.Ceiling(reginf.AvaregDelayInCase / reginf.NumAllCases);
                reginles.Add(reginf);
            }
            return reginles;
        }
        public void sendMessage(string type, string mailToUser, string mailToEmployee, string contract)
        {
          /*  SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
            smtpServer.Credentials = new System.Net.NetworkCredential("courthousesyria@gmail.com", "Qweasd12#");
            smtpServer.Port = 587;
            smtpServer.EnableSsl = true;

            if (type == "Erorr")
            {
                MailMessage mailUser = new MailMessage();
                mailUser.From = new MailAddress("courthousesyria@gmail.com");
                mailUser.To.Add(contract);
                mailUser.Subject = mailToUser;
                mailUser.Body = mailToEmployee;
                smtpServer.Send(mailUser);
            }
            else
            {
                MailMessage mailUser = new MailMessage();
                MailMessage mailEmployee = new MailMessage();
                var mu = mailForm(type, contract);

                mailUser.From = mailEmployee.From = new MailAddress("courthousesyria@gmail.com");
                mailUser.To.Add(mailToUser);
                mailUser.Subject = mu[0].subject;
                mailUser.Body = mu[0].mailBody;
                smtpServer.Send(mailUser);
                if (mu.Count > 1)
                {
                    mailEmployee.To.Add(mailToEmployee);
                    mailEmployee.Subject = mu[1].subject;
                    mailEmployee.Body = mu[1].mailBody;
                    smtpServer.Send(mailEmployee);
                }
            }
          */
        }
        public List<MailForm> mailForm(string type,string contract)
        {
            var m = new List<MailForm>();
            var MUser = new MailForm();
            var MEmployee = new MailForm();
            var da = "";
            if (type.Contains("BenSchedule"))
            {
                da = type.Substring(11);
                type = "BenSchedule";
            }
            if (type.Contains("AddBen"))
            {
                da = type.Substring(6);
                type = "AddBen";
            }
            if (type.Contains("Sentencing"))
            {
                da = type.Substring(10);
                type = "Sentencing";
            }
            var context = HttpContext.HttpContext.Request;
            string url = $"{context.Scheme}://{context.Host}/Issues/Details?id={contract}";
          //  string url = Path.Combine(uri, "Issues", $"Details?id={contract}");            
            switch (type)
            {
                case "Create":{
                        MUser.subject = MEmployee.subject = "قضية جديدة " + contract;
                        MUser.mailBody = "تم انشاء قضية جديدة بنجاح يمكن الانتقال الى قضيتكم عن طريق الرابط التالي\n" + url;                        
                        MEmployee.mailBody = "تم انشاء قضية جديدة الرجاء تدقيقها وشكراً يمكن الانتقال الى قضيتكم عن طريق الرابط التالي\n" + url;
                        m.Add(MUser);
                        m.Add(MEmployee);
                        return m; 
                    }
                case "Ckeck":{
                        MUser.subject = MEmployee.subject = "قسم التدقيق " + contract;
                        MUser.mailBody = "تم تدقيق قضية بنجاح يمكن الانتقال الى قضيتكم عن طريق الرابط التالي\n" + url;                        
                        MEmployee.mailBody = "تم تدقيق القضية بنجاح الرجاء اضافة الدفعات المالية المستحقة وشكراً يمكن الانتقال الى قضيتكم عن طريق الرابط التالي\n" + url;
                        m.Add(MUser);
                        m.Add(MEmployee);
                        return m;
                    }
                case "AddFees":
                    {
                        MUser.subject = MEmployee.subject = "قسم المالية " + contract;
                        MUser.mailBody = "تم اضافة الدفعات بنجاح الرجاء المبادرة بالدفع وشكراً يمكن الانتقال الى قضيتكم عن طريق الرابط التالي\n" + url;
                        m.Add(MUser);
                        return m;
                    }
                case "PayFees":
                    {
                        MUser.subject = MEmployee.subject = "قسم المالية " + contract;
                        MEmployee.mailBody = "تم الانتهاء من الدفعات الرجاء تدقيق الدفعات وشكراً يمكن الانتقال الى قضيتكم عن طريق الرابط التالي\n" + url;
                        m.Add(MEmployee);
                        return m;
                    }
                case "CkeckFees":
                    {
                        MUser.subject = MEmployee.subject = "قسم المالية " + contract;
                        MUser.mailBody = "تم تدقيق الدفعات بنجاح وإحالة قضيتكم للقضاء يمكن الانتقال الى قضيتكم عن طريق الرابط التالي\n" + url;
                        MEmployee.mailBody = "تم تدقيق الدفعات بنجاح الرجاء جدولة القضية وشكراً يمكن الانتقال الى قضيتكم عن طريق الرابط التالي\n" + url;
                        m.Add(MUser);
                        m.Add(MEmployee);
                        return m;
                    }
                case "BenSchedule":
                    {
                        MUser.subject = MEmployee.subject = "قسم القضاء تحديد موعد الجلسة " + contract;
                        MUser.mailBody = "تم تحديد تاريخ الجلسة القضائية لحضرتكم وشكراً\n" + da + "\n" + " يمكن الانتقال الى قضيتكم عن طريق الرابط التالي\n" + url;
                        m.Add(MUser);
                        return m;
                    }
                case "Sentencing":
                    {
                        MUser.subject = MEmployee.subject = "قسم القضاء اصدار الحكم " + contract;
                        MUser.mailBody = "تم اصدار الحكم القضائية بالقضية وشكراً\n" + da + "\n" + " يمكن الانتقال الى قضيتكم عن طريق الرابط التالي\n" + url;
                        m.Add(MUser);
                        return m;
                    }
                case "AddBen":
                    {
                        MUser.subject = MEmployee.subject = "اضافة مستفيد لقضية " + contract;
                        MUser.mailBody = "تم اضافة السيد \n" + da + "\n" + " الى قضية" + " يمكن الانتقال الى قضيتكم عن طريق الرابط التالي\n" + url;
                        m.Add(MUser);
                        return m;
                    }
                case "DeleteCon":
                    {
                        MUser.subject = MEmployee.subject = " حذف قضية " + contract;
                        MUser.mailBody = "تم حذف قضيتكم من الادارة \n";
                        m.Add(MUser);
                        return m;
                    }
            }
            return m;
        }
        public bool personCheck (string val)
        {
            var check = DB.Beneficiaries.Where(a => a.person.idNumber == val && a.faceId == true);
            if (check.Count() > 0)
            {
                return true;
            }
            else return false;
        }
    }
}
