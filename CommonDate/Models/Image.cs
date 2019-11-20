using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CommonDate.Models
{
    public class Image
    {
        [Key]
        public int ImageId { get; set; }

        [Display(Name ="Upload File")]
        public string Title { get; set; }

        public string ImagePath { get; set; }

        public HttpPostedFile ImageFile { get; set; }

        [ForeignKey("User")]
        public int? Id { get; set; }
        public User User { get; set; }

    }
}