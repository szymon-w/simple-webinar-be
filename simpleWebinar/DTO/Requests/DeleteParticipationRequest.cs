using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace simpleWebinar.DTO.Requests
{
    public class DeleteParticipationRequest : Attribute
    {
        [Required]
        public string Login { get; set; }
    }
}
