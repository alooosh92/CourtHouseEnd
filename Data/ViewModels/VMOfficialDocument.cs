using CourtHouse.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourtHouse.Data.ViewModels
{
    public class VMOfficialDocument
    {
        [Key]
        public string id { get; set; }
        [Required]
        [MaxLength(50)]
        public string imageType { get; set; }
        [Required]
        [Url]
        public string image { get; set; }
        [Required]
        public RealtyContract realtyContract { get; set; }
        public bool isChecked { get; set; }
        public IFormFile imageUrl { get; set; }
    }
}
