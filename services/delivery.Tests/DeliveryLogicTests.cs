using System;
using Xunit;
using DeliveryService.Domain;

namespace DeliveryService.Tests
{
    public class DeliveryLogicTests
    {
        [Fact]
        public void Delivery_Assignment_CreatesAssignedDelivery()
        {
            var delivery = DeliveryAssignmentLogic.Assign("order123", "123 Main St", "courier1", "idem-key-1");
            Assert.Equal("ASSIGNED", delivery.Status);
            Assert.Equal("order123", delivery.OrderId);
            Assert.Equal("courier1", delivery.CourierId);
            Assert.Equal("idem-key-1", delivery.IdempotencyKey);
        }
    }
}
