using CourtHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CourtHouse.Data.Repository.RepUserFun;

namespace CourtHouse.Data.Repository
{
    public interface IRepositoryUser
    {
        User chooseUser(Region region, string role);
        IList<EmployeeInfo> employeeInfo(Region Reg);
        IList<RegionInfo> regionInfo();
        void sendMessage(string type, string mailTo, string mailToEmployee, string contract);
        bool personCheck(string val);
    }
}
