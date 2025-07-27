using System.Collections.Generic;
using System.Threading.Tasks;
using CartService.Domain;

namespace CartService.Persistence
{
    public interface ICartRepository
    {
        Task<Cart> GetCartAsync(string userId);
        Task AddOrUpdateCartAsync(Cart cart);
        Task RemoveCartAsync(string userId);
        Task<List<Cart>> ListCartsAsync();
    }
}
