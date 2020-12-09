using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace simpleWebinar.DTO.Requests
{
    public class CreateWebinarRequest:Attribute
    {
        [Required]
        public string Login { get; set; }
        [Required]
        [RegularExpression("^([A-Z]|[0-9]){5}$",
            ErrorMessage = "Code must constist of 5 signs - capital letters or numbers only!")]
        public string Code { get; set; }
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
