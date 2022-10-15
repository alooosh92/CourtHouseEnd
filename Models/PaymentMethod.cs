using System.ComponentModel.DataAnnotations;

namespace CourtHouse.Models
{
    public class PaymentMethod
    {
        [Key]
        public int id { get; set; }
        [Required]
        [MaxLength(50)]
        public string paymentMethods { get; set; }
        [Required]
        [MaxLength(20)]
        public string accountNumber { get; set; }
        [Required]
        public double amount { get; set; }
    }
}
