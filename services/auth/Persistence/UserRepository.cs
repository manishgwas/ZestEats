using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using AuthService.Domain;
using System.Collections.Generic;

namespace AuthService.Persistence {
    public class UserRepository : IUserRepository {
        private readonly string _connectionString;
        public UserRepository(string connectionString) {
            _connectionString = connectionString;
        }
        public async Task<User?> GetByIdAsync(Guid id) {
            // TODO: Implement SQL query
            return null;
        }
        public async Task<User?> GetByUsernameAsync(string username) {
            // TODO: Implement SQL query
            return null;
        }
        public async Task<User?> GetByEmailAsync(string email) {
            // TODO: Implement SQL query
            return null;
        }
        public async Task CreateAsync(User user) {
            // TODO: Implement SQL insert
        }
        public async Task UpdateAsync(User user) {
            // TODO: Implement SQL update
        }
        public async Task DeleteAsync(Guid id) {
            // TODO: Implement SQL delete
        }
        public async Task<IEnumerable<User>> GetAllAsync() {
            // TODO: Implement SQL select all
            return new List<User>();
        }
    }
}
