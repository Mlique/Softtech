using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Softtech.Models
{
    public partial class TblInspection
    {
        [Key]
        public string InspectionId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }
        
        public string Condition { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Comment")]
        public string Comment { get; set; }
        public string InspectorId { get; set; }
        [Required]
        public string StudentId { get; set; }
        [Required(ErrorMessage = "Please select the room")]
        [Display(Name = "RoomId")]
        public string RoomId { get; set; }
        public string CheckPdfUrl { get; set; }
        public virtual ApplicationUser Inspector { get; set; }
        public virtual ApplicationUser Student { get; set; }
        public virtual TblRoom Room { get; set; }
    }
}
