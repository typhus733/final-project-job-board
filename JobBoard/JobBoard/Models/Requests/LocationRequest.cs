using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoard.Models
{
    public class LocationRequest
    {
        [Display(Name = "Name")]
        public string Name { get; set; }
        
        [Display(Name = "Street")]
        public string Street { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "Zip")]
        public int? Zip { get; set; }


    }
}
