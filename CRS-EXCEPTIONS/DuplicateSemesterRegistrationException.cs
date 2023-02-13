using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_EXCEPTIONS
{
    public class DuplicateSemesterRegistrationException : Exception
    {
        public DuplicateSemesterRegistrationException() { }
        public DuplicateSemesterRegistrationException(string message) : base(message) { }
        public DuplicateSemesterRegistrationException(string message, Exception innerException) : base(message, innerException) { }
    }
}
