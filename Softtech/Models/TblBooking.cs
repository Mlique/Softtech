using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Softtech.Models
{
    public partial class TblBooking
    {
        [Key]
        public string BookingId { get; set; }
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Status")]
        public bool Status { get; set; }
        public string RoomId { get; set; }
        public string RoomTypeId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Student Number")]
        public string StudentId { get; set; }
        [Required(ErrorMessage = "Please enter the year")]
        public string Year { get; set; }
        public string StudentFundedBy { get; set; }
        public string PayMethod { get; set; }
        public string BursaryName { get; set; }
        public string ContactNumber { get; set; }
        public string PayAmount { get; set; }
        public string CardHolder { get; set; }
        public string CardNumber { get; set; }
        public string ExpiryMonth { get; set; }
        public string ExpiryYear { get; set; }
        public string CVV { get; set; }
        public bool TermsAndConditions { get; set; }

        public virtual TblRoom Room { get; set; }
        public virtual TblRoomType RoomType { get; set; }
        public virtual ApplicationUser Student { get; set; }
    }
    //stores data for stored procedure
    //2021 appointments
    public class Jan
    {
        public int Total { get; set; }
    }
    public class Feb
    {
        public int Total { get; set; }
    }
    public class Mar
    {
        public int Total { get; set; }
    }
    public class Apr
    {
        public int Total { get; set; }
    }
    public class May
    {
        public int Total { get; set; }
    }
    public class Jun
    {
        public int Total { get; set; }
    }
    public class Jul
    {
        public int Total { get; set; }
    }
    public class Aug
    {
        public int Total { get; set; }
    }
    public class Sep
    {
        public int Total { get; set; }
    }
    public class Oct
    {
        public int Total { get; set; }
    }
    public class Nov
    {
        public int Total { get; set; }
    }
    public class Dec
    {
        public int Total { get; set; }
    }
    //2021 Approved appointments
    public class JR
    {
        public int Total { get; set; }
    }
    public class FR
    {
        public int Total { get; set; }
    }
    public class MR
    {
        public int Total { get; set; }
    }
    public class AR
    {
        public int Total { get; set; }
    }
    public class MA
    {
        public int Total { get; set; }
    }
    public class JU
    {
        public int Total { get; set; }
    }
    public class JL
    {
        public int Total { get; set; }
    }
    public class AU
    {
        public int Total { get; set; }
    }
    public class SE
    {
        public int Total { get; set; }
    }
    public class OC
    {
        public int Total { get; set; }
    }
    public class NO
    {
        public int Total { get; set; }
    }
    public class DE
    {
        public int Total { get; set; }
    }
    //cancelled appointments
    public class JA
    {
        public int Total { get; set; }
    }
    public class FE
    {
        public int Total { get; set; }
    }
    public class MAR
    {
        public int Total { get; set; }
    }
    public class AP
    {
        public int Total { get; set; }
    }
    public class MY
    {
        public int Total { get; set; }
    }
    public class JN
    {
        public int Total { get; set; }
    }
    public class JUL
    {
        public int Total { get; set; }
    }
    public class AUGU
    {
        public int Total { get; set; }
    }
    public class SEPT
    {
        public int Total { get; set; }
    }
    public class OCT
    {
        public int Total { get; set; }
    }
    public class NOV
    {
        public int Total { get; set; }
    }
    public class DEC
    {
        public int Total { get; set; }
    }
}
