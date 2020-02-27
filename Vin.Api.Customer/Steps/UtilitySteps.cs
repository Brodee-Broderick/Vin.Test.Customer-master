using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;

namespace Vin.Api.Customer.Steps
{
    [Binding]
    public class UtilitySteps
    {
        private HttpClient _httpClient;
        private HttpResponseMessage _httpResponse;

        [Given(@"I am using Vin\.Api\.Customer")]
        public void GivenIAmUsingVin_Api_Customer()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://customer.vinsolutions.com/");
        }
        
        [When(@"I hit the healthcheck endpoint")]
        public async Task WhenIHitTheHealthcheckEndpoint()
        {
            Assert.NotNull(_httpClient);
            _httpResponse = await _httpClient.GetAsync("healthcheck");
        }
        
        [Then(@"the API returns OK")]
        public void ThenTheAPIReturnsOK()
        {
            Assert.NotNull(_httpResponse);
            Assert.Equal(HttpStatusCode.OK, _httpResponse.StatusCode);
        }
        [Then(@"the API does not return UnAuthorized")]
        public void ThenTheAPIDoesNotReturnUnAuthorized()
        {
            Assert.NotNull(_httpResponse);
            Assert.NotEqual(HttpStatusCode.Unauthorized, _httpResponse.StatusCode);
        }

    }
}
