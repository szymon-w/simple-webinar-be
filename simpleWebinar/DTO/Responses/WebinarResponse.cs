using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace simpleWebinar.DTO.Responses
{
    public class WebinarResponse
    {
        public string Teacher { get; set; }
        public string Topic { get; set; }
        public string Code { get; set; }
        public string Date { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public int? Note { get; set; }
        public Boolean IsFinished { get; set; }
        public Boolean IsUserSignedUp { get; set; }
        public Boolean IsUserATeacher { get; set; }
        public Boolean IsNotedByUser { get; set; }
        
    }
}
