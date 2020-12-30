using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace simpleWebinar.DTO.Responses
{
    public class LogInResponse
    {
        public string Login { get; set; }
        public Boolean IsTeacher { get; set; }
        public Boolean IsAdmin { get; set; }
    }
}
