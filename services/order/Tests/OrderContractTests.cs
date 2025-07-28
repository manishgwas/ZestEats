using System;
using Xunit;
using OrderService.Domain;

namespace OrderService.Tests
{
    public class OrderContractTests
    {
        [Fact]
        public void OrderContract_Matches_Expectations()
        {
            var order = new Order { UserId = "user3" };
            Assert.NotNull(order.Id);
            Assert.NotNull(order.Items);
        }
    }
}
