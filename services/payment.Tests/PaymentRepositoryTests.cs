using System;
using Xunit;
using PaymentService.Domain;
using PaymentService.Persistence;

namespace PaymentService.Tests
{
    public class PaymentRepositoryTests
    {
        [Fact]
        public void Can_Create_And_Get_Payment()
        {
            var repo = new PaymentRepository();
            var payment = new Payment
            {
                Id = Guid.NewGuid(),
                OrderId = "order456",
                Status = "PENDING",
                CreatedAt = DateTime.UtcNow
            };
            repo.CreatePayment(payment);
            var fetched = repo.GetPaymentByOrderId("order456");
            Assert.NotNull(fetched);
            Assert.Equal("order456", fetched.OrderId);
        }
    }
}
