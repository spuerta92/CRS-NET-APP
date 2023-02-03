using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_EXCEPTIONS
{
    public class StudentCourseNotFoundException : Exception
    {
        public StudentCourseNotFoundException() { }
        public StudentCourseNotFoundException(string message) : base(message) { }
        public StudentCourseNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
