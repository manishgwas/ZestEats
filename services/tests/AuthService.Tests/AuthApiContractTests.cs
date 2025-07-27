using Microsoft.VisualStudio.TestTools.UnitTesting;
using AuthService.Domain;
using AuthService.Persistence;
using System.Threading.Tasks;

namespace AuthService.Tests.Contract {
    [TestClass]
    public class AuthApiContractTests {
        [TestMethod]
        public async Task UserRepository_Contract() {
            var repo = new InMemoryUserRepository();
            var user = new User {
                Id = System.Guid.NewGuid(),
                Username = "contractuser",
                Email = "contract@example.com",
                PasswordHash = "hash",
                Role = UserRole.Customer
            };
            await repo.CreateAsync(user);
            var fetched = await repo.GetByIdAsync(user.Id);
            Assert.AreEqual(user.Username, fetched?.Username);
        }
    }

    // Simple in-memory repo for contract tests
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
