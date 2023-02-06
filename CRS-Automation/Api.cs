using CRS_COMMON;
using CRS_MODELS;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers;

namespace CRS_Automation
{
    public class Api : BaseApi
    {
        private readonly string baseUri = Settings.WebApiBaseUri;
        
        // user endpoints
        private readonly string getAllUsers = "/api/v1/User/GetUsers";
        private readonly string getUser = "/api/v1/User/GetUser/{0}/{1}/{2}";
        private readonly string getUserById = "/api/v1/User/GetUser/{0}";
        private readonly string addUser = "/api/v1/User/AddUser";
        private readonly string updateUser = "/api/v1/User/UpdateUser/{0}";
        private readonly string deleteUser = "/api/v1/User/DeleteUser/{0}";

        public Api()
        {

        }
        public List<Users>? GetAllUsers()
        {
            var content = HttpGet(baseUri, getAllUsers, "application/json").Content;
            var jsonString = content.ReadAsStringAsync().Result;
            var json = jsonString.AsJsonObject<List<Users>>();
            return json;
        }

        public List<Users>? GetAllUsers2()
        {
            var content = RestSharpGet(baseUri, getAllUsers, "application/json").Content;
            var json = content?.AsJsonObject<List<Users>>();
            return json;
        }

        public List<Users>? GetAllUsers3()
        {
            var json = RestSharpGetJson<List<Users>>(baseUri, getAllUsers, "application/json");
            return json;
        }

        public List<Users>? GetAllUsers4()
        {
            var content = RestSharpGetAsync(baseUri, getAllUsers, "application/json").Result.Content;
            var json = content?.AsJsonObject<List<Users>>();
            return json;
        }

        public Users? GetUser(string username, string password, int roleId)
        {
            var requestUri = string.Format(getUser, username, password, roleId);
            var json = RestSharpGetJson<Users>(baseUri, requestUri, "application/json");
            return json;
        }

        public Users? GetUserById(int userId)
        {
            var requestUri = string.Format(getUserById, userId);
            var json = RestSharpGetJson<Users>(baseUri, requestUri, "application/json");
            return json;
        }

        public Users? AddUser(Users user)
        {
            var content = RestSharpPost(baseUri, addUser, "application/json", user).Content;
            var json = content?.AsJsonObject<Users>();
            return json;
        }

        public Users? UpdateUser(int userId, Users user)
        {
            var requestUri = string.Format(updateUser, userId);
            var content = RestSharpPut(baseUri, requestUri, "application/json", user).Content;
            var json = content?.AsJsonObject<Users>();
            return json;
        }

        public void DeleteUser(int userId)
        {
            var requestUri = string.Format(deleteUser, userId);
            RestSharpDelete(baseUri, requestUri, "application/json");
        }
    }
}
