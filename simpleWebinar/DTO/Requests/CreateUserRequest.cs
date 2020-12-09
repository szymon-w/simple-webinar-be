using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace simpleWebinar.DTO.Requests
{
    public class CreateUserRequest:Attribute
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.{8,}).*$", 
            ErrorMessage = "Password has to contain at least one small letter, one capital letter and one digit. It has to be at least 8-digit long")]
        public string Password { get; set; }
        [Required]
        public string Password2 { get; set; }
        [Required]
        public Boolean IsTeacher { get; set; }
        [Required]
        public Boolean IsAdmin { get; set; }

    }
}
