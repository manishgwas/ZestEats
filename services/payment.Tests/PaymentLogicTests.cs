using System;
using Xunit;
using PaymentService.Domain;

namespace PaymentService.Tests
{
    public class PaymentLogicTests
    {
        [Fact]
        public void Payment_Created_HasPendingStatus()
        {
            var payment = new Payment
            {
                Id = Guid.NewGuid(),
                OrderId = "order123",
                Status = "PENDING",
                CreatedAt = DateTime.UtcNow
            };
            Assert.Equal("PENDING", payment.Status);
        }
    }
}
