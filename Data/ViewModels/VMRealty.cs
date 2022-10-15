using CourtHouse.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourtHouse.Data.ViewModels
{
    public class VMRealty
    {
        public string id { get; set; }
        public string area { get; set; }        
        public int regionSelect { get; set; }
        public List<Region> regionList { get; set; }
        public string info { get; set; }
        public string realtyType { get; set; }
        public string adress { get; set; }
        public double theFinancialValue { get; set; }
        public bool isChecked { get; set; }
    }
}
