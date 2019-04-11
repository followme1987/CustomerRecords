using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;

namespace CustomerRecords.WebApi.IntegrationTest
{
    [TestFixture]
    public class CustomerRecordsControllerTest
    {
        private readonly HttpClient _client;

        public CustomerRecordsControllerTest()
        {
            _client = new WebApplicationFactory<Startup>().CreateClient();
        }

        [Test]
        public async Task Get_Request_Should_Return_Ok()
        {
            var response = await _client.GetAsync("/api/customerRecords");

            response.EnsureSuccessStatusCode();

            var expected = HttpStatusCode.OK;

            Assert.AreEqual(expected, response.StatusCode);

        }

        [Test]
        public async Task Get_Request_Should_Return_Customer_Id_And_Name_Only()
        {
            var response = await _client.GetAsync("/api/customerRecords");

            response.EnsureSuccessStatusCode();

            var stringResponse = await response.Content.ReadAsStringAsync();

            Assert.IsTrue(stringResponse.Contains("Name"));
            Assert.IsTrue(stringResponse.Contains("Id"));
            Assert.IsTrue(!stringResponse.Contains("Latitude"));
            Assert.IsTrue(!stringResponse.Contains("Longitude"));
        }
    }
}