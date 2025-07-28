using System;
using Xunit;
using PaymentService.Domain;
using PaymentService.Persistence;

namespace PaymentService.Tests
{
    public class PaymentIntegrationTests
    {
        [Fact]
        public void Payment_Flow_Success()
        {
            var repo = new PaymentRepository();
            var payment = new Payment
            {
                Id = Guid.NewGuid(),
                OrderId = "order789",
                Status = "PENDING",
                CreatedAt = DateTime.UtcNow
            };
            repo.CreatePayment(payment);
            payment.Status = "COMPLETED";
            var fetched = repo.GetPaymentByOrderId("order789");
            Assert.NotNull(fetched);
            Assert.Equal("COMPLETED", payment.Status);
        }
    }
}
