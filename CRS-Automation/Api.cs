using CRS_COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRS_MODELS;
using RestSharp;

namespace CRS_Automation
{
    public class Api : BaseApi
    {
        private string baseUri = Settings.WebApiBaseUri;
        
        // user endpoints
        private string GetAllUsersUri = $"/api/v1/Student/GetStudents";
        public Api()
        {

        }

        public List<Users>? GetAllUsers()
        {
            var content = RestSharpGet(baseUri, GetAllUsersUri).Content;
            return content?.AsJsonObject<List<Users>>();
        }
    }
}
