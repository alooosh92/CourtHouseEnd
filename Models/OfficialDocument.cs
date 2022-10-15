using System.ComponentModel.DataAnnotations;

namespace CourtHouse.Models
{
    public class OfficialDocument
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
    }
}
