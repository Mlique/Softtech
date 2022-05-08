using Softtech.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Softtech.ViewModel
{
    public class ReviewViewModel
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
