using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRS_COMMON;
using CRS_MODELS;

namespace CRS_DAO
{
    public class DbLogger
    {
        private readonly ICrsRepository repository;
        private readonly Helpers helpers;

        public DbLogger() {}
        public DbLogger(ICrsRepository repository)
        {
            this.repository = repository;
            helpers = new Helpers();
        }

        public void ApiError(string message)
        {
            var messageLog = new LogMessage()
            {
                ErrorMessage = message
                //StackTrace = exception.StackTrace,
                //Source = exception.Source,
                //Target = exception.TargetSite.Name
            };

            var errorLog = new ApiErrorLog()
            {
                Message = helpers.ObjectToJsonString(messageLog),
                Status = "Error",
                CreateDateTime = DateTime.Now
            };

            this.repository.AddErrorLog(errorLog);
        }

        public void DbError(string message)
        {
            var messageLog = new LogMessage()
            {
                ErrorMessage = message
                //StackTrace = exception.StackTrace,
                //Source = exception.Source,
                //Target = exception.TargetSite.Name
            };

            var errorLog = new DbErrorLog()
            {
                Message = helpers.ObjectToJsonString(messageLog),
                Status = "Error",
                CreateDateTime = DateTime.Now
            };

            this.repository.AddErrorLog(errorLog);
        }
    }
}
