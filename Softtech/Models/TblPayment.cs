using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Softtech.Models
{
    public partial class TblPayment
    {
        [Key]
        public string PaymentId { get; set; }
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Amount Paid")]
        public string AmountPaid { get; set; }
        public string Balance { get; set; }
        public string Reference { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Tenant")]
        public string StudentId { get; set; }
        public string AdminId { get; set; }
        public string DocumentPath { get; set; }
        public string ImagePath { get; set; }

        //public virtual ApplicationUser Admin { get; set; }
        public virtual ApplicationUser Student { get; set; }
    }
}
