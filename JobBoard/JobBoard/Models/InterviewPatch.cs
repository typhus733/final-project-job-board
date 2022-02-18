using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoard.Models
{
    public class InterviewPatch
    {
        [Display(Name = "Candidate")]
        public string CandidateId { get; set; }
        
        [Display(Name = "Position")]
        public string PositionID { get; set; }
        
        [Display(Name = "Location")]
        public string LocationID { get; set; }

        //Update datetime to take specific time
        [Display(Name = "Start Time")]
        public virtual DateTime StartTime { get; set; }
        
        [Display(Name = "End Time")]
        public virtual DateTime EndTime { get; set; }

    }
}
