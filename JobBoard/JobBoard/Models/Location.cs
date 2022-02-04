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
        public int LocationID { get; set; }
        [Required]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "Position List")]
        public virtual List<Position> PositionList { get; set; }
        [Display(Name = "Interview List")]
        public virtual List<Interview> InterviewList { get; set; }



    }
}
