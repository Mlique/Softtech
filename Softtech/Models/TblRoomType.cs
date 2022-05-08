using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Softtech.Models
{
    public class TblRoomType
    {
        [Key]
        public string RoomTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TblBooking> Bookings { get; set; }
        public virtual ICollection<TblRoom> Rooms { get; set; }
    }
}
