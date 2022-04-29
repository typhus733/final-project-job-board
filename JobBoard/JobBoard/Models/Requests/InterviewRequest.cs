using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoard.Models
{
    public class InterviewRequest
    {        
        [Display(Name = "Position")]
        public int? PositionId { get; set; }
                
        [Display(Name = "Candidate")]
        public int? CandidateId { get; set; } 
                
        [Display(Name = "Start Time")]
        public DateTime? StartTime { get; set; }

        [Display(Name = "End Time")]
        public DateTime? EndTime { get; set; }

    }
}
