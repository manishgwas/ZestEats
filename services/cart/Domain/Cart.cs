using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CartService.Domain
{
    public class Cart
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string UserId { get; set; }
        public List<CartItem> Items { get; set; } = new();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }

    public class CartItem
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string MenuItemId { get; set; }
        [Required]
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
