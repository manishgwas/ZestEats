using System;
using Xunit;
using OrderService.Domain;

namespace OrderService.Tests
{
    public class OrderLifecycleTests
    {
        [Fact]
        public void CanCreateOrder()
        {
            var order = new Order { UserId = "user1" };
            Assert.Equal("user1", order.UserId);
            Assert.Equal("Pending", order.Status);
        }
    }
}
