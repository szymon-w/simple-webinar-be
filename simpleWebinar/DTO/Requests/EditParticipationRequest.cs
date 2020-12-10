using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace simpleWebinar.DTO.Requests
{
    public class EditParticipationRequest:Attribute
    {
        [Required]
        public string Login { get; set; }
        [Required]
        [Range(1,5, ErrorMessage = "Note has to be in range between 1 and 5")]
        public int Note { get; set; }

    }
}
