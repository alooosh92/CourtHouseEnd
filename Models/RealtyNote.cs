using System;
using System.ComponentModel.DataAnnotations;

namespace CourtHouse.Models
{
    public class RealtyNote
    {
        [Key]
        public string id { get; set; }
        [Required]
        public Realty realty { get; set; }
        [Required]
        public string noteType { get; set; }
        [Required]
        public User user { get; set; }
        [Required]
        public DateTime noteDate { get; set; }
        public string note { get; set; }
    }
}
