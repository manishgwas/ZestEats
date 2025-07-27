using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AuthService.Domain;
using AuthService.Persistence;
using AuthService.Security;
using System.Threading.Tasks;

namespace AuthService.Controllers {
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase {
        private readonly IUserRepository _repo;
        private readonly string _jwtSecret;
        public UsersController(IUserRepository repo) {
            _repo = repo;
            _jwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET") ?? "your_jwt_secret_here";
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user) {
            user.PasswordHash = PasswordHasher.HashPassword(user.PasswordHash);
            await _repo.CreateAsync(user);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User login) {
            var user = await _repo.GetByUsernameAsync(login.Username);
            if (user == null || user.PasswordHash != PasswordHasher.HashPassword(login.PasswordHash))
                return Unauthorized();
            var token = JwtTokenService.GenerateToken(user, _jwtSecret);
            return Ok(new { token });
        }

        [Authorize]
        [HttpGet("me")]
        public async Task<IActionResult> Me() {
            var username = User.Identity?.Name;
            var user = await _repo.GetByUsernameAsync(username ?? "");
            return Ok(user);
        }
    }
}
