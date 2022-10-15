using System.ComponentModel.DataAnnotations;

namespace CourtHouse.Models
{
    public class Realty
    {
        [Key]
        public string id { get; set; }
        [Required]
        [MaxLength(50)]
        public string area { get; set; }

        [Required]
        public Region region { get; set; }

        [MaxLength(200)]
        public string info { get; set; }

        [Required]
        [MaxLength(50)]
        public string realtyType { get; set; }

        [Required]
        [MaxLength(200)]
        public string adress { get; set; }

        [Required]
        public double theFinancialValue { get; set; }

        public bool isChecked { get; set; }
        public User createBy { get; set; }

    }
}
