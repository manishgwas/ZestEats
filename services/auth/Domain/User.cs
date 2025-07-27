using System;
using System.ComponentModel.DataAnnotations;

namespace AuthService.Domain {
    public enum UserRole {
        Customer,
        RestaurantOwner,
        DeliveryPartner
    }

    public class User {
        public Guid Id { get; set; }
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string PasswordHash { get; set; } = string.Empty;
        public UserRole Role { get; set; }
    }
}
