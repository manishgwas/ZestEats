using System;
using System.Collections.Generic;

namespace OrderService.Domain
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string UserId { get; set; } = string.Empty;
        public List<OrderItem> Items { get; set; } = new();
        public string Status { get; set; } = "Pending";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? PaymentId { get; set; }
        public string? DeliveryId { get; set; }
        public string? IdempotencyKey { get; set; }
    }

    public class OrderItem
    {
        public string MenuItemId { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
