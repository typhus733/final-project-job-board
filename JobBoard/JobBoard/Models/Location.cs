using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoard.Models
{
    public class Location
    {
        [Key]
        [Display(Name = "Location ID")]
        public string LocationID { get; set; }

        [Required]
        [Display(Name = "Location Name")]
        public string LocationName { get; set; }
        
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

    }
}
