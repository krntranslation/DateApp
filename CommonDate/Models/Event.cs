using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CommonDate.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [Display(Name ="Event")]
        public string eventName { get; set; }

        [Display(Name ="Location")]
        public string location { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Event Time")]
        public DateTime eventDate { get; set; }
  
        [ForeignKey("User")]
        public int? Id { get; set; }
        public User User { get; set; }


    }
}