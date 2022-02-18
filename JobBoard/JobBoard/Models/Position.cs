using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoard.Models
{
    public class Position
    {
        [Key]
        [Display(Name = "Position ID")]
        public string PositionID { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }
        
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
        
        [Required]
        [Display(Name = "Location ID")]
        public string LocationID { get; set; }   
    }
}
