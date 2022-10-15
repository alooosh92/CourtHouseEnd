using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourtHouse.Data.ViewModels
{
    public class VMRealtyContract
    {
        public string id { get; set; }
        public string user { get; set; }
        public DateTime startDate { get; set; }
        public string contractType { get; set; }     
        public bool isChecked { get; set; }
        public bool isFinance { get; set; }
        public bool isJudge { get; set; }
        public bool isRecorder { get; set; }
        public string sortcon { get; set; }
    }
}
