using CourtHouse.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourtHouse.Data.ViewModels
{
    public class VMBeneficiary
    {
        [Key]
        public string id { get; set; }
        [Required]
        public Person person { get; set; }
        [Required]
        public string typePerson { get; set; }
        [Required]
        public double period { get; set; }
        [Required]
        public RealtyContract realtyContract { get; set; }
        public List<Region> regionList { get; set; }
        public int regionSelect { get; set; }
        public bool isChecked { get; set; }      
        public List<WaysToCommunicate> ways { get; set; }
        [Required]
        public int wayToCommunicate { get; set; }
        public IFormFile personImage { get; set; }
        public IFormFile identityImageFront { get; set; }
        public IFormFile identityImageBack { get; set; }
    }
}
