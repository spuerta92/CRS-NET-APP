using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_MODELS
{
    public class LogMessage
    {
        public string Source { get; set; }
        public string ErrorMessage { get; set; }
        public string StackTrace { get; set; }
        public string Target { get; set; }
    }
    public class ApiErrorLog
    {
        public LogMessage Message { get; set; }
        public string Status { get; set; }
        public DateTime CreateDateTime { get; set; }
    }

    public class DbErrorLog
    {
        public LogMessage Message { get; set; }
        public string Status { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}
