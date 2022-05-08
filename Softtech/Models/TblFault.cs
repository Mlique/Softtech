using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Softtech.Models
{
    public partial class TblFault
    {
        [Key]
        public string FaultId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Description of the fault")]
        public string Description { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "A date field is required")]
        [Display(Name = "Report Date")]
        public DateTime ReportDate { get; set; } = DateTime.Today;
     
        public bool Status { get; set; }
        [Required(ErrorMessage = "Room number field is required")]
        [Display(Name = "Room Number")]
        public string RoomId { get; set; }
        public string StudentId { get; set; }
        public string ImagePath { get; set; }
        public virtual TblRoom Room { get; set; }
        public virtual ApplicationUser Student { get; set; }
    }
}
