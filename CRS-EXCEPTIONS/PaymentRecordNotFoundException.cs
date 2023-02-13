using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_EXCEPTIONS
{
    public class PaymentRecordNotFoundException : Exception
    {
        public PaymentRecordNotFoundException() { }
        public PaymentRecordNotFoundException(string message) : base(message) { }
        public PaymentRecordNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
