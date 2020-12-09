using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simpleWebinar.Exceptions
{
    public class FinishBeforeStartException : Exception
    {
        public FinishBeforeStartException(string message) : base(message)
        {
        }

        public FinishBeforeStartException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
