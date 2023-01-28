using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_MODELS
{
    public class LogMessage
    {
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
        public string Status { get; set; }
        public DateTime CreateDateTime { get; set; }
    }

    public class DbErrorLog
    {
        [Key]
        public int LogId { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}
