using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Softtech.ViewModel
{
    public class EditUserViewModel
    {
        public string Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your first name")]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your last name")]
        public string LastName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your username")]
        public string Username { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your phone number")]
        public string CellNumber { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your email address")]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your address")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your province")]
        public string Province { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your country")]
        public string Country { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your city")]
        public string City { get; set; }
        public string StudentNo { get; set; }
        [DataType(DataType.Date)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please insert your date of birth")]
        public DateTime DateOfBirth { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your postal code")]
        public string ZipCode { get; set; }
        public string NextOfKinFirstName { get; set; }
        public string NextOfKinLastName { get; set; }
        public string Relationship { get; set; }
        public IFormFile ProfileImage { get; set; }
    }
}
