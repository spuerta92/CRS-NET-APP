using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_EXCEPTIONS
{
    public class StudentNotRegisteredException : Exception
    {
        public StudentNotRegisteredException() { }
        public StudentNotRegisteredException(string message) : base(message) { }
        public StudentNotRegisteredException(string message, Exception innerException) : base(message, innerException) { }
    }
}
