using System.ComponentModel.DataAnnotations;

namespace CourtHouse.Models
{
    public class Region
    {
        [Key]                
        public int id { get; set; }
        [Required]
        public string regionName { get; set; }
    }
}
