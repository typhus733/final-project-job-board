using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoard.Models
{
    public class PositionPatch
    {
        [Display(Name = "Title")]
        public string Title { get; set; }
        
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Interview List")]
        public virtual List<Interview> PositionInterviews { get; set; }
    }
}
