using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Softtech.Models
{
    public partial class TblVisitor
    {
        [Key]
        public string VisitorId { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public TimeSpan TimeIn { get; set; }
        public TimeSpan TimeOut { get; set; }
        [Required]
        public string RoomId { get; set; }
        [Required]
        public string StudentId { get; set; }

        public virtual ApplicationUser Student { get; set; }
        public virtual TblRoom Room { get; set; }
    }
}
