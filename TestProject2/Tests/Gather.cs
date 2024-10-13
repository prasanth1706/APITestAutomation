using APITestAutomation.Models;
using RestSharp;
using TestProject2.Helpers;

namespace TestProject2.Tests
{
    public class Gather : BaseTest
    {
        [Test]
        public async Task TestGetApiCallWithQueryParamsAsync()
        {
            // Define the API endpoint and query parameters
            string endpoint = "/api/test";
            var queryParams = new Dictionary<string, string>
            {
                { "filter", "value1" },
                { "page", "1" }
            };

            // Send GET request and retry on failure
            var response = await RetryHelper.RetryAsync(() => ApiHelper.SendRequestAsync<Formula>(endpoint, Method.Get, _environment, queryParams), retryCount: 2);

            // Assert the response using Assert.That()
            Assert.That(response.IsSuccessful, Is.True, "API call failed after retrying.");
            Assert.That((int)response.StatusCode, Is.EqualTo(200), "Unexpected status code.");
        }

        [Test]
        public async Task TestPostApiCallAsync()
        {
            // Define the API endpoint and request body
            string endpoint = "/api/create";
            var body = new
            {
                Name = "TestName",
                Value = "TestValue"
            };

            // Send POST request and retry on failure
            var response = await RetryHelper.RetryAsync(() => ApiHelper.SendRequestAsync<Formula>(endpoint, Method.Post, _environment, body: body), retryCount: 2);

            // Assert the response using Assert.That()
            Assert.That(response.IsSuccessful, Is.True, "API call failed after retrying.");
            Assert.That((int)response.StatusCode, Is.EqualTo(201), "Expected status code 201 for resource creation.");
        }
    }
}
