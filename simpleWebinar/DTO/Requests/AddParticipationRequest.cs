using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace simpleWebinar.DTO.Requests
{
    public class AddParticipationRequest:Attribute
    {
        [Required]
        public string Login { get; set; }
    }
}
