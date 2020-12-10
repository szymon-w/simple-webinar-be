using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simpleWebinar.Exceptions
{
    public class WebinarNotHostedByGivenUserException : Exception
    {
        public WebinarNotHostedByGivenUserException(string message) : base(message)
        {
        }

        public WebinarNotHostedByGivenUserException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
