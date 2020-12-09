using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simpleWebinar.Exceptions
{
    public class RemoveDoneWebinarException : Exception
    {
        public RemoveDoneWebinarException(string message) : base(message)
        {
        }

        public RemoveDoneWebinarException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
