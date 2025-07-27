using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading.Tasks;

namespace GatewayService.Tests.Contract {
    [TestClass]
    public class GatewayApiContractTests {
        [TestMethod]
        public async Task Gateway_Endpoints_Contract() {
            // This is a stub. In real tests, use TestServer or WebApplicationFactory
            using var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:5000/restaurant/test");
            Assert.IsNotNull(response);
            // Assert contract, status code, response shape, etc.
        }
    }
}
