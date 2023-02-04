using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_COMMON
{
    public static class Dates
    {
        public static DateTime OneMinuteAgo = DateTime.Now.AddMinutes(-1);
        public static DateTime OneHourAgo = DateTime.Now.AddHours(-1);
        public static DateTime Yesterday = DateTime.Today.AddDays(-1);
        public static DateTime LastWeek = DateTime.Today.AddDays(-7);
        public static DateTime LastMonth = DateTime.Today.AddMonths(-1);
        public static DateTime LastYear = DateTime.Today.AddYears(-1);

        public static DateTime OneMinuteLater = DateTime.Now.AddMinutes(1);
        public static DateTime OneHourLater = DateTime.Now.AddHours(1);
        public static DateTime Tomorrow = DateTime.Today.AddDays(1);
        public static DateTime NextWeek = DateTime.Today.AddDays(7);
        public static DateTime NextMonth = DateTime.Today.AddMonths(1);
        public static DateTime NextYear = DateTime.Today.AddYears(1);
    }
}
