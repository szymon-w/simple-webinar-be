using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace simpleWebinar.DTO.Requests
{
    public class EditWebinarRequest : Attribute
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Topic { get; set; }
        [Required]
        public DateTime? Date { get; set; }
        [Required]
        public DateTime? StartTime { get; set; }
        [Required]
        public DateTime? FinishTime { get; set; }
    }
}
