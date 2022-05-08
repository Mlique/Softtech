using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Softtech.ViewModel
{
    public class ApplicationUserEditViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string CityId { get; set; }
        public string StudentNo { get; set; }
        public string CellNumber { get; set; }
        public string DateOfBirth { get; set; }
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
    }
}
