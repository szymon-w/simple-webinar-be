using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simpleWebinar.Exceptions
{
    public class ParticipationNotExistException : Exception
    {
        public ParticipationNotExistException(string message) : base(message)
        {
        }

        public ParticipationNotExistException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
