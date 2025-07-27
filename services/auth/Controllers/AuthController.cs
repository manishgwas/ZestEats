using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AuthService.Domain;
using AuthService.Persistence;
using AuthService.Security;
using System.Threading.Tasks;

namespace AuthService.Controllers {
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase {
        private readonly IUserRepository _repo;
        private readonly string _jwtSecret;
        public AuthController(IUserRepository repo) {
            _repo = repo;
            _jwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET") ?? "your_jwt_secret_here";
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] string email) {
            // TODO: Implement password reset logic (send email, etc.)
            return Ok();
        }
    }
}
