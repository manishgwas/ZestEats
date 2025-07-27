using Microsoft.VisualStudio.TestTools.UnitTesting;
using CartService.Domain;
using CartService.Persistence;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CartService.Tests
{
    [TestClass]
    public class CartServiceTests
    {
        [TestMethod]
        public async Task AddOrUpdateCart_ShouldAddOrUpdateCart()
        {
            var repo = new CartRepository();
            var cart = new Cart { Id = "1", UserId = "u1" };
            await repo.AddOrUpdateCartAsync(cart);
            var result = await repo.GetCartAsync("u1");
            Assert.IsNotNull(result);
            Assert.AreEqual("u1", result.UserId);
        }
        // More unit, integration, and contract tests can be added here
    }
}
