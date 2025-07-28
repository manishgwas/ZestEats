using System;

namespace PaymentService.Domain
{
    public class Payment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string OrderId { get; set; } = string.Empty;
        public string Status { get; set; } = "Initiated";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? RazorpayPaymentId { get; set; }
        public string? IdempotencyKey { get; set; }
    }
}
