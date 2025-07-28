using System;
using System.Threading.Tasks;
using Xunit;
using OrderService.Domain;
using OrderService.Persistence;

namespace OrderService.Tests
{
    public class OrderIntegrationTests
    {
        [Fact]
        public async Task CanPlaceAndRetrieveOrder()
        {
            var repo = new OrderRepository();
            var order = new Order { UserId = "user2" };
            repo.CreateOrder(order);
            var retrieved = repo.GetOrderById(order.Id);
            Assert.NotNull(retrieved);
            Assert.Equal("user2", retrieved.UserId);
        }
    }
}
