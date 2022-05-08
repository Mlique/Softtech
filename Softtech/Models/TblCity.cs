using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Softtech.Models
{
    public partial class TblCity
    {
        [Key]
        public string CityId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Street Name")]
        public string CityName { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
