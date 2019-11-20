using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CommonDate.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        
        [Required]
        [Display(Name = "City")]
        public string City { get; set; }
        
        [Required]
        [Display(Name = "State Code")]
        public string StateCode { get; set; }
        
        [Required]
        [Display(Name = "ZIP Code")]
        public int Zipcode { get; set; }

        [Required]
        [Display(Name ="Phone Number")]
        public int PhoneNumber { get; set; }

        [Required]
        [Display(Name ="Your Gender")]
        public string Gender { get; set; }

        [Required]
        [Display(Name ="Gender Preference")]
        public string GenderPreference { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }


    }
}