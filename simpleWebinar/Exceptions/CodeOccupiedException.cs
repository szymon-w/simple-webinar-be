using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simpleWebinar.Exceptions
{
    public class CodeOccupiedException : Exception
    {
        public CodeOccupiedException(string message) : base(message)
        {
        }

        public CodeOccupiedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
