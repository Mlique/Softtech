using Microsoft.AspNetCore.Http;
using Softtech.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Softtech.ViewModel
{
    public class FaultViewModel
    {
        [Key]
        public string FaultId { get; set; }
        public string Description { get; set; }
        public DateTime ReportDate { get; set; } = DateTime.Today;

        public bool Status { get; set; }
        [Required(ErrorMessage = "Room number field is required")]
        [Display(Name = "Room Number")]
        public string RoomId { get; set; }
       
        public string StudentId { get; set; }
        public IFormFile PdfFile { get; set; }
        public string DocumentPath { get; set; }

        public virtual TblRoom Room { get; set; }
        public virtual ApplicationUser Student { get; set; }
    }
}
