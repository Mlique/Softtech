using Softtech.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Softtech.ViewModel
{
    public class StudentListViewModel
    {
        [Key]
        public string StudentId { get; set; }
        public string FullName { get; set; }
        public string StudentNumber { get; set; }
        [Required(ErrorMessage = "Please select the room number")]
        [Display(Name = "Room No.")]
        public string RoomId { get; set; }
        [Required(ErrorMessage = "Please select the room type")]
        [Display(Name = "Room Type")]
        public string RoomTypeId { get; set; }

        public virtual TblRoom Room { get; set; }
        public virtual TblRoomType RoomType { get; set; }
        public virtual ApplicationUser Student { get; set; }
    }
}
