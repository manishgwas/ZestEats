using System.Collections.Generic;
using System.Threading.Tasks;
using MenuService.Domain;

namespace MenuService.Persistence
{
    public interface IMenuRepository
    {
        Task<Menu> GetMenuAsync(string id);
        Task<List<Menu>> GetMenusByRestaurantAsync(string restaurantId);
        Task AddMenuAsync(Menu menu);
        Task UpdateMenuAsync(Menu menu);
        Task DeleteMenuAsync(string id);
        Task<List<Menu>> ListMenusAsync();
    }
}
