using System.Collections.Generic;
using System.Threading.Tasks;
using CartService.Domain;
using StackExchange.Redis;
using Newtonsoft.Json;

namespace CartService.Persistence
{
    public class CartRepository : ICartRepository
    {
        private readonly IDatabase _db;
        public CartRepository()
        {
            var redis = ConnectionMultiplexer.Connect("localhost:6379");
            _db = redis.GetDatabase();
        }
        public async Task<Cart> GetCartAsync(string userId)
        {
            var value = await _db.StringGetAsync(userId);
            return value.HasValue ? JsonConvert.DeserializeObject<Cart>(value) : null;
        }
        public async Task AddOrUpdateCartAsync(Cart cart)
        {
            await _db.StringSetAsync(cart.UserId, JsonConvert.SerializeObject(cart));
        }
        public async Task RemoveCartAsync(string userId)
        {
            await _db.KeyDeleteAsync(userId);
        }
        public async Task<List<Cart>> ListCartsAsync()
        {
            // For demo: not efficient for production, but shows concept
            var server = ConnectionMultiplexer.Connect("localhost:6379").GetServer("localhost", 6379);
            var keys = server.Keys();
            var carts = new List<Cart>();
            foreach (var key in keys)
            {
                var value = await _db.StringGetAsync(key);
                if (value.HasValue)
                    carts.Add(JsonConvert.DeserializeObject<Cart>(value));
            }
            return carts;
        }
    }
}
