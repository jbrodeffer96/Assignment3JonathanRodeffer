using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2JonathanRodeffer.Models
{
    public class UserDataEntry
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required][Phone(ErrorMessage ="Invalid Phone Number")]
        public string PhoneNumber { get; set; }
        [Required][EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }

        public string Message { get; set; }
        [Required]
        public string Confirm { get; set; }
    }
}
