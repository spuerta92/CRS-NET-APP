using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_EXCEPTIONS
{
    public class CourseNotFoundException : Exception
    {
        public CourseNotFoundException() { }
        public CourseNotFoundException(string message) : base(message) { }
        public CourseNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
