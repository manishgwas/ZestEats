using System;

namespace DeliveryService.Domain
{
    public class Delivery
    {
        public Guid Id { get; set; }
        public string OrderId { get; set; }
        public string Address { get; set; }
        public string Status { get; set; } // e.g., ASSIGNED, IN_PROGRESS, DELIVERED, FAILED
        public DateTime AssignedAt { get; set; }
        public DateTime? DeliveredAt { get; set; }
        public string? CourierId { get; set; }
        public string? IdempotencyKey { get; set; }
    }

    public static class DeliveryAssignmentLogic
    {
        public static Delivery Assign(string orderId, string address, string courierId, string idempotencyKey)
        {
            return new Delivery
            {
                Id = Guid.NewGuid(),
                OrderId = orderId,
                Address = address,
                Status = "ASSIGNED",
                AssignedAt = DateTime.UtcNow,
                CourierId = courierId,
                IdempotencyKey = idempotencyKey
            };
        }
    }
}
