using Microsoft.AspNetCore.Mvc.Rendering;
using Softtech.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Softtech.ViewModel
{
    public class VisitorsViewModel
    {
        [Key]
        public string VisitorId { get; set; }
        [Required(ErrorMessage = "Visitor full name required")]
        public string FullName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Visitor time in required")]
        [DataType(DataType.Time)]
        public TimeSpan TimeIn { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan TimeOut { get; set; }
        [Required(ErrorMessage = "Student room number is required")]
        public string RoomNo { get; set; }
        [Required(ErrorMessage = "Student visited required")]
        public string VisiteeName { get; set; }
        public IEnumerable<SelectListItem> Students { get; set; }
    }
}
