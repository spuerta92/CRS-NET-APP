using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_EXCEPTIONS
{
    public class SemesterRegistrationRecordNotFoundException : Exception
    {
        public SemesterRegistrationRecordNotFoundException() { }
        public SemesterRegistrationRecordNotFoundException(string message) : base(message) { }
        public SemesterRegistrationRecordNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
