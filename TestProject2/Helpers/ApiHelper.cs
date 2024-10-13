using RestSharp;
using TestProject2.Models;

namespace TestProject2.Helpers
{
    public static class ApiHelper
    {
        public static async Task<RestResponse> SendRequestAsync(string endpoint, Method method, EnvironmentModel env,
            Dictionary<string, string> queryParams = null, object body = null, Dictionary<string, string> headers = null)
        {
            var client = new RestClient(env.BaseUrl);
            var request = new RestRequest(endpoint, method);
            request.AddHeader("Accept", "application/json");
            // Add the API Key as a default header
            request.AddHeader("Authorization", $"Bearer {env.ApiKey}");

            // Add custom headers if provided
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.AddHeader(header.Key, header.Value);
                }
            }

            // Add query parameters for GET requests or others where query parameters are used
            if (queryParams != null)
            {
                foreach (var param in queryParams)
                {
                    request.AddQueryParameter(param.Key, param.Value);
                }
            }

            // Add body for POST/PUT requests
            if (body != null && (method == Method.Post || method == Method.Put))
            {
                request.AddJsonBody(body);
            }

            // Execute the request asynchronously
            return await client.ExecuteAsync(request);
        }
    }
}
