using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simpleWebinar.Exceptions
{
    public class DoneWebinarException : Exception
    {
        public DoneWebinarException(string message) : base(message)
        {
        }

        public DoneWebinarException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
