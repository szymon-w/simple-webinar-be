using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace simpleWebinar.DTO.Requests
{
    public class CreateContactMessageRequest:Attribute
    {
        [Required]
        public string Message { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        

    }
}
