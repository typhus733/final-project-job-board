using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoard.Models
{
    public class Interview
    {
        [Key]
        [Required]
        [Display(Name = "Interview ID")]
        public string InterviewID { get; set; }
        [Required]
        [Display(Name = "Position")]
        public string PositionID { get; set; }
        [Required]
        [Display(Name = "Location")]
        public string LocationID { get; set; }
        [Required]
        [Display(Name = "Candidate")]
        public string CandidateID { get; set; }        

        [Required]
        [Display(Name = "Start Time")]
        public virtual DateTime StartTime { get; set; }
        [Required]
        [Display(Name = "End Time")]
        public virtual DateTime EndTime { get; set; }

    }
}
