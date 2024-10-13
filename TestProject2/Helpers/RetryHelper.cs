using RestSharp;

namespace TestProject2.Helpers
{
    public static class RetryHelper
    {
        public static async Task<RestResponse> RetryAsync(Func<Task<RestResponse>> apiCall, int retryCount = 2)
        {
            RestResponse response = null;
            for (int i = 0; i <= retryCount; i++)
            {
                response = await apiCall();
                if (response.IsSuccessful)
                    return response;
            }
            return response;
        }
    }
}
