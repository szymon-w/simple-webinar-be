using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace simpleWebinar.Models
{
    public class ContactMessage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMessage { get; set; }
        [Required]
        public string Message { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }

    }
}
