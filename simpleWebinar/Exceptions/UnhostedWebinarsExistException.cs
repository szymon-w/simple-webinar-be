using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simpleWebinar.Exceptions
{
    public class UnhostedWebinarsExistException : Exception
    {
        public UnhostedWebinarsExistException(string message) : base(message)
        {
        }

        public UnhostedWebinarsExistException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
