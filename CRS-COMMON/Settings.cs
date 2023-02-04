using System;

namespace CRS_COMMON
{
    public static class Settings
    {
        public static string Env = "Develop";
        public static string UserName = Environment.UserName;
        public static string UserDomainName = Environment.UserDomainName;
        public static string BaseDir = Environment.CurrentDirectory + @"..\..\..\";
        public static string WebApiBaseUri = "https://localhost:7046";
        public static string HangfireBaseUri = "http://localhost:5187";
        public static void ConfigureEnvironment(string env)
        {
            switch (env)
            {
                case "Develop":
                    break;
                case "UAT":
                    break;
                case "Production":
                    break;
                default:
                    break;
            }
        }
    }
}