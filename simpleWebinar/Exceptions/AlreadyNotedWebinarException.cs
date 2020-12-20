using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simpleWebinar.Exceptions
{
    public class AlreadyNotedWebinarException : Exception
    {
        public AlreadyNotedWebinarException(string message) : base(message)
        {
        }

        public AlreadyNotedWebinarException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
