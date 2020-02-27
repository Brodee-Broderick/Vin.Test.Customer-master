using System;
using System.Net.Http;
using TechTalk.SpecFlow;
using Vin.Api.Customer.Models.Requests;
using Vin.Api.Customer.Models.Response;
using Newtonsoft.Json;

namespace Vin.Api.Customer
{
    [Binding]
    public class FIndOrCreateSteps
    {
        private HttpClient _httpClient = new HttpClient();
        private HttpResponseMessage _httpResponse;
        private FindOrCreateCustomerRequest request = new FindOrCreateCustomerRequest();

        [Given(@"I have a proper json payload")]
        public void GivenIHaveAProperJsonPayload()
        {
            

        }

        [When(@"sending the New Customer payload to the find and create endpoint")]
        public void WhenSendingTheNewCustomerPayloadToTheFindAndCreateEndpoint()
        {
            _httpClient.PostAsync("https://qa-customer.vinsolutions.com/api/customers/FindOrCreate", JsonConvert.SerializeObject(request));
        }

        [Then(@"I get a unique customer id")]
        public object ThenIGetAUniqueCustomerId()
        {
            FindOrCreateCustomerResponse.Equals
        }

    }
}
