using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simpleWebinar.Exceptions
{
    public class NotSignedUpToWebinarException : Exception
    {
        public NotSignedUpToWebinarException(string message) : base(message)
        {
        }

        public NotSignedUpToWebinarException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
