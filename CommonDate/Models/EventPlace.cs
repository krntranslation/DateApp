using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CommonDate.Models
{
    public class EventPlace
    {
        public Class1[] Property1 { get; set; }
    }
    public class Class1
    {
        [Display(Name= "Event Name")]
        public string eventName { get; set; }

        [Display(Name ="Location")]
        public string location { get; set; }
    }
}