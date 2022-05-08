using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Softtech.ViewModel
{
    public class PaymentViewModel
    {
        [Key]
        public string PaymentId { get; set; }
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "The amount paid is required")]
        [Display(Name = "Amount Paid")]
        public string AmountPaid { get; set; }
        public string Balance { get; set; }
        public string Reference { get; set; }
        public string StudentId { get; set; }
        public string AdminId { get; set; }
        [Required(ErrorMessage = "Please upload the proof of payment")]
        public IFormFile ProofOfPayPdf { get; set; }
        public string DocumentPath { get; set; }
        public IFormFile Photo { get; set; }
        public string ImagePath { get; set; }
    }
}
