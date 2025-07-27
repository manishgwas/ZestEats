using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using CartService.Domain;
using CartService.Persistence;

namespace CartService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _repo;
        public CartController(ICartRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<ActionResult<List<Cart>>> ListCarts() =>
            await _repo.ListCartsAsync();
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<Cart>> GetCart(string userId) =>
            await _repo.GetCartAsync(userId);
        [HttpPost]
        public async Task<IActionResult> AddOrUpdateCart(Cart cart)
        {
            await _repo.AddOrUpdateCartAsync(cart);
            return Ok(cart);
        }
        [HttpDelete("user/{userId}")]
        public async Task<IActionResult> RemoveCart(string userId)
        {
            await _repo.RemoveCartAsync(userId);
            return NoContent();
        }
    }
}
