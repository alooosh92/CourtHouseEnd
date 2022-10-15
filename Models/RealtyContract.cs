using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace CourtHouse.Models
{
    public class RealtyContract
    {
        [Key]
        public string id { get; set; }
        [Required]
        public User user { get; set; }
        [Required]        
        public DateTime startDate { get; set; }
        [Required]
        [MaxLength(50)]
        public string contractType { get; set; }
        [Required]
        public Realty realty { get; set; }
        public User checker { get; set; }
        public User finance { get; set; }
        public User judge { get; set; }
        public bool isChecked { get; set; }
        public bool isAddFinance { get; set; }
        public bool isPayFinance { get; set; }
        public bool isFinance { get; set; }
        public bool isJudge { get; set; }
        public bool isRecorder { get; set; }
        public string judgment { get; set; }

    }
}
