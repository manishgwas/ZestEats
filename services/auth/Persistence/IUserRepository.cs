using System;
using System.Threading.Tasks;
using AuthService.Domain;
using System.Collections.Generic;

namespace AuthService.Persistence {
    public interface IUserRepository {
        Task<User?> GetByIdAsync(Guid id);
        Task<User?> GetByUsernameAsync(string username);
        Task<User?> GetByEmailAsync(string email);
        Task CreateAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<User>> GetAllAsync();
    }
}
