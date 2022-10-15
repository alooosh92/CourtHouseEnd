using CourtHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourtHouse.Data.ViewModels
{
    public class VMRealtyContractWithList
    {
        public IList<RealtyContract> NewContract { get; set; }
        public IList<RealtyContract> CheckContract { get; set; }
        public IList<RealtyContract> WaitPayContract { get; set; }
        public IList<RealtyContract> WaitScheduleContract { get; set; }
        public IList<RealtyContract> ScheduleContract { get; set; }
        public IList<RealtyContract> EndContract { get; set; }
        public IList<RealtyContract> ScheduleContractToday { get; set; }
    }
}
