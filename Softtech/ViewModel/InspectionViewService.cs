using Microsoft.AspNetCore.Http;
using Softtech.Models;
using Softtech.Models.CommonMapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Softtech.ViewModel
{
    public class InspectionViewService 
    {
        [Key]
        public string InspectionId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        [Required(ErrorMessage = "Please enter the comment or condition of the room")]
        [Display(Name = "Comment")]
        public string Comment { get; set; }
        public string Condition { get; set; }
        public string InspectorId { get; set; }
        public string StudentId { get; set; }
        [Required(ErrorMessage = "Please select the room")]
        [Display(Name = "RoomId")]
        public string RoomId { get; set; }
        [Display(Name = "Upload your checklist in pdf format")]
        [Required]
        public IFormFile CheckPdf { get; set; }
        public string CheckPdfUrl { get; set; }
        public TblInspection App { get; set; }
        public virtual ApplicationUser Inspector { get; set; }
        public virtual ApplicationUser Student { get; set; }
        public virtual TblRoom Room { get; set; }

    }
}
