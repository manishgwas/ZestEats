using Microsoft.VisualStudio.TestTools.UnitTesting;
using AuthService.Domain;
using AuthService.Security;

namespace AuthService.Tests.Integration {
    [TestClass]
    public class JwtIntegrationTests {
        [TestMethod]
        public void Jwt_Issuance_And_Validation() {
            var user = new User {
                Id = System.Guid.NewGuid(),
                Username = "jwtuser",
                Email = "jwt@example.com",
                Role = UserRole.Customer
            };
            var secret = "test_secret";
            var token = JwtTokenService.GenerateToken(user, secret);
            Assert.IsFalse(string.IsNullOrEmpty(token));
            // Token validation logic would go here
        }
    }
}
