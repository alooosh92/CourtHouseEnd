using CourtHouse.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourtHouse.Data.ViewModels
{
  
    public class VMUser
    {
        [Key]
        public string id { set; get; }
        public string userName { set; get; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string password { get; set; }
        public bool Admin { get; set; }
        public bool LocalAdmin { get; set; }
        public bool Checker { get; set; }
        public bool Finance { get; set; }
        public bool Judge { get; set; }
        public bool Recorder { get; set; }
        public bool HumanResources { get; set; }
        public bool DataEntry { get; set; }
        public bool Employee { get; set; }
        public int regionSelect { get; set; }
        public List<Region> regionList { get; set; }
    }
}
