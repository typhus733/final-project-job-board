using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoard.Models
{
    public class LocationPatch
    {
        [Display(Name = "Location Name")]
        public string LocationName { get; set; }       

        [Display(Name = "Address")]
        public string Address { get; set; }         
    }
}
