using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_EXCEPTIONS
{
    public class DuplicatePaymentException : Exception
    {
        public DuplicatePaymentException() { }
        public DuplicatePaymentException(string message) : base(message) { }
        public DuplicatePaymentException(string message, Exception innerException) : base(message, innerException) { }
    }
}
