using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourtHouse.Models
{
    public class EmployeeInfo
    {
        public int id { get; set; }
        public User user { get; set; }
        public int NumAllCases { get; set; }
        public int NumEndCasesInThisMonth { get; set; }
        public int NumUnfinishedCases { get; set; }
        public double AvaregDelayInCase { get; set; }
    }
}
