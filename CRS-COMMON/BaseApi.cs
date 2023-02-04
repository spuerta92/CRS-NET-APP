using RestSharp;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace CRS_COMMON
{
    public class BaseApi
    {
        // http client 
        protected HttpClient HttpClient(string baseUri, ICredentials? credentials = null)
        {
            var handler = new HttpClientHandler();

            if (credentials != null)
            {
                handler.Credentials = credentials;
            }

            var client = new HttpClient(handler);
            client.BaseAddress = new Uri(baseUri);
            client.Timeout = TimeSpan.FromSeconds(30);

            return client;
        }
        protected HttpRequestMessage HttpRequest(string requestUri,
                                                 HttpMethod method,
                                                 string contentType,
                                                 string? cookie = null,
                                                 string? authenticationType = null,
                                                 string? authenticationString = null,
                                                 string? token = null)
        {
            var request = new HttpRequestMessage(method, requestUri);
            request.Headers.Add("Accept", contentType);
            request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
            request.Headers.Add("Accept-Language", "en-US,en;q=0.9");
            request.Headers.Add("Connection", "keep-alive");

            switch(authenticationType)
            {
                case "Basic":
                    var encodedAuthenticationString = Convert.ToBase64String(Encoding.ASCII.GetBytes(authenticationString));
                    request.Headers.Authorization = new AuthenticationHeaderValue(authenticationType, encodedAuthenticationString);
                    break;
                case "Bearer":
                    request.Headers.Authorization = new AuthenticationHeaderValue(authenticationType, token);
                    break;
            }
            return request;
        }
        public HttpResponseMessage HttpGet(string baseUri,
                                            string requestUri,
                                            string contentType,
                                            ICredentials? credentials = null,
                                            string? cookie = null,
                                            string? authenticationType = null,
                                            string? authenticationString = null,
                                            string? token = null)
        {
            var client = HttpClient(baseUri, credentials);
            var request = HttpRequest(requestUri, HttpMethod.Get, contentType, cookie, authenticationType, authenticationString, token);

            try
            {
                return client.Send(request); ; 
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<HttpResponseMessage> HttpGetAsync(string baseUri,
                                                            string requestUri,
                                                            string contentType,
                                                            ICredentials? credentials = null,
                                                            string? cookie = null,
                                                            string? authenticationType = null,
                                                            string? authenticationString = null,
                                                            string? token = null)
        {
            var client = HttpClient(baseUri, credentials);
            var request = HttpRequest(requestUri, HttpMethod.Get, contentType, cookie, authenticationType, authenticationString, token);

            HttpResponseMessage? response = null;
            try
            {
                response = await client.SendAsync(request);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public HttpResponseMessage HttpPost(string baseUri,
                                            string requestUri,
                                            string contentType,
                                            ICredentials? credentials = null,
                                            HttpContent? content = null,
                                            string? cookie = null,
                                            string? authenticationType = null,
                                            string? authenticationString = null,
                                            string? token = null)
        {
            var client = HttpClient(baseUri, credentials);
            var request = HttpRequest(requestUri, HttpMethod.Post, contentType, cookie, authenticationType, authenticationString, token);

            if(content != null)
            {
                request.Content = content;
            }

            try
            {
                return client.Send(request); ;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<HttpResponseMessage> HttpPostAsync(string baseUri,
                                                                string requestUri,
                                                                string contentType,
                                                                ICredentials? credentials = null,
                                                                HttpContent? content = null,
                                                                string? cookie = null,
                                                                string? authenticationType = null,
                                                                string? authenticationString = null,
                                                                string? token = null)
        {
            var client = HttpClient(baseUri, credentials);
            var request = HttpRequest(requestUri, HttpMethod.Post, contentType, cookie, authenticationType, authenticationString, token);

            if (content != null)
            {
                request.Content = content;
            }

            try
            {
                return await client.SendAsync(request);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public HttpResponseMessage HttpPut(string baseUri,
                                            string requestUri,
                                            string contentType,
                                            ICredentials? credentials = null,
                                            HttpContent? content = null,
                                            string? cookie = null,
                                            string? authenticationType = null,
                                            string? authenticationString = null,
                                            string? token = null)
        {
            var client = HttpClient(baseUri, credentials);
            var request = HttpRequest(requestUri, HttpMethod.Put, contentType, cookie, authenticationType, authenticationString, token);

            if (content != null)
            {
                request.Content = content;
            }

            try
            {
                return client.Send(request); ;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<HttpResponseMessage> HttpPutAsync(string baseUri,
                                                            string requestUri,
                                                            string contentType,
                                                            ICredentials? credentials = null,
                                                            HttpContent? content = null,
                                                            string? cookie = null,
                                                            string? authenticationType = null,
                                                            string? authenticationString = null,
                                                            string? token = null)
        {
            var client = HttpClient(baseUri, credentials);
            var request = HttpRequest(requestUri, HttpMethod.Put, contentType, cookie, authenticationType, authenticationString, token);

            if (content != null)
            {
                request.Content = content;
            }

            try
            {
                return await client.SendAsync(request); ;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public HttpResponseMessage HttpDelete(string baseUri,
                                                string requestUri,
                                                string contentType,
                                                ICredentials? credentials = null,
                                                string? cookie = null,
                                                string? authenticationType = null,
                                                string? authenticationString = null,
                                                string? token = null)
        {
            var client = HttpClient(baseUri, credentials);
            var request = HttpRequest(requestUri, HttpMethod.Delete, contentType, cookie, authenticationType, authenticationString, token);

            try
            {
                return client.Send(request); ;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<HttpResponseMessage> HttpDeleteAsync(string baseUri,
                                                                string requestUri,
                                                                string contentType,
                                                                ICredentials? credentials = null,
                                                                string? cookie = null,
                                                                string? authenticationType = null,
                                                                string? authenticationString = null,
                                                                string? token = null)
        {
            var client = HttpClient(baseUri, credentials);
            var request = HttpRequest(requestUri, HttpMethod.Delete, contentType, cookie, authenticationType, authenticationString, token);

            try
            {
                return await client.SendAsync(request); ;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // restsharp
        protected RestClient RestSharpClient(string baseUri, ICredentials? credentials = null)
        {
            var options = new RestClientOptions(baseUri);

            if (credentials != null)
            {
                options.Credentials = credentials;
            }

            var client = new RestClient(options);
            client.Options.MaxTimeout = (int)TimeSpan.FromSeconds(30).TotalSeconds;

            return client;
        }
        protected RestRequest RestSharpRequest(string requestUri, 
                                                Method method, 
                                                string contentType,
                                                string? cookie = null)
        {
            var request = new RestRequest(requestUri, method);
            request.AddHeader("Accept", contentType);
            request.AddHeader("Accept-Encoding", "gzip, deflate, br");
            request.AddHeader("Accept-Language", "en-US,en;q=0.9");
            request.AddHeader("Connection", "keep-alive");

            if (cookie != null)
            {
                request.AddHeader("Cookie", cookie);
            }

            request.Timeout = (int)TimeSpan.FromSeconds(30).TotalSeconds;

            return request;
        }
        public RestResponse RestSharpGet(string baseUri,
            string requestUri,
            string contentType = "application/json",
            ICredentials? credentials = null,
            string? cookie = null)
        {
            var client = RestSharpClient(baseUri, credentials);
            var request = RestSharpRequest(requestUri, Method.Get, contentType, cookie);

            try
            {
                return client.Execute(request);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<RestResponse> RestSharpGetAsync(string baseUri,
            string requestUri,
            string contentType = "application/json",
            ICredentials? credentials = null,
            string? cookie = null)
        {
            var client = RestSharpClient(baseUri, credentials);
            var request = RestSharpRequest(requestUri, Method.Get, contentType, cookie);

            try
            {
                return await client.ExecuteAsync(request);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public RestResponse RestSharpPost(string baseUri,
            string requestUri,
            string contentType = "application/json",
            object? content = null,
            ICredentials? credentials = null,
            string? cookie = null)
        {
            var client = RestSharpClient(baseUri, credentials);
            var request = RestSharpRequest(requestUri, Method.Post, contentType, cookie);

            if (content != null)
            {
                request.AddBody(content, contentType);
            }

            try
            {
                return client.Execute(request);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<RestResponse> RestSharpPostAsync(string baseUri,
            string requestUri,
            string contentType = "application/json",
            object? content = null,
            ICredentials? credentials = null,
            string? cookie = null)
        {
            var client = RestSharpClient(baseUri, credentials);
            var request = RestSharpRequest(requestUri, Method.Post, contentType, cookie);

            if (content != null)
            {
                request.AddBody(content, contentType);
            }

            try
            {
                return await client.ExecuteAsync(request);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public RestResponse RestSharpPut(string baseUri,
            string requestUri,
            string contentType = "application/json",
            object? content = null,
            ICredentials? credentials = null,
            string? cookie = null)
        {
            var client = RestSharpClient(baseUri, credentials);
            var request = RestSharpRequest(requestUri, Method.Put, contentType, cookie);

            if (content != null)
            {
                request.AddBody(content, contentType);
            }

            try
            {
                return client.Execute(request);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<RestResponse> RestSharpPutAsync(string baseUri,
            string requestUri,
            string contentType = "application/json",
            object? content = null,
            ICredentials? credentials = null,
            string? cookie = null)
        {
            var client = RestSharpClient(baseUri, credentials);
            var request = RestSharpRequest(requestUri, Method.Put, contentType, cookie);

            if (content != null)
            {
                request.AddBody(content, contentType);
            }

            try
            {
                return await client.ExecuteAsync(request);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public RestResponse RestSharpDelete(string baseUri,
            string requestUri,
            string contentType = "application/json",
            ICredentials? credentials = null,
            string? cookie = null)
        {
            var client = RestSharpClient(baseUri, credentials);
            var request = RestSharpRequest(requestUri, Method.Delete, contentType, cookie);

            try
            {
                return client.Execute(request);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<RestResponse> RestSharpDeleteAsync(string baseUri,
            string requestUri,
            string contentType = "application/json",
            ICredentials? credentials = null,
            string? cookie = null)
        {
            var client = RestSharpClient(baseUri, credentials);
            var request = RestSharpRequest(requestUri, Method.Delete, contentType, cookie);

            try
            {
                return await client.ExecuteAsync(request);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
