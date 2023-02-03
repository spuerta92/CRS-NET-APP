using System;
using System.Collections.Generic;
<<<<<<< HEAD
=======
using System.ComponentModel.DataAnnotations;
>>>>>>> a113c99bf437f70cfa726660e3327fbc0878161b
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_MODELS
{
    public class LogMessage
    {
<<<<<<< HEAD
        public string Source { get; set; }
        public string ErrorMessage { get; set; }
        public string StackTrace { get; set; }
        public string Target { get; set; }
    }
    public class ApiErrorLog
    {
        public LogMessage Message { get; set; }
=======
        //public string Source { get; set; }
        public string ErrorMessage { get; set; }
        //public string StackTrace { get; set; }
        //public string Target { get; set; }
    }
    public class ApiErrorLog
    {
        [Key]
        public int LogId { get; set; }
        public string Message { get; set; }
>>>>>>> a113c99bf437f70cfa726660e3327fbc0878161b
        public string Status { get; set; }
        public DateTime CreateDateTime { get; set; }
    }

    public class DbErrorLog
    {
<<<<<<< HEAD
        public LogMessage Message { get; set; }
=======
        [Key]
        public int LogId { get; set; }
        public string Message { get; set; }
>>>>>>> a113c99bf437f70cfa726660e3327fbc0878161b
        public string Status { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}
