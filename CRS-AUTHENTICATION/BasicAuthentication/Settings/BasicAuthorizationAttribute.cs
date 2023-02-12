using Microsoft.AspNetCore.Authorization;

namespace CRS_Authentication.BasicAuthentication.Settings
{
    public class BasicAuthorizationAttribute : AuthorizeAttribute
    {
        public BasicAuthorizationAttribute()
        {
            Policy = "CRS_Authentication";
        }
    }
}
