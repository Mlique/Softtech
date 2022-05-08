using Softtech.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Softtech.ViewModel
{
    public class BookingViewModel
    {
        [Key]
        public string BookingId { get; set; }
        
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public string RoomId { get; set; }

        [Required(ErrorMessage = "Please select the room type")]
        [Display(Name = "Room Number")]
        public string RoomTypeId { get; set; }
        public string StudentId { get; set; }
        [Required(ErrorMessage = "Please enter the year")]
        public string Year { get; set; }
        public string StudentFundedBy { get; set; }
        public string PayMethod { get; set; }
        public string BursaryName { get; set; }
        public string ContactNumber { get; set; }
        public string PayAmount { get; set; }
        public string CardHolder { get; set; }
        public string CardNumber { get; set; }
        public string ExpiryMonth { get; set; }
        public string ExpiryYear { get; set; }
        public string CVV { get; set; }
        [Required(ErrorMessage = "Accept terms && conditions")]
        public bool TermsAndConditions { get; set; }

        public virtual TblRoom Room { get; set; }
        public virtual TblRoomType RoomType { get; set; }
        public virtual ApplicationUser Student { get; set; }
    }
}
