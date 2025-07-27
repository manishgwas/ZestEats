using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading.Tasks;

[TestClass]
public class RestaurantContractTests
{
    private static readonly HttpClient _client = new HttpClient { BaseAddress = new System.Uri("http://localhost:5000") };

    [TestMethod]
    public async Task Healthz_ReturnsOk()
    {
        var response = await _client.GetAsync("/healthz");
        response.EnsureSuccessStatusCode();
    }
}
