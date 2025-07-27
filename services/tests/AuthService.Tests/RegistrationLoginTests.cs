using Microsoft.VisualStudio.TestTools.UnitTesting;
using AuthService.Controllers;
using AuthService.Domain;
using AuthService.Persistence;
using AuthService.Security;
using System.Threading.Tasks;

namespace AuthService.Tests.Unit {
    [TestClass]
    public class RegistrationLoginTests {
        [TestMethod]
        public async Task Register_User_Success() {
            // Arrange
            var repo = new InMemoryUserRepository();
            var controller = new UsersController(repo);
            var user = new User {
                Id = System.Guid.NewGuid(),
                Username = "unituser",
                Email = "unit@example.com",
                PasswordHash = "password",
                Role = UserRole.Customer
            };
            // Act
            var result = await controller.Register(user);
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task Login_User_Success() {
            // Arrange
            var repo = new InMemoryUserRepository();
            var user = new User {
                Id = System.Guid.NewGuid(),
                Username = "unituser",
                Email = "unit@example.com",
                PasswordHash = PasswordHasher.HashPassword("password"),
                Role = UserRole.Customer
            };
            await repo.CreateAsync(user);
            var controller = new UsersController(repo);
            var login = new User {
                Username = "unituser",
                PasswordHash = "password"
            };
            // Act
            var result = await controller.Login(login);
            // Assert
            Assert.IsNotNull(result);
        }
    }

    // Simple in-memory repo for unit tests
    public class InMemoryUserRepository : IUserRepository {
        private readonly Dictionary<string, User> _users = new();
        public Task<User?> GetByIdAsync(System.Guid id) => Task.FromResult(_users.Values.FirstOrDefault(u => u.Id == id));
        public Task<User?> GetByUsernameAsync(string username) => Task.FromResult(_users.GetValueOrDefault(username));
        public Task<User?> GetByEmailAsync(string email) => Task.FromResult(_users.Values.FirstOrDefault(u => u.Email == email));
        public Task CreateAsync(User user) { _users[user.Username] = user; return Task.CompletedTask; }
        public Task UpdateAsync(User user) { _users[user.Username] = user; return Task.CompletedTask; }
        public Task DeleteAsync(System.Guid id) { var user = _users.Values.FirstOrDefault(u => u.Id == id); if (user != null) _users.Remove(user.Username); return Task.CompletedTask; }
        public Task<IEnumerable<User>> GetAllAsync() => Task.FromResult<IEnumerable<User>>(_users.Values);
    }
}
