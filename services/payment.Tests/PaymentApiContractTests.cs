using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;

namespace PaymentService.Tests
{
    public class PaymentApiContractTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        public PaymentApiContractTests(WebApplicationFactory<Program> factory)
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
