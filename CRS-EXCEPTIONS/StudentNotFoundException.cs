﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_EXCEPTIONS
{
    public class StudentNotFoundException : Exception
    {
        public StudentNotFoundException() { }
        public StudentNotFoundException(string message) : base(message) { }
        public StudentNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
