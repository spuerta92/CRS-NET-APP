using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRS_MODELS;

namespace CRS_DAO
{
    public class Logger
    {
        private readonly ICrsRepository repository;

        public Logger() {}
        public Logger(ICrsRepository repository)
        {
            this.repository = repository;
        }

        public void ApiError(Exception exception)
        {
            var messageLog = new LogMessage()
            {
                ErrorMessage = exception.Message,
                StackTrace = exception.StackTrace,
                Source = exception.Source,
                Target = exception.TargetSite.Name
            };

            var errorLog = new ApiErrorLog()
            {
                Message = messageLog,
                Status = "Error",
                CreateDateTime = DateTime.Now
            };

            this.repository.AddErrorLog(errorLog);
        }

        public void DbError(Exception exception)
        {
            var messageLog = new LogMessage()
            {
                ErrorMessage = exception.Message,
                StackTrace = exception.StackTrace,
                Source = exception.Source,
                Target = exception.TargetSite.Name
            };

            var errorLog = new DbErrorLog()
            {
                Message = messageLog,
                Status = "Error",
                CreateDateTime = DateTime.Now
            };

            this.repository.AddErrorLog(errorLog);
        }
    }
}
