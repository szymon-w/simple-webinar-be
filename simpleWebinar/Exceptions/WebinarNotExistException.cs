using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simpleWebinar.Exceptions
{
    public class WebinarNotExistException : Exception
    {
        public WebinarNotExistException(string message) : base(message)
        {
        }

        public WebinarNotExistException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
