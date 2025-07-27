using Microsoft.EntityFrameworkCore;
using Restaurant.Domain;

namespace Restaurant.Persistence
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options) { }
        public DbSet<RestaurantEntity> Restaurants { get; set; }
    }
}
