using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoard.Models
{
    public class CandidateRequest
    {       
        [Display(Name = "First Name")]
        public string First_Name { get; set; }

        [Display(Name = "Last Name")]
        public string Last_Name { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
