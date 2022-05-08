using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Softtech.Models
{
    public partial class TblDeposit
    {
        [Key]
        public string DepositId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Amount")]
        public decimal Amount { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Student Number")]
        public string StudentId { get; set; }
        public virtual ApplicationUser Student { get; set; }
    }
}
