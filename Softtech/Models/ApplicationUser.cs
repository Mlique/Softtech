using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Softtech.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string StudentNo { get; set; }
        public string CellNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ImagePath { get; set; }
        public string ZipCode { get; set; }
        public string NextOfKinFirstName { get; set; }
        public string NextOfKinLastName { get; set; }
        public string Relationship { get; set; }
        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + " " + FirstName;
            }
        }
        public virtual TblRoom Room { get; set; }
        public virtual ICollection<TblBooking> Booking { get; set; }
        public virtual ICollection<TblDeposit> Deposits { get; set; }
        public virtual ICollection<TblFault> Faults { get; set; }
        public virtual ICollection<TblPayment> Payments { get; set; }
        public virtual ICollection<TblReview> Fines { get; set; }
        public virtual ICollection<TblInspection> Inspections { get; set; }
        public virtual ICollection<TblVisitor> Visitors { get; set; }
        //public List<TblPayment> Administrator { get; set; } = new List<TblPayment>();
        //public List<> Students { get; set; } = new List<TblPayment>();
        public List<TblInspection> StudentInspec { get; set; } = new List<TblInspection>();
        public List<TblInspection> Inspectors { get; set; } = new List<TblInspection>();
    }
}
