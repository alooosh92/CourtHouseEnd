using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourtHouse.Models
{
    public class RealtyContractNote
    {
        [Key]
        public string id { get; set; }
        [Required]
        public RealtyContract realtyContract { get; set; }
        [Required]
        public string noteType { get; set; }
        [Required]
        public User user { get; set; }
        [Required]
        public DateTime noteDate { get; set; }
        public string note { get; set; }
    }
}
