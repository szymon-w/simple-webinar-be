using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simpleWebinar.Exceptions
{
    public class AlreadySignedUpToWebinarException : Exception
    {
        public AlreadySignedUpToWebinarException(string message) : base(message)
        {
        }

        public AlreadySignedUpToWebinarException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
