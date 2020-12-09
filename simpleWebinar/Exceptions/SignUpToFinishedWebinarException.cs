using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simpleWebinar.Exceptions
{
    public class SignUpToFinishedWebinarException : Exception
    {
        public SignUpToFinishedWebinarException(string message) : base(message)
        {
        }

        public SignUpToFinishedWebinarException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
