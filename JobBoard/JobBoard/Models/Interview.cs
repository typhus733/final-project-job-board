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
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Position")]
        public int PositionID { get; set; }
        [Required]
        [Display(Name = "Location")]
        public int LocationID { get; set; }
        [Required]
        [Display(Name = "Candidate")]
        public int CandidateID { get; set; }        

        [Required]
        [Display(Name = "Start Time")]
        public virtual DateTime StartTime { get; set; }
        [Required]
        [Display(Name = "End Time")]
        public virtual DateTime EndTime { get; set; }

    }
}
