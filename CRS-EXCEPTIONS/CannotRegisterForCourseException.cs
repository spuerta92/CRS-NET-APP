using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_EXCEPTIONS
{
    public class CannotRegisterForCourseException : Exception
    {
        public CannotRegisterForCourseException() { }
        public CannotRegisterForCourseException(string message) : base(message) { }
        public CannotRegisterForCourseException(string message, Exception innerException) : base(message, innerException) { }
    }
}
