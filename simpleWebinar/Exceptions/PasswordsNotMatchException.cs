using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simpleWebinar.Exceptions
{
    public class PasswordsNotMatchException : Exception
    {
        public PasswordsNotMatchException(string message) : base(message)
        {
        }

        public PasswordsNotMatchException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
