using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoard.Models
{
    public class CandidatePatch
    {
        
        [Display(Name = "Name")]
        public string Name { get; set; }
        
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
