using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Softtech.Models
{
    public partial class TblReview
    {
        [Key]
        public string ReviewId { get; set; }      
        public string Comment { get; set; }
        public string Reply { get; set; }
        public string Rate { get; set; }
        public string StudentId { get; set; }
        public virtual ApplicationUser Student { get; set; }
    }
}
