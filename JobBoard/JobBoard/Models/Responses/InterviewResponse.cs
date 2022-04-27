using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoard.Models
{
    public class InterviewResponse
    {
        [Key]
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Position")]
        public int PositionId { get; set; }

        [Required]
        [Display(Name = "Candidate")]
        public int CandidateId { get; set; } 
        
        [Required]
        [Display(Name = "Start Time")]
        public virtual DateTime StartTime { get; set; }

        [Required]
        [Display(Name = "End Time")]
        public virtual DateTime EndTime { get; set; }

    }
}
