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
        [Display(Name = "Candidate")]
        public string Id { get; set; }
        //[Required]
        //[Display(Name = "Position")]
        //public virtual Position InterviewPosition { get; set; }
        //[Required]
        //[Display(Name = "Location")]
        //public virtual Location InterviewLocation { get; set; }
        [Required]
        [Display(Name = "Start Time")]
        public virtual DateTime StartTime { get; set; }
        [Required]
        [Display(Name = "End Time")]
        public virtual DateTime EndTime { get; set; }

    }
}
