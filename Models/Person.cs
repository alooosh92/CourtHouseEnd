using System;
using System.ComponentModel.DataAnnotations;

namespace CourtHouse.Models
{
    public class Person
    {
        [Required]
        public string title { get; set; }     
        [Required]
        [MaxLength(50)]
        public string firstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string lastName { get; set; }
        [Required]
        [MaxLength(50)]
        public string fatherName { get; set; }
        [Required]
        [MaxLength(50)]
        public string motherName { get; set; }
        [Required]        
        public Region region { get; set; }
        [Required]
        [MaxLength(50)]
        public string placeOFBirth { get; set; }
        [Required]        
        public DateTime dateOfBirth { get; set; }
        [Key]
        [MinLength(5)]
        [MaxLength(20)]
        public string idNumber { get; set; }
        [Required]
        [MaxLength(20)]
        public string mobile { get; set; }
        [MaxLength(20)]
        public string phone { get; set; }
        public string adress { get; set; }
        [EmailAddress]
        public string emailAddress { get; set; }
        [Required]
        public string nationality { get; set; }
        [Url]
        public string personImage { get; set; }
        [Url]
        public string identityImageFront { get; set; }
        [Url]
        public string identityImageBack { get; set; }
        public WaysToCommunicate wayToCommunicate { get; set; }
    }
}
