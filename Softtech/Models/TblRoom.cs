using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Softtech.Models
{
    public partial class TblRoom
    {
        [Key]
        public string RoomId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Room Number")]
        public string RoomNo { get; set; }
        public string RoomTypeId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Price")]
        public string Price { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Available")]
        public bool Available { get; set; }
        public virtual TblRoomType RoomType { get; set; }
        public virtual ICollection<TblBooking> TblBooking { get; set; }
        public virtual ICollection<TblFault> TblFault { get; set; }
        public virtual ICollection<ApplicationUser> Students { get; set; }
        public virtual ICollection<TblInspection> Inspections { get; set; }
    }
}
