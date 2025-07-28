using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;

namespace DeliveryService.Tests
{
    public class DeliveryApiContractTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        public DeliveryApiContractTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Healthz_ReturnsOk()
        {
            var response = await _client.GetAsync("/healthz");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            Assert.Equal("\"Healthy\"", content);
        }
    }
}
