using CourtHouse.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourtHouse.Data.ViewModels
{
    public class VMFees
    {
        [Key]
        public string id { get; set; }
        [Required]
        public Person person { get; set; }
        [Required]
        public RealtyContract realtyContract { get; set; }
        [Required]
        public string reasonOfPayment { get; set; }
        public double TheFinancialValue { get; set; }
        public IList<PaymentMethod> paymentMethods { get; set; }
        public PaymentMethod paymentMethod { get; set; }
        public string financialNoticeNumber { get; set; }
        public bool isPayment { get; set; }
        [Url]
        public string paymentImage { get; set; }
        public IFormFile paymentImageUrl { get; set; }
    }
}
