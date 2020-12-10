using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simpleWebinar.Exceptions
{
    public class NotFinishedWebinarException : Exception
    {
        public NotFinishedWebinarException(string message) : base(message)
        {
        }

        public NotFinishedWebinarException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
