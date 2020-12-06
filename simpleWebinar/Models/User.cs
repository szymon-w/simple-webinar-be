using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace simpleWebinar.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [Required]
        public string Login { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.{8,})")]
        public string Password { get; set; }
        public Boolean IsTeacher { get; set; }
        public Boolean IsAdmin { get; set; }

        public ICollection<Webinar> Webinars { get; set; }
        public ICollection<UserWebinar> UserWebinars { get; set; }

    }
}
