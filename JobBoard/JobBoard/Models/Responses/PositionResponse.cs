using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobBoard.Models
{
    public class PositionResponse
    {
        [Key]
        [Display(Name = "Position Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }
        
        [Required]
        [Display(Name = "Department")]
        public string Department { get; set; }
        
        [Required]
        [Display(Name = "Location ID")]
        public int LocationID { get; set; }   

        [Required]
        [Display(Name = "Is Fulltime")]
        public bool IsFulltime { get; set; }
    }
}
