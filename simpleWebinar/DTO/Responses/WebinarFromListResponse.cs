using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simpleWebinar.DTO.Responses
{
    public class WebinarFromListResponse
    {
        public string Topic { get; set; }
        public string Teacher { get; set; }
        public string Date { get; set; }
        public string Code { get; set; }
    }
}
