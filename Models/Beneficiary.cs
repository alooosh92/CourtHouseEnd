using System;
using System.ComponentModel.DataAnnotations;

namespace CourtHouse.Models
{
    public class Beneficiary
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
        public bool isChecked { get; set; }
        public WaysToCommunicate waysToCommunicate { get; set; }
        public DateTime SessionDate { get; set; }
        public bool faceId { get; set; }
        public bool faceIdChecked { get; set; }
    }
}
