using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoard.Models
{
    public class PositionRequest
    {        
        [Display(Name = "Title")]
        public string Title { get; set; }
        
        [Display(Name = "Department")]
        public string Department { get; set; }
        
        [Display(Name = "Location ID")]
        public int? LocationID { get; set; }   

        [Display(Name = "Is Fulltime")]
        public bool? IsFulltime { get; set; }
    }
}
