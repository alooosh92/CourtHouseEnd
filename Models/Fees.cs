
using System.ComponentModel.DataAnnotations;

namespace CourtHouse.Models
{
    public class Fees
    {
        [Key]
        public string id { get; set; }
        [Required]
        public Person person { get; set; }
        [Required]
        public RealtyContract realtyContract { get; set; }
        [Required]
        public double theFinancialValue { get; set; }
        public string reasonOfPayment { get; set; }
        public PaymentMethod paymentMethod { get; set; }        
        public string financialNoticeNumber { get; set; }
        public bool isPayment { get; set; }
        [Url]
        public string paymentImage { get; set; }
    }
}
