using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MenuService.Domain;
using MenuService.Persistence;

namespace MenuService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuRepository _repo;
        public MenuController(IMenuRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<ActionResult<List<Menu>>> ListMenus() =>
            await _repo.ListMenusAsync();
        [HttpGet("{id}")]
        public async Task<ActionResult<Menu>> GetMenu(string id) =>
            await _repo.GetMenuAsync(id);
        [HttpGet("restaurant/{restaurantId}")]
        public async Task<ActionResult<List<Menu>>> GetMenusByRestaurant(string restaurantId) =>
            await _repo.GetMenusByRestaurantAsync(restaurantId);
        [HttpPost]
        public async Task<IActionResult> AddMenu(Menu menu)
        {
            await _repo.AddMenuAsync(menu);
            return CreatedAtAction(nameof(GetMenu), new { id = menu.Id }, menu);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMenu(string id, Menu menu)
        {
            menu.Id = id;
            await _repo.UpdateMenuAsync(menu);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenu(string id)
        {
            await _repo.DeleteMenuAsync(id);
            return NoContent();
        }
    }
}
