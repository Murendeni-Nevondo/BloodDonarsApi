using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BlooDonarsApi.Models
{
    public class BloodUser
    {
        public int Id { get; set; }
        [Required, StringLength(50, ErrorMessage ="First Name should not exceed 50 characters")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string  Country { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        [Required, StringLength(5, ErrorMessage ="Blood group should not exceed 5 characters")]
        public string BloodGroup { get; set; }
    }
}