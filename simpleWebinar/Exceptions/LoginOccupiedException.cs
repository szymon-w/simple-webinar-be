using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simpleWebinar.Exceptions
{
    public class LoginOccupiedException : Exception
    {
        public LoginOccupiedException(string message) : base(message)
        {
        }

        public LoginOccupiedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
