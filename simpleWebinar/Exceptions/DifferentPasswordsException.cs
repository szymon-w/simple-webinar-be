using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simpleWebinar.Exceptions
{
    public class DifferentPasswordsException : Exception
    {
        public DifferentPasswordsException(string message) : base(message)
        {
        }

        public DifferentPasswordsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
