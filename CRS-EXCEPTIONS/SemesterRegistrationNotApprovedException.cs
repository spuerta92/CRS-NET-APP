using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_EXCEPTIONS
{
    public class SemesterRegistrationNotApprovedException : Exception
    {
        public SemesterRegistrationNotApprovedException() { }
        public SemesterRegistrationNotApprovedException(string message) : base(message) { }
        public SemesterRegistrationNotApprovedException(string message, Exception innerException) : base(message, innerException) { }
    }
}
