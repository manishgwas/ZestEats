using System.Collections.Generic;
using System.Threading.Tasks;
using MenuService.Domain;
using MongoDB.Driver;

namespace MenuService.Persistence
{
    public class MenuRepository : IMenuRepository
    {
        private readonly IMongoCollection<Menu> _menus;
        public MenuRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("ZestEats");
            _menus = database.GetCollection<Menu>("menus");
        }
        public async Task<Menu> GetMenuAsync(string id) =>
            await _menus.Find(m => m.Id == id).FirstOrDefaultAsync();
        public async Task<List<Menu>> GetMenusByRestaurantAsync(string restaurantId) =>
            await _menus.Find(m => m.RestaurantId == restaurantId).ToListAsync();
        public async Task AddMenuAsync(Menu menu) =>
            await _menus.InsertOneAsync(menu);
        public async Task UpdateMenuAsync(Menu menu) =>
            await _menus.ReplaceOneAsync(m => m.Id == menu.Id, menu);
        public async Task DeleteMenuAsync(string id) =>
            await _menus.DeleteOneAsync(m => m.Id == id);
        public async Task<List<Menu>> ListMenusAsync() =>
            await _menus.Find(_ => true).ToListAsync();
    }
}
