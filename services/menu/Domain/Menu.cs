using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MenuService.Domain
{
    public class Menu
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string RestaurantId { get; set; }
        [Required]
        public string Name { get; set; }
        public List<MenuItem> Items { get; set; } = new();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }

    public class MenuItem
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
